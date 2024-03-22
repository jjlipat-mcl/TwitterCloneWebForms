using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using TwitterClone.App_Code.Data;
using TwitterClone.App_Code.Users;

namespace TwitterClone.App_Code.Posts
{
    public class PostRepository
    {

        public void CreatePost(Post post)
        {
            using (var connection = SqlDataSource.GetConnection())
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText =
                    "INSERT INTO Posts(content, postedOn, postedBy) " +
                    "VALUES (@content, @postedOn, @postedBy)";
                command.Parameters.AddWithValue("content", post.Content);
                command.Parameters.AddWithValue("postedOn", post.PostedOn);
                command.Parameters.AddWithValue("postedBy", post.PostedBy);
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Post> GetAllPosts(string userId)
        {
            using (var connection = SqlDataSource.GetConnection())
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText =
                    "SELECT * " +
                    "FROM Posts " +
                    "ORDER BY postedOn DESC";
                return command
                    .ExecuteReader()
                    .Cast<IDataRecord>()
                    .Select(row => new Post()
                    {
                        Content = (string)row["content"],
                        PostedOn = (DateTime)row["postedOn"],
                        PostedBy = (string)row["postedBy"]
                    })
                    .ToList();
            }
        }

        public IEnumerable<Post> GetPostsOfUser(string username)
        {
            using (var connection = SqlDataSource.GetConnection())
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText =
                    "SELECT * " +
                    "FROM Posts " +
                    "WHERE postedBy = @username " +
                    "ORDER BY postedOn DESC";
                command.Parameters.AddWithValue("username", username);
                return command
                    .ExecuteReader()
                    .Cast<IDataRecord>()
                    .Select(row => new Post()
                    {
                        Content = (string)row["content"],
                        PostedOn = (DateTime)row["postedOn"]
                    })
                    .ToList();
            }
        }

        public IEnumerable<Post> GetPostsOfUserReader(string username)
        {
            using (var connection = SqlDataSource.GetConnection())
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText =
                    "SELECT * " +
                    "FROM Posts " +
                    "WHERE postedBy = @username " +
                    "ORDER BY postedOn DESC";
                command.Parameters.AddWithValue("username", username);
                var reader = command.ExecuteReader();

                List<Post> posts = new List<Post>();
                while (reader.Read())
                {
                    posts.Add(new Post()
                    {
                        Content = (string)reader["content"],
                        PostedOn = (DateTime)reader["postedOn"]
                    });
                }

                return posts;
            }
        }


        public DataTable GetPostsOfUserDataTable(string username)
        {
            using (var connection = SqlDataSource.GetConnection())
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText =
                    "SELECT * " +
                    "FROM Posts " +
                    "WHERE postedBy = @username " +
                    "ORDER BY postedOn DESC";
                command.Parameters.AddWithValue("username", username);

                var dataTable = new DataTable();
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public void LikePost(string username, string postId)
        {
            using (var connection = SqlDataSource.GetConnection())
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText =
                    "INSERT INTO PostLikes(postId, username) " +
                    "VALUES (@postId, @username)";
                command.Parameters.AddWithValue("userId", username);
                command.Parameters.AddWithValue("username", postId);
                command.ExecuteNonQuery();
            }
        }

        public void UnlikePost(string username, string postId)
        {
            using (var connection = SqlDataSource.GetConnection())
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText =
                    "DELETE FROM PostLikes" +
                    "WHERE postId = @postId AND username = @username";
                command.Parameters.AddWithValue("userId", username);
                command.Parameters.AddWithValue("username", postId);
                command.ExecuteNonQuery();
            }
        }
    }
}

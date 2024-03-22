using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using TwitterClone.App_Code.Data;
using TwitterClone.App_Code.Posts;

namespace TwitterClone.App_Code.Users
{
    public class UserRepository
    {
        public void CreateUser(User user)
        {
            using (var connection = SqlDataSource.GetConnection())
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText =
                    "INSERT INTO Users(username) " +
                    "VALUES (@username)";
                command.Parameters.AddWithValue("username", user.Username);
                command.ExecuteNonQuery();
            }
        }

        public User GetUser(string username)
        {
            using (var connection = SqlDataSource.GetConnection())
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText =
                    "SELECT * " +
                    "FROM Users " +
                    "WHERE username = @username";
                command.Parameters.AddWithValue("username", username);
                return command
                    .ExecuteReader()
                    .Cast<IDataRecord>()
                    .Select(row => new User()
                    {
                        Username = (string)row["username"]
                    })
                    .ToList()
                    .FirstOrDefault();
            }

        }

        public IEnumerable<User> GetAllUsers()
        {
            using (var connection = SqlDataSource.GetConnection())
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText =
                    "SELECT * " +
                    "FROM Users";
                return command
                    .ExecuteReader()
                    .Cast<IDataRecord>()
                    .Select(row => new User()
                    {
                        Username = (string)row["username"]
                    })
                    .ToList();
            }
        }

        public IEnumerable<User> GetUsersWithUsernamesLike(string usernameLike)
        {
            using (var connection = SqlDataSource.GetConnection())
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText =
                    "SELECT * " +
                    "FROM Users " +
                    "WHERE username LIKE @usernameLike";
                command.Parameters.AddWithValue("usernameLike", $"%{usernameLike}%");
                return command
                    .ExecuteReader()
                    .Cast<IDataRecord>()
                    .Select(row => new User()
                    {
                        Username = (string)row["username"]
                    })
                    .ToList();
            }
        }

        public void FollowUser(string userIdOFollower, string userIdToFollow)
        {
            using (var connection = SqlDataSource.GetConnection())
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText =
                    "INSERT INTO UserFollows(follower, followed) " +
                    "VALUES (@follower, @followed)";
                command.Parameters.AddWithValue("follower", userIdOFollower);
                command.Parameters.AddWithValue("followed", userIdToFollow);
                command.ExecuteNonQuery();
            }
        }

        public void UnfollowUser(string userIdOFollower, string userIdToFollow)
        {
            using (var connection = SqlDataSource.GetConnection())
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText =
                    "DELETE FROM UserFollows" +
                    "WHERE follower = @follower AND followed = @followed";
                command.Parameters.AddWithValue("follower", userIdOFollower);
                command.Parameters.AddWithValue("followed", userIdToFollow);
                command.ExecuteNonQuery();
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TwitterClone.App_Code.Posts;
using TwitterClone.App_Code.Users;

namespace TwitterClone
{
    public partial class Default : System.Web.UI.Page
    {
        private User loggedInUser;
        private PostRepository repository;
        public IEnumerable<Post> feedPosts;

        protected void Page_Load(object sender, EventArgs e)
        {
            repository  = new PostRepository();
            loggedInUser = new User() { Username = "joblipat" }; 

            feedPosts = repository.GetPostsOfUser(loggedInUser.Username);
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            var content = postContent.Text;
            repository.CreatePost(new Post()
            {
                Content = content,
                PostedBy = loggedInUser.Username,
                PostedOn = DateTime.Now
            });
            Response.Redirect(Request.RawUrl);
        }
    }
}
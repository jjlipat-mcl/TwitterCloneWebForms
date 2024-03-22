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
    public partial class UserPage : System.Web.UI.Page
    {
        private UserRepository userRepository;
        private PostRepository postRepository;
        public User viewingUser;
        public IEnumerable<Post> posts;

        protected void Page_Load(object sender, EventArgs e)
        {
            userRepository = new UserRepository();
            postRepository = new PostRepository();
            
            
            var viewingUsername = Request.QueryString["username"];

            viewingUser = userRepository.GetUser(viewingUsername);
            posts = postRepository.GetPostsOfUser(viewingUsername);
        }

    }
}
using StackOverflow.Repository.Model;
using System;

namespace Data_Access_Layer
{
    public class PostDAL
    {
        private static readonly DbHelper db_helper_instance = DbHelper.Instance;
        //private static List<Post> _posts = new List<Post>
        //{
        //};

        public IEnumerable<Post> getPosts()
        {
            Func<Post> createPostInstance = () => new Post();
            string query = "SELECT * FROM Posts";
            // Execute the query
            return db_helper_instance.ExecuteQuery(query, createPostInstance);
        }
    }
}
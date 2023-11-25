using System;
using System.Linq;
using Data_Access_Layer;
using StackOverflow.Repository.Model;

namespace Business_Layer
{
    public class PostBL
    {
        private readonly PostDAL _postDAL;
        private List<Post> _posts;
        public PostBL()
        {
            _postDAL = new PostDAL();
        }

        public IEnumerable<Post> GetArticles()
        {
            return _posts ?? _postDAL.getPosts();
        }

        //public Post? Update(Guid id, Article updatedArticle)
        //{
        //    var response = _articleDAL.Update(updatedArticle);
        //    if (response != null)
        //    {
        //        _articles = null; // invalidate local _articles after changes, this caching can be done at the DAL level also.
        //    }
        //    return response;
        //}

        //public Article? GetArticleById(Guid id)
        //{
        //    var articles = GetArticles();
        //    return articles.FirstOrDefault(a => a.Id == id);
        //}

        //public Boolean RemoveById(Guid Id)
        //{
        //    return _articleDAL.RemoveById(Id);
        //}
    }
}
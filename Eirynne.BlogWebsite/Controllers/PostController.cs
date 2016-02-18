using Eirynne.Posts;
using System.Linq;
using System.Collections;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Eirynne.BlogWebsite.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostSelector _posts;

        public PostController(IPostSelector posts)
        {
            _posts = posts;
        }

        public ActionResult Home()
        {
            IEnumerable<Post> posts = _posts.Select().Take(5);

            return View(posts);
        }

        public ActionResult Archive(int year, int month, string text, string tag)
        {
            // TODO: build a PostQuery from values in the route or querystring
            PostQuery query = new PostQuery();
            IEnumerable<Post> posts = _posts.Select(query);

            return View(posts);
        }

        public ActionResult Details(int year, int month, string key)
        {
            Post post = _posts.Select(key);

            return View(post);
        }
    }
}
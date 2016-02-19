using System;
using System.Linq;
using System.Collections.Generic;

namespace Eirynne.Posts.Mock
{
    public class PostSelector : IPostSelector
    {
        private readonly List<Post> _posts;
        private readonly List<PostTag> _tags;

        public PostSelector()
        {
            _tags = new List<PostTag>(3);
            _tags.Add(new PostTag() { ID = "dogs", tag = "Dogs" });
            _tags.Add(new PostTag() { ID = "cosmetics", tag = "Cosmetics" });
            _tags.Add(new PostTag() { ID = "games", tag = "Games" });

            _posts = new List<Post>(3);
            _posts.Add(GetPost(1, _tags[0]));
            _posts.Add(GetPost(2, _tags[0], _tags[1]));
            _posts.Add(GetPost(3, _tags[2]));
        }

        public IEnumerable<Post> Select()
        {
            return _posts;
        }

        public IEnumerable<Post> Select(PostQuery query)
        {
            return _posts;
        }

        public Post Select(object key)
        {
            return _posts.First(p => p.ID.ToString() == key.ToString());
        }

        private Post GetPost(int index, params PostTag[] tags)
        {
            return new Post()
            {
                ID = index.ToString(),
                title = "Title " + index,
                postCopy = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam volutpat tempus lectus vitae auctor. Nulla sit amet pretium diam. Integer tempor consectetur efficitur. Donec porta ex eget enim tincidunt eleifend.",
                postDate = new DateTime(2016, 1, index),
                Tags = tags
            };
        }
    }
}

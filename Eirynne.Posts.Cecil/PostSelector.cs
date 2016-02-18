using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eirynne.Posts.Cecil
{
    public class PostSelector : IPostSelector
    {
        public IEnumerable<Post> Select()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> Select(PostQuery query)
        {
            throw new NotImplementedException();
        }

        public Post Select(object key)
        {
            throw new NotImplementedException();
        }
    }
}

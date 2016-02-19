using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eirynne.Posts
{
    public class Post
    {
        public object ID { get; set; }

        public string title { get; set; }

        public DateTime postDate { get; set; }

        public string postCopy { get; set; }

        public string promoImage { get; set; }

        public IEnumerable<PostTag> Tags { get; set; }
    }
}

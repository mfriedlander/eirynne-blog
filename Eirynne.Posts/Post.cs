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

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Copy { get; set; }

        public string PromoImage { get; set; }

        public IEnumerable<PostTag> Tags { get; set; }
    }
}

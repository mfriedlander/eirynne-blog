using System.Collections.Generic;

namespace Eirynne.Posts
{
    public class PostQuery
    {
        public int? Year { get; set; }

        public int? Month { get; set; }

        public string Text { get; set; }

        public IEnumerable<object> TagKeys { get; set; }
    }
}

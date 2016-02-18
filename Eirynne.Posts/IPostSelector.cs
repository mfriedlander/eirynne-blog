using System.Collections.Generic;

namespace Eirynne.Posts
{
    public interface IPostSelector
    {
        Post Select(object key);

        IEnumerable<Post> Select();

        IEnumerable<Post> Select(PostQuery query);
    }
}

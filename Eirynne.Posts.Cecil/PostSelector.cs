using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace Eirynne.Posts.Cecil
{
    public class PostSelector : IPostSelector
    {
        public IEnumerable<Post> Select()
        {
            string connectionString = "Provider=Microsoft.ace.OLEDB.12.0;Data Source=C:/Users/Erin/source/Repos/eirynne-blog/Eirynne.BlogWebsite/App_Data/Eirynne.BlogWebsite.accdb";
            string cmdText = "SELECT Posts.title, Posts.postDate FROM Posts";

            DataSet dataSet = new DataSet();
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);

            connection.Open();
            dataAdapter.Fill(dataSet, "Posts");
            connection.Close();

            // Map results into an IEnumerable<Post>
            List<Post> posts = new List<Post>();

            // Iterate over rows in the dataset that contain the values we need
            // Create new posts using these values and add them to the posts variable
            
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Post post = new Post();

                post.Title = row[0].ToString();
                post.Date = DateTime.Parse(row[1].ToString());
                post.Tags = new List<PostTag>();

                posts.Add(post);
            }

            return posts;
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

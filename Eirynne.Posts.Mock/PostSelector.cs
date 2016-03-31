using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace Eirynne.Posts.Mock
{

    public class Database
    {
        static void Main()
        {
            //string strAccessConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=..\\..\\Eirynne.BlogWebsite.ACCDB";
            string strAccessConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=EirynneBlogWebsite.MDB";

            string strAccessSelect = "SELECT Posts.title, Posts.postDate, Tags.tag FROM Posts, Tags, PostsTags WHERE Posts.ID = PostsTags.postID AND Tags.ID = PostsTags.tagID";

            DataSet myDataSet = new DataSet();
            OleDbConnection myAccessConn = null;
            try
            {
                myAccessConn = new OleDbConnection(strAccessConn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to create a database connection. \n{0}", ex.Message);
                return;
            }

            try
            {
                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                myAccessConn.Open();
                myDataAdapter.Fill(myDataSet, "Posts");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to retrieve required data from the DataBase.\n{0}", ex.Message);
                return;
            }
            finally
            {
                myAccessConn.Close();
            }

            DataTableCollection dta = myDataSet.Tables;
            foreach (DataTable dt in dta)
            {
                Console.WriteLine("Found data table {0}", dt.TableName);
            }

            Console.WriteLine("{0} tables in data set", dta.Count);

            Console.WriteLine("{0} rows in Posts table", myDataSet.Tables["Posts"].Rows.Count);

            Console.WriteLine("{0} columns in Posts table", myDataSet.Tables["Posts"].Columns.Count);
            DataColumnCollection drc = myDataSet.Tables["Posts"].Columns;
            int i = 0;
            foreach (DataColumn dc in drc)
            {
                Console.WriteLine("Column name[{0} is {1}, of type {2}", i++, dc.ColumnName, dc.DataType);
            }

            DataRowCollection dra = myDataSet.Tables["Posts"].Rows;
            foreach (DataRow dr in dra)
            {
                Console.WriteLine("CategoryName[{0}] was posted {1}  and is tagged {2}", dr[0], dr[1], dr[2]);
            }

            if (System.Diagnostics.Debugger.IsAttached) Console.ReadLine();
        }
    }

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

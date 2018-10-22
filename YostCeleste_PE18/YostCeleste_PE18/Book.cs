using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YostCeleste_PE18
{
    class Book
    {
        public string title;
        public string author;
        public string rating;

        public Book(string p_title, string p_author, string p_rating)
        {
            title = p_title;
            author = p_author;
            rating = p_rating;
        }

        /// end of const


        public string AddList()
        {
            string returnLine = "Title: " + title + " - Author: "+ author + " - Rating: " + rating;
            return returnLine;
        }

    }
}

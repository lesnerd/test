using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library_Application.Items
{
    public class Book : LibraryItem
    {
        private long ISBNNumber;
        private string name;
        private string author;
        private DateTime publicationDate;

        public bool DoSearch(object item)
        {
            return ISBNNumber == item.ISBNNumber || name == item.name || author == item.author || publicationDate == item.publicationDate;
        }
    }
}

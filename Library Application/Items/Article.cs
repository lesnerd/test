using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library_Application.Items
{
    public class Article : LibraryItem
    {
        private List<Magazine> magaziesThatWasPublishedIn;
        private DateTime publicationDate;

        public override bool DoSearch(LibraryItem item)
        {
            
        }

    }
}

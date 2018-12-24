using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library_Application.Items
{
    public class LibraryItem
    {
        protected int uniqID;
        public bool isAvailable;

        public int GetUniqId()
        {
            return uniqID;
        }


        public bool Search(LibraryItem item)
        {
            return this.uniqID == item.uniqID || DoSearch(item);
        }

        public virtual bool DoSearch(LibraryItem item)
        {
            return true;
        }

    }
}

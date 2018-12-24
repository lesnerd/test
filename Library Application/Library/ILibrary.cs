using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library_Application.Items;

namespace Library_Application.Library
{
    interface ILibrary
    {
        void Add(LibraryItem item);
        void Delete(LibraryItem item);
        void Borrow(LibraryItem item);
        void Return(int uniqId);
        List<LibraryItem> Search(LibraryItem item);
    }
}

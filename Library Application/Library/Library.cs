using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library_Application.Items;

namespace Library_Application.Library
{
    public class Library : ILibrary
    {

        private List<LibraryItem> libraryItems;

        public object AddLock = new object();
        public object DeleteLock = new object();
        public object BorrowLock = new object();
        public object ReturnLock = new object();

        public Library()
        {
            libraryItems = new List<LibraryItem>();
        }


        public void Add(LibraryItem item)
        {
            if (item == null)
            {
                Console.WriteLine("No item to add");
                return;
            }
            lock(AddLock)
                libraryItems.Add(item);
        }

        public void Delete(LibraryItem item)
        {
            if(item == null)
            {
                Console.WriteLine("No item to delete");
                return;
            }
            lock (DeleteLock)
                libraryItems.Remove(item);
        }

        public void Borrow(LibraryItem item)
        {
            if (item == null)
            {
                Console.WriteLine("No item to return");
                return;
            }

            lock(BorrowLock)
            {
                var borrowItem = libraryItems.Find(x => x == item);
                borrowItem.isAvailable = false;
            }

        }

        public void Return(int uniqId)
        {
            lock(ReturnLock)
            {
                var retItem = libraryItems.Find(x => x.GetUniqId() == uniqId);
                retItem.isAvailable = true;
            }
        }

        public List<LibraryItem> Search(LibraryItem item)
        {
            List<LibraryItem> retItems = new List<LibraryItem>();


            return retItems;
        }
    }
}

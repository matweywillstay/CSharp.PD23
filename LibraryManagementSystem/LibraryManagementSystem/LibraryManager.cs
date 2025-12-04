using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class LibraryManager
    {
        private LibraryCatalog<Book> _bookCatalog;

        private LibraryCatalog<Magazine> _magazineCatalog;

        public LibraryManager()
        {
            _bookCatalog = new LibraryCatalog<Book>();
            _magazineCatalog = new LibraryCatalog<Magazine>();
        }

        public void AddItem(ILibraryItem item)
        {
            if(item is Book b)
            {
                _bookCatalog.AddItem(b);
            }
            else if (item is Magazine m)
            {
                _magazineCatalog.AddItem(m);
            }
        }
        public List<ILibraryItem> GetAllItems()
        {
            List<ILibraryItem> all = new List<ILibraryItem>();
            all.AddRange( _bookCatalog.GetAllItems());
            all.AddRange(_magazineCatalog.GetAllItems());
            return all;
        }

        public ILibraryItem? GetItemById(int id)
        {
            var book = _bookCatalog.GetItemById(id);
            if (book != null)
            {
                return book;
            }

            var magazine = _magazineCatalog.GetItemById(id);
            if(magazine != null)
            {
                return magazine;
            }

            return null;
        }
    }
}

using MVVMTestBM.Models.Interfaces;
using MVVMTestBM.Repositories;
using MVVMTestBM.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MVVMTestBM.Services
{
    public class BookService : IBookService
    {
        public BookService(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        private readonly BookRepository _bookRepository;

        public void Add(IBook book)
        {
            if (book.Name is null)
            {
                //return;
                MessageBox.Show("Название книги не должно быть пустым!");
            }
            else
            {
                _bookRepository.Books.Add(book);
            }
            
        }

        public void Delete(IBook book)
        {
            IBook bookToRemove = _bookRepository.Books.FirstOrDefault(b => b.Id == book.Id);

            if (bookToRemove is null)
            {
                return;
            }

            _bookRepository.Books.Remove(bookToRemove);
        }

        public void Find(IBook book)
        {
            //List<IBook> findingBook = (List<IBook>)_bookRepository.Books.SingleOrDefault(c => c.Name == book.Name);
            //List<IBook> evens = _bookRepository.Books.Where(c => c.Name == book.Name);
            /*if (findingBook is null)
            {
                MessageBox.Show("Книга не найдена.");
                //return;
                
            } else
            {
                string res = "Книга " + findingBook.Name + " найдена. Автор: " + findingBook.Author;
                MessageBox.Show(res);
            } */
            var foundBooks = from books in _bookRepository.Books
                             where books.Name == book.Name
                             select books;
            foreach (IBook foundBook in foundBooks)
                MessageBox.Show($"Книга {foundBook.Name} найдена. Автор: {foundBook.Author}");

            //_bookRepository.Books.Remove(bookToRemove);
        }

        public void Edit(IBook book)
        {
            throw new System.NotImplementedException();
        }
    }
}

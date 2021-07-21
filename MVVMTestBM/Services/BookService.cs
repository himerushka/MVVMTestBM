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
            IBook foundBook = _bookRepository.Books.FirstOrDefault(c => c.Name == book.Name);
            /* если бы книг было несколько
            var foundBooks = from books in _bookRepository.Books
                             where books.Name == book.Name
                             select books;
            foreach (IBook foundBook in foundBooks)*/
            if (foundBook is not null)
            {
                MessageBox.Show($"Книга {foundBook.Name} найдена. Автор: {foundBook.Author}");
            }
            else MessageBox.Show("Книга не найдена.");

        }

        public void Edit(IBook selectedBook, IBook newBook)
        {
            //IBook foundBook = _bookRepository.Books.FirstOrDefault(d => b.Id == book.Id);
            int i = _bookRepository.Books.IndexOf(selectedBook);
            _bookRepository.Books.ElementAt(i).Name = newBook.Name;
            _bookRepository.Books.ElementAt(i).Author = newBook.Author;
        }
    }
}

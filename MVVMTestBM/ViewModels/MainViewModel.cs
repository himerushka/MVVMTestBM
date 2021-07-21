using MVVMTestBM.Core;
using MVVMTestBM.Models;
using MVVMTestBM.Models.Interfaces;
using MVVMTestBM.Repositories;
using MVVMTestBM.Services.Interfaces;
using System;
using System.Collections.Specialized;
using System.Windows.Input;
using System.Windows.Threading;

namespace MVVMTestBM.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(BookRepository bookRepository, IBookService bookService)
        {
            BookRepository = bookRepository;

            _bookService = bookService;

            BookForEdit = new Book();
        }

        public BookRepository BookRepository { get; }

        private readonly IBookService _bookService;

        private IBook _selectedBook;

        public IBook SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                OnPropertyChanged();
            }
        }

        private IBook _bookForEdit;

        public IBook BookForEdit
        {
            get => _bookForEdit;
            set
            {
                _bookForEdit = value;
                OnPropertyChanged();
            }
        }

        private ICommand _addBookCommand;
        public ICommand AddBookCommand => _addBookCommand ??= new RelayCommand(AddBook);

        private void AddBook(object commandParameter)
        {
            _bookService.Add(BookForEdit);

            BookForEdit = new Book();
        }

        private ICommand _deleteBookCommand;
        public ICommand DeleteBookCommand => _deleteBookCommand ??= new RelayCommand(DeleteBook, o => SelectedBook is not null);

        private void DeleteBook(object commandParameter)
        {
            _bookService.Delete(SelectedBook);
        }

        private ICommand _findBookCommand;
        //private RelayCommand findBookCommand;
        public ICommand FindBookCommand => _findBookCommand ??= new RelayCommand(FindBook);
        private void FindBook(object commandParameter)
        {
            _bookService.Find(BookForEdit);
        }

        private ICommand _editBookCommand;
        //private RelayCommand editBookCommand;
        public ICommand EditBookCommand => _editBookCommand ??= new RelayCommand(EditBook, o => SelectedBook is not null);
        private void EditBook(object commandParameter)
        {
            _bookService.Edit(SelectedBook, BookForEdit);
        }

        private void ListView_Loaded(object sender, NotifyCollectionChangedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 3); // 3s
            timer.Tick += new EventHandler(RandomBook);
            timer.Start();
        }
        private void RandomBook(object sender, EventArgs e)
        {
            _bookService.RandomEvent();
        }
    }
}

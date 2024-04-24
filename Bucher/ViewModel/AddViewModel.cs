using Bucher.Model;
using Bucher.Model.Models;
using Bucher;
using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Bucher.ViewModel.AddViewModel
{
    class AddGenreViewModel : NotifyPropertyChanged
    {
        private string _name;
        private string _description;
        public Genre SelectedGenre { get; set; }

        private MainViewModel _mainViewModel;
        public AddGenreViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }
        // not sure

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        private RelayCommand _addGenreCommand;
        public RelayCommand AddGenreCommand
        {
            get
            {
                if (_addGenreCommand == null)
                {
                    _addGenreCommand = new RelayCommand((o) =>
                    {
                        if (DataWorker.CreateGenre(Name, Description) == true)
                        {
                            CreatedWindow.CreateMessageBox("Успешно");

                            Name = "";
                            Description = "";
                            _mainViewModel.Books = DataWorker.SelectAllBooksTable();

                        }
                        else
                        {
                            CreatedWindow.CreateMessageBox("Неудача");
                        }   
                    },
                    (o) =>
                    {
                        return true;
                    }
                    );

                }
                return _addGenreCommand;
            }
        }
    }

    class AddBookViewModel : NotifyPropertyChanged
    {

        private MainViewModel _mainViewModel;
        public AddBookViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }
        public List<Genre> Genres { get; set; } = DataWorker.GetGenre();
        public Genre SelectedGenre { get; set; }
        private string _name;
        private string _description;
        public int _price;
        public string _genre;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public string Genre
        {
            get { return _genre; }
            set
            {
                _description = value;
                OnPropertyChanged("Genre");
            }
        }

        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("price");
            }
        }

        private RelayCommand _addBookCommand;
        public RelayCommand AddBookCommand
        {
            get
            {
                if (_addBookCommand == null)
                {
                    _addBookCommand = new RelayCommand((o) =>
                    {
                        if (DataWorker.CreateBooks(Name, SelectedGenre.IdGenre, Price, Description) == true)
                        {
                            CreatedWindow.CreateMessageBox("Успешно");
                            Name = null;
                            Genre = null;
                            Price = 0;
                            Description = null;
                            _mainViewModel.Books = DataWorker.SelectAllBooksTable();
                        }
                        else
                        {
                            CreatedWindow.CreateMessageBox("Неудача");
                        }
                    },
                    (o) =>
                    {
                        return Name != null && SelectedGenre != null;
                    }
                    );

                }
                return _addBookCommand;
            }
        }
    }


    class AddClientViewModel : NotifyPropertyChanged
    {
        public List<Client> Clients { get; set; } = DataWorker.GetClient();

        private MainViewModel _mainViewModel;
        public AddClientViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        

        private string _name;
        private string _lastname;
        private string _surname;
        public string _address;
        public int? _telephone;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }

        public string Lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                OnPropertyChanged("Lastname");
            }
        }

        public int? Telephone
        {
            get { return _telephone; }
            set
            {
                _telephone = value;
                OnPropertyChanged("Telephone");
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }


        private RelayCommand _addClientCommand;
        public RelayCommand AddClientCommand
        {
            get
            {
                if (_addClientCommand == null)
                {
                    _addClientCommand = new RelayCommand((o) =>
                    {
                        if (DataWorker.CreateClient(Name, Lastname, Surname, Telephone, Address) == true)
                        {
                            CreatedWindow.CreateMessageBox("Успешно");

                            _mainViewModel.Clients = DataWorker.SelectAllClientsTable();
                        }
                        else
                        {
                            CreatedWindow.CreateMessageBox("Неудача");
                        }
                    },
                    (o) =>
                    {
                        return true;
                    }
                    );

                }
                return _addClientCommand;
            }
        }
    }



    class AddOrderViewModel : NotifyPropertyChanged
    {
        public List<Orders> Orders { get; set; } = DataWorker.GetOrders();
        public List<Books> Books { get; set; } = DataWorker.GetBook();
        public List<Client> Clients { get; set; } = DataWorker.GetClient();

        private MainViewModel _mainViewModel;
        public AddOrderViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        private int _price;
        private DateTime _dateIssue;
        private DateTime _timeIssue;
        private int _bookId;
        private int _clientId;



        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }
        public int BookId
        {
            get { return _bookId; }
            set
            {
                _bookId= value;
                OnPropertyChanged("BookId");
            }
        }
        public int ClientId
        {
            get { return _clientId; }
            set
            {
                _clientId= value;
                OnPropertyChanged("ClientId");
            }
        }

        public DateTime TimeIssue
        {
            get { return _timeIssue; }
            set
            {
                _timeIssue = value;
                OnPropertyChanged("TimeIssue");
            }
        }
        public DateTime DateIssue
        {
            get { return _dateIssue; }
            set
            {
                _dateIssue = value;
                OnPropertyChanged("DateIssue");
            }
        }

        private Books _selectedBook;
        public Books SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;
                OnPropertyChanged("SelectedBooks");
            }
        }

        private Client _selectedClient;
        public Client SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

        private RelayCommand _addOrderCommand;
        public RelayCommand AddOrderCommand
        {
            get
            {
                if (_addOrderCommand == null)
                {
                    _addOrderCommand = new RelayCommand((o) =>
                    {
                        DateIssue = DateTime.Now;
                        TimeIssue = DateTime.Now;

                        if (DataWorker.CreateOrder(Price, TimeIssue, DateIssue, SelectedBook.IdBook, SelectedClient.IdClient) == true)
                        {
                            CreatedWindow.CreateMessageBox("Успешно");

                           _mainViewModel.Orders = DataWorker.SelectAllOrdersTable();
                        }
                        else
                        {
                            CreatedWindow.CreateMessageBox("Неудача");
                        }
                    },
                    (o) =>
                    {
                        return true;
                    }
                    );

                }
                return _addOrderCommand;
            }
        }
    }



}
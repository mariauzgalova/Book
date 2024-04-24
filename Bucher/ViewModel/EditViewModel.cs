using Bucher.Model;
using Bucher.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucher.ViewModel.EditViewModel
{
    internal class EditBooksViewModel: NotifyPropertyChanged
    {
        public List<Books> books { get; set; } = DataWorker.GetBook();

        private MainViewModel _mainViewModel;
        public EditBooksViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        private Books _selectedBook;
        public Books SelectedBook
        {
            get
            {
                return _selectedBook;
            }
            set
            {
                _selectedBook = value;
                Name = _selectedBook.Name;
            }
        }

        private string _name; 
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private int _price;
        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public List<Genre> genres { get; set; } = DataWorker.GetGenre();
        private Genre _selectedGenre;
        public Genre SelectedGenre
        {
            get
            {
                return _selectedGenre;
            }
            set
            {
                _selectedGenre = value;
                OnPropertyChanged("SelectedGenre");
            }
        }
        private RelayCommand _editBookCommand;
        public RelayCommand editBookCommand
        {
            get
            {
                if (_editBookCommand == null)
                {
                    _editBookCommand = new RelayCommand((o) =>
                    {
                        if (DataWorker.EditBooks(SelectedBook, Name, SelectedGenre.IdGenre, Price, Description) == true)
                        {
                            CreatedWindow.CreateMessageBox("Удача");
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
                return _editBookCommand;
            }
        }
    }

    internal class EditGenreViewModel : NotifyPropertyChanged
    {
        private MainViewModel _mainViewModel;
        public EditGenreViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public List<Genre> genres { get; set; } = DataWorker.GetGenre();
        private Genre _selectedGenre;
        public Genre SelectedGenre
        {
            get
            {
                return _selectedGenre;
            }
            set
            {
                _selectedGenre = value;
                OnPropertyChanged("SelectedGenre");
            }
        }
        private RelayCommand _editGenreCommand;
        public RelayCommand editGenreCommand
        {
            get
            {
                if (_editGenreCommand == null)
                {
                    _editGenreCommand = new RelayCommand((o) =>
                    {
                        if (DataWorker.EditGenre(SelectedGenre, Name, Description) == true)
                        {
                            CreatedWindow.CreateMessageBox("Удача");
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
                return _editGenreCommand;
            }
        }
    }

    class EditClientViewModel : NotifyPropertyChanged
    {
        public List<Client> Clients { get; set; } = DataWorker.GetClient();

        private MainViewModel _mainViewModel;
        public EditClientViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }



        private string _name;
        private string _lastname;
        private string _surname;
        public string _address;
        public int? _telephone;
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
                OnPropertyChanged("address");
            }
        }


        private RelayCommand _editClientCommand;
        public RelayCommand EditClientCommand
        {
            get
            {
                if (_editClientCommand == null)
                {
                    _editClientCommand = new RelayCommand((o) =>
                    {
                        if (DataWorker.EditClient(SelectedClient, Name, Lastname, Surname, Telephone, Address) == true)
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
                return _editClientCommand;
            }
        }
    }

    class EditOrderViewModel : NotifyPropertyChanged
    {
        public List<Orders> Orders { get; set; } = DataWorker.GetOrders();
        public List<Books> Books { get; set; } = DataWorker.GetBook();
        public List<Client> Clients { get; set; } = DataWorker.GetClient();

        private MainViewModel _mainViewModel;
        public EditOrderViewModel(MainViewModel mainViewModel)
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
                _bookId = value;
                OnPropertyChanged("BookId");
            }
        }
        public int ClientId
        {
            get { return _clientId; }
            set
            {
                _clientId = value;
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

        private Orders _selectedOrder;
        public Orders SelectedOrders
        {
            get { return _selectedOrder; }
            set
            {
                _selectedOrder = value;
                OnPropertyChanged("SelectedClient");
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

        private RelayCommand _editOrderCommand;
        public RelayCommand EditOrderCommand
        {
            get
            {
                if (_editOrderCommand == null)
                {
                    _editOrderCommand = new RelayCommand((o) =>
                    {
                        if (DataWorker.EditOrder(SelectedOrders, Price, TimeIssue, DateIssue, SelectedBook.IdBook, SelectedClient.IdClient) == true)
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
                return _editOrderCommand;
            }
        }
    }

}

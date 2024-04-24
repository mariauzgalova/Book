using Bucher.Model;
using Bucher.ViewModel.AddViewModel;
using Bucher.ViewModel.EditViewModel;
using Store.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucher.ViewModel
{
    internal class MainViewModel : NotifyPropertyChanged
    {
        private string _searchText = "";
        public string SearchText
        {
            get { return _searchText; }
            set {
                _searchText = value.Replace(" ", string.Empty);
                OnPropertyChanged("SearchText");
            }
        }

        private RelayCommand _searchCommand; 
        public RelayCommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {
                    _searchCommand = new RelayCommand((o) =>
                    {
                        if (SearchText != string.Empty)
                        {
                            Books = DataWorker.SelectAllBooksTable().Where(c => $"{c.Name} {c.NameGenre} {c.Price} {c.Description}".ToLower().Contains(SearchText.ToLower())).ToList();
                        }
                        else
                        {
                            Books = DataWorker.SelectAllBooksTable();
                        }
                    });
                }
                return _searchCommand;
            }
        }   

        private List<BooksTable> _books = DataWorker.SelectAllBooksTable();
        public List<BooksTable> Books
        {
            get { return _books; }
            set
            {
                _books = value;
                OnPropertyChanged("Books");
            }
        }

        private List<ClientsTable> _clients = DataWorker.SelectAllClientsTable();
        public List<ClientsTable> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                OnPropertyChanged("Clients");
            }
        }

        private List<OrdersTable> _orders = DataWorker.SelectAllOrdersTable();
        public List<OrdersTable> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                OnPropertyChanged("Orders");
            }
        }

        private RelayCommand _openAddGenreWindow;
        public RelayCommand OpenAddGenreWindow
        {
            get
            {
                if(_openAddGenreWindow == null)
                {
                    _openAddGenreWindow = new RelayCommand((o) =>
                    {
                        AddGenreViewModel addGenreViewModel = new AddGenreViewModel(this);
                        CreatedWindow.CreateWindow(addGenreViewModel);
                    });
                }
                return _openAddGenreWindow;
            }
        }

        private RelayCommand _openAddBookWindow;
        public RelayCommand OpenAddBookWindow
        {
            get
            {
                if (_openAddBookWindow == null)
                {
                    _openAddBookWindow = new RelayCommand((o) =>
                    {
                        AddBookViewModel addBookViewModel = new AddBookViewModel(this);
                        CreatedWindow.CreateWindow(addBookViewModel);
                    });
                }
                return _openAddBookWindow;
            }
        }

        private RelayCommand _openAddClientWindow;
        public RelayCommand OpenAddClientWindow
        {
            get
            {
                if (_openAddClientWindow == null)
                {
                    _openAddClientWindow = new RelayCommand((o) =>
                    {
                        AddClientViewModel addBookViewModel = new AddClientViewModel(this);
                        CreatedWindow.CreateWindow(addBookViewModel);
                    });
                }
                return _openAddClientWindow;
            }
        }

        private RelayCommand _openAddOrderWindow;
        public RelayCommand OpenAddOrderWindow
        {
            get
            {
                if (_openAddOrderWindow == null)
                {
                    _openAddOrderWindow = new RelayCommand((o) =>
                    {
                        AddOrderViewModel addOrderViewModel = new AddOrderViewModel(this);
                        CreatedWindow.CreateWindow(addOrderViewModel);
                    });
                }
                return _openAddOrderWindow;
            }
        }

        private RelayCommand _openEditBookWindow;
        public RelayCommand OpenEditBookWindow
        {
            get
            {
                if (_openEditBookWindow == null)
                {
                    _openEditBookWindow = new RelayCommand((o) =>
                    {
                        EditBooksViewModel editBookViewModel = new EditBooksViewModel(this);
                        CreatedWindow.CreateWindow(editBookViewModel);
                    });
                }
                return _openEditBookWindow;
            }
        }

        private RelayCommand _openEditOrderWindow;
        public RelayCommand OpenEditOrderWindow
        {
            get
            {
                if (_openEditOrderWindow == null)
                {
                    _openEditOrderWindow = new RelayCommand((o) =>
                    {
                        EditOrderViewModel editBookViewModel = new EditOrderViewModel(this);
                        CreatedWindow.CreateWindow(editBookViewModel);
                    });
                }
                return _openEditOrderWindow;
            }
        }

        private RelayCommand _openEditClientWindow;
        public RelayCommand OpenEditClientWindow
        {
            get
            {
                if (_openEditClientWindow == null)
                {
                    _openEditClientWindow = new RelayCommand((o) =>
                    {
                        EditClientViewModel editClientModel = new EditClientViewModel(this);
                        CreatedWindow.CreateWindow(editClientModel);
                    });
                }
                return _openEditClientWindow;
            }
        }


        private RelayCommand _openEditGenreWindow;
        public RelayCommand OpenEditGenreWindow
        {
            get
            {
                if (_openEditGenreWindow == null)
                {
                    _openEditGenreWindow = new RelayCommand((o) =>
                    {
                        EditGenreViewModel editGenreViewModel = new EditGenreViewModel(this);
                        CreatedWindow.CreateWindow(editGenreViewModel);
                    });
                }
                return _openEditGenreWindow;
            }
        }

        private RelayCommand _openRemoveClientWindow;
        public RelayCommand OpenRemoveClientWindow
        {
            get
            {
                if (_openRemoveClientWindow == null)
                {
                    _openRemoveClientWindow = new RelayCommand((o) =>
                    {
                        string text = "Выберите пользователя";
                        List<object> list = DataWorker.GetClient().Select(x => (object)x).ToList();
                        RemoveItemViewModel removeItemViewModel = new RemoveItemViewModel(text, list, this);

                        CreatedWindow.CreateWindow(removeItemViewModel);

                    });
                }
                return _openRemoveClientWindow;
            }
        }

        private RelayCommand _openRemoveBookWindow;
        public RelayCommand OpenRemoveBookWindow
        {
            get
            {
                if (_openRemoveBookWindow == null)
                {
                    _openRemoveBookWindow = new RelayCommand((o) =>
                    {
                        string text = "Выберите книгу";
                        List<object> list = DataWorker.GetBook().Select(x => (object)x).ToList();
                        RemoveItemViewModel removeItemViewModel = new RemoveItemViewModel(text, list, this);

                        CreatedWindow.CreateWindow(removeItemViewModel);

                    });
                }
                return _openRemoveBookWindow;
            }
        }

        private RelayCommand _openRemoveGenreWindow;
        public RelayCommand OpenRemoveGenreWindow
        {
            get
            {
                if (_openRemoveGenreWindow == null)
                {
                    _openRemoveGenreWindow = new RelayCommand((o) =>
                    {
                        string text = "Выберите жанр";
                        List<object> list = DataWorker.GetGenre().Select(x => (object)x).ToList();
                        RemoveItemViewModel removeItemViewModel = new RemoveItemViewModel(text, list, this);

                        CreatedWindow.CreateWindow(removeItemViewModel);

                    });
                }
                return _openRemoveGenreWindow;
            }
        }

        private RelayCommand _openRemoveOrderWindow;
        public RelayCommand OpenRemoveOrderWindow
        {
            get
            {
                if (_openRemoveOrderWindow == null)
                {
                    _openRemoveOrderWindow = new RelayCommand((o) =>
                    {
                        string text = "Выберите Заказ";
                        List<object> list = DataWorker.GetOrders().Select(x => (object)x).ToList();
                        RemoveItemViewModel removeItemViewModel = new RemoveItemViewModel(text, list, this);

                        CreatedWindow.CreateWindow(removeItemViewModel);

                    });
                }
                return _openRemoveOrderWindow;
            }
        }


    }
}

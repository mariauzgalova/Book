using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using Bucher.View;
using Bucher.ViewModel;
using Bucher.ViewModel.AddViewModel;
using Bucher.ViewModel.EditViewModel;
using Store.ViewModel;

namespace Bucher.Model
{
    public static class CreatedWindow
    {
        public static void CreateMessageBox(string message)
        {
            MessageBox.Show(message);
        }

        public static void CreateWindow(object dataContext)
        {
            if (dataContext is AddBookViewModel addBookView)
            {
                Create create = new Create();
                create.DataContext = addBookView;
                SettingWindow(create);
            }
            else if (dataContext is EditBooksViewModel EditBook)
            {
                EditBook editBook = new EditBook();
                editBook.DataContext = EditBook;
                SettingWindow(editBook);
            }
            else if (dataContext is AddGenreViewModel addGroupViewModel)
            {
                Creategenre addGenre = new Creategenre();
                addGenre.DataContext = addGroupViewModel;
                SettingWindow(addGenre);
            }
            else if (dataContext is EditGenreViewModel editGenreViewModel)
            {
                Editgenre editGenre = new Editgenre();
                editGenre.DataContext = editGenreViewModel;
                SettingWindow(editGenre);
            }
            else if (dataContext is EditClientViewModel editClientViewModel)
            {
                EditClient editClient= new EditClient();
                editClient.DataContext = editClientViewModel;
                SettingWindow(editClient);
            }
            else if (dataContext is AddClientViewModel addClientViewModel)
            {
                AddClient addClient= new AddClient();
                addClient.DataContext = addClientViewModel;
                SettingWindow(addClient);
            }
            else if (dataContext is RemoveItemViewModel remove)
            {
                RemoveItem removeItem = new RemoveItem();
                removeItem.DataContext = remove;
                SettingWindow(removeItem);
            }
            else if (dataContext is EditOrderViewModel editOrderViewModel)
            {
                EditOrder addClient = new EditOrder();
                addClient.DataContext = editOrderViewModel;
                SettingWindow(addClient);
            }
            else if (dataContext is AddOrderViewModel addOrderViewModel)
            {
                AddOrder addClient = new AddOrder();
                addClient.DataContext = addOrderViewModel;
                SettingWindow(addClient);
            }

        }
        private static void SettingWindow(Window window)
        {
            window.Visibility = Visibility.Visible;
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
        }
    }
}

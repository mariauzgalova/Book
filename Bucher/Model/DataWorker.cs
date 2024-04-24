using Bucher.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace Bucher.Model
{
    internal class DataWorker
    {
        public static bool CreateGenre(string Name, string Description)
        {
            using (ApplicationContext db = new ApplicationContext())
                if (!db.Genre.Any(p => p.Name == Name && p.Description == Description))
                {
                    Genre genre = new Genre()
                    {
                        Name = Name,
                        Description = Description
                    };

                    db.Genre.Add(genre);
                    db.SaveChanges();
                    return true;
                }
            return false;
        }
        public static bool EditGenre(Genre oldGenre, string newName, string newDescription)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Genre genre = db.Genre.FirstOrDefault(i => i.IdGenre == oldGenre.IdGenre);
                if (genre != null)
                {
                    genre.Name = newName;
                    genre.Description = newDescription;
                    genre.IdGenre = oldGenre.IdGenre;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public static void DeleteGenre(Genre genre)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Genre.Remove(genre);
                db.SaveChanges();
            }
        }
        public static List<Genre> GetGenre()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Genre.ToList();
            }
        }


        public static bool CreateBooks(string Name, int? Genre, int Price, string Description)
        {
            using (ApplicationContext db = new ApplicationContext())
                if (!db.Books.Any(p => p.Name == Name && p.Genre == Genre && p.Price == Price && p.Description == Description))
                {
                    Books books = new Books()
                    {
                        Name = Name,
                        Genre = Genre,
                        Price = Price,
                        Description = Description,
                    };
                    db.Books.Add(books);
                    db.SaveChanges();
                    return true;
                }
            return false;
        }
        public static bool EditBooks(Books oldBook, string newName, int newGenre, int newPrice, string newDescription)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Books books = db.Books.FirstOrDefault(i => i.IdBook == oldBook.IdBook);
                if (books != null)
                {
                    books.Name = newName;
                    books.Genre = newGenre;
                    books.Price = newPrice;
                    books.Description = newDescription;

                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public static void DeleteBooks(Books books)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Books.Remove(books);
                db.SaveChanges();
            }
        }
        public static List<Books> GetBook()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Books.ToList();
            }
        }

        public static List<BooksTable> SelectAllBooksTable()
        {
            List<Books> books = GetBook();
            List<BooksTable> booksTable = new List<BooksTable>();
            foreach (Books book in books)
            {
                booksTable.Add(BooksTable.ConvertBooksOnBooksTable(book));
            }
            return booksTable;
        }

        public static List<ClientsTable> SelectAllClientsTable()
        {
            List<Client> clients = GetClient();
            List<ClientsTable> clientsTable = new List<ClientsTable>();
            foreach (Client client in clients)
            {
                clientsTable.Add(ClientsTable.ConvertClientsOnClientTable(client));
            }
            return clientsTable;
        }

        public static List<Empoyees> SelectAllEmployees()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Empoyees.ToList();
            }
        }

        public static bool CreateClient(string name, string lastname, string surname, int? telephone, string address)
        {
            using (ApplicationContext db = new ApplicationContext())
            {

                Client client = new Client()
                {
                    Name = name,
                    Lastname = lastname,
                    Surname = surname,
                    Telefon = telephone,
                    Adress = address,
                };

                db.Client.Add(client);
                db.SaveChanges();
                return true;
            }

        }
        public static bool EditClient(Client oldClient, string name, string lastname, string surname, int? telephone, string address)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Client client = db.Client.FirstOrDefault(i => i.IdClient == oldClient.IdClient);
                if (client != null)
                {

                    client.Name = name;
                    client.Lastname = lastname;
                    client.Surname = surname;
                    client.Telefon = telephone;
                    client.Adress = address;

                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public static void DeleteClient(Client client)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Client.Remove(client);
                db.SaveChanges();
            }
        }
        public static List<Client> GetClient()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Client.ToList();
            }
        }


        public static bool CreateOrder(int? price, DateTime? timeIssue, DateTime? dateIssue, int? bookId, int? clientId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Orders order = new Orders()
                {
                    Price = price,
                    TimeIssue = timeIssue,
                    DateIssue = dateIssue,
                    ClientId = clientId,
                    BookId = bookId,
                };

                db.Orders.Add(order);
                db.SaveChanges();

                return true;
            }

        }


        public static bool EditOrder(Orders oldOrder, int? price, DateTime? timeIssue, DateTime? dateIssue, int? bookId, int? clientId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Orders order = db.Orders.FirstOrDefault(i => i.IdOrder == oldOrder.IdOrder);
                if (order != null)
                {
                    order.Price = price;
                    order.TimeIssue = timeIssue;
                    order.DateIssue = dateIssue;
                    order.ClientId = clientId;
                    order.BookId = bookId;

                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public static void DeleteOrders(Orders genre)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Orders.Remove(genre);
                db.SaveChanges();
            }
        }
        public static List<Orders> GetOrders()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Orders.ToList();
            }
        }

        public static List<OrdersTable> SelectAllOrdersTable()
        {
            List<Orders> orders = GetOrders();
            List<OrdersTable> ordersTable = new List<OrdersTable>();
            foreach (Orders order in orders)
            {
                ordersTable.Add(OrdersTable.ConvertOrderOnOrdersTable(order));
            }
            return ordersTable;
        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bucher.Model.Models;


namespace Bucher.Model
{
    internal class OrdersTable
    {
        public int IdOrder { get; set; }
        public int? Price { get; set; }
        public DateTime? DateIssue { get; set; }
        public DateTime? TimeIssue { get; set; }

        public int? ClientId { get; set; }
        public int? BookId { get; set; }

        public string ClientName { get; set; }
        public string BookName { get; set; }

        public static OrdersTable ConvertOrderOnOrdersTable(Orders order)
        {
            OrdersTable ordersTable = new OrdersTable();
            ordersTable.IdOrder = order.IdOrder;
            ordersTable.Price = order.Price;
            ordersTable.TimeIssue = order.TimeIssue;
            ordersTable.DateIssue = order.DateIssue;
            ordersTable.ClientId = order.ClientId;
            ordersTable.BookId = order.BookId;

            using (ApplicationContext db = new ApplicationContext())
            {
                ordersTable.BookName = db.Books.FirstOrDefault(g => g.IdBook == order.BookId).Name;
                Client client = db.Client.FirstOrDefault(g => g.IdClient == order.ClientId);
                ordersTable.ClientName = $"{client.Name} {client.Surname} {client.Lastname}";

            }

            return ordersTable;
        }
    }
}

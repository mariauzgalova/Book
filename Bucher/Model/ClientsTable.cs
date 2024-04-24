using Bucher.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucher.Model
{
    internal class ClientsTable
    {
        public int IdClient { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public int? Telefon { get; set; }

        public static ClientsTable ConvertClientsOnClientTable(Client client)
        {
            ClientsTable clientsTable= new ClientsTable();
            clientsTable.IdClient = client.IdClient;
            clientsTable.Name = client.Name;
            clientsTable.Lastname = client.Lastname;
            clientsTable.Surname = client.Surname;
            clientsTable.Adress = client.Adress;
            clientsTable.Telefon = client.Telefon;

            return clientsTable;
        }

    }
}

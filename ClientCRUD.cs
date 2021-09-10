using Newtonsoft.Json;
using ProyectoAgencia;
using ProyectoAgencia.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace ProjectAgency
{
    public class ClientCRUD : IClientCRUD
    {
        List<Client> allClients = new List<Client>();
        private string clientJsonFile = ConfigurationManager.AppSettings[("pathClients")];
        string clientJsonString = File.ReadAllText("client.json");//I didn't use an "using" block because File.ReadAllText close the file at the end.
        Client client = new Client();


        public Client Get(string Id)
        {
            allClients = JsonConvert.DeserializeObject<List<Client>>(clientJsonString);

            foreach (Client client in allClients)
            {
                if (Convert.ToString(Id).Equals(client.DNI))
                {
                    Console.WriteLine($"DNI: {client.DNI}");
                    Console.WriteLine($"Name: {client.Name}");
                    Console.WriteLine($"Lastname: {client.Lastname}");
                    Console.WriteLine($"Phone: {client.Phone}");
                    Console.WriteLine($"Address: {client.Address}");
                    Console.WriteLine($"City: {client.City}");
                    Console.WriteLine($"Cp: {client.Cp}");
                    Console.WriteLine($"LastUpdatedDate: {client.LastUpdatedDate}");
                    return client;
                }
            }
            return client;
        }


        public Client Create(Client client)
        {
            allClients = JsonConvert.DeserializeObject<List<Client>>(clientJsonString);
            Console.WriteLine("Enter the DNI:");
            client.DNI = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Name:");
            client.Name = Console.ReadLine();
            Console.WriteLine("Enter the Lastname:");
            client.Lastname = Console.ReadLine();
            Console.WriteLine("Enter the Phone:");
            client.Phone = Console.ReadLine();
            Console.WriteLine("Enter the Address");
            client.Address = Console.ReadLine();
            Console.WriteLine("Enter the City:");
            client.City = Console.ReadLine();
            Console.WriteLine("Is the Cp:");
            client.Cp = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Is the LastUpdatedDate:");
            client.LastUpdatedDate = Console.ReadLine();

            allClients.Add(client);
            Console.WriteLine("Client was added succesfully !!");
            string clientJson = JsonConvert.SerializeObject(allClients);
            File.WriteAllText(clientJsonFile, clientJson);
            return client;
        }

    }
}

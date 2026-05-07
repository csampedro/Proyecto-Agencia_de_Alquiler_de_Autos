﻿using Newtonsoft.Json;
using ProyectoAgencia;
using ProyectoAgencia.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProyectoAgencia
{
    public class ClientCRUD : ICRUD<Client>
    {
        private readonly string _clientFilePath;//private variables starts with _
        public ClientCRUD(string clientFilePath)
        {
            _clientFilePath = clientFilePath;
        }

        public Client Get(int Id)
        {
            return ListAll().FirstOrDefault(client => client.Id == Id);
        }
        public bool CheckUniqueDni(int dni)
        {
            return !ListAll().Any(client => client.DNI == dni);
        }

        public Client Create(Client client)
        {
            var allClients = ListAll();

            if (CheckUniqueDni(client.DNI)) 
            {
                allClients.Add(client);
                SaveAll(allClients);
                Console.WriteLine("Client was added successfully !!");
                return client;
            }

            Console.WriteLine("Client was NOT added because DNI is duplicated !!"); // Corrección de tipografía
            return client;
        }

        public void Delete(int Id)
        {
            var allClients = ListAll();
            var clientToRemove = allClients.FirstOrDefault(c => c.Id == Id);

            if (clientToRemove != null)
            {
                allClients.Remove(clientToRemove);
                SaveAll(allClients);
            }
        }

        public void Update(Client client)
        {
            var allClients = ListAll();
            var index = allClients.FindIndex(c => c.Id == client.Id);

            if (index != -1)
            {
                allClients[index] = client;
                SaveAll(allClients);
            }
        }

        public List<Client> ListAll()
        {
            if (!File.Exists(_clientFilePath)) return new List<Client>();
            var clientJsonString = File.ReadAllText(_clientFilePath);
            return JsonConvert.DeserializeObject<List<Client>>(clientJsonString) ?? new List<Client>();
        }

        private void SaveAll(List<Client> allClients)
        {
            string json = JsonConvert.SerializeObject(allClients, Formatting.Indented);
            File.WriteAllText(_clientFilePath, json);
        }
    }
}

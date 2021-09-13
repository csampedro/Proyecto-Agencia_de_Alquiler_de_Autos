using Newtonsoft.Json;
using ProyectoAgencia;
using ProyectoAgencia.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectAgency
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
            var clientJsonString = File.ReadAllText(_clientFilePath);
            var allClients = JsonConvert.DeserializeObject<List<Client>>(clientJsonString);

            foreach (Client client in allClients)
            {
                if (Convert.ToInt32(Id).Equals(client.Id))
                {
                    return client;
                }
            }
            return null;
        }
        
        public bool CheckUniqueDni(string dni)
        {
            var clientJsonString = File.ReadAllText(_clientFilePath);
            var allClients = JsonConvert.DeserializeObject<List<Client>>(clientJsonString);

            foreach (Client element in allClients)
            {
                if (Convert.ToInt32((dni)).Equals(element.DNI))
                {
                    string clientJson = JsonConvert.SerializeObject(allClients);
                    return false;
                }                
            }
            return true;
        }

        public Client Create(Client client)
        {
            var clientJsonString = File.ReadAllText(_clientFilePath);
            var allClients = JsonConvert.DeserializeObject<List<Client>>(clientJsonString);
            
            bool IsDniUnique = CheckUniqueDni(Convert.ToString(client.DNI));
            if (IsDniUnique == true) 
            {
                allClients.Add(client);
                Console.WriteLine("Client was added succesfully !!");
                File.WriteAllText(_clientFilePath, JsonConvert.SerializeObject(allClients));
                return client;
            }
            Console.WriteLine("Client was NOT added becasue DNI is duplicated !!");
            return client;
        }

        public void Delete(string Id)
        {

            var clientJsonString = File.ReadAllText(_clientFilePath);
            var allClients = JsonConvert.DeserializeObject<List<Client>>(clientJsonString);

            foreach (Client element in allClients)
            {
                if (Convert.ToInt32(Id).Equals(element.Id))
                {
                    allClients.Remove(element);
                    string clientJson = JsonConvert.SerializeObject(allClients);
                    File.WriteAllText(_clientFilePath, clientJson);
                    break;
                }
            }
        }

        public void Update(Client client)
        {
            var clientJsonString = File.ReadAllText(_clientFilePath);
            var allClients = JsonConvert.DeserializeObject<List<Client>>(clientJsonString);

            for (var i = 0; i < allClients.Count; i++)
            {
                if (client.Id == (allClients[i].Id))
                {
                    allClients[i].DNI = client.DNI;
                    allClients[i].Name = client.Name;
                    allClients[i].Lastname = client.Lastname;
                    allClients[i].Phone = client.Phone;
                    allClients[i].Address = client.Address;
                    allClients[i].City = client.City;
                    allClients[i].Cp = client.Cp;
                    allClients[i].LastUpdatedDate = client.LastUpdatedDate;
                    string json = JsonConvert.SerializeObject(allClients);
                    File.WriteAllText(_clientFilePath, json);
                }
            }
        }

        public List<Client> ListAll()
        {
            var clientJsonString = File.ReadAllText(_clientFilePath);
            var allClients = JsonConvert.DeserializeObject<List<Client>>(clientJsonString);

            return allClients;
        }
    }
}

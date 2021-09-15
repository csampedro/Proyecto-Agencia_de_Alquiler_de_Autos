using Newtonsoft.Json;
using ProyectoAgencia.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;


namespace ProyectoAgencia
{
    public class RentalCRUD : ICRUD<Rental>
    {
        private readonly string _rentalFilePath;//private variables starts with _
        public RentalCRUD(string rentalFilePath)
        {
            _rentalFilePath = rentalFilePath;
        }

        public Rental Get(int Id)
        {
            var rentalJsonString = File.ReadAllText(_rentalFilePath);
            var allRentals = JsonConvert.DeserializeObject<List<Rental>>(rentalJsonString);

            foreach (Rental rental in allRentals)
            {
                if (Convert.ToInt32(Id).Equals(rental.Id))
                {
                    return rental;
                }
            }
            return null;//if no matches, return null
        }

        public Rental Create(Rental rental)
        {
            var rentalJsonString = File.ReadAllText(_rentalFilePath);
            var allRentals = JsonConvert.DeserializeObject<List<Rental>>(rentalJsonString);
            
            allRentals.Add(rental);
            string rentalJson = JsonConvert.SerializeObject(allRentals);
            File.WriteAllText(_rentalFilePath, rentalJson);
            return rental;
        }

        public void Delete(string Id)
        {
            var rentalJsonString = File.ReadAllText(_rentalFilePath);
            var allRentals = JsonConvert.DeserializeObject<List<Rental>>(rentalJsonString);

            foreach (Rental element in allRentals)
            {
                if (Id.Equals(element.Id))
                {
                    Console.WriteLine($"Idt: {Id} deleted !!");
                    allRentals.Remove(element);
                    string rentaljson = JsonConvert.SerializeObject(allRentals);
                    File.WriteAllText(_rentalFilePath, rentaljson);
                    break;
                }
            }
        }

        public void Update(Rental rental)
        {
            var rentalJsonString = File.ReadAllText(_rentalFilePath);
            var allRentals = JsonConvert.DeserializeObject<List<Rental>>(rentalJsonString);
            for (var i = 0; i < allRentals.Count; i++)
            {
                if (rental.Id == (allRentals[i].Id))
                {
                    allRentals[i].RentalDuration = rental.RentalDuration;
                    allRentals[i].RentalClientId = rental.RentalClientId;
                    allRentals[i].RentalCarId = rental.RentalCarId;
                    allRentals[i].RentalReturnDate = rental.RentalReturnDate;
                    string rentaljson = JsonConvert.SerializeObject(allRentals);
                    File.WriteAllText(_rentalFilePath, rentaljson);
                }
            }
        }

        public List<Rental> ListAll()
        {
            var rentalJsonString = File.ReadAllText(_rentalFilePath);
            var allRentals = JsonConvert.DeserializeObject<List<Rental>>(rentalJsonString);

            return allRentals;
        }

    }
}

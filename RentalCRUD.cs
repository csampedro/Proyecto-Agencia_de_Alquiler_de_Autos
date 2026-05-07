﻿﻿﻿using Newtonsoft.Json;
using ProyectoAgencia.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


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
            return ListAll().FirstOrDefault(rental => rental.Id == Id);
        }

        public Rental Create(Rental rental)
        {
            var allRentals = ListAll();
            allRentals.Add(rental);
            SaveAll(allRentals);
            return rental;
        }

        public void Delete(int Id)
        {
            var allRentals = ListAll();
            var rentalToRemove = allRentals.FirstOrDefault(r => r.Id == Id);

            if (rentalToRemove != null)
            {
                Console.WriteLine($"Id: {Id} deleted !!");
                allRentals.Remove(rentalToRemove);
                SaveAll(allRentals);
            }
        }

        public void Update(Rental rental)
        {
            var allRentals = ListAll();
            var index = allRentals.FindIndex(r => r.Id == rental.Id);

            if (index != -1)
            {
                allRentals[index] = rental;
                SaveAll(allRentals);
            }
        }

        public List<Rental> ListAll()
        {
            if (!File.Exists(_rentalFilePath)) return new List<Rental>();
            var rentalJsonString = File.ReadAllText(_rentalFilePath);
            return JsonConvert.DeserializeObject<List<Rental>>(rentalJsonString) ?? new List<Rental>();
        }

        private void SaveAll(List<Rental> allRentals)
        {
            string json = JsonConvert.SerializeObject(allRentals, Formatting.Indented);
            File.WriteAllText(_rentalFilePath, json);
        }
    }
}

using Newtonsoft.Json;
using ProyectoAgencia.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectAgency
{
    public class CarCRUD : ICRUD<Car>
    {
        private readonly string _carFilePath;//private variables starts with _
        public CarCRUD(string carFilePath)
        {
            _carFilePath = carFilePath;
        }

        public Car Get(int Id)
        {
         var carJsonString = File.ReadAllText(_carFilePath);
         var allCars = JsonConvert.DeserializeObject<List<Car>>(carJsonString);

            foreach (Car car in allCars)
            {
                if (Convert.ToString(Id).Equals(car.Id))
                {
                    return car;
                }
            }
            return null;
        }

        public Car Create(Car car)
        {
            var carJsonString = File.ReadAllText(_carFilePath);
            var allCars = JsonConvert.DeserializeObject<List<Car>>(carJsonString);

            allCars.Add(car);            
            string json = JsonConvert.SerializeObject(allCars);
            File.WriteAllText(_carFilePath, json);
            return car;
        }

        public void Delete(string Id)
        {
            var carJsonString = File.ReadAllText(_carFilePath);
            var allCars = JsonConvert.DeserializeObject<List<Car>>(carJsonString);

            foreach (Car element in allCars)
            {
                if (Id.Equals(element.Id))
                {
                    allCars.Remove(element);
                    string json = JsonConvert.SerializeObject(allCars);
                    File.WriteAllText(_carFilePath, json);
                    break;
                }
            }
        }

        public void Update(Car car)
        {
            var carJsonString = File.ReadAllText(_carFilePath);
            var allCars = JsonConvert.DeserializeObject<List<Car>>(carJsonString);

            for (var i = 0; i < allCars.Count; i++)
            {
                if (car.Id == (allCars[i].Patent))
                {
                    allCars[i].Patent = car.Patent;
                    allCars[i].Brand = car.Brand;
                    allCars[i].Model = car.Model;
                    allCars[i].DoorsAmount = car.DoorsAmount;
                    allCars[i].Color = car.Color;
                    allCars[i].Automatic = car.Automatic;
                    string json = JsonConvert.SerializeObject(allCars);
                    File.WriteAllText(_carFilePath, json);
                }
            }
        }

        public List<Car> ListAll()
        {
            var carJsonString = File.ReadAllText(_carFilePath);
            var allCars = JsonConvert.DeserializeObject<List<Car>>(carJsonString);

            return allCars;
        }
    }
}

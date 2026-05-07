using Newtonsoft.Json;
using ProyectoAgencia.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProyectoAgencia
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
            return ListAll().FirstOrDefault(car => car.Id == Id);
        }

        public Car Create(Car car)
        {
            var allCars = ListAll();
            allCars.Add(car);            
            SaveAll(allCars);
            return car;
        }

        public void Delete(int Id)
        {
            var allCars = ListAll();
            var carToRemove = allCars.FirstOrDefault(c => c.Id == Id);
            
            if (carToRemove != null)
            {
                allCars.Remove(carToRemove);
                SaveAll(allCars);
            }
        }

        public void Update(Car car)
        {
            var allCars = ListAll();
            var index = allCars.FindIndex(c => c.Id == car.Id);

            if (index != -1)
            {
                allCars[index] = car;
                SaveAll(allCars);
            }
        }

        public List<Car> ListAll()
        {
            if (!File.Exists(_carFilePath)) return new List<Car>();
            var carJsonString = File.ReadAllText(_carFilePath);
            return JsonConvert.DeserializeObject<List<Car>>(carJsonString) ?? new List<Car>();
        }

        private void SaveAll(List<Car> allCars)
        {
            string json = JsonConvert.SerializeObject(allCars, Formatting.Indented);
            File.WriteAllText(_carFilePath, json);
        }
    }
}

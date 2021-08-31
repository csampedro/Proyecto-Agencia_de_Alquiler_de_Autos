using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace ProjectAgency
{
    public class CarCRUD
    {
        List<Car> allCars = new List<Car>();
        public static string fileName = "car.json";
        Car car = new Car();
        public static string path = @"C:\Users\csampedro\source\repos\Proyecto-Agencia_de_Alquiler_de_Autos\bin\Debug\car.json";
        string jsonString = File.ReadAllText(fileName);


        public void GetCar(string Id)
        {
            allCars = JsonConvert.DeserializeObject<List<Car>>(jsonString);
            for (var i = 0; i < allCars.Count; i++)
            {
                if (Convert.ToString(Id) == (allCars[i].Patent))
                {
                    Console.WriteLine($"Patente: {allCars[i].Patent}");
                    Console.WriteLine($"Patente: {allCars[i].Brand}");
                    Console.WriteLine($"Patente: {allCars[i].Model}");
                    Console.WriteLine($"Patente: {allCars[i].DoorsAmount}");
                    Console.WriteLine($"Patente: {allCars[i].Color}");
                    Console.WriteLine($"Patente: {allCars[i].Automatic}");
                }
            }
        }

        public void CreateCar()
        {
            allCars = JsonConvert.DeserializeObject<List<Car>>(jsonString);
            Console.WriteLine("Enter the patent:");
            car.Patent = Console.ReadLine();
            Console.WriteLine("Enter the brand:");
            car.Brand = Console.ReadLine();
            Console.WriteLine("Enter the model:");
            car.Model = Console.ReadLine();
            Console.WriteLine("Enter the doors amount:");
            car.DoorsAmount = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Enter the color:");
            car.Color = Console.ReadLine();
            Console.WriteLine("Is the car automatic?(true/false):");
            car.Automatic = Convert.ToBoolean(Console.ReadLine());
            allCars.Add(car);
            Console.WriteLine("Car was added succesfully !!");
            string json = JsonConvert.SerializeObject(allCars);
            System.IO.File.WriteAllText(path, json);
        }

        public void Delete(string patent)
        {

            allCars = JsonConvert.DeserializeObject<List<Car>>(jsonString);

            foreach (Car element in allCars)
            {
                if (patent.Equals(element.Patent))
                {
                    Console.WriteLine($"Patent: {patent} deleted !!");
                    allCars.Remove(element);
                    string json = JsonConvert.SerializeObject(allCars);
                    System.IO.File.WriteAllText(path, json);
                    break;
                }
            }
        }

        public void Update(string Id)
        {
            allCars = JsonConvert.DeserializeObject<List<Car>>(jsonString);
            for (var i = 0; i < allCars.Count; i++)
            {
                if (Convert.ToString(Id) == (allCars[i].Patent))
                {
                    Console.WriteLine("Enter the NEW patent:");
                    allCars[i].Patent = Console.ReadLine();
                    Console.WriteLine("Enter the NEW brand:");
                    allCars[i].Brand = Console.ReadLine();
                    Console.WriteLine("Enter the NEW model:");
                    allCars[i].Model = Console.ReadLine();
                    Console.WriteLine("Enter the doors NEW amount:");
                    allCars[i].DoorsAmount = Convert.ToByte(Console.ReadLine());
                    Console.WriteLine("Enter the NEW color:");
                    allCars[i].Color = Console.ReadLine();
                    Console.WriteLine("UPDATE - Is the car automatic?(true/false):");
                    allCars[i].Automatic = Convert.ToBoolean(Console.ReadLine());
                    Console.WriteLine("Car was Updated succesfully !!");
                    string json = JsonConvert.SerializeObject(allCars);
                    System.IO.File.WriteAllText(path, json);

                }
            }

        }


    }
}

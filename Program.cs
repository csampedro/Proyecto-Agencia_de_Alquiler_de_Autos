using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace ProjectAgency
{
    public class Program
    {
        public static string path = @"C:\Users\csampedro\source\repos\Proyecto-Agencia_de_Alquiler_de_Autos\bin\Debug\car.json";
        public static string fileName = "car.json";
        public CarCRUD carCrud;

        static void Main(string[] args)
        {                        
            bool leave = false;
            

            while (!leave)
            {
                Console.WriteLine("1. Get car information option");
                Console.WriteLine("2. Add car option");
                Console.WriteLine("3. Delete car option");
                Console.WriteLine("4. Update car option");
                Console.WriteLine("5. Leave");
                Console.WriteLine("Select an option");
                int option = Convert.ToInt32(Console.ReadLine());
                CarCRUD carCrud = new CarCRUD();

                switch (option)
                {
                    case 1:
                        Console.WriteLine("You have chosen Get car information option");
                        Console.WriteLine("Enter the car patent");
                        var Id = Console.ReadLine();
                        carCrud.GetCar(Id);
                        break;

                    case 2:
                        Console.WriteLine("You have chosen Add car option");
                        carCrud.CreateCar();
                        break;

                    case 3:   // pasarlo aNetcore 5.0
                        Console.WriteLine("You have chosen Delete car option");
                        Console.WriteLine("Enter the car patent to be deleted");
                        var patentToDelete = Console.ReadLine();
                        carCrud.Delete(patentToDelete);
                        break;

                    case 4:   
                        Console.WriteLine("You have chosen Update car option");
                        Console.WriteLine("Enter the car patent to be updated");
                        var patentToUpdate = Console.ReadLine();
                        carCrud.Update(patentToUpdate);
                        break;

                    case 5:
                        Console.WriteLine("You have chosen Leave option");
                        leave = true;
                        break;

                    default:
                        Console.WriteLine("Select an option");
                        break;
                }
            }
        }
    }
}

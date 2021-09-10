using ProyectoAgencia;
using System;

namespace ProjectAgency
{
    public class Program
    {
        public CarCRUD carCrud;
        public Car car;
        public ClientCRUD clientCrud;
        public Client client;

        static void Main(string[] args)
        {                        
            bool leave = false;


            while (!leave)
            {
                Car car = new Car();
                CarCRUD carCrud = new CarCRUD();
                Client client = new Client();
                ClientCRUD clientCrud = new ClientCRUD();
                Console.WriteLine("-----------------");
                Console.WriteLine("CAR MENU");
                Console.WriteLine("-----------------");
                Console.WriteLine("1. Get car information option");
                Console.WriteLine("2. Add car option");
                Console.WriteLine("3. Delete car option");
                Console.WriteLine("4. Update car option");
                Console.WriteLine("5. List All Cars");
                Console.WriteLine("6. Leave");
                Console.WriteLine("");
                Console.WriteLine("-----------------");
                Console.WriteLine("CLIENT MENU //WIP");
                Console.WriteLine("-----------------");
                Console.WriteLine("7. Get client information option //WIP");
                Console.WriteLine("");

                Console.WriteLine("Select an option");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("You have chosen Get car information option");
                        Console.WriteLine("Enter the car Id");
                        var Id = Console.ReadLine();
                        carCrud.Get(Id);
                        break;

                    case 2:
                        Console.WriteLine("You have chosen Add car option");
                        carCrud.Create(car);
                        break;

                    case 3:   // pasarlo aNetcore 5.0
                        Console.WriteLine("You have chosen Delete car option");
                        Console.WriteLine("Enter the car Id to be deleted");
                        var patentToDelete = Console.ReadLine();
                        carCrud.Delete(patentToDelete);
                        break;

                    case 4:   
                        Console.WriteLine("You have chosen Update car option");
                        Console.WriteLine("Enter the car Id to be updated");
                        var patentToUpdate = Console.ReadLine();
                        carCrud.Update(patentToUpdate);
                        break;

                    case 5:
                        Console.WriteLine("You have chosen List All Cars option");
                        carCrud.ListAll();
                        break;

                    case 6:
                        Console.WriteLine("You have chosen Leave option");
                        leave = true;
                        break;

                    case 7:
                        Console.WriteLine("You have chosen Create client option");
                        clientCrud.Create(client);
                        break;


                    default:
                        Console.WriteLine("Select an option");
                        break;
                }
            }
        }
    }
}

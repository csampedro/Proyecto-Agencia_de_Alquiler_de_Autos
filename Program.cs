using ProyectoAgencia;
using System;
using System.Configuration;

namespace ProjectAgency
{
    public class Program
    {
        static void Main()
        {                        
            bool leave = false;

            while (!leave)
            {
                var car = new Car();
                var carCrud = new CarCRUD(ConfigurationManager.AppSettings[("pathCars")]);
                var client = new Client();
                var clientCrud = new ClientCRUD(ConfigurationManager.AppSettings[("pathClients")]);
                var rental = new Rental();
                var rentalCrud = new RentalCRUD(ConfigurationManager.AppSettings[("pathRentals")]);

                Console.WriteLine("-----------------");
                Console.WriteLine("CAR MENU");
                Console.WriteLine("-----------------");
                Console.WriteLine("1. Get car information option");
                Console.WriteLine("2. Add car option");
                Console.WriteLine("3. Delete car option");
                Console.WriteLine("4. Update car option");
                Console.WriteLine("5. List All Cars");
                Console.WriteLine("");
                Console.WriteLine("-----------------");
                Console.WriteLine("CLIENT MENU");
                Console.WriteLine("-----------------");
                Console.WriteLine("6. Get client information option");
                Console.WriteLine("7. Add client option");
                Console.WriteLine("8. Delete client optionP");
                Console.WriteLine("9. Update client option");
                Console.WriteLine("10. List All Client");
                Console.WriteLine("");
                Console.WriteLine("-----------------");
                Console.WriteLine("RENTAL MENU");
                Console.WriteLine("-----------------");
                Console.WriteLine("11. Get rental information option");
                Console.WriteLine("12. Add rental option");
                Console.WriteLine("13. Delete rental option");
                Console.WriteLine("14. Update rental option");
                Console.WriteLine("15. List All rentals");
                Console.WriteLine("");
                Console.WriteLine("16. Leave");
                Console.WriteLine("");
                Console.WriteLine("Select an option");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("You have chosen Get car information option");
                        Console.WriteLine("Enter the car Id");
                        car = carCrud.Get(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine($"Patent: {car.Id}");
                        Console.WriteLine($"Patent: {car.Patent}");
                        Console.WriteLine($"Brand: {car.Brand}");
                        Console.WriteLine($"Model: {car.Model}");
                        Console.WriteLine($"DoorsAmount: {car.DoorsAmount}");
                        Console.WriteLine($"Color: {car.Color}");
                        Console.WriteLine($"Automatic: {car.Automatic}");
                        break;

                    case 2:
                        Console.WriteLine("You have chosen Add car option");
                        Console.WriteLine("Enter the Id:");
                        car.Id = Console.ReadLine();
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
                        Console.WriteLine("Car was added succesfully !!");
                        carCrud.Create(car);
                        break;

                    case 3:   // pasarlo aNetcore 5.0
                        Console.WriteLine("You have chosen Delete car option");
                        Console.WriteLine("Enter the car Id to be deleted");
                        var patentToDelete = Console.ReadLine();
                        carCrud.Delete(patentToDelete);
                        Console.WriteLine($"Id: {patentToDelete} deleted !!");
                        break;

                    case 4:
                        Console.WriteLine("You have chosen Update car option");
                        Console.WriteLine("Enter the car Id to be updated");
                        car.Id = Console.ReadLine();
                        Console.WriteLine("Enter the NEW patent:");
                        car.Patent = Console.ReadLine();
                        Console.WriteLine("Enter the NEW brand:");
                        car.Brand = Console.ReadLine();
                        Console.WriteLine("Enter the NEW model:");
                        car.Model = Console.ReadLine();
                        Console.WriteLine("Enter the doors NEW amount:");
                        car.DoorsAmount = Convert.ToByte(Console.ReadLine());
                        Console.WriteLine("Enter the NEW color:");
                        car.Color = Console.ReadLine();
                        Console.WriteLine("UPDATE - Is the car automatic?(true/false):");
                        car.Automatic = Convert.ToBoolean(Console.ReadLine());
                        Console.WriteLine("Car was Updated succesfully !!");
                        carCrud.Update(car);
                        break;

                    case 5:
                        Console.WriteLine("You have chosen List All Cars option");
                        var allCars = carCrud.ListAll();

                        for (var i = 0; i < allCars.Count; i++)
                        {
                            car.Id = allCars[i].Id;
                            Console.WriteLine($"Car Id: {car.Id}");
                            car.Patent = allCars[i].Patent;
                            Console.WriteLine($"Patent: {car.Patent}");
                            car.Brand = allCars[i].Brand;
                            Console.WriteLine($"Brand: {car.Brand}");
                            car.Model = allCars[i].Model;
                            Console.WriteLine($"Model: {car.Model}");
                            car.DoorsAmount = allCars[i].DoorsAmount;
                            Console.WriteLine($"DoorsAmount: {car.DoorsAmount}");
                            car.Color = allCars[i].Color;
                            Console.WriteLine($"Color: {car.Color}");
                            car.Automatic = allCars[i].Automatic;
                            Console.WriteLine($"Automatic: {car.Automatic}");
                        }
                        break;

                    case 6:
                        Console.WriteLine("You have chosen Get client information option");
                        Console.WriteLine("Enter the client Id");
                        client = clientCrud.Get(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine($"Id: {client.Id}");
                        Console.WriteLine($"DNI: {client.DNI}");
                        Console.WriteLine($"Name: {client.Name}");
                        Console.WriteLine($"Lastname: {client.Lastname}");
                        Console.WriteLine($"Phone: {client.Phone}");
                        Console.WriteLine($"Address: {client.Address}");
                        Console.WriteLine($"City: {client.City}");
                        Console.WriteLine($"Cp: {client.Cp}");
                        Console.WriteLine($"LastUpdatedDate: {client.LastUpdatedDate}");
                        break;

                    case 7:
                        Console.WriteLine("You have chosen Create client option");
                        Console.WriteLine("Enter the Id:");
                        client.Id = Convert.ToInt32(Console.ReadLine());
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
                        clientCrud.Create(client);
                        break;

                    case 8:   
                        Console.WriteLine("You have chosen Delete client option");
                        Console.WriteLine("Enter the client Id to be deleted");
                        var clientToBeDelete = (Console.ReadLine());                        
                        clientCrud.Delete(clientToBeDelete);
                        Console.WriteLine($"Idt: {clientToBeDelete} deleted !!");
                        break;

                    case 9:
                        Console.WriteLine("You have chosen Update client option");
                        Console.WriteLine("Enter the client Id to be updated");
                        client.Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the NEW DNI:");
                        client.DNI = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the NEW Name:");
                        client.Name = Console.ReadLine();
                        Console.WriteLine("Enter the NEW Lastname:");
                        client.Lastname = Console.ReadLine();
                        Console.WriteLine("Enter the doors NEW phone:");
                        client.Phone = Console.ReadLine();
                        Console.WriteLine("Enter the NEW address:");
                        client.Address = Console.ReadLine();
                        Console.WriteLine("Enter the NEW City:");
                        client.City = Console.ReadLine();
                        Console.WriteLine("Enter the NEW Cp");
                        client.Cp = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the NEW LastUpdatedDate");
                        client.LastUpdatedDate = Console.ReadLine();
                        Console.WriteLine("Client was Updated succesfully !!");
                        clientCrud.Update(client);
                        break;

                    case 10:
                        Console.WriteLine("You have chosen List All Clients option");
                        var allClient = clientCrud.ListAll();
                        for (var i = 0; i < allClient.Count; i++)
                        {
                            client.Id = allClient[i].Id;
                            Console.WriteLine($"Client Id: {client.Id}");
                            client.DNI = allClient[i].DNI;
                            Console.WriteLine($"DNI: {client.DNI}");
                            client.Name = allClient[i].Name;
                            Console.WriteLine($"Name: {client.Name}");
                            client.Lastname = allClient[i].Lastname;
                            Console.WriteLine($"Lastname: {client.Lastname}");
                            client.Phone = allClient[i].Phone;
                            Console.WriteLine($"Phone: {client.Phone}");
                            client.Address = allClient[i].Address;
                            Console.WriteLine($"Address: {client.Address}");
                            client.City = allClient[i].City;
                            Console.WriteLine($"City: {client.City}");
                            client.Cp = allClient[i].Cp;
                            Console.WriteLine($"Cp: {client.Cp}");
                            client.LastUpdatedDate = allClient[i].LastUpdatedDate;
                            Console.WriteLine($"LastUpdatedDate: {client.LastUpdatedDate}");
                        }
                        break;

                    case 11:
                        Console.WriteLine("You have chosen Get rental information option");
                        Console.WriteLine("Enter the rental Id");
                        rental = rentalCrud.Get(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine($"Id: {rental.Id}");
                        Console.WriteLine($"RentalDuration: {rental.RentalDuration}");
                        Console.WriteLine($"RentalClientId: {rental.RentalClientId}");
                        Console.WriteLine($"RentalCarId: {rental.RentalCarId}");
                        Console.WriteLine($"RentalReturnDate: {rental.RentalReturnDate}");
                        break;

                    case 12:
                        Console.WriteLine("You have chosen Create rental option");
                        Console.WriteLine("Enter the Id:");
                        rental.Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Rental duration:");
                        rental.RentalDuration = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Client Id:");
                        rental.RentalClientId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Rental Car Id:");
                        rental.RentalCarId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Rental Returned Date:");
                        rental.RentalReturnDate = Console.ReadLine();
                        rentalCrud.Create(rental);
                        Console.WriteLine("Rental was added succesfully !!");
                        break;

                    case 13:
                        Console.WriteLine("You have chosen Delete rental option");
                        Console.WriteLine("Enter the rental Id to be deleted");
                        rentalCrud.Delete(Console.ReadLine());
                        break;

                    case 14:
                        Console.WriteLine("You have chosen Update rental option");
                        Console.WriteLine("Enter the rental Id to be updated");
                        rental.Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the NEW Rental Duration:");
                        rental.RentalDuration = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the NEW Rental Client Id:");
                        rental.RentalClientId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the NEW Rental Car Id:");
                        rental.RentalCarId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the doors NEW Rental Return Date:");
                        rental.RentalReturnDate = Console.ReadLine();
                        Console.WriteLine("Rental was Updated succesfully !!");
                        rentalCrud.Update(rental);
                        break;

                    case 15:
                        Console.WriteLine("You have chosen List All rentals option");
                        var allRentals = rentalCrud.ListAll();
                        for (var i = 0; i < allRentals.Count; i++)
                        {
                                rental.Id = allRentals[i].Id;
                                Console.WriteLine($"RentalId: {rental.Id}");
                                rental.RentalDuration = allRentals[i].RentalDuration;
                                Console.WriteLine($"RentalDuration: {rental.RentalDuration}");
                                rental.RentalClientId = allRentals[i].RentalClientId;
                                Console.WriteLine($"RentalClientId: {rental.RentalClientId}");
                                rental.RentalCarId = allRentals[i].RentalCarId;
                                Console.WriteLine($"RentalCarId: {rental.RentalCarId}");
                                rental.RentalReturnDate = allRentals[i].RentalReturnDate;
                                Console.WriteLine($"RentalReturnDate: {rental.RentalReturnDate}");                            
                        }
                        break;

                    case 16:
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

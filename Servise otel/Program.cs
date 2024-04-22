using Core.datalar;
using Core.Exceptions;
using Core.Models;
using Core.Service.Abstract;
using Core.Service.Implement;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;

namespace Servise_otel
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            int choice;
            int check;
            int select;


            HotelService hotelService= new HotelService();
            RoomService roomService = new RoomService();

            do
            {
                Console.WriteLine("Menu:\n1.Enter to system.\n0.Exit.");
                choice = Convert.ToInt32(Console.ReadLine());

                if(choice == 1)
                {
                    do
                    {
                        Console.WriteLine("Menu:\n1.Created hotel.\n2.See all hotels.\n3.Choose hotel.\n0.Exit.");
                        check = Convert.ToInt32(Console.ReadLine());

                        if(check ==1)
                        {
                            Console.WriteLine("Enter to hotel name:");
                            string name= Console.ReadLine();

                            Hotel hotel = new Hotel(name);
                            
                            bool choose=true;
                            foreach(var item in Lists.hotels)
                            {
                                if(item.Name.Equals(name))
                                {
                                    choose = false;
                                    Console.WriteLine("Otel is available!");

                                }
                            }
                            if (choose)
                            {

                                await hotelService.AddHotel(hotel);
                                Console.WriteLine(" ");
                                Console.WriteLine("Hotel successfully created.");
                                
                            }
                            
                        }
                        else if (check == 2)
                        {
                            await hotelService.GetAll();     /*.ForEach(x => Console.WriteLine(x));*/

                        }
                        else if (check == 3)
                        {
                            Console.WriteLine("Enter to hotel name:");
                            string name=Console.ReadLine();

                            await hotelService.ChoiceHotel(name);

                            do
                            {
                                Console.WriteLine("Menu:\n1.Created room.\n2.See all room.\n3.Make a reservation.\n0.Exit.");
                                select = Convert.ToInt32(Console.ReadLine());

                                if(select == 1)
                                {
                                    Console.WriteLine("Enter to room name:");
                                    string roomName= Console.ReadLine();

                                    Console.WriteLine(" ");
                                    string priceStr = " ";
                                    double price;

                                    do
                                    {
                                        Console.WriteLine("Enter to room price:");
                                        priceStr = Console.ReadLine();
                                    }
                                    while(!double.TryParse(priceStr, out price));

                                    Console.WriteLine(" ");
                                    string personCapacityStr = " ";
                                    int personCapacity;

                                    do
                                    {
                                        Console.WriteLine("Enter to room personcapacity:");
                                        personCapacityStr = Console.ReadLine();
                                    }
                                    while (!int.TryParse(personCapacityStr, out personCapacity));

                                    Room room = new Room(roomName,price,personCapacity);

                                    await roomService.AddRoom(room);

                                    Console.WriteLine(" ");
                                    Console.WriteLine("room created successfully.");
                                }
                                else if (select == 2)
                                {
                                    await roomService.GetAll();  /*.ForEach(x => Console.WriteLine(x));*/
                                }
                                else if (select == 3)
                                {
                                    Console.WriteLine(" ");
                                    string idStr = " ";
                                    int id;

                                    do
                                    {
                                        Console.WriteLine("Enter to Id:");
                                        idStr = Console.ReadLine();
                                    }
                                    while(!int.TryParse(idStr, out id));

                                    Console.WriteLine(" ");
                                    string personCountStr= " ";
                                    int personCount;

                                    do
                                    {
                                        Console.WriteLine("Enter to personcount:");
                                        personCountStr = Console.ReadLine();    
                                    }
                                    while(!int.TryParse(personCountStr, out personCount));

                                    try
                                    {
                                        
                                            await roomService.MakeRezervation(id, personCount);
                                            Console.WriteLine("reservation was made.");
                                        
                                       
                                    }
                                    catch(NullReferenceException)
                                    {
                                        Console.WriteLine("Id not found!");
                                    }
                                    
                                    catch (NotAvailableException)
                                    {
                                        Console.WriteLine("The room is not suitable for you!");
                                    }
                                    catch(Exception)
                                    {
                                        Console.WriteLine("Error!");
                                    }

                                    


                                    
                                }
                            }
                            while(select != 0);
                        }

                    }
                    while(check != 0);
                }
            }
            while (choice != 0);

            Console.WriteLine("Completed program!");
        }
    }
}

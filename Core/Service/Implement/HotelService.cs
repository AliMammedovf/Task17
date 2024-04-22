using Core.datalar;
using Core.Models;
using Core.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Implement
{
    public   class HotelService : IHotel
    {
        public async Task AddHotel(Hotel hotel)
        {
             Lists.hotels.Add(hotel);
        }

        public async  Task ChoiceHotel( string name)
        {
            Lists.hotels.FirstOrDefault( x =>  x.Name == name);

        }

        public async Task GetAll()
        {
           List<Hotel> a =  Lists.hotels; 
            foreach (Hotel hotel in a)
            {
                Console.WriteLine(hotel);
            }
        }

        
    }
}

using Core.Models;
using Core.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.datalar;
using Core.Exceptions;

namespace Core.Service.Implement
{
    public  class RoomService : IRoom
    {
        

        public async Task AddRoom(Room room)
        {
            Lists.rooms.Add(room);
        }

        public async Task GetAll()
        {
           List<Room> b= Lists.rooms;

            foreach(Room room in b)
            {
                Console.WriteLine(room);
            }
        }

        public async Task MakeRezervation(int? roomId, int personCount)
        {
            if (roomId == null)
            {
                throw new NullReferenceException("Id tapilmadi!");
            }

            Room room =Lists.rooms.FirstOrDefault(x => x.Id == roomId);

            if (room == null && roomId != room.Id)
            {
                throw new NotAvailableException("Id uygun otaq tapilmadi!");
            }
            
            if (personCount > room.PersonCapacity)
            {
                throw new NotAvailableException("otaq size uygun deyil!");
            }
            else
            {
                room.IsAvilable = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Room
    {
        public int Id { get; set; }

        private static int _id;
        public string RoomName { get; set; }

        private double _price { get; set; }

        private int _personCapacity { get; set; }

        public bool IsAvilable { get; set; } = true;

        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value > 0)
                {
                    _price = value;
                }
            }
        }
        public int PersonCapacity
        {
            get
            {
                return _personCapacity;
            }
            set
            {
                if (value > 0)
                {
                    _personCapacity = value;
                }
            }
        }

        public Room(string name, double price, int personcapacity)
        {
            _id++;
            Id = _id;
            RoomName = name;
            _price = price;
            _personCapacity = personcapacity;
        }
        public Room()
        {
            
        }

        public string ShowInfo()
        {
            return $" Id:{Id}\n Name:{RoomName}\n Price:{Price}\n PersonCapacity:{PersonCapacity}";
        }

        public  override string ToString()
        {
            return ShowInfo();
        }
    }
}

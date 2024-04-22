using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public  class Hotel
    {
        public int Id { get; set; }

        private static int _id;

        public string Name { get; set; }

        public Hotel(string name)
        {
            _id++;
            Id = _id;
            Name = name;
        }
        public Hotel()
        {

        }

        public  override string ToString()
        {
            return $" Id:{Id}\n Name:{Name}";
        }

    }
}

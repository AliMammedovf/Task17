using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Service.Abstract
{
    public interface IHotel
    {
            Task  AddHotel(Hotel hotel);

            Task GetAll();

            Task ChoiceHotel(string name);
    }
}

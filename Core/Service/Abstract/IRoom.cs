using Core.Models;

namespace Core.Service.Abstract
{
    public interface IRoom
    {
        Task AddRoom(Room room);

        Task GetAll();

        Task MakeRezervation(int? roomId, int personCount);
    }
}

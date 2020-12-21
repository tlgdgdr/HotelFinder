using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Abstract
{
    public interface IHotelService
    {
        Task<List<Hotel>> getAllHotels();
        Task<Hotel> getHotelById(int id);
        Task<Hotel> getHotelByName(string name);
        Task<Hotel> createHotel(Hotel hotel);
        Task<Hotel> updateHotel(Hotel hotel);
        Task deleteHotel(int id);
    }
}

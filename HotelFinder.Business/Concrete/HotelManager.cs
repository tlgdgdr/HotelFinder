using HotelFinder.Business.Abstract;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Concrete
{
    public class HotelManager : IHotelService
    {
        private IHotelRepository _hotelRepository;

        public HotelManager(IHotelRepository hotelRepository )
        {
            _hotelRepository = hotelRepository;
        }


        public async Task<Hotel> createHotel(Hotel hotel)
        {
            return await _hotelRepository.createHotel(hotel);
        }

        public async Task deleteHotel(int id)
        {
           await _hotelRepository.deleteHotel(id);
        }

        public async Task<List<Hotel>> getAllHotels()
        {
            return await _hotelRepository.getAllHotels();
        }

        public async Task<Hotel> getHotelById(int id)
        {
            if (id > 0)
            {
                return await _hotelRepository.getHotelById(id);
            }
            throw new Exception("id value can not be less than 1");
            
        }

        public async Task<Hotel> getHotelByName(string name)
        {
            if (name != null)
            {
                return await _hotelRepository.getHotelByName(name);
            }
            throw new Exception("name value can not be unvalid");
        }

        public async Task<Hotel> updateHotel(Hotel hotel)
        {
            return await _hotelRepository.updateHotel(hotel);
        }
    }
}

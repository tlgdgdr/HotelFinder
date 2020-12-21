using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        HotelDbContext DbContext = new HotelDbContext();

        public async Task<Hotel> createHotel(Hotel hotel)
        {
            DbContext.Hotels.Add(hotel);
            await DbContext.SaveChangesAsync();
            return hotel;
        }

        public async Task deleteHotel(int id)
        {
            var deleted = await getHotelById(id);
            DbContext.Hotels.Remove(deleted);
            await DbContext.SaveChangesAsync();
        }

        public async Task<List<Hotel>> getAllHotels()
        {
            return await DbContext.Hotels.ToListAsync();
        }

        public async Task<Hotel> getHotelById(int id)
        {
            return  await DbContext.Hotels.FindAsync(id);
        }

        public async Task<Hotel> getHotelByName(string name)
        {
            return await DbContext.Hotels.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
        }

        public async Task<Hotel> updateHotel(Hotel hotel)
        {
            DbContext.Hotels.Update(hotel);
            DbContext.SaveChanges();
            return hotel;
        }
    }
}

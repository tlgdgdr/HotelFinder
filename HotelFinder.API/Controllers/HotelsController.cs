using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var hotels =await _hotelService.getAllHotels();
            return Ok(hotels);//200 + data
        }
        /// <summary>
        /// Get Hotels by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel =await _hotelService.getHotelById(id);
            if (hotel != null)
            {
                return Ok(hotel);//200 + data
            }
            return NotFound();//404
        }

        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetHotelByName(string name)
        {
            var hotel = await _hotelService.getHotelByName(name);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound();
        }

        /// <summary>
        /// Create and add hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Hotel hotel)
        {
            var created = await _hotelService.createHotel(hotel);
            return CreatedAtAction("Get",new { id = created.Id }, created);
        }

        /// <summary>
        /// Update Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Hotel hotel)
        {
            if (await _hotelService.getHotelById(hotel.Id)!=null)
            {
                return Ok(await _hotelService.updateHotel(hotel)); // 200 + data
            }
            return NotFound();
        }

        /// <summary>
        /// Delete Hotel
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _hotelService.getHotelById(id) != null)
            {
                await _hotelService.deleteHotel(id);
                return Ok();
            }
            return NotFound(); 
        }
    }
}

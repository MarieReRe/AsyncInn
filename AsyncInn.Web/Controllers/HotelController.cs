using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Web.Models;
using AsyncInn.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsyncInn.Web.Controllers
{
    public class HotelController : Controller
    {
        IHotelService hotelService;

        public HotelController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        // GET: HotelController
        public async Task<ActionResult> Index()
        {
            var hotels = await hotelService.GetHotels();
            return View(hotels.OrderBy(hotels => hotels.HotelName));
        }

        // GET: HotelController/Details/5
        public async Task<ActionResult> Details(long id)
        {
            var hotel = await hotelService.GetHotelById(id);
            return View(hotel);
        }
        //GET: Hotel/Create
        // GET: HotelController/Delete/5
        public ActionResult Create()
        {
            return View();
        }
        // POST: Hotel/Create
        [HttpPost]
        public async Task <ActionResult> Create(Hotel hotel)
        {
            try
            {

                await hotelService.Create(hotel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            
        }
        // Get: HotelController/Edit/5
        public async Task<ActionResult> Edit(long id)
        {
            var hotel = await hotelService.GetHotelById(id);
            return View(hotel);
        }

        // POST: HotelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(long id, Hotel hotel)
        {
            try
            {
                await hotelService.Edit(id, hotel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HotelController/Delete/5
        public async Task <ActionResult> Delete(long id)
        {
           var hotel = await hotelService.GetHotelById(id);
            return View(hotel);
        }

        // POST: HotelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Delete(long id, IFormCollection collection)
        {
            try
            {
                await hotelService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

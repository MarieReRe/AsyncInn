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
    public class HotelsController : Controller
    {
        IHotelService hotelService;

        public HotelsController(IHotelService hotelService)
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

        // POST: HotelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(long id, IFormCollection collection)
        {
            try
            {
                var hotel = await hotelService.GetHotelById(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HotelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HotelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

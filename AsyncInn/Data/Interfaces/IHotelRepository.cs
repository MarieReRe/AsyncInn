﻿using AsyncInn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data.Interfaces
{
    public interface IHotelRepository
    {
   

        //C: Create
        Task<Hotel> CreateHotel(Hotel hotel);

        //R: Read
        Task<Hotel> GetHotelById(long id);
        Task<IEnumerable<Hotel>> GetHotels();

        //U: Update
        Task UpdateHotel(Hotel hotel);

        //D: Delete
        Task DeleteHotel(int id);
    }
}

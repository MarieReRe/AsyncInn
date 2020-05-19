using System;
using Microsoft.EntityFrameworkCore

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions<AsyncDbContext> options) : base(options)
        {

        }

    }
}

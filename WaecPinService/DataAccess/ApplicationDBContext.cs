using Microsoft.EntityFrameworkCore;
using System;
using WaecPinService.Model;

namespace WaecPinService.DataAccess
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<ScratchCard> ScratchCards { get; set; }

    }

}

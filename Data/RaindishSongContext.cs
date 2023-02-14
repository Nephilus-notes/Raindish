using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raindish.Models;

namespace Raindish.Data
{
    public class RaindishSongContext : DbContext
    {
        public RaindishSongContext (DbContextOptions<RaindishSongContext> options)
            : base(options)
        {
        }

        public DbSet<Raindish.Models.Song> Song { get; set; } = default!;
    }
}

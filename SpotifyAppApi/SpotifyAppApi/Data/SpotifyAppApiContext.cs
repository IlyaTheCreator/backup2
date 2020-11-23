using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpotifyAppApi.Models;

namespace SpotifyAppApi.Data
{
    public class SpotifyAppApiContext : DbContext
    {
        public SpotifyAppApiContext(DbContextOptions<SpotifyAppApiContext> opt) : base(opt){}

        public DbSet<User> Users { get; set; }
    }
}

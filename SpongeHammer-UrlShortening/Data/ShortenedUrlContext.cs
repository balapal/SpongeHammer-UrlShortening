using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpongeHammer_UrlShortening.Models;

namespace SpongeHammer_UrlShortening.Data
{
    public class ShortenedUrlContext : DbContext
    {
        public ShortenedUrlContext (DbContextOptions<ShortenedUrlContext> options)
            : base(options)
        {
        }

        public DbSet<SpongeHammer_UrlShortening.Models.ShortenedUrl> ShortenedUrls { get; set; }
    }
}

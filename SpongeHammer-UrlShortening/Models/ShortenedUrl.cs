using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpongeHammer_UrlShortening.Models
{
    public class ShortenedUrl
    {
        [Key]
        public string ShortenedLinkId { get; set; }

        [NotMapped]
        public string ShortUrl { get; set; }

        public string OriginalUrl { get; set; }
    }
}

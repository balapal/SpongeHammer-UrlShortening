using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpongeHammer_UrlShortening.Models
{
    public class ShortenedUrl
    {
        [Key]
        public string ShortenedLinkId { get; set; }

        public string OriginalUrl { get; set; }
    }
}

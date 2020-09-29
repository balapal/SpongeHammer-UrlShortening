using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpongeHammer_UrlShortening.Data;
using SpongeHammer_UrlShortening.Models;

namespace SpongeHammer_UrlShortening.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortenedUrlController : ControllerBase
    {
        private readonly ShortenedUrlContext _context;

        public ShortenedUrlController(ShortenedUrlContext context)
        {
            _context = context;
        }

        // GET: api/ShortenedUrl
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShortenedUrl>>> GetShortenedUrl()
        {
            return await _context.ShortenedUrls.ToListAsync();
        }

        // GET: api/ShortenedUrl/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShortenedUrl>> GetShortenedUrl(string id)
        {
            var shortenedUrl = await _context.ShortenedUrls.FindAsync(id);

            if (shortenedUrl == null)
            {
                return NotFound();
            }

            return RedirectPermanentPreserveMethod(shortenedUrl.OriginalUrl);
        }

        // POST: api/ShortenedUrl
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShortenedUrl>> PostShortenedUrl(ShortenedUrl shortenedUrl)
        {
            shortenedUrl.ShortenedLinkId = Guid.NewGuid().ToString();
            _context.ShortenedUrls.Add(shortenedUrl);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ShortenedUrlExists(shortenedUrl.ShortenedLinkId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }


            String baseUrl = string.Format("{0}://{1}{2}/", Request.Scheme, Request.Host, Request.Path);
            shortenedUrl.ShortUrl = baseUrl + shortenedUrl.ShortenedLinkId;

            return CreatedAtAction("GetShortenedUrl", new { id = shortenedUrl.ShortenedLinkId }, shortenedUrl);
        }

        private bool ShortenedUrlExists(string id)
        {
            return _context.ShortenedUrls.Any(e => e.ShortenedLinkId == id);
        }
    }
}

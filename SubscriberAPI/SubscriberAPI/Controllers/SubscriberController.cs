#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubscriberAPI.Data;
using SubscriberAPI.Models;
using System.Xml.Serialization;
using System.Xml;
using System.Text;

namespace SubscriberAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        private readonly Database _context;

        public SubscriberController(Database context)
        {
            _context = context;
        }

        // GET: api/Subscriber
        [HttpGet("{xml=false}")]
        public async Task<ActionResult<IEnumerable<SubscriberModel>>> GetSubscribers([FromQuery] bool xml)
        {
			if (xml)
			{
                var subscribers = await _context.Subscribers.ToListAsync();
                string xmlString = string.Empty;

                XmlSerializer serializer = new XmlSerializer(typeof(List<SubscriberModel>));
                using (var sww = new StringWriter())
                {
                    using XmlWriter writer = XmlWriter.Create(sww);
                    serializer.Serialize(writer, subscribers);
                    xmlString = sww.ToString();
                }

                var cd = new System.Net.Mime.ContentDisposition
                {
					// for example foo.bak
					FileName = "subscribers.xml",

					// always prompt the user for downloading, set to true if you want 
					// the browser to try to show the file inline
					Inline = false,
                };
                Response.Headers.Add("Content-Disposition", cd.ToString());
				return File(Encoding.UTF8.GetBytes(xmlString), "application/xml");
			}
			else
            {
                return await _context.Subscribers.ToListAsync();
            }
        }

        // GET: api/Subscriber/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriberModel>> GetSubscriberModel(int id)
        {
            var subscriberModel = await _context.Subscribers.FindAsync(id);

            if (subscriberModel == null)
            {
                return NotFound();
            }

            return subscriberModel;
        }

        // PUT: api/Subscriber/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscriberModel(int id, SubscriberModel subscriberModel)
        {
            if (id != subscriberModel.Su_Id)
            {
                return BadRequest();
            }

            _context.Entry(subscriberModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriberModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Subscriber
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubscriberModel>> PostSubscriberModel(SubscriberModel subscriberModel)
        {
            _context.Subscribers.Add(subscriberModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscriberModel", new { id = subscriberModel.Su_Id }, subscriberModel);
        }

        // DELETE: api/Subscriber/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriberModel(int id)
        {
            var subscriberModel = await _context.Subscribers.FindAsync(id);
            if (subscriberModel == null)
            {
                return NotFound();
            }

            _context.Subscribers.Remove(subscriberModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubscriberModelExists(int id)
        {
            return _context.Subscribers.Any(e => e.Su_Id == id);
        }
    }
}

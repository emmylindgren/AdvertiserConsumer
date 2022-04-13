using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubscriberAPI.Data;
using SubscriberAPI.Models;
using System.Xml.Serialization;
using System.Xml;
using System.Text;

namespace SubscriberAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class XmlController : Controller
	{
		private readonly Database _context;

		public XmlController(Database context)
		{
			_context = context;
		}
		
		[HttpPost]
		public async Task<IActionResult> Post(IFormFile uploadFile)
		{
			List<SubscriberModel> subscriberList;

			if (uploadFile is not null)
			{
				if (uploadFile.Length > 0)
				{

					XmlSerializer serializer = new(typeof(List<SubscriberModel>));

					subscriberList = serializer.Deserialize(uploadFile.OpenReadStream()) as List<SubscriberModel>;

					// Kolla ifall Su_Id skickas med,
					// blir nasty fel om vi försöker stoppa in i db när Su_Id finns med och inte är 0.
					foreach (SubscriberModel subscriber in subscriberList)
					{
						subscriber.Su_Id = 0;
					}
					
					_context.Subscribers.AddRange(subscriberList);
					await _context.SaveChangesAsync();
					return StatusCode(201);
				}
				return BadRequest("File is empty");
			}
			return BadRequest("No file was provided.");
		}

		[HttpGet]
		public async Task<IActionResult> GetXml()
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
				FileName = "subscribers.xml",
				Inline = false,
			};
			Response.Headers.Add("Content-Disposition", cd.ToString());
			return File(Encoding.UTF8.GetBytes(xmlString), "application/xml");
		}
	}
}

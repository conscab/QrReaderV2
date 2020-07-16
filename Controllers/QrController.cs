using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace QR_Reader_v2.Controllers
{
    public class QRController : ApiController
    {
        //HttpResponseMessage PostResult;


        // GET: api/QR
        public async Task<string> GetAsync()
        {
        
            var message = new HttpRequestMessage();
            var content = new MultipartFormDataContent();
            var file = "F:\\Work\\QrReaderV2\\Content\\Resources\\qrcode.png";

            FileStream filestream = new FileStream(file, FileMode.Open);
            string fileName = Path.GetFileName(file);

            content.Add(new StreamContent(filestream), "file", fileName);
            

            message.Method = HttpMethod.Post;

            //message.Content.Headers

            message.Content = content;

        
            message.RequestUri = new Uri("http://goqr.me/api/doc/read-qr-code/");

            var client = new HttpClient();



            var response = await client.SendAsync(message);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();

            //return response;

        }

        // GET: api/QR/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/QR
        public void Post([FromBody] string value)
        {

        }

        // PUT: api/QR/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/QR/5
        public void Delete(int id)
        {
        }
    }
}

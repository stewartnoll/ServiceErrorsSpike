using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Foo.Proxy.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Foo.Proxy.Controllers
{
    [Route("emailsettings")]
    public class EmailSettingsController : Controller
    {
        // GET api/values
        [HttpPut]
        public async Task<dynamic> UpdateAsync([FromBody]UpdateEmailSettingsRequest request)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5000");
            var httpResponseMessage = await httpClient.PutAsync("settings/2", new StringContent(JsonConvert.SerializeObject(request).ToString(), Encoding.UTF8, "application/json"));
            
            var content = await httpResponseMessage.Content.ReadAsStringAsync();
            
            if(!httpResponseMessage.IsSuccessStatusCode) {
                Response.StatusCode = 400;
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(content);
                return errorResponse;
            }

            return content;
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace OpenAPIs.Controllers;

[ApiController]
[Route("[controller]")]
public class SwapiController : ControllerBase
{
     string BASE_API_URL = "https://swapi.dev/";


         //GET Swapi
        [HttpGet(Name = "swapi")]
       public async Task<ActionResult> GetSwapi()
        {
            try
            {
                List<string>? swapi = new List<string>();

                using (var httpCient = new HttpClient())
                {
                    var response = await httpCient.GetAsync(BASE_API_URL + "api/people/");
                    if (response.IsSuccessStatusCode)
                    {
                        swapi = await response.Content.ReadFromJsonAsync<List<string>>();
                    }
                }

                return Ok(swapi);
            } catch (Exception )
            {
                return StatusCode(500, "Internal Server Error");
            }

        }

}


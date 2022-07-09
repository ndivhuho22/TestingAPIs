using Microsoft.AspNetCore.Mvc;

namespace OpenAPIs.Controllers;

[ApiController]
[Route("[controller]")]
public class ChunkController : ControllerBase
{
     string BASE_API_URL = "https://api.chucknorris.io/";


         //GET categories
        [HttpGet(Name = "categories")]
       public async Task<ActionResult> GetCategories()
        {
            try
            {
                List<string>? categories = new List<string>();

                using (var httpCient = new HttpClient())
                {
                    var response = await httpCient.GetAsync(BASE_API_URL + "jokes/categories");
                    if (response.IsSuccessStatusCode)
                    {
                        categories = await response.Content.ReadFromJsonAsync<List<string>>();
                    }
                }

                return Ok(categories);
            } catch (Exception )
            {
                return StatusCode(500, "Internal Server Error");
            }

        }

}
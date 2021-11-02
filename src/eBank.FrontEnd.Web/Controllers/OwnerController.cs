using eBank.FrontEnd.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace eBank.FrontEnd.Web.Controllers
{
    public class OwnerController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();

        List<OwnerDTO> _oOwners = new List<OwnerDTO>();
        OwnerDTO _oOwner = new OwnerDTO();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<OwnerDTO>> GetAllOwners()
        {
            _oOwners = new List<OwnerDTO>();

            using (var httpClient = new HttpClient(_clientHandler))
            {

                using (var response = await httpClient.GetAsync("https://localhost:44349/api/v1/Owner"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oOwners = JsonConvert.DeserializeObject<List<OwnerDTO>>(apiResponse);
                }

                return _oOwners;
            }
        }

        [HttpGet]
        public async Task<OwnerDTO> GetOwnerById(int OwnerId)
        {
            _oOwner = new OwnerDTO();

            using (var httpClient = new HttpClient(_clientHandler))
            {

                using (var response = await httpClient.GetAsync("https://localhost:44349/api/v1/Owner/" + OwnerId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oOwner = JsonConvert.DeserializeObject<OwnerDTO>(apiResponse);
                }

                return _oOwner;
            }
        }
    }
}

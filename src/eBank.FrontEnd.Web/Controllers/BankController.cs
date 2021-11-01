using eBank.FrontEnd.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eBank.FrontEnd.Web.Controllers
{
    public class BankController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();

        BankDTO _oBank = new BankDTO();
        List<BankDTO> _oBanks = new List<BankDTO>();

        public BankController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErros) => { return true; };

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<BankDTO>> GetAllBanks()
        {
            _oBanks = new List<BankDTO>();

            using (var httpClient = new HttpClient(_clientHandler))
            {

                using (var response = await httpClient.GetAsync("https://localhost:44368/api/v1/Bank"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oBanks = JsonConvert.DeserializeObject<List<BankDTO>>(apiResponse);
                }

                return _oBanks;
            }
        }

        [HttpGet]
        public async Task<BankDTO> GetBankById(int BankId)
        {
            _oBank = new BankDTO();

            using (var httpClient = new HttpClient(_clientHandler))
            {

                using (var response = await httpClient.GetAsync("https://localhost:44368/api/v1/Bank/" + BankId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oBank = JsonConvert.DeserializeObject<BankDTO>(apiResponse);
                }

                return _oBank;
            }
        }

        [HttpPost]
        public async Task<string> AddBank(BankDTO bank)
        {
            string msg = "";

            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(bank), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44368/api/v1/Bank/", content))
                {
                    msg = await response.Content.ReadAsStringAsync();
                }

                return msg;
            }
        }

        [HttpPut]
        public async Task<string> UpdateBank(int bankId, BankDTO bank)
        {
            string msg = "";

            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(bank), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("https://localhost:44368/api/v1/Bank/" + bankId, content))
                {
                    msg = await response.Content.ReadAsStringAsync();
                }

                return msg;
            }
        }

        [HttpDelete]
        public async Task<string> DeleteBank(int bankId)
        {
            string msg = "";

            using (var httpClient = new HttpClient(_clientHandler))
            {

                using (var response = await httpClient.DeleteAsync("https://localhost:44368/api/v1/Bank/" + bankId))
                {
                    msg = await response.Content.ReadAsStringAsync();
                }

                return msg;
            }
        }
    }
}

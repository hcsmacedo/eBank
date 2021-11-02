using eBank.FrontEnd.Web.Controllers;
using eBank.FrontEnd.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eAccount.FrontEnd.Web.Controllers
{
    public class AccountController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        AccountDTO _oAccount = new AccountDTO();
        List<AccountDTO> _oAccounts = new List<AccountDTO>();

        #region Controller

        private BankController _bankController;
        private OwnerController _ownerController;

        #endregion

        public AccountController(BankController bankController, OwnerController ownerController)
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErros) => { return true; };
            _bankController = bankController;
            _ownerController = ownerController;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<AccountDTO>> GetAllAccounts()
        {
            _oAccounts = new List<AccountDTO>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                //BankDTO _oBank = new BankDTO();
                //OwnerDTO _oOwner = new OwnerDTO();

                using (var response = await httpClient.GetAsync("https://localhost:44327/api/v1/Account"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oAccounts = JsonConvert.DeserializeObject<List<AccountDTO>>(apiResponse);
                }
                try { 
                    foreach (var row in _oAccounts)
                    {
                       
                        row.Bank =  _bankController.GetBankById(row.BankId).Result;
                        row.Owner = _ownerController.GetOwnerById(row.OwnerId).Result;

                        _bankController = new BankController();
                        _ownerController = new OwnerController();
                    }
                }
                catch (Exception e)
                {
                    
                }

                return _oAccounts;
            }
        }

        [HttpGet]
        public async Task<AccountDTO> GetAccountById(int AccountId)
        {
            _oAccount = new AccountDTO();

            using (var httpClient = new HttpClient(_clientHandler))
            {

                using (var response = await httpClient.GetAsync("https://localhost:44327/api/v1/Account/" + AccountId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oAccount = JsonConvert.DeserializeObject<AccountDTO>(apiResponse);
                }

                return _oAccount;
            }
        }

        [HttpPost]
        public async Task<string> AddAccount(AccountDTO Account)
        {
            string msg = "";

            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(Account), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44327/api/v1/Account/", content))
                {
                    msg = await response.Content.ReadAsStringAsync();
                }

                return msg;
            }
        }

        [HttpPut]
        public async Task<string> UpdateAccount(int AccountId, AccountDTO Account)
        {
            string msg = "";

            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(Account), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("https://localhost:44327/api/v1/Account/" + AccountId, content))
                {
                    msg = await response.Content.ReadAsStringAsync();
                }

                return msg;
            }
        }

        [HttpDelete]
        public async Task<string> DeleteAccount(int AccountId)
        {
            string msg = "";

            using (var httpClient = new HttpClient(_clientHandler))
            {

                using (var response = await httpClient.DeleteAsync("https://localhost:44327/api/v1/Account/" + AccountId))
                {
                    msg = await response.Content.ReadAsStringAsync();
                }

                return msg;
            }
        }
    }
}

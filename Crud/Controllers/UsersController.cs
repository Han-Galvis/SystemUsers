using Crud.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Crud.Controllers
{
    public class UsersController : Controller
    {
        private readonly HttpClient _httpClient;
        public UsersController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient();
            //Endpoint
            _httpClient.BaseAddress = new Uri("https://hcgl.bsite.net/api/");
        }
        public async Task<IActionResult>  Index()
        {
            try
            {
                var resp = await _httpClient.GetAsync("Users");
                if (resp.IsSuccessStatusCode)
                {
                    var content = await resp.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<IEnumerable<UsersViewModel>>(content);
                    return View("Index", user);
                }
                return View(new List<UsersViewModel>());
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Users/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var users = JsonConvert.DeserializeObject<UsersViewModel>(content);
                    return Ok(users);
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            catch(Exception ex)
            {
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsersViewModel users)
        {
            try
            {
                users.Created = DateTime.UtcNow;
                users.LastUpdate = DateTime.UtcNow;
                var json = JsonConvert.SerializeObject(users);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("Users", content);

                if (response.IsSuccessStatusCode)
                {
                    return Ok("Index");
                }
                return Ok("Index");


            }
            catch(Exception ex) {
                return Ok("Index");
            }
           
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromBody] UsersViewModel producto)
        {
                var json = JsonConvert.SerializeObject(producto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"Users/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", new { id });
                }
                else
                {
                return RedirectToAction("Index");
                }
            
            return View(producto);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"Users/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}

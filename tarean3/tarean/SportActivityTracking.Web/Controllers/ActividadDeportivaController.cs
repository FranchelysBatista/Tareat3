using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SportActivityTracking.Api.Dtos;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using SportActivityTracking.Web.Models;

public class ActividadDeportivaController : Controller
{
    private readonly HttpClient _httpClient;

    public ActividadDeportivaController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/ActividadDeportiva");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<ActividadesDeportivasDtos>>>(result);
                var actividades = apiResponse?.Data;

                return View(actividades);
            }
            else
            {
                TempData["ErrorMessage"] = "Hubo un problema al obtener las actividades.";
                return View("Error");
            }
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Ocurrió un error inesperado: {ex.Message}";
            return View("Error");
        }
    }

    public async Task<IActionResult> Details(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/ActividadDeportiva/{id}");

            if (response.IsSuccessStatusCode)
            {
                var actividadJson = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<ActividadesDeportivasDtos>>(actividadJson);

                if (apiResponse?.Data != null)
                {
                    var actividad = apiResponse.Data;
                    return View(actividad);
                }
            }

            return NotFound();
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Ocurrió un error al obtener los detalles: {ex.Message}";
            return View("Error");
        }
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ActividadesDeportivasDtos actividad)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(actividad), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/ActividadDeportiva", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Actividad creada exitosamente";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Hubo un problema al crear la actividad.";
                }
            }
            return View(actividad);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Ocurrió un error inesperado: {ex.Message}";
            return View(actividad);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/ActividadDeportiva/{id}");

            if (response.IsSuccessStatusCode)
            {
                var actividadJson = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<ActividadesDeportivasDtos>>(actividadJson);

                if (apiResponse?.Data != null)
                {
                    var actividad = apiResponse.Data;
                    return View(actividad);
                }
            }

            return NotFound();
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Ocurrió un error al obtener la actividad: {ex.Message}";
            return View("Error");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ActividadesDeportivasDtos actividad)
    {
        try
        {
            if (actividad.Id <= 0)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(actividad), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"api/ActividadDeportiva/{actividad.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Actividad actualizada exitosamente.";
                    TempData["ActividadId"] = actividad.Id;
                    return RedirectToAction("Edit", new { id = actividad.Id });
                }
                else
                {
                    TempData["ErrorMessage"] = "Hubo un problema al actualizar la actividad.";
                }
            }

            return View("Edit", actividad);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Ocurrió un error inesperado: {ex.Message}";
            return View("Error");
        }
    }
}
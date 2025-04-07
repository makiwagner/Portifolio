using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MeuBff.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MeuBffController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public MeuBffController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClient = httpClientFactory.CreateClient();
        _configuration = configuration;
    }

    [HttpGet("data")]
    public async Task<IActionResult> GetDataFromApi()
    {
        // Obtenha a URL da Web API da configuração
        var apiUrl = _configuration["ApiUrl"];

        if (string.IsNullOrEmpty(apiUrl))
        {
            return BadRequest("A URL da API não está configurada.");
        }

        
        try
        {
            var response = await _httpClient.GetAsync($"{apiUrl}/WeatherForecast");
            response.EnsureSuccessStatusCode(); // Lança uma exceção para códigos de status de erro

            var jsonResult = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<WeatherForecast>>(jsonResult); // Ou uma classe específica se você tiver o modelo

            // Aqui você pode realizar transformações ou lógica adicional antes de retornar para o cliente
            return Ok(data);
        }
        catch (HttpRequestException ex)
        {
            return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, $"Erro ao chamar a API: {ex.Message}");
        }
        catch (JsonException ex)
        {
            return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, $"Erro ao desserializar a resposta da API: {ex.Message}");
        }
    }
}

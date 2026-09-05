using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

// Classes para mapear a estrutura do JSON da API
public class AdviceResponse
{
    [JsonPropertyName("slip")]
    public Slip? Slip { get; set; }
}

public class Slip
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("advice")]
    public string? Advice { get; set; }
}

class Program
{
    static async Task Main()
    {
        // a) Endpoint da API
        string url = "https://api.adviceslip.com/advice";
        
        using HttpClient client = new HttpClient();

        try
        {
            // Fazendo a requisição GET para a API
            string responseBody = await client.GetStringAsync(url);

            // Deserializando a string JSON para o objeto em C#
            var result = JsonSerializer.Deserialize<AdviceResponse>(responseBody);

            // b) Imprimindo os dados na tela do console no formato solicitado
            if (result?.Slip != null)
            {
                Console.WriteLine("Conselho de Hoje:");
                Console.WriteLine(result.Slip.Advice);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro ao acessar a API: {ex.Message}");
        }
    }
}
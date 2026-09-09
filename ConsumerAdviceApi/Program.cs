using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


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
       
        string url = "https://api.adviceslip.com/advice";
        
        using HttpClient client = new HttpClient();

        try
        {
            string responseBody = await client.GetStringAsync(url);

            
            var result = JsonSerializer.Deserialize<AdviceResponse>(responseBody);

           
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

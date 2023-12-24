using EHA_AspNetCore.Models.People;
using EHA_AspNetCore.Services.Interfaces;
using EHA_AspNetCore.Data;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace EHA_AspNetCore.Services;

public class SupplierService : ISupplierService
{
    private readonly AppDbContext _context;
    private readonly HttpClient _httpClient;

    public SupplierService(AppDbContext context, HttpClient httpClient)
    {
        _context = context;
        _httpClient = httpClient;
    }

    public bool CheckIfForeignKey(int id)
    {
        throw new NotImplementedException();
    }

    public Supplier ProcessObject(Supplier obj)
    {
        throw new NotImplementedException();
    }

    public async Task<string> ZipCodeAPI(string zipCode, string countryName)
    {
        if (countryName == "BRAZIL")
        {
            return await ConsumeBrazilLocationApi(zipCode);
        }
        else if (countryName == "USA")
        {
            return ConsumeUSALocationApi(zipCode);
        }
        else
        {
            return null;
        }
    }

    private string ConsumeUSALocationApi(string zipCode)
    {
        throw new NotImplementedException();
    }

    private async Task<string> ConsumeBrazilLocationApi(string zipCode)
    {
        try
        {
            string formattedZipCode = RegexOnlyNumbers(zipCode);
            string apiUrl = $"https://viacep.com.br/ws/{formattedZipCode}/json/";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return FormatBrazilResponse(content);
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        return "";
    }

    public string RegexOnlyNumbers(string text)
    {
        return Regex.Replace(text, @"[^0-9]", "");
    }

    private string FormatBrazilResponse(string response)
    {
        var resp = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);

        JObject json = new JObject();
        json["city"] = resp["localidade"].ToString();
        json["state"] = resp["uf"].ToString();
        json["address"] = resp["logradouro"].ToString();
        json["district"] = resp["bairro"].ToString();
        json["country"] = "Brazil";

        return JsonConvert.SerializeObject(json);
    }

    public Task<ICollection<Supplier>> GetAll()
    {
        throw new NotImplementedException();
    }
}

using EHA_AspNetCore.Models.People;
using EHA_AspNetCore.Services.Interfaces;
using EHA_AspNetCore_Angular.Data;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace EHA_AspNetCore.Services;

public class CustomerService : ICustomerService
{
    private readonly AppDbContext _context;
    private readonly HttpClient _httpClient;

    public CustomerService(AppDbContext context, HttpClient httpClient)
    {
        _context = context;
        _httpClient = httpClient;
    }

    public bool CheckIfForeignKey(int id)
    {
        throw new NotImplementedException();
    }

    public Customer ProcessObject(Customer obj)
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

    //public class EnderecoViaCEP
    //{
    //    public string Cep { get; set; }
    //    public string Logradouro { get; set; }
    //    public string Complemento { get; set; }
    //    public string Bairro { get; set; }
    //    public string Localidade { get; set; }
    //    public string Uf { get; set; }
    //    public string Ibge { get; set; }
    //    public string Gia { get; set; }
    //    public string Ddd { get; set; }
    //    public string Siafi { get; set; }
    //}



}

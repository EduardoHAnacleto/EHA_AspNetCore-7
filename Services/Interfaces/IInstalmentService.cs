using EHA_AspNetCore.Models.Payments;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Text.Json.Nodes;

namespace EHA_AspNetCore.Services.Interfaces;

public interface IInstalmentService : IService<Instalment>
{
    public List<Instalment> JsonArrayToObject(string jsonString)
    {
        List<Instalment> list = new List<Instalment>(); 
        JArray array = JArray.Parse(jsonString);
        foreach (JObject obj in array.Children<JObject>())
        {
            foreach (JProperty prop in obj.Properties())
            {
                Instalment inst = new Instalment();
              
            }
        }
        return null;
    }
}

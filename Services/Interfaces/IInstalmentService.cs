using EHA_AspNetCore.DTOs;
using EHA_AspNetCore.Models.Payments;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Text.Json.Nodes;

namespace EHA_AspNetCore.Services.Interfaces;

public interface IInstalmentService : IService<Instalment>
{

    List<Instalment> MapDtoToClass(List<InstalmentDTO> Dtolist);

    List<Instalment> SetId(int id, List<Instalment> list);

    List<Instalment> SetPaymentMethod(List<Instalment> list);

    List<Instalment> RemoveExistingInstalments(int id);

}

using EHA_AspNetCore.DTOs;
using EHA_AspNetCore.Models.Payments;
using EHA_AspNetCore.Services.Interfaces;
using EHA_AspNetCore_Angular.Data;
using System.Text.Json.Nodes;

namespace EHA_AspNetCore.Services;

public class InstalmentService : IInstalmentService
{
    private readonly AppDbContext _context;

    public InstalmentService(AppDbContext context)
    {
        _context = context;
    }

    public Instalment ProcessObject(Instalment obj)
    {
        throw new NotImplementedException();
    }

    public List<Instalment> MapDtoToClass(List<InstalmentDTO> Dtolist)
    {
        var instalmentList = new List<Instalment>();
        foreach (var dto in Dtolist)
        {
            var instalment = new Instalment
            {
                Days = dto.Days,
                Number = dto.Number,
                PaymentMethodId = dto.PaymentMethodId,
                Percentage = dto.Percentage
            };
            instalmentList.Add(instalment);
        }      
        return instalmentList;
    }

    public List<Instalment> SetId(int id, List<Instalment> list)
    {
        foreach (var obj in list)
        {
            obj.PaymentConditionId = id;
            obj.PaymentMethod = _context.PaymentMethods.FirstOrDefault(x => x.Id == obj.PaymentMethodId);
        }
        return list;
    }

    public List<Instalment> SetPaymentMethod(List<Instalment> list)
    {
        foreach (var obj in list)
        {
            obj.PaymentMethod = _context.PaymentMethods.FirstOrDefault(x => x.Id == obj.PaymentMethodId);
        }
        return list;
    }

    public List<Instalment> RemoveExistingInstalments(int id)
    {
        return _context.Instalments
            .Where(e => e.PaymentConditionId == id)
            .ToList();  
        
    }

    public bool CheckIfForeignKey(int id)
    {
        throw new NotImplementedException();
    }
}

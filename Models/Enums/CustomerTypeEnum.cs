using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EHA_AspNetCore.Models.Enums;

[Table("CustomerTypes")]
public abstract class CustomerTypeEnum
{
    enum CustomerType
    {
        Natural = 0,
        Legal = 1
    }
    

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EHA_AspNetCore_Angular.Models.Base
{
    public abstract class Identification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date of Creation")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfCreation { get; }

        [Display(Name = "Date of Last Update")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfLastUpdate { get; }

        [Display(Name = "Last update User")]
        public Guid UserLastUpdated { get; }

    }
}

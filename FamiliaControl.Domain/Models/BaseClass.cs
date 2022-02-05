using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiliaControl.Domain.Models
{
    public class BaseClass
    {        
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public DateTime Create { get; set; }
        public DateTime? LastUpdate { get; set; }
        public Guid? LastUserUpdate { get; set; }
    }
}

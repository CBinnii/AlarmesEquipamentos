using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarmes_Equipamentos.DAL.Model.Base
{
    public abstract class BaseModel
    {
        [Required]
        public virtual int Id { get; set; }
    }
}

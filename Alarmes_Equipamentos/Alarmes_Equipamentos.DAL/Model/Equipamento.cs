using Alarmes_Equipamentos.DAL.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarmes_Equipamentos.DAL.Model
{
    [Table("dbo.Equipamento")]
    public partial class Equipamento : BaseModel
    {
        [Required]
        [StringLength(20)]
        public string Nome { get; set; }

        [StringLength(10)]
        [Display(Name = "Número de Série")]
        public string NumeroSerie { get; set; }

        public EnumTipo Tipo { get; set; }

        [Display(Name = "Data Cadastro")]
        public DateTime DataCadastro { get; set; }

        public virtual Alarme Alarme { get; set; }
    }
}

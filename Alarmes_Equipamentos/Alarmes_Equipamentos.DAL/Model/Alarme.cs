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
    [Table("dbo.Alarme")]
    public class Alarme : BaseModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [StringLength(10)]
        [Display(Name = "Número de Série")]
        public string NumeroSerie { get; set; }

        [Display(Name = "Classificação")]
        public EnumTipo Classificacao { get; set; }

        [Display(Name = "Data Cadastro")]
        public DateTime DataCadastro { get; set; }

        [ForeignKey("Equipamento")]
        public int IdEquipamento { get; set; }

        public virtual Equipamento Equipamento { get; set; }
    }
}

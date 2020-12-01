using Alarmes_Equipamentos.Areas.Alarmes.ViewModels;
using Alarmes_Equipamentos.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alarmes_Equipamentos.Areas.Equipamentos.ViewModels
{
    public class Equipamento
    {
        public virtual int Id { get; set; }

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
using System.ComponentModel.DataAnnotations;

namespace Alarmes_Equipamentos.DAL
{
    public enum EnumCassificacao
    {
        [Display(ResourceType = typeof(Resources.Enumeradores.EnumClassificacao), Name = "Baixo")]
        Baixo = 1,
        [Display(ResourceType = typeof(Resources.Enumeradores.EnumClassificacao), Name = "Medio")]
        Medio = 2,
        [Display(ResourceType = typeof(Resources.Enumeradores.EnumClassificacao), Name = "Alto")]
        Alto = 3
    }
}

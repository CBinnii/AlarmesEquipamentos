using AutoMapper;
using AlarmeVM = Alarmes_Equipamentos.Areas.Alarmes.ViewModels.Alarme;
using EquipamentoVM = Alarmes_Equipamentos.Areas.Equipamentos.ViewModels.Equipamento;
using Alarmes_Equipamentos.DAL.Model;

namespace Alarmes_Equipamentos.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            #region Alarme
            CreateMap<AlarmeVM, Alarme>();
            #endregion
            
            #region Alarme
            CreateMap<EquipamentoVM, Equipamento>();
            #endregion
        }
    }
}
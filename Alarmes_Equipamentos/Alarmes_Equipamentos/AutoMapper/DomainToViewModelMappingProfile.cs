using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AlarmeVM = Alarmes_Equipamentos.Areas.Alarmes.ViewModels.Alarme;
using Alarmes_Equipamentos.DAL.Model;
using EquipamentoVM = Alarmes_Equipamentos.Areas.Equipamentos.ViewModels.Equipamento;

namespace Alarmes_Equipamentos.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            #region Alarme
            CreateMap<Alarme, AlarmeVM>();
            #endregion

            #region Alarme
            CreateMap<Equipamento, EquipamentoVM>();
            #endregion
        }
    }
}
using Alarmes_Equipamentos.Areas.Equipamentos.ViewModels;
using Alarmes_Equipamentos.BLL;
using Alarmes_Equipamentos.Controllers;
using Alarmes_Equipamentos.Email;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alarmes_Equipamentos.Areas.Equipamentos.Controllers
{
    public class EquipamentoController : Controller
    {
        protected readonly IEquipamentoBLL _equipamentoBLL;
        protected readonly IMapper _mapper;

        // GET: Equipamentos/Equipamento
        public ActionResult Index()
        {
            var bllBusca = _equipamentoBLL.Listar();
            var viewmodel = _mapper.Map<IEnumerable<Equipamento>>(bllBusca);

            return View(viewmodel);
        }

        // GET: Equipamentos/Manter
        public ActionResult Manter()
        {
            return View();
        }
    }
}
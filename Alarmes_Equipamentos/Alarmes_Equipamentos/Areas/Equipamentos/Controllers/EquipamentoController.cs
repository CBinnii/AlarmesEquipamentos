using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alarmes_Equipamentos.Areas.Equipamentos.Controllers
{
    public class EquipamentoController : Controller
    {
        // GET: Equipamentos/Equipamento
        public ActionResult Index()
        {
            return View();
        }
    }
}
using Alarmes_Equipamentos.AutoMapper;
using Alarmes_Equipamentos.BLL;
using Alarmes_Equipamentos.Email;
using Alarmes_Equipamentos.ViewModel.Erro;
using AutoMapper;
using log4net;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Alarmes_Equipamentos.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IMapper _mapper;
        protected readonly AlarmesEquipamentosMailer _mailer;
        protected ICollection<string> Destinatarios;
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BaseController()
        {
        }

        protected int TamanhoPagina
        {
            get
            {
                return 50;
            }
        }

        protected void PreencherDestinatarios(string acao)
        {
            var email = "abcd@abc.com.br";

            if (!string.IsNullOrEmpty(email))
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                if (match.Success)
                {
                    Destinatarios.Add(email);
                }
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception is BusinessException)
            {
                filterContext.ExceptionHandled = true;
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.BadRequest, filterContext.Exception.Message);
                }
                else
                {
                    var viewResult = new ViewResult() { ViewName = "~/Views/Erro/Index.cshtml" };
                    viewResult.TempData["erro"] = new ErroVM { Mensagem = filterContext.Exception.Message, StatusCode = (int)HttpStatusCode.BadRequest };
                    filterContext.Result = viewResult;
                }
            }

            base.OnException(filterContext);
        }
    }
}
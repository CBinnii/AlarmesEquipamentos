using System.Web.Mvc;

namespace Alarmes_Equipamentos.Areas.Alarmes
{
    public class AlarmesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Alarmes";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Alarmes_default",
                "Alarmes/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
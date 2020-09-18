using System.Web.Mvc;

namespace CiberNeo.Areas.Inicio
{
    public class InicioAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Inicio";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Inicio_default",
                "Inicio/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
namespace VehicleQuote.Controllers {
	using System;
	using System.Linq;
	using System.Web.Mvc;
    using VehicleQuote.Api;
    using System.Collections.Generic;
    using System.Configuration;
    /// <summary>
    /// Controller that serves the quoting portion of the website
    /// </summary>
    [RoutePrefix("Quote")]
	[Route("{action}")]
	public class QuoteController : Controller {

		/// <summary>
		/// Index action / landing page
		/// </summary>
		/// <returns>A ViewResult</returns>
		[Route]
		[Route("~/")]
		[Route("Index")]
		[HttpGet]
		public ViewResult Index() {
            //string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            string strMakes = ConfigurationManager.AppSettings["fileMakes"];
            string strModels = ConfigurationManager.AppSettings["fileModels"];
            string xmlMakes = Server.MapPath("~/App_Data/" + strMakes);
            string xmlModels = Server.MapPath("~/App_Data/" + strModels);
            
            List<Make> lstMakes = XMLUtility.ToObjects<Make>(xmlMakes, "makes");
            List<MakeModels> lstModels = XMLUtility.ToObjects<MakeModels>(xmlModels, "modelsbymake");

            return View();
		}























	}
}
namespace VehicleQuote.Controllers {
	using System;
	using System.Linq;
	using System.Web.Mvc;
    using VehicleQuote.Api;
    using System.Collections.Generic;
    using System.Configuration;
    using VehicleQuote.Models;
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
            
            MyModel model = new MyModel();
            model.makeId = "0";
            model.modelId = "0";
            MakesModels.lstMakes = XMLUtility.ToObjects<Make>(xmlMakes, "makes");
            model.lstMakes = MakesModels.lstMakes.Except(MakesModels.lstMakes.Where(a => a.id == "EEE" || a.id == null)).ToList();
            MakesModels.lstModels = XMLUtility.ToObjects<MakeModels>(xmlModels, "modelsbymake");
            model.lstModels = MakesModels.lstModels.Except(MakesModels.lstModels.Where(a => a.id == "INVALID" || a.id == null)).ToList();
            

            return View(model);
		}



        public PartialViewResult _Form()
        {
            /*
            string strMakes = ConfigurationManager.AppSettings["fileMakes"];
            string strModels = ConfigurationManager.AppSettings["fileModels"];
            string xmlMakes = Server.MapPath("~/App_Data/" + strMakes);
            string xmlModels = Server.MapPath("~/App_Data/" + strModels);
            //MakesModels myModel = new MakesModels();
            MyModel model = new MyModel();
            model.makeId = "0";
            model.modelId = "0";
            MakesModels.lstMakes = XMLUtility.ToObjects<Make>(xmlMakes, "makes");
            model.lstMakes = MakesModels.lstMakes.Except(MakesModels.lstMakes.Where(a => a.id == "EEE" || a.id == null)).ToList();
            MakesModels.lstModels = XMLUtility.ToObjects<MakeModels>(xmlModels, "modelsbymake");
            model.lstModels = MakesModels.lstModels.Except(MakesModels.lstModels.Where(a => a.id == "INVALID" || a.id == null)).ToList();

            return PartialView("_Form", model);
            */
            return PartialView("_Form");
        }

        [HttpPost]
        public PartialViewResult SubmitMyModel(VehicleQuote.Models.MyModel model)
        {
            // Submission logic here
            return PartialView("_Form", model);
        }





















    }
}
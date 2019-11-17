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
            return View();
        }

        public ActionResult RenderForm()
        {
            string strMakes = ConfigurationManager.AppSettings["fileMakes"];
            string strModels = ConfigurationManager.AppSettings["fileModels"];
            string xmlMakesPath = Server.MapPath("~/App_Data/" + strMakes);
            string xmlModelsPath = Server.MapPath("~/App_Data/" + strModels);
            MyModel model = new MyModel();
            try
            {
                model.lstMakes = MakesModels.getMakes(xmlMakesPath);
                model.lstModels = MakesModels.getMakeModels(xmlModelsPath);

            }
            catch (Exception e)
            {
                return View("Error");
            }

            return PartialView("_Form", model);
        }

        [HttpPost]
        public ActionResult SubmitMyModel(VehicleQuote.Models.MyModel model)
        {
            ViewBag.Records = "";

            if (ModelState.IsValid)
                ViewBag.Records = "Make Id: " + model.makeId + " Model Id:  " + model.modelId;

            return PartialView("_ThankYou");
        }

  



















    }
}
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

            string strMakes = ConfigurationManager.AppSettings["fileMakes"];
            string strModels = ConfigurationManager.AppSettings["fileModels"];
            string xmlMakes = Server.MapPath("~/App_Data/" + strMakes);
            string xmlModels = Server.MapPath("~/App_Data/" + strModels);
            MyModel model = new MyModel();
            try
            {
                model = loadData(xmlMakes, xmlModels);
            }
            catch (Exception e)
            {
                
            }
            return View(model);

        }

        [HttpPost]
        public ActionResult SubmitMyModel(VehicleQuote.Models.MyModel model)
        {
            ViewBag.Records = "";

            if (ModelState.IsValid)
                ViewBag.Records = "Make Id: " + model.makeId + " Model Id:  " + model.modelId;

            return PartialView("_ThankYou");
        }

        public MyModel loadData(string xmlMakesPath, string xmlModelsPath)
        {
            MyModel model = new MyModel();
            try { 
                 MakesModels.lstMakes = XMLUtility.ToObjects<Make>(xmlMakesPath, "makes");
                 model.lstMakes = MakesModels.lstMakes.Except(MakesModels.lstMakes.Where(a => a.id == "EEE" || a.id == null)).ToList();

                 MakesModels.lstModels = XMLUtility.ToObjects<MakeModels>(xmlModelsPath, "modelsbymake");
                 model.lstModels = MakesModels.lstModels.Except(MakesModels.lstModels.Where(a => a.id == "INVALID" || a.id == null)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return model;
        }



















    }
}
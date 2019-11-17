namespace VehicleQuote.Api {
	using System.Linq;
	using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;

    /// <summary>
    /// Used for parsing out make and model data
    /// </summary>
    public static class MakesModels {
        public static List<Make>  getMakes(string xmlMakesPath)
        {
            string strIgnoredMakes = "EEE";
            string xmlRootMakes = "makes";
            List<Make> lstMakes = new List<Make>();

            try { 
                lstMakes = XMLUtility.ToObjects<Make>(xmlMakesPath, xmlRootMakes);
                lstMakes = lstMakes.Except(lstMakes.Where(a => a.id == strIgnoredMakes || a.id == null)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstMakes;
        }

        public static List<MakeModels> getMakeModels(string xmlModelsPath)
        {
            string strIgnoredModles = "INVALID";
            string xmlRootModels = "modelsbymake";
            List<MakeModels> lstMakeModels = new List<MakeModels>();

            try
            {
                lstMakeModels = XMLUtility.ToObjects<MakeModels>(xmlModelsPath, xmlRootModels);
                lstMakeModels = lstMakeModels.Except(lstMakeModels.Where(a => a.id == strIgnoredModles || a.id == null)).ToList();

                foreach (MakeModels item in lstMakeModels)
                {
                    item.Models = item.Models.Where(a => a.id != null).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstMakeModels;
        }
    }

    [XmlType("make")]
    public class Make
    {
        [XmlAttribute]
        public string id { get; set; }
        [XmlAttribute]
        public string description { get; set; }
    }

    public class Model
    {
        [XmlAttribute]
        public string id { get; set; }
 
        [XmlAttribute]
        public string description { get; set; }
    }

    [XmlType("make")]
    public class MakeModels
    {
        [XmlAttribute]
        public string id { get; set; }

        [XmlElement("model")]
        public List<Model> Models { get; set; }
    }
}
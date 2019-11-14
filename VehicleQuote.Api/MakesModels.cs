namespace VehicleQuote.Api {
	using System.Linq;
	using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;

    /// <summary>
    /// Used for parsing out make and model data
    /// </summary>
    public static class MakesModels {
  
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
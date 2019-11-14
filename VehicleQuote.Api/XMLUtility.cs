﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace VehicleQuote.Api
{
    public static class XMLUtility
    {
        public static string ToXml<T>(T objectToParse) where T : class, new()
        {
            if (objectToParse == null)
                throw new XmlException("Unable to parse a object which is null.", new ArgumentNullException("objectToParse"));

            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(typeof(T));
            try
            {
                serializer.Serialize(stringwriter, objectToParse);
            }
            catch (Exception e)
            {
                throw new XmlException(string.Format("Unable to serialize the object {0}.", objectToParse.GetType()), e);
            }

            return stringwriter.ToString();
        }

        public static T ToObject<T>(string xmlTextToParse) where T : class, new()
        {
            if (string.IsNullOrEmpty(xmlTextToParse))
                throw new XmlException("Invalid string input. Cannot parse an empty or null string.", new ArgumentException("xmlTestToParse"));

            var stringReader = new System.IO.StringReader(xmlTextToParse);
            var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute("makes"));
            try
            {
                return serializer.Deserialize(stringReader) as T;
            }
            catch (Exception e)
            {
                throw new XmlException(string.Format("Unable to convert to given string into the type {0}. See inner exception for details.", typeof(T)), e);
            }
        }

        public static List<T> ToObjects<T>(string xmlTextToParse, string rootAttribute) where T : class, new()
        {
            if (string.IsNullOrEmpty(xmlTextToParse))
                throw new XmlException("Invalid string input. Cannot parse an empty or null string.", new ArgumentException("xmlTestToParse"));

            StreamReader reader = new StreamReader(xmlTextToParse);

            var serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute(rootAttribute));
            try
            {
                return serializer.Deserialize(reader) as List<T>;
            }
            catch (Exception e)
            {
                throw new XmlException(string.Format("Unable to convert to given string into the type {0}. See inner exception for details.", typeof(T)), e);
            }
        }
    }
}

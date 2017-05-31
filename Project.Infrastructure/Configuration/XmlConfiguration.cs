using System;
using System.Web.Configuration;

namespace Project.Infrastructure.Configuration
{
    public interface IXmlConfiguration
    {
        string XmlFilePath { get; }
    }
    public class XmlConfiguration : IXmlConfiguration
    {
        public string XmlFilePath => AppDomain.CurrentDomain.GetData("DataDirectory") + "//" +
                                     WebConfigurationManager.AppSettings["personXmlFile"];

    }
}

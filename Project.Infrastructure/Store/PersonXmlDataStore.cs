using System.Linq;
using System.Xml.Linq;
using Project.Domain.Entities;
using Project.Infrastructure.Configuration;

namespace Project.Infrastructure.Store
{
    public class PersonXmlDataStore : XmlDataStoreBase<Person>
    {
        public PersonXmlDataStore(IXmlConfiguration xmlConfiguration) : base(xmlConfiguration)
        {
        }

        protected override bool CheckIfExist(Person entity)
        {
            var xmlDoc = GetXDocument();

            var items = xmlDoc.Element("items").Elements("Person");
            return items.Where(x => x.Element("Name").Value == entity.Name &&
                                    x.Element("Secondname").Value == entity.Secondname).Any();
        }

        protected override XDocument CreateNewXDocument()
        {
            var xdoc = new XDocument();
            var node = new XElement("items");
            xdoc.Add(node);
            return xdoc;
        }

        protected override XElement CreateNewNode(Person entity)
        {
            return new XElement("Person",
                new XElement("Name", entity.Name),
                new XElement("Secondname", entity.Secondname));
        }

        protected override void AddNode(XDocument xmlDoc, XElement newNode)
        {
            xmlDoc.Element("items").Add(newNode);
        }

        private void CreateRoot(XDocument xmlDoc)
        {
            
        }
    }
}
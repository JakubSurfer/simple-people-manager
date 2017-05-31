
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Configuration;
using System.Xml.Linq;
using Moq;
using NUnit.Framework;
using Project.Domain.Entities;
using Project.Infrastructure.Configuration;
using Project.Infrastructure.Store;

namespace Tests
{

    [TestFixture]
    public class when_saving_new_entity_to_txt_file : FileTestBase
    {
        [SetUp]
        public void Setup()
        {
            var path = BuildFilePath("\\App_Data\\personDetails.xml");
            DeleteFileIfExists(path);
            CreateFileIfNotExists(path);
        }

        [Test]
        public void It_should_have_proper_content()
        {
            var mockMailClient = new Moq.Mock<IXmlConfiguration>();
            mockMailClient.Setup(x => x.XmlFilePath).Returns(BuildFilePath("\\App_Data\\personDetails.xml"));
            var fileDataStore = new PersonXmlDataStore(mockMailClient.Object);
            var person = new Person
            {
                Name = "a",
                Secondname = "b"
            };
            
            fileDataStore.Store(person);
            var content = GetFileContent("\\App_Data\\personDetails.xml");
            var a = XDocument.Parse(content);
            var items = a.Element("items").Elements("Person").ToList();
            var personName = items.FirstOrDefault().Element("Name").Value;
            var personsecondname = items.FirstOrDefault().Element("Secondname").Value;
            Assert.AreEqual(items.Count, 1);
            Assert.AreEqual(personName, "a");
            Assert.AreEqual(personsecondname, "b");
        }
    }
}

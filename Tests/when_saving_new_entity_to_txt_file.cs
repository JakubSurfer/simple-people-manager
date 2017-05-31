using NUnit.Framework;
using Project.Domain.Entities;
using Project.Infrastructure.Store;

namespace Tests
{

    [TestFixture]
    public class when_saving_new_entity_to_xml_file : FileTestBase
    {
        [SetUp]
        public void Setup()
        {
            var path = BuildFilePath("\\App_Data\\personDetails.txt");
            DeleteFileIfExists(path);
        }

        [Test]
        public void It_should_have_proper_content()
        {
            var fileDataStore = new FileDataStore();
            var person = new Person
            {
                Name = "a",
                Secondname = "b"
            };
            
            fileDataStore.Store(person);
            var content = GetFileContent("\\App_Data\\personDetails.txt");
            Assert.AreEqual(content, "a,b");
        }
    }
}

using System;
using Castle.Components.DictionaryAdapter;
using NUnit.Framework;
using Project.Domain.Entities;
using Project.Infrastructure.Mapping;

namespace Tests
{
    public class when_mapping_person_to_persondetails
    {
        private class PersonDetails
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Secondname { get; set; }
            public string Thirddname { get; set; }
            public DateTime BirthDate { get; set; }
        }

        [Test]
        public void It_should_have_proper_mapped_properties()
        {
            var mapper = new FlatMapper();
            var persondetails = new PersonDetails
            {
                Name = "a",
                Secondname = "b",
                Thirddname = "c",
                BirthDate = DateTime.Now
            };


            var person = mapper.Map<PersonDetails, Person>(persondetails);
            Assert.AreEqual(person.Name, persondetails.Name);
            Assert.AreEqual(person.Secondname, persondetails.Secondname);
        }
    }
}

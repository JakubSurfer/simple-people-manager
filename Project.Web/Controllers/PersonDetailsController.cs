using System.Linq;
using System.Net;
using System.Web.Mvc;
using Project.Domain.Entities;
using Project.Infrastructure.Database;
using Project.Infrastructure.Mapping;
using Project.Infrastructure.Store;
using Project.Web.Models;

namespace Project.Web.Controllers
{
    public class PersonDetailsController : Controller
    {
        private readonly IFlatMapper _mapper;
        private readonly PersonRepository _personRepository;
        private readonly IDataStoreService<Person> _dataStoreService;

        public PersonDetailsController(
            IFlatMapper mapper, 
            PersonRepository personRepository, 
            IDataStoreService<Person> dataStoreService)
        {
            _mapper = mapper;
            _personRepository = personRepository;
            _dataStoreService = dataStoreService;
        }

        public ActionResult Index()
        {
            var all = _personRepository.GetAll();
            return View(all.ToList());
        }

       public ActionResult Details(int? id)
       {
           if (id == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
           var person = _personRepository.Get(id.Value);
           if (person == null)
           {
               return HttpNotFound();
           }
           var personDetails = _mapper.Map<Person, PersonDetails>(person);
            return View(personDetails);
    }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Secondname,Sex,MartialStatus,BirthDate")] PersonDetails personDetails)
        {
            if (ModelState.IsValid)
            {
                var person =_mapper.Map<PersonDetails, Person>(personDetails);
                _dataStoreService.SaveAll(person);
                return RedirectToAction("Index");
            }

            return View(personDetails);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var person = _personRepository.Get(id.Value);
            var personDetails = _mapper.Map<Person, PersonDetails>(person);
            return View(personDetails);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _personRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}

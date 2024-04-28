using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using telephoneBook_RDF.Data;
using telephoneBook_RDF.Models;
using VDS.RDF.Storage;

namespace telephoneBook_RDF.Controllers
{
    public class PhoneBookEntryController : Controller
    {
        private RDFDataManagement db = new RDFDataManagement();

        // GET: PhoneBookEntryController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PhoneBook/ShowSearchForm
        public IActionResult ShowSearchForm()
        {
            return View("ShowSearchForm", new List<PhoneBookEntryModel> { new PhoneBookEntryModel()});
        }

        // GET: PhoneBook/ShowSearchResults
        public IActionResult ShowSearchResults(string SearchFirstName, string SearchLastName, string SearchEmailAddress, string SearchPostalCode, string SearchStreetName, string SearchStreetNumber )
        {
            //return View();
            if (SearchFirstName != null || SearchLastName != null || SearchEmailAddress != null || SearchPostalCode != null || SearchStreetName != null || SearchStreetNumber != null )
            {
                return View("ShowSearchForm", db.getEntriesBy( SearchFirstName, SearchLastName, SearchEmailAddress, SearchPostalCode, SearchStreetName, SearchStreetNumber));
            }
            else
            {
                return View("ShowSearchForm", db.getEntries());
            }
        }
    }
}

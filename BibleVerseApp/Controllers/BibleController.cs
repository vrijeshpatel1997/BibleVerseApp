using BibleVerseApp.Models;
using BibleVerseApp.Services.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseApp.Controllers
{
    public class BibleController : Controller
    {
        /// <summary>
        /// intial view
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {

            List<BibleVerse> searchResults = new List<BibleVerse>();

            return View(searchResults);
        }
        [HttpPost]
        public IActionResult Index([Bind] VerseSearch objSearch)
        {
            List<BibleVerse> searchResults = new List<BibleVerse>();
            //make SURE DATA IS VALUD
            if (ModelState.IsValid)
            {
                BibleBusiness sendSearchCrit = new BibleBusiness();
                searchResults = sendSearchCrit.GetAllVerses(objSearch).ToList();
                return View(searchResults);

            }
            return View(searchResults);
        }
    }
}

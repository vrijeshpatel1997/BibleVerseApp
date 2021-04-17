using BibleVerseApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseApp.Controllers
{
    public class BibleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Search([Bind] VerseSearch objSearch)
        {


            if (ModelState.IsValid)
            {

            }


            return View(objSearch);
        }
    } 
}

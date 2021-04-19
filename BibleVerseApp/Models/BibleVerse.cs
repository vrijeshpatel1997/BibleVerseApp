using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseApp.Models
{
    public class BibleVerse
    {

        //define the model properties
        public int id { get; set; }
        [Display(Name = "Book")]
        public string BookName { get; set; }
        public int Chapter { get; set; }
        public int Verse { get; set; }
        [Display(Name = "Scripture")]
        public string Text { get; set; }
        [Display(Name = "Testament")]
        public string OT_NT { get; set; }
        public string Genre { get; set; }

    }
}

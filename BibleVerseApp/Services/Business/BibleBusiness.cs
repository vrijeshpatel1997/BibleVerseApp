using BibleVerseApp.Models;
using BibleVerseApp.Services.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibleVerseApp.Services.Business
{
    public class BibleBusiness
    {
        public IEnumerable<BibleVerse> GetAllVerses(VerseSearch passSearchCriteria)
        {
            BibleData PassToDataLayer = new BibleData();

            IEnumerable<BibleVerse> allVerses = PassToDataLayer.getBibleVerses(passSearchCriteria);

            return allVerses;
        }


    }
}

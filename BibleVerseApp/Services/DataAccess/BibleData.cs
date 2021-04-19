using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BibleVerseApp.Models;
using BibleVerseApp.Services.Utilities;

namespace BibleVerseApp.Services.DataAccess
{
    public class BibleData : DatabaseManager
    {


        //iemurable in c# is an interface that defines one method
        //this allows readonly accessto a collection than a collection that
        //implements IEmurable can be used witha= a for-each loop
        public IEnumerable<BibleVerse> getBibleVerses(VerseSearch searchCriteria)
        {
            string testamentSearch = "";
            //create the transpot 
            List<BibleVerse> searchResults = new List<BibleVerse>();

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                if (searchCriteria.Testament == "OT")
                    testamentSearch = " AND key_english.t = 'OT'";
                else if (searchCriteria.Testament == "NT")
                    testamentSearch = " AND key_english.t= 'NT'";
                else
                    testamentSearch = "";


                //define the query
                string query = string.Format(@"SELECT bible.t AS Text, bible.b, bible.c AS Chapter, bible.v AS Verse, key_english.n AS Book, key_english.t AS Testament, key_english.g, key_genre_english.g, key_genre_english.n AS Genre
                  FROM {0} Bible
                  JOIN key_english
                  ON bible.b = key_english.b
                  JOIN key_genre_English
                  ON key_english.g = key_genre_english.g
                  WHERE bible.t LIKE '%{1}%' {2}
                  ORDER BY bible.b, Chapter, Verse", searchCriteria.BibleVersion, searchCriteria.Text, testamentSearch);

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            //INSTIATE our bibleverse class creating an object

                            //called verse
                            BibleVerse verse = new BibleVerse();
                            //populate this object with a verse that was found
                            verse.BookName = reader["Book"].ToString();
                            verse.Chapter = Convert.ToInt32(reader["Chapter"].ToString());
                            verse.Verse = Convert.ToInt32(reader["Verse"].ToString());
                            verse.Genre = reader["Genre"].ToString();
                            if (reader["Testament"].ToString() == "OT")
                                verse.OT_NT = "Old Testament";
                            else
                                verse.OT_NT = "New Testament";
                            verse.Text = reader["Text"].ToString();

                            searchResults.Add(verse);
                        }
                    }
                }


            }
            return searchResults;
        }

    }
}

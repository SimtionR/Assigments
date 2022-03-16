using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling_Debugging.Library
{
    public class ExceptionsExemple
    {
        public bool isQualified { get; set; }
        public int score { get; set; }

        public void GetInfoAboutContender(int contenderId)
        {

            Console.WriteLine("OpeningDB");
            try
            {
                var score = GetScoreBasedOnID(contenderId);

                if (score < 50)
                {
                    this.score = score;
                    isQualified = false;

                }
                else
                {
                    this.score = score;
                    isQualified = true;

                }
            }
            catch (Exception ex )
            {
                //log the info ;
                throw;
            }

            finally
            {
                //Closing the DB opened even if we got an exception; 
                Console.WriteLine("ClosingDB");
            }

        }


        public int GetScoreBasedOnID(int contenderId)
        {
            int[] scores = new int[] { 100, 97,55,32,66,86,42,23,55,77 };
            return scores[contenderId];
        }


    }
}

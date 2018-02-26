using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicDNAPerformanceReview.Filtters
{
    public class MyFilter
    {
        public CMRSEntities2 db = new CMRSEntities2();
        ReviewTable tblReview = new ReviewTable();

        public List<ReviewTable> ByYear(int year)
        {
            List<ReviewTable> lstReview = new List<ReviewTable>();
         

            var yearly = from rev in db.ReviewTables
                                        where rev.DateOfReview.Value.Year == year
                                        select rev;
            foreach (var item in yearly)
            {
                lstReview.Add(item);
            }
            return lstReview;
        }

        public List<ReviewTable> ByQauter(string qauter)
        {
            List<ReviewTable> lstReview = new List<ReviewTable>();


            var yearly = from rev in db.ReviewTables
                         where rev.PeriodOfReview == qauter
                         select rev;
            foreach (var item in yearly)
            {
                lstReview.Add(item);
            }
            return lstReview;
        }

        public List<ReviewTable> ByName(int name)
        {
            List<ReviewTable> lstReview = new List<ReviewTable>();


            var yearly = from rev in db.ReviewTables
                         where rev.fkEmployeeId == name
                         select rev;
            foreach (var item in yearly)
            {
                lstReview.Add(item);
            }
            return lstReview;
        }


        public List<ReviewTable> ByYearQuater(string year,string quater)
        {
            List<ReviewTable> lstReview = new List<ReviewTable>();
            var _byYearQuater = (from rev in db.ReviewTables
                                 where rev.DateOfReview.Value.Year.ToString() == year && rev.PeriodOfReview == quater
                                 select rev).ToList();
            foreach (var item in _byYearQuater)
            {
                lstReview.Add(item);
            }
            return lstReview;
        }

        public List<ReviewTable> ByYearName(string year, int name)
        {
            List<ReviewTable> lstReview = new List<ReviewTable>();
            var _byYearQuater = (from rev in db.ReviewTables
                                 where rev.DateOfReview.Value.Year.ToString() == year && rev.fkEmployeeId == name
                                 select rev).ToList();
            foreach (var item in _byYearQuater)
            {
                lstReview.Add(item);
            }
            return lstReview;
        }

        public List<ReviewTable> ByQuaterName(string quater, int name)
        {
            List<ReviewTable> lstReview = new List<ReviewTable>();
            var _byYearQuater = (from rev in db.ReviewTables
                                 where rev.PeriodOfReview == quater && rev.fkEmployeeId == name
                                 select rev).ToList();
            foreach (var item in _byYearQuater)
            {
                lstReview.Add(item);
            }
            return lstReview;
        }



        public List<ReviewTable> ByYearQuaterName(string year, string quater,int name)
        {
            List<ReviewTable> lstReview = new List<ReviewTable>();
            var _byYearQuaterName = (from rev in db.ReviewTables
                                 where rev.DateOfReview.Value.Year.ToString() == year && rev.PeriodOfReview == quater && rev.fkEmployeeId == name
                                 select rev).ToList();
            foreach (var item in _byYearQuaterName)
            {
                lstReview.Add(item);
            }
            return lstReview;
        }

    }
}
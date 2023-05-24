using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models.Company
{
    public class IndexVM
    {
        public FilterVM Filter { get;set; }

        public List<CompaniesVM> Items { get; set; }
        public PagerVM Pager { get; set; }
    }
}
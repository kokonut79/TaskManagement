using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Models.Company;

namespace MVC.Models.Workers
{
    public class IndexVM
    {
        public FilterVM Filter { get; set; }
        public List<WorkersVM> Items { get; set; }
        public PagerVM Pager { get; set; }
    }
}
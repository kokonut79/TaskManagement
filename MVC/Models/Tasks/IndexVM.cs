using MVC.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models.Tasks
{
    public class IndexVM
    {
        public FilterVM Filter { get; set; }
        public List<TasksVM> Items { get; set; }
        public PagerVM Pager { get; set; }
    }
}
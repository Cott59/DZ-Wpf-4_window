using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_Wpf_4_window
{
    public class ToDo
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public string Description { get; set; }

      
        public ToDo(string title, DateTime date, string description) 
        { this.Title = title; this.Date = date; this.Description = description; this.Doing = false; }

        public bool Doing {  get; set; }


    }
}

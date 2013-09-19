using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Lesson02.Models
{
    public class Comment
    {
        public string Body { get; set; }

        public Person Person { get; set; }

        public ICollection<Country> Countries
        {
            get
            {
                return new Collection<Country>()
                       {
                           new Country() {Name = "Balarus"},
                           new Country() {Name = "Cuba"}
                       };
            }
        }

        public string Country { get; set; }

        public DateTime Date { get; set; }
    }
}
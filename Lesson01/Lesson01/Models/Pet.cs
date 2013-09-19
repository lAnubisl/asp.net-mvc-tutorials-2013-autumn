using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson01.Models
{
    public class Pet
    {
        private string name;

        public Pet(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }
    }
}
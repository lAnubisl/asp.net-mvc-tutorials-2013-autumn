using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson06
{
    public class Cat
    {
        public virtual long Id { get; set; }
        public virtual string Color { get; set; }
        public virtual int Age { get; set; } 
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflectionwith_CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]

    public class RangeAttribute : Attribute
    {

        public RangeAttribute(int Min, int Max)
        {
            this.Min = Min;
            this.Max = Max;
        }

        public string ErrorMessage { set; get; }
        public int Min { set; get; }
        public int Max { set; get; }
    }


    public class clsPerson
    {
        public clsPerson(string Name, int Age, int Experience)
        {
            this.Name = Name;
            this.Age = Age;
            this.Experience = Experience;
        }
        public string Name { set; get; }

        [Range(18, 30, ErrorMessage = "Age Must Be Between 18 and 30")]
        public int Age { set; get; }

        [Range(20, 30, ErrorMessage = "Experience must be between 20 and 30.")]
        public int Experience { get; set; }

    }
}

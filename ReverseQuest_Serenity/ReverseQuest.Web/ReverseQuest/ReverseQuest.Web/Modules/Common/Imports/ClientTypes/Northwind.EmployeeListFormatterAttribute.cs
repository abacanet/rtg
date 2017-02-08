using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace ReverseQuest.Northwind
{
    public partial class EmployeeListFormatterAttribute : CustomFormatterAttribute
    {
        public const string Key = "ReverseQuest.Northwind.EmployeeListFormatter";

        public EmployeeListFormatterAttribute()
            : base(Key)
        {
        }
    }
}


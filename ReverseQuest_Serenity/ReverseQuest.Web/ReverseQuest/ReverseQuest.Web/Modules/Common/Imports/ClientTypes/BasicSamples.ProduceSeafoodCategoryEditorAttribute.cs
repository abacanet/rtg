using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace ReverseQuest.BasicSamples
{
    public partial class ProduceSeafoodCategoryEditorAttribute : LookupEditorBaseAttribute
    {
        public const string Key = "ReverseQuest.BasicSamples.ProduceSeafoodCategoryEditor";

        public ProduceSeafoodCategoryEditorAttribute()
            : base(Key)
        {
        }
    }
}


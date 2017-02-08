using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace ReverseQuest.BasicSamples
{
    public partial class FilteredLookupDetailEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "ReverseQuest.BasicSamples.FilteredLookupDetailEditor";

        public FilteredLookupDetailEditorAttribute()
            : base(Key)
        {
        }
    }
}


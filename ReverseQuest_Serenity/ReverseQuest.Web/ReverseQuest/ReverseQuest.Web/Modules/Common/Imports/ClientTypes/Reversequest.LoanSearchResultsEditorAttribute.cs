using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace ReverseQuest.Reversequest
{
    public partial class LoanSearchResultsEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "ReverseQuest.Reversequest.LoanSearchResultsEditor";

        public LoanSearchResultsEditorAttribute()
            : base(Key)
        {
        }
    }
}


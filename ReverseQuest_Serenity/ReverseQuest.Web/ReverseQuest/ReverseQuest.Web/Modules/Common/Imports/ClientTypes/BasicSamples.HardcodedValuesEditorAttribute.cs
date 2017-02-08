using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace ReverseQuest.BasicSamples
{
    public partial class HardcodedValuesEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "ReverseQuest.BasicSamples.HardcodedValuesEditor";

        public HardcodedValuesEditorAttribute()
            : base(Key)
        {
        }
    }
}


using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Serenity
{
    [Imported, Serializable, PreserveMemberCase, IncludeGenericArguments(false)]
    public class UpdateLocalizationRequest<TEntity> : ServiceRequest
        where TEntity : class, new()
    {
        public JsDictionary<string, TEntity> Entities { get; set; }
    }
}
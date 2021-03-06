﻿using System;
using System.Runtime.CompilerServices;

namespace Serenity
{
    [Imported, Serializable, PreserveMemberCase, IncludeGenericArguments(false)]
    public class SaveRequest<TEntity> : ServiceRequest
        where TEntity : new()
    {
        public object EntityId { get; set; }
        public TEntity Entity { get; set; }
    }
}
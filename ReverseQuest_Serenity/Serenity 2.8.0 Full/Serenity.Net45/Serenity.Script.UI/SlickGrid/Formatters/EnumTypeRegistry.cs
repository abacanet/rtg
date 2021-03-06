﻿using System;
using System.Collections.Generic;

namespace Serenity
{
    public static class EnumTypeRegistry
    {
        private static JsDictionary<string, Type> knownTypes;

        public static Type Get(string key)
        {
            if (knownTypes == null)
            {
                knownTypes = new JsDictionary<string, Type>();
                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    foreach (var type in assembly.GetTypes())
                    {
                        if (type.IsEnum)
                        {
                            var fullName = type.FullName;
                            knownTypes[fullName] = type;

                            var enumKeyAttr = type.GetCustomAttributes(typeof(EnumKeyAttribute), false);
                            if (enumKeyAttr != null && enumKeyAttr.Length > 0)
                                knownTypes[((EnumKeyAttribute)enumKeyAttr[0]).Value] = type;

                            foreach (var k in Q.Config.RootNamespaces)
                            {
                                if (fullName.StartsWith(k + "."))
                                {
                                    knownTypes[fullName.Substr(k.Length + 1)] = type;
                                }
                            }
                        }
                    }
                }
            }

            if (!knownTypes.ContainsKey(key))
                throw new Exception(String.Format("Can't find {0} enum type!", key));

            return knownTypes[key];
        }
    }
}
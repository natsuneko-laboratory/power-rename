// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Reflection;

namespace NatsunekoLaboratory.PowerRename.Extensions
{
    internal static class TypeExtensions
    {
        public static string GetDisplayName(this Type t)
        {
            var attr = t.GetCustomAttribute<DisplayNameAttribute>();
            return attr?.DisplayName;
        }
    }
}
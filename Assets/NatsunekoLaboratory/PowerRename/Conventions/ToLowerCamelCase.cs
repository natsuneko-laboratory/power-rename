﻿// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using System.ComponentModel;

using NatsunekoLaboratory.PowerRename.Conventions.Interfaces;
using NatsunekoLaboratory.PowerRename.Extensions;

namespace NatsunekoLaboratory.PowerRename.Conventions
{
    /// <summary>
    ///     lowerCamelCase
    /// </summary>
    [DisplayName("To lowerCamelCase")]
    internal class ToLowerCamelCase : IRenameConvention
    {
        public void DoLayout() { }

        public void BeginDryRun()
        {
            // nothing to do
        }

        public void EndDryRun()
        {
            // nothing to do
        }

        public string DoRename(string current)
        {
            return current.WithDelimiter(null, (i, w) => i == 0 ? $"{w[0].ToString().ToLowerInvariant()}{w.Substring(1)}" : w);
        }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}
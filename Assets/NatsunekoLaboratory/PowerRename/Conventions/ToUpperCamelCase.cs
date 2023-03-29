// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using System.ComponentModel;

using NatsunekoLaboratory.PowerRename.Conventions.Interfaces;
using NatsunekoLaboratory.PowerRename.Extensions;

namespace NatsunekoLaboratory.PowerRename.Conventions
{
    /// <summary>
    ///     UpperCamelCase
    /// </summary>
    [DisplayName("To UpperCamelCase")]
    internal class ToUpperCamelCase : IRenameConvention
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
            return current.WithDelimiter(null, w => $"{w[0].ToString().ToUpperInvariant()}{w.Substring(1)}");
        }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}
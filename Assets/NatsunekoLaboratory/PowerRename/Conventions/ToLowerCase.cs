// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using System.ComponentModel;

using NatsunekoLaboratory.PowerRename.Conventions.Interfaces;

namespace NatsunekoLaboratory.PowerRename.Conventions
{
    /// <summary>
    ///     lowercase
    /// </summary>
    [DisplayName("To lowercase")]
    internal class ToLowerCase : IRenameConvention
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
            return current.ToLowerInvariant();
        }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}
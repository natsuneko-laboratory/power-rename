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
    ///     snake_case
    /// </summary>
    [DisplayName("To snake_case")]
    internal class ToSnakeCase : IRenameConvention
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
            return current.WithDelimiter('_', w => w.ToLowerInvariant());
        }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}
// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using System.ComponentModel;

using NatsunekoLaboratory.PowerRename.Conventions.Interfaces;

namespace NatsunekoLaboratory.PowerRename.Conventions
{
    [DisplayName("Remove trailing spaces")]
    internal class RemoveTrailingSpaces : IRenameConvention
    {
        public void DoLayout() { }

        public void BeginDryRun() { }

        public void EndDryRun() { }

        public string DoRename(string current)
        {
            return current.TrimEnd();
        }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}
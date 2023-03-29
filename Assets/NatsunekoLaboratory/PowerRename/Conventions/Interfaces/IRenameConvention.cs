// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

namespace NatsunekoLaboratory.PowerRename.Conventions.Interfaces
{
    internal interface IRenameConvention
    {
        void DoLayout();

        void BeginDryRun();

        void EndDryRun();

        string DoRename(string current);
    }
}
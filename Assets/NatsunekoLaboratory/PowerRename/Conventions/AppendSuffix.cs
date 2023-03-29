// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using System.ComponentModel;

using NatsunekoLaboratory.PowerRename.Conventions.Interfaces;

using UnityEditor;

namespace NatsunekoLaboratory.PowerRename.Conventions
{
    [DisplayName("Append Suffix")]
    internal class AppendSuffix : IRenameConvention
    {
        private string _value;

        public AppendSuffix()
        {
            _value = "suffix";
        }

        public void DoLayout()
        {
            _value = EditorGUILayout.TextField("Suffix", _value);
        }

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
            return $"{current}{_value}";
        }

        public override string ToString()
        {
            return $"Add \"{_value}\" to suffix";
        }
    }
}
// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using System.ComponentModel;

using NatsunekoLaboratory.PowerRename.Conventions.Interfaces;

using UnityEditor;

namespace NatsunekoLaboratory.PowerRename.Conventions
{
    [DisplayName("Append Prefix")]
    internal class AppendPrefix : IRenameConvention
    {
        private string _value;

        public AppendPrefix()
        {
            _value = "prefix";
        }

        public void DoLayout()
        {
            _value = EditorGUILayout.TextField("Prefix", _value);
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
            return $"{_value}{current}";
        }

        public override string ToString()
        {
            return $"Add \"{_value}\" to prefix";
        }
    }
}
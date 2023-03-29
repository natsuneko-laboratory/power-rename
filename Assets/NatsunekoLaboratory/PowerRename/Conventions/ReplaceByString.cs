// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using System.ComponentModel;

using NatsunekoLaboratory.PowerRename.Conventions.Interfaces;

using UnityEditor;

namespace NatsunekoLaboratory.PowerRename.Conventions
{
    [DisplayName("Replace by String")]
    internal class ReplaceByString : IRenameConvention
    {
        private string _from;
        private string _to;

        public ReplaceByString()
        {
            _from = "";
            _to = "";
        }

        public void DoLayout()
        {
            _from = EditorGUILayout.TextField("Regex", _from);
            _to = EditorGUILayout.TextField("Replace With", _to);
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
            return current.Replace(_from, _to);
        }

        public override string ToString()
        {
            return $"Replace \"{_from}\" with {_to}";
        }
    }
}
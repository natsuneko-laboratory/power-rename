// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using System.ComponentModel;

using NatsunekoLaboratory.PowerRename.Conventions.Interfaces;

using UnityEditor;

namespace NatsunekoLaboratory.PowerRename.Conventions
{
    [DisplayName("Append Sequential Number to Suffix")]
    internal class AppendSequentialNumberToSuffix : IRenameConvention
    {
        private int _cacheStarts;
        private int _digits;
        private int _starts;

        public AppendSequentialNumberToSuffix()
        {
            _digits = 3;
        }

        public void DoLayout()
        {
            _digits = EditorGUILayout.IntField("Digits", _digits);
            _starts = EditorGUILayout.IntField("Start Index", _starts);
        }

        public void BeginDryRun()
        {
            _cacheStarts = _starts;
        }

        public void EndDryRun()
        {
            _starts = _cacheStarts;
        }

        public string DoRename(string current)
        {
            return $"{current}{(_starts++).ToString().PadLeft(_digits, '0')}";
        }

        public override string ToString()
        {
            if (_digits <= 0)
                return string.Empty;

            return $"Add {_digits}-digit sequential number starting with {_starts} to suffix";
        }
    }
}
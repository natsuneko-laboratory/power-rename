﻿// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using System.ComponentModel;

using NatsunekoLaboratory.PowerRename.Conventions.Interfaces;

using UnityEditor;

namespace NatsunekoLaboratory.PowerRename.Conventions
{
    [DisplayName("Remove Suffix")]
    internal class RemoveSuffix : IRenameConvention
    {
        private int _length;

        public RemoveSuffix()
        {
            _length = 1;
        }

        public void DoLayout()
        {
            _length = EditorGUILayout.IntField("Length", _length);
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
            return current.Substring(0, current.Length - _length);
        }

        public override string ToString()
        {
            if (_length < 0)
                return string.Empty;

            return $"Remove {_length} characters from suffix";
        }
    }
}
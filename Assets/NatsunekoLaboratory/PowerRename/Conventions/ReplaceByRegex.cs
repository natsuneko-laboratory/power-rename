// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Text.RegularExpressions;

using NatsunekoLaboratory.PowerRename.Conventions.Interfaces;

using UnityEditor;

namespace NatsunekoLaboratory.PowerRename.Conventions
{
    [DisplayName("Replace by Regular Expressions")]
    internal class ReplaceByRegex : IRenameConvention
    {
        private bool _isValidRegex;
        private string _pattern;
        private Regex _regex;
        private string _to;

        public ReplaceByRegex()
        {
            _pattern = "";
            _to = "";
        }

        public void DoLayout()
        {
            _pattern = EditorGUILayout.TextField("Regex", _pattern);
            _to = EditorGUILayout.TextField("Replace With", _to);

            try
            {
                var _ = Regex.Match("", _pattern);
                _regex = null;
                _isValidRegex = true;
            }
            catch
            {
                _isValidRegex = false;
            }
        }

        public void BeginDryRun()
        {
            // nothing to do
        }

        public void EndDryRun()
        {
            _regex = null;
        }

        public string DoRename(string current)
        {
            if (string.IsNullOrWhiteSpace(_pattern) || !_isValidRegex)
                return current;

            if (_regex == null)
                _regex = new Regex(_pattern, RegexOptions.ECMAScript);

            return _regex.Replace(current, _to);
        }

        public override string ToString()
        {
            if (_isValidRegex)
                return $"Replace \"{_pattern}\" with {_to} using regular expression";

            return string.Empty;
        }
    }
}
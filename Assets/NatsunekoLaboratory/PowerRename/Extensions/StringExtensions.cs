// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Text;

namespace NatsunekoLaboratory.PowerRename.Extensions
{
    internal static class StringExtensions
    {
        private static readonly char[] Separators = { '_', ' ', '-' };

        public static string WithDelimiter(this string input, char? delimiter, Func<int, string, string> convert)
        {
            var sb = new StringBuilder();
            var processingCharacters = new StringBuilder();
            var i = 0;

            foreach (var c in input)
            {
                if (char.IsUpper(c))
                {
                    var token = processingCharacters.ToString();
                    if (!string.IsNullOrWhiteSpace(token))
                    {
                        sb.Append(convert(i++, token));
                        sb.Append(delimiter);
                    }

                    processingCharacters.Clear();
                    processingCharacters.Append(c);
                    continue;
                }

                if (Separators.Contains(c))
                {
                    var token = processingCharacters.ToString();
                    if (!string.IsNullOrWhiteSpace(token))
                    {
                        sb.Append(convert(i++, token));
                        sb.Append(delimiter ?? c);
                    }

                    processingCharacters.Clear();
                    continue;
                }

                processingCharacters.Append(c);
            }

            if (!string.IsNullOrWhiteSpace(processingCharacters.ToString()))
                sb.Append(convert(i, processingCharacters.ToString()));

            return sb.ToString().Trim();
        }

        public static string WithDelimiter(this string input, char? delimiter, Func<string, string> convert)
        {
            return input.WithDelimiter(delimiter, (_, w) => convert(w));
        }
    }
}
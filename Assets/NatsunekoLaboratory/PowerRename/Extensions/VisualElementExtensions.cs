// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using UnityEngine.UIElements;

namespace NatsunekoLaboratory.PowerRename.Extensions
{
    internal static class VisualElementExtensions
    {
        private static readonly Regex NameRegex = new Regex("\\[name=[\"'](?<name>.+)[\"']\\]", RegexOptions.Compiled);

        public static VisualElement Bind(this VisualElement e, VisualElement to)
        {
            to.Add(e);

            return e;
        }

        // Unity UI Toolkit is supposed to be a late-developed API, so why is it worse than JS Web API???????
        public static List<T> GetElementsByClassName<T>(this VisualElement e, string className) where T : VisualElement
        {
            return e.Query<T>(null, className).Where(w => w.ClassListContains(className)).ToList();
        }

        public static List<T> GetElementsByName<T>(this VisualElement e, string name) where T : VisualElement
        {
            return e.Query<T>(name).ToList();
        }

        public static T QuerySelector<T>(this VisualElement e, string selectors) where T : VisualElement
        {
            var elements = e.QuerySelectorAll<T>(selectors);
            if (elements.Count > 1)
                throw new InvalidOperationException();

            return elements.FirstOrDefault();
        }

        public static List<T> QuerySelectorAll<T>(this VisualElement e, string selectors) where T : VisualElement
        {
            var match = NameRegex.Match(selectors);
            if (match.Success && !string.IsNullOrWhiteSpace(match.Groups["name"].Value))
            {
                var name = match.Groups["name"].Value;
                var remainingSelectors = NameRegex.Replace(selectors, "");

                return e.QuerySelectorAllInternal<T>(name, remainingSelectors);
            }

            return e.QuerySelectorAllInternal<T>(null, selectors);
        }

        private static List<T> QuerySelectorAllInternal<T>(this VisualElement e, string name, string selectors) where T : VisualElement
        {
            var classes = selectors.Split('.', ' ').Where(w => !string.IsNullOrWhiteSpace(w)).ToArray();
            return e.Query<T>(name, classes).ToList();
        }
    }
}
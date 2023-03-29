// ------------------------------------------------------------------------------------------
//  Copyright (c) Natsuneko. All rights reserved.
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// ------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

using NatsunekoLaboratory.PowerRename.Conventions.Interfaces;
using NatsunekoLaboratory.PowerRename.Extensions;

using UnityEditor;

using UnityEditorInternal;

using UnityEngine;
using UnityEngine.UIElements;

using Object = UnityEngine.Object;

namespace NatsunekoLaboratory.PowerRename
{
    public class PowerRenameEditor : EditorWindow
    {
        private const string StyleGuid = "e4413b2d2104aa1469eb69e3972f8c1e";
        private const string XamlGuid = "11811b7843556494d90577d8ea3f9e4c";

        private static readonly List<Type> Conventions = new List<Type>();

        private readonly List<IRenameConvention> _conventions = new List<IRenameConvention>();
        private IRenameConvention _focusedConvention;

        private ReorderableList _list;
        private Vector2 _previewScrollPosition;

        [InitializeOnLoadMethod]
        private static void InitializeOnLoad()
        {
            var t = typeof(IRenameConvention);
            var conventions = typeof(IRenameConvention).Assembly.GetTypes()
                                                       .Where(w => w != t)
                                                       .Where(w => t.IsAssignableFrom(w));

            Conventions.AddRange(conventions);
        }

        [MenuItem("Window/Natsuneko Laboratory/Power Rename")]
        private static void ShowWindow()
        {
            var window = GetWindow<PowerRenameEditor>();
            window.titleContent = new GUIContent("Power Rename");
            window.Show();
        }

        private void OnEnable()
        {
            Selection.selectionChanged += OnSelectionChanged;
        }

        private void OnDisable()
        {
            Selection.selectionChanged -= OnSelectionChanged;
        }

        private void OnSelectionChanged()
        {
            Repaint();
        }

        private void CreateGUI()
        {
            var root = rootVisualElement;
            root.styleSheets.Add(LoadAssetByGuid<StyleSheet>(StyleGuid));

            var xaml = LoadAssetByGuid<VisualTreeAsset>(XamlGuid);
            var tree = xaml.CloneTree();
            root.Add(tree);

            root.QuerySelector<Button>("[name='apply-changes']").clicked += ApplyChanges;

            new IMGUIContainer(() =>
            {
                if (_list == null)
                {
                    _list = new ReorderableList(_conventions, typeof(IRenameConvention), true, true, true, true);
                    _list.onAddDropdownCallback += (rect, list) =>
                    {
                        var m = new GenericMenu();

                        foreach (var convention in Conventions)
                            m.AddItem(new GUIContent(convention.GetDisplayName()), false, () => _conventions.Add(Activator.CreateInstance(convention) as IRenameConvention));

                        m.DropDown(rect);
                    };

                    _list.drawElementCallback += (rect, index, active, focused) =>
                    {
                        var convention = _conventions[index];
                        var str = convention.ToString();

                        EditorGUI.LabelField(rect, string.IsNullOrWhiteSpace(str) ? convention.GetType().GetDisplayName() : str);
                    };

                    _list.onSelectCallback += list => _focusedConvention = _conventions[list.index];
                }

                _list.DoLayoutList();
            }).Bind(root.QuerySelector<VisualElement>("[name='conventions-container']"));

            new IMGUIContainer(() =>
            {
                if (_focusedConvention == null)
                {
                    EditorGUILayout.LabelField("No Options Available");
                    return;
                }

                _focusedConvention?.DoLayout();
            }).Bind(root.QuerySelector<VisualElement>("[name='options-container']"));

            new IMGUIContainer(() =>
            {
                using (var scroller = new EditorGUILayout.ScrollViewScope(_previewScrollPosition, GUILayout.ExpandWidth(false)))
                {
                    _previewScrollPosition = scroller.scrollPosition;

                    foreach (var go in GetTargetGameObjects())
                        EditorGUILayout.LabelField(go.name);
                }
            }).Bind(root.QuerySelector<VisualElement>("[name='left-container']"));

            new IMGUIContainer(() =>
            {
                using (var scroller = new EditorGUILayout.ScrollViewScope(_previewScrollPosition, GUILayout.ExpandWidth(false)))
                {
                    _previewScrollPosition = scroller.scrollPosition;

                    var conventions = _conventions.Where(w => w != null).ToList();
                    conventions.ForEach(w => w.BeginDryRun());

                    foreach (var go in GetTargetGameObjects())
                        EditorGUILayout.LabelField(conventions.Aggregate(go.name, (n, runner) => runner.DoRename(n)));

                    conventions.ForEach(w => w.EndDryRun());
                }
            }).Bind(root.QuerySelector<VisualElement>("[name='right-container']"));
        }

        private void ApplyChanges()
        {
            var objects = GetTargetGameObjects();
            var conventions = _conventions.Where(w => w != null).ToList();

            foreach (var go in objects)
            {
                Undo.RecordObject(go, "PowerRename");
                go.name = conventions.Aggregate(go.name, (n, runner) => runner.DoRename(n));
            }
        }

        private static List<GameObject> GetTargetGameObjects()
        {
            var selections = Selection.gameObjects.ToList();
            selections.Sort((a, b) => a.transform.GetSiblingIndex() - b.transform.GetSiblingIndex());

            return selections;
        }

        private static T LoadAssetByGuid<T>(string guid) where T : Object
        {
            return AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(guid));
        }
    }
}
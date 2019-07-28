// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Detox Studios LLC" file="uScript.cs">
//   Copyright 2010-2019 Detox Studios LLC. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Detox.ScriptEditor;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Detox.Editor.GUI.Windows
{
    public class GenerateNodesWindow : EditorWindow
    {
        private int _selectedIndex = 0;
        private string _customType = "";
        private bool _useReflected = true;
        private Type[] _reflectedTypes;
        private Color _customFieldColor = Color.white;
        private string _shortName = "";
        private bool[] _nodesToGenerate;

        public void Init()
        {
            titleContent = new GUIContent("Node Gen");
            position = new Rect(Screen.width / 2, Screen.height / 2, 300, 350);
            _reflectedTypes = GenerateNodes.GetAllLoadedTypes().OrderBy(t => t.Name).ToArray();
            _nodesToGenerate = new bool[Enum.GetNames(typeof(GenerateNodes.Nodes)).Length - 3];
            for (int i = 0; i < _nodesToGenerate.Length; i++)
            {
                _nodesToGenerate[i] = true;
            }
            CheckType();
        }

        void OnGUI()
        {
            EditorGUILayout.BeginVertical(GUILayout.ExpandHeight(true));
            {
                GUILayout.Space(10);    // vertical space
                if (uScript.WeakInstance == null)
                {
                    DrawOrphanGUI();
                }
                else
                {
                    DrawInstructions();
                    GUILayout.Space(10); // vertical space
                    EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
                    {
                        GUILayout.Space(10);    // horizontal space
                        bool reflected = DrawReflected();
                        bool custom = DrawCustom();

                        if (reflected != _useReflected)
                        {
                            // reflected value changed
                            _useReflected = reflected;
                            if (_useReflected) _customType = "";
                            CheckType();
                        }
                        else if (custom == _useReflected)
                        {
                            // custom value changed
                            _useReflected = !custom;
                            if (_useReflected) _customType = "";
                            CheckType();
                        }
                        GUILayout.Space(10);    // horizontal space
                    }
                    EditorGUILayout.EndHorizontal();
                    GUILayout.Space(10); // vertical space
                    DrawShortName();
                    GUILayout.Space(10); // vertical space
                    DrawGeneratedNames();
                    GUILayout.FlexibleSpace();  // vertical space
                    DrawBottomButtons();
                }
                GUILayout.Space(10);    // vertical space
            }
            EditorGUILayout.EndVertical();
        }

        private void CheckType()
        {
            Color prevColor = UnityEngine.GUI.color;
            Type foundType = null;
            if (_useReflected)
            {
                foundType = _reflectedTypes[_selectedIndex];
            }
            else
            {
                if (uScript.WeakInstance != null)
                {
                    foundType = uScript.WeakInstance.GetType(_customType);
                }
            }

            if (foundType != null)
            {
                _customFieldColor = Color.green;
                string name = foundType.FullName;
                if (name.Contains("."))
                {
                    _shortName = name.Substring(name.LastIndexOf(".") + 1);
                }
                else
                {
                    _shortName = name;
                }
            }
            else
            {
                if (!_useReflected && !string.IsNullOrEmpty(_customType)) _customFieldColor = Color.red;
                _shortName = "";
            }

            if (prevColor != _customFieldColor) Repaint();
        }

        private void DrawInstructions()
        {
            EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            {
                GUILayout.Space(10);    // horizontal space
                EditorGUILayout.LabelField("Try locating the type you are looking for in the reflected drop-down. If the desired type is not in the drop-down, try typing it into the custom type field. Note that you will need to include namespaces (ex. System.Boolean, instead of just Boolean).", Style.Instructions, GUILayout.ExpandHeight(true));
                GUILayout.Space(10);    // horizontal space
            }
            EditorGUILayout.EndHorizontal();
        }

        private bool DrawReflected()
        {
            bool reflected;
            EditorGUILayout.BeginVertical();
            {
                reflected = EditorGUILayout.BeginToggleGroup("Reflected", _useReflected);
                {
                    if (_reflectedTypes == null || _reflectedTypes.Count() == 0)
                    {
                        EditorGUILayout.LabelField("Unable to get reflected types, please try again after re-opening uScript.", Style.Instructions, GUILayout.ExpandHeight(true));
                        if (GUILayout.Button("Refresh"))
                        {
                            _reflectedTypes = GenerateNodes.GetAllLoadedTypes().OrderBy(t => t.Name).ToArray();
                            Repaint();
                        }
                    }
                    else
                    {
                        int oldIndex = _selectedIndex;
                        _selectedIndex = EditorGUILayout.Popup(_selectedIndex, _reflectedTypes.Select(t => t.Name.Replace("[]", " List")).ToArray());
                        if (oldIndex != _selectedIndex)
                        {
                            CheckType();
                        }
                    }
                }
                EditorGUILayout.EndToggleGroup();
                if (reflected) _customFieldColor = Color.white;
            }
            EditorGUILayout.EndVertical();

            return reflected;
        }

        private bool DrawCustom()
        {
            bool custom;
            EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));
            {
                custom = EditorGUILayout.BeginToggleGroup("Custom", !_useReflected);
                {
                    var customFieldFocused = UnityEngine.GUI.GetNameOfFocusedControl() == "customField";

                    var oldColor = UnityEngine.GUI.color;
                    UnityEngine.GUI.color = _customFieldColor;
                    UnityEngine.GUI.SetNextControlName("customField");
                    _customType = EditorGUILayout.TextField(_customType, Style.TextField);
                    if (UnityEngine.GUI.GetNameOfFocusedControl() == "customField")
                    {
                        if (!customFieldFocused)
                        {
//                                    this.filterTextCache = _customType;
                        }

                        if (Event.current.isKey)
                        {
                            switch (Event.current.keyCode)
                            {
                                case KeyCode.Escape:
                                    FocusedControl.Clear();
//                                            _customType = this.filterTextCache;
                                    Event.current.Use();
                                    break;

                                case KeyCode.Return:
                                case KeyCode.LeftArrow:
                                case KeyCode.RightArrow:
                                case KeyCode.UpArrow:
                                case KeyCode.DownArrow:
                                case KeyCode.End:
                                case KeyCode.Home:
                                case KeyCode.PageDown:
                                case KeyCode.PageUp:
                                    // Do nothing
                                    break;

                                default:
                                    CheckType();
                                    break;
                            }
                        }
                    }
                    UnityEngine.GUI.color = oldColor;
                }
                EditorGUILayout.EndToggleGroup();
            }
            EditorGUILayout.EndVertical();

            return custom;
        }

        private void DrawShortName()
        {
            EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            {
                GUILayout.Space(10);    // horizontal space
                EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));
                {
                    EditorGUILayout.LabelField(new GUIContent("Short Name"), Style.Heading);
                    string newShortName = EditorGUILayout.TextField(_shortName);
                    string safeNewShortName = UnityCSharpGenerator.MakeSyntaxSafe(newShortName);
                    if (safeNewShortName != newShortName)
                    {
                        Repaint();
                    }
                    _shortName = safeNewShortName;
                }
                EditorGUILayout.EndVertical();
                GUILayout.Space(10);    // horizontal space
            }
            EditorGUILayout.EndHorizontal();
        }

        private void DrawGeneratedNames()
        {
            EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            {
                GUILayout.Space(10);    // horizontal space
                EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));
                {
                    EditorGUILayout.LabelField(new GUIContent("Type Name:"), Style.Heading);
                    EditorGUILayout.LabelField(GenerateNodes.GetTypeName(GetCurrentType(), _shortName));
                    string[] classNames = GenerateNodes.GetClassNames(GetCurrentType(), _shortName);
                    int enumIndex = GenerateNodes.GetIndices(GenerateNodes.Nodes.SetEnumByString)[0];
                    if (classNames != null && classNames.Length > 0)
                    {
                        EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
                        {
                            EditorGUILayout.LabelField(new GUIContent("Nodes To Generate:"), Style.Heading);
                            if (GUILayout.Button("All")) { for (int i = 0; i < _nodesToGenerate.Length; i++) { _nodesToGenerate[i] = true; } }
                            if (GUILayout.Button("None")) { for (int i = 0; i < _nodesToGenerate.Length; i++) { _nodesToGenerate[i] = false; } }
                            if (GUILayout.Button("Invert")) { for (int i = 0; i < _nodesToGenerate.Length; i++) { _nodesToGenerate[i] = !_nodesToGenerate[i]; } }
                            if (GUILayout.Button("Set")) { int[] indices = GenerateNodes.GetIndices(GenerateNodes.Nodes.Set); for (int i = 0; i < indices.Length; i++) { _nodesToGenerate[indices[i]] = true; } }
                            if (GUILayout.Button("List")) { int[] indices = GenerateNodes.GetIndices(GenerateNodes.Nodes.List); for (int i = 0; i < indices.Length; i++) { _nodesToGenerate[indices[i]] = true; } }
                        }
                        EditorGUILayout.EndHorizontal();
                        for (int i = 0; i < classNames.Length; i++)
                        {
                            string content = classNames[i];
                            bool typeExists = false;
                            if (uScript.WeakInstance != null)
                            {
                                Type t = uScript.WeakInstance.GetType(classNames[i]);
                                typeExists = t != null;
                            }
                            if (typeExists)
                            {
                                // this type already exists - force its generation switch to off and disable the GUI
                                UnityEngine.GUI.enabled = false;
                                content += " (Type already exists)";
                                _nodesToGenerate[i] = false;
                            }
                            if (i == enumIndex)
                            {
                                if (!typeof(Enum).IsAssignableFrom(GetCurrentType()))
                                {
                                    // this type needs to be an enum but it's not - force its generation switch to off and disable the GUI
                                    UnityEngine.GUI.enabled = false;
                                    content += " (Type is not an enum type)";
                                    _nodesToGenerate[i] = false;
                                }
                            }
                            _nodesToGenerate[i] = EditorGUILayout.ToggleLeft(new GUIContent(content), _nodesToGenerate[i]);
                            UnityEngine.GUI.enabled = true;
                        }
                    }
                }
                EditorGUILayout.EndVertical();
                GUILayout.Space(10);    // horizontal space
            }
            EditorGUILayout.EndHorizontal();
        }

        private void DrawOrphanGUI()
        {
            EditorGUILayout.BeginVertical(GUILayout.ExpandWidth(true));
            {
                // draw empty panel
                uScriptGUIPanel.DrawOrphanGUI("Generate Nodes window");
            }
            EditorGUILayout.EndVertical();
        }

        private void DrawBottomButtons()
        {
            EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            {
                GUILayout.Space(10);    // horizontal space
                bool close = false;
                if (_nodesToGenerate.Where(b => b == true).Count() == 0 || GetCurrentType() == null || string.IsNullOrEmpty(_shortName)) UnityEngine.GUI.enabled = false;
                if (GUILayout.Button("Generate Node(s)"))
                {
                    // Generate selected nodes
                    GenerateNodes.Generate(GetCurrentType(), _shortName, GenerateNodes.GetNodesFromBoolArray(_nodesToGenerate));
                    close = true;
                }

                UnityEngine.GUI.enabled = true;
                if (GUILayout.Button("Cancel"))
                {
                    close = true;
                }

                if (close) this.Close();
                GUILayout.Space(10);    // horizontal space
            }
            EditorGUILayout.EndHorizontal();
        }

        private Type GetCurrentType()
        {
            return (_useReflected && _reflectedTypes != null && _reflectedTypes.Length > _selectedIndex) ? _reflectedTypes[_selectedIndex] : uScript.WeakInstance.GetType(_customType);
        }

        private static class Style
        {
            static Style()
            {
                Instructions = new GUIStyle(EditorStyles.label)
                {
                    margin = new RectOffset(4, 4, 4, 16),
                    padding = new RectOffset(3, 3, 1, 0),
                    wordWrap = true
                };

                TextField = new GUIStyle(UnityEngine.GUI.skin.textField)
                {
                    margin = new RectOffset(6, 6, 1, 3)
                };

                Heading = new GUIStyle(UnityEngine.GUI.skin.label)
                {
                    fontStyle = FontStyle.Bold
                };

                Checkbox = new GUIStyle(UnityEngine.GUI.skin.toggle)
                {
                    imagePosition = ImagePosition.ImageLeft,
                    alignment = TextAnchor.MiddleRight,
                    contentOffset = new Vector2(100.0f, 0.0f)
                };
            }

            public static GUIStyle Instructions { get; private set; }

            public static GUIStyle TextField { get; private set; }

            public static GUIStyle Heading { get; private set; }

            public static GUIStyle Checkbox { get; private set; }
        }
    }
}

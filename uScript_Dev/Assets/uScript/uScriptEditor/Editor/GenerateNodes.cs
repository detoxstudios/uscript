// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Detox Studios LLC" file="uScript.cs">
//   Copyright 2010-2018 Detox Studios LLC. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEditor;

namespace Detox.Editor
{
    public static class GenerateNodes
    {
        public enum Nodes
        {
            None = 0,
            Set = 1,
            AccessList = 2,
            ForEach = 4,
            ForEachAuto = 8,
            GetListSize = 16,
            IsInList = 32,
            ModifyList = 64,
            ReplaceValueAtIndex = 128,
            ReplaceValueInList = 256,
            SetEnumByString = 512,
            List = AccessList | ForEach | ForEachAuto | GetListSize | IsInList | ModifyList | ReplaceValueAtIndex | ReplaceValueInList,
            All = 0xffff
        }

        private static string GetClassName(string name, Nodes node)
        {
            switch (node)
            {
                case Nodes.Set:
                    return "uScriptAct_Set" + (string.IsNullOrEmpty(name) ? "" : name);
                case Nodes.AccessList:
                    return "uScriptAct_AccessList" + (string.IsNullOrEmpty(name) ? "" : name);
                case Nodes.ForEach:
                    return "uScriptAct_ForEachList" + (string.IsNullOrEmpty(name) ? "" : name);
                case Nodes.ForEachAuto:
                    return "uScriptAct_ForEachList" + (string.IsNullOrEmpty(name) ? "" : name) + "Auto";
                case Nodes.GetListSize:
                    return "uScriptAct_GetListSize" + (string.IsNullOrEmpty(name) ? "" : name);
                case Nodes.IsInList:
                    return "uScriptAct_IsInList" + (string.IsNullOrEmpty(name) ? "" : name);
                case Nodes.ModifyList:
                    return "uScriptAct_ModifyList" + (string.IsNullOrEmpty(name) ? "" : name);
                case Nodes.ReplaceValueAtIndex:
                    return "uScriptAct_ReplaceValueAtIndexInList" + (string.IsNullOrEmpty(name) ? "" : name);
                case Nodes.ReplaceValueInList:
                    return "uScriptAct_ReplaceValueInList" + (string.IsNullOrEmpty(name) ? "" : name);
                case Nodes.SetEnumByString:
                    return "uScriptAct_SetEnumByString" + (string.IsNullOrEmpty(name) ? "" : name);
                default:
                    Debug.Assert(false, "Invalid node type: " + node.ToString());
                    break;
            }

            return "INVALID_CLASS_NAME";
        }

        private static void GenerateNode(Type type, string name, Nodes nodeToGenerate)
        {
            // create requested node
            string templateName = GetClassName("", nodeToGenerate); // getting class name with empty string gives template filename (no extension)
            string className = GetClassName(name, nodeToGenerate);
            string nodeFileTemplate = uScriptConfig.ConstantPaths.Templates + "/" + templateName + ".cs.template";
            string nodeFile = Preferences.UserNodes + "/" + className + ".cs";
            if (File.Exists(nodeFileTemplate) && !File.Exists(nodeFile))
            {
                string fileContents = File.ReadAllText(nodeFileTemplate);
                fileContents = fileContents.Replace("{CLASS}", className).Replace("{TYPE}", GetTypeName(type, name)).Replace("{NAME}", GetName(type, name));
                File.WriteAllText(nodeFile, fileContents);
                AssetDatabase.Refresh();
            }
        }

        public static int[] GetIndices(Nodes nodes)
        {
            List<int> indices = new List<int>();
            int index = 1;
            for (int i = 1; i <= (int)Nodes.SetEnumByString; i = i << 1)
            {
                if ((nodes & (Nodes)i) == (Nodes)i) indices.Add(index-1);
                index++;
            }

            return indices.ToArray();
        }

        public static Nodes GetNodesFromBoolArray(bool[] nodes)
        {
            Nodes retval = Nodes.None;
            int expected = Enum.GetNames(typeof(Nodes)).Length - 2;
            Debug.Assert(nodes.Length == expected, string.Format("Wrong number of bools in nodes array.  Expected {0}, got {1}.", expected, nodes.Length));
            int index = 0;
            for (int i = 1; i <= (int)Nodes.SetEnumByString; i = i << 1)
            {
                if (nodes[index]) retval |= (Nodes)i;
                index++;
            }
            return retval;
        }

        public static string[] GetClassNames(Type type, string name, Nodes nodesToInclude = Nodes.All)
        {
            List<string> names = new List<string>();
            for (int i = 1; i <= (int)Nodes.SetEnumByString; i = i << 1)
            {
                if ((nodesToInclude & (Nodes)i) == (Nodes)i) names.Add(GetClassName(name, (Nodes)i));
            }
            return names.ToArray();
        }

        public static string GetTypeName(Type type, string name)
        {
            return type == null ? "" : type.FullName;
        }

        public static string GetName(Type type, string name)
        {
            return (string.IsNullOrEmpty(name) ? "" : name);
        }

        public static void Generate(Type type, string name, Nodes nodesToGenerate)
        {
            // loop through all the node types and generate the requested ones
            for (int i = 1; i <= (int)Nodes.SetEnumByString; i = i << 1)
            {
                if ((nodesToGenerate & (Nodes)i) == (Nodes)i) GenerateNode(type, name, (Nodes)i);
            }
        }

        public static Type[] GetAllLoadedTypes()
        {
            List<Type> allTypes = new List<Type>();

            if (uScript.WeakInstance != null && uScript.WeakInstance.ScriptEditorCtrl != null && uScript.WeakInstance.ScriptEditorCtrl.ScriptEditor != null)
            {
                foreach (string type in uScript.WeakInstance.ScriptEditorCtrl.ScriptEditor.Types)
                {
                    Type t = uScript.WeakInstance.GetType(type);
                    if (null != t)
                    {
                        //don't show uscript logic nodes as types
                        if (typeof(uScriptLogic).IsAssignableFrom(t) || typeof(uScriptEvent).IsAssignableFrom(t)) continue;

                        allTypes.Add(t);
                    }
                }
            }

            return allTypes.ToArray();
        }
    }
}

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PanelScriptList.cs" company="Detox Studios, LLC">
//   Copyright 2010-2014 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the StatusIcons type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using UnityEngine;
using UnityEditor;

namespace Detox.Editor.GUI
{
	[InitializeOnLoad]
	internal static class StatusIcons
	{
		static StatusIcons()
		{
			
			// Add delegate
			EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowListElementOnGUI;

			// Request repaint of hierarchy windows 
			EditorApplication.RepaintHierarchyWindow();
		}
		
		private static void HierarchyWindowListElementOnGUI(int instanceID, Rect selectionRect)
		{
			if (EditorApplication.isPlayingOrWillChangePlaymode) return;

			GameObject go = (GameObject)EditorUtility.InstanceIDToObject(instanceID);
			if ( go.GetComponent<uScriptEvent>() != null || go.GetComponent<uScriptCode>() != null || go.GetComponent<uScript_MasterComponent>() != null ) DrawIcon(selectionRect);
		}
		
		private static void RefreshGUI()
		{
			EditorApplication.RepaintHierarchyWindow();
		}
		
		
		private static Rect GetRightAligned(Rect rect, float size)
		{
			if (rect.height > 20)
			{
				// Unity 4.x large project icons
				rect.y = rect.y - 3;
				rect.x = rect.width + rect.x - 12;
				rect.width = size;
				rect.height = size;
			}
			else
			{
				// Normal icons
				float border = (rect.height - size);
				rect.x = rect.x + rect.width - (border / 2.0f);
				rect.x -= size;
				rect.width = size;
				rect.y = rect.y + border / 2.0f;
				rect.height = size;
			}
			return rect;
		}

		private static void DrawIcon(Rect rect)
		{
			string statusText = "uScript attached.";
			Texture2D texture = uScriptGUI.GetTexture("iconScriptFile02");
			Rect placement = GetRightAligned(rect, texture.width);
			var clickRect = placement;
			if (texture) UnityEngine.GUI.DrawTexture(placement, texture);
			if (UnityEngine.GUI.Button(clickRect, new GUIContent("", statusText), GUIStyle.none))
			{
				// context menu?
			}
		}
	}
}
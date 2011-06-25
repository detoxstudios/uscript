using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using Detox.ScriptEditor;
using Detox.FlowChart;

//using Detox.Data.Tools;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;




public sealed class uScriptGUIPanelPalette : uScriptGUIPanel
{
   //
   // Singleton pattern
   //
   static readonly uScriptGUIPanelPalette _instance = new uScriptGUIPanelPalette();
   public static uScriptGUIPanelPalette Instance { get { return _instance; } }
   private uScriptGUIPanelPalette() { Init(); }


   //
   // Members specific to this panel class
   //
   String _paletteFilterText = string.Empty;

   private List<PaletteMenuItem> _paletteMenuItems;
   bool _paletteFoldoutToggle = false;


   //
   // Methods common to the panel classes
   //
   public void Init()
   {
      _name = "Nodes Palette";
      _size = 250;
      _region = uScriptGUI.Region.Palette;

      BuildPaletteMenu(null, null);
   }

   public void Update()
   {
      //
      // Called whenever member data should be updated
      //
      BuildPaletteMenu(null, null);
   }

   public override void Draw()
   {
      //
      // Called during OnGUI()
      //

      // Local references to uScript
      uScript uScriptInstance = uScript.Instance;
//      ScriptEditorCtrl m_ScriptEditorCtrl = uScriptInstance.ScriptEditorCtrl;
      bool m_CanvasDragging = uScriptInstance.m_CanvasDragging;


      EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox, _options);
      {
         // Toolbar
         //
         EditorGUILayout.BeginHorizontal(EditorStyles.toolbar, GUILayout.ExpandWidth(true));
         {
            GUILayout.Label(_name, uScriptGUIStyle.panelTitle, GUILayout.ExpandWidth(true));
            GUILayout.FlexibleSpace();

            // Toggle hierarchy foldouts
            bool newToggleState = GUILayout.Toggle(_paletteFoldoutToggle,
                                                   (_paletteFoldoutToggle ? uScriptGUIContent.toolbarButtonCollapse : uScriptGUIContent.toolbarButtonExpand),
                                                   uScriptGUIStyle.paletteToolbarButton,
                                                   GUILayout.ExpandWidth(false));
            if (_paletteFoldoutToggle != newToggleState)
            {
               _paletteFoldoutToggle = newToggleState;
               if (_paletteFoldoutToggle)
               {
                  ExpandPaletteMenuItem(null);
               }
               else
               {
                  CollapsePaletteMenuItem(null);
               }
            }

            GUI.SetNextControlName ("FilterSearch" );
            string _filterText = uScriptGUI.ToolbarSearchField(_paletteFilterText, GUILayout.Width(100));
            GUI.SetNextControlName ("" );
            if (_filterText != _paletteFilterText)
            {
               // Drop focus if the user inserted a newline (hit enter)
               if (_filterText.Contains('\n'))
               {
                  GUIUtility.keyboardControl = 0;
               }

               // Trim leading whitespace
               _filterText = _filterText.TrimStart( new char[] { ' ' } );

               _paletteFilterText = _filterText;
               FilterPaletteMenuItems();
            }
         }
         EditorGUILayout.EndHorizontal();






         if (m_CanvasDragging && uScript.Preferences.DrawPanelsOnUpdate == false)
         {
            DrawHiddenNotification();
         }
         else
         {
            // Node list
            //
            _scrollviewOffset = EditorGUILayout.BeginScrollView( _scrollviewOffset, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview", GUILayout.ExpandWidth(true) );
            {
               foreach (PaletteMenuItem item in _paletteMenuItems)
               {
                  DrawPaletteMenu(item);
               }
            }
            EditorGUILayout.EndScrollView();
         }
      }
      EditorGUILayout.EndVertical();

      uScriptGUI.DefineRegion(uScriptGUI.Region.Palette);
//      uScriptInstance.SetMouseRegion( uScript.MouseRegion.Palette );
   }





   private class PaletteMenuItem : System.Windows.Forms.MenuItem
   {
      public String Name;
      public String Tooltip;
      public System.EventHandler Click;
      public List<PaletteMenuItem> Items;
      public bool Expanded;
      public bool Hidden;
      public int Indent;

      public void OnClick()
      {
         if (Click != null)
         {
            Click(this, new EventArgs());
         }
      }
   }

   private void ExpandPaletteMenuItem(PaletteMenuItem paletteMenuItem)
   {
      if (paletteMenuItem == null)
      {
         foreach (PaletteMenuItem item in _paletteMenuItems)
         {
            ExpandPaletteMenuItem(item);
         }
      }
      else if (paletteMenuItem.Items != null && paletteMenuItem.Items.Count > 0)
      {
         paletteMenuItem.Expanded = true;
         foreach (PaletteMenuItem item in paletteMenuItem.Items)
         {
            if (item == null)
            {
               uScriptDebug.Log(paletteMenuItem.Name + " has a null child!\n", uScriptDebug.Type.Error);
               return;
            }
            ExpandPaletteMenuItem(item);
         }
      }
   }

   private void CollapsePaletteMenuItem(PaletteMenuItem paletteMenuItem)
   {
      if (paletteMenuItem == null)
      {
         foreach (PaletteMenuItem item in _paletteMenuItems)
         {
            CollapsePaletteMenuItem(item);
         }
      }
      else if (paletteMenuItem.Items != null && paletteMenuItem.Items.Count > 0)
      {
         paletteMenuItem.Expanded = false;
         foreach (PaletteMenuItem item in paletteMenuItem.Items)
         {
            if (item == null)
            {
               uScriptDebug.Log(paletteMenuItem.Name + " has a null child!\n", uScriptDebug.Type.Error);
               return;
            }
            CollapsePaletteMenuItem(item);
         }
      }
   }


   private void FilterPaletteMenuItems()
   {
      foreach (PaletteMenuItem item in _paletteMenuItems)
      {
         item.Hidden = FilterPaletteMenuItem(item, false);
      }
   }

   private bool FilterPaletteMenuItem(PaletteMenuItem paletteMenuItem, bool shouldForceVisible)
   {
      // return TRUE if the parent or item should be hidden
      if (shouldForceVisible || paletteMenuItem.Name.ToLower().Contains(_paletteFilterText.ToLower()))
      {
         // filter matched, so this and all children should be visible
         if (paletteMenuItem.Items != null)
         {
            foreach (PaletteMenuItem item in paletteMenuItem.Items)
            {
                item.Hidden = FilterPaletteMenuItem(item, true);
            }
         }
         return false;
      }
      else if (paletteMenuItem.Items != null)
      {
         // check each child to see if this should be visible
         bool shouldHideParent = true;
         foreach (PaletteMenuItem item in paletteMenuItem.Items)
         {
            item.Hidden = FilterPaletteMenuItem(item, false);
            if (item.Hidden == false)
            {
               shouldHideParent = false;
            }
         }

         return shouldHideParent;
      }

      // has no children and wasn't a match
      return true;
   }


   private void BuildPaletteMenu(ToolStripItem contextMenuItem, PaletteMenuItem paletteMenuItem)
   {
      // Local references to uScript
      uScript uScriptInstance = uScript.Instance;
      ScriptEditorCtrl m_ScriptEditorCtrl = uScriptInstance.ScriptEditorCtrl;

      if (contextMenuItem == null || paletteMenuItem == null)
      {
         //
         // Create a new palette menu, destroying the old one
         //
         _paletteMenuItems = new List<PaletteMenuItem>();

         foreach (ToolStripItem item in m_ScriptEditorCtrl.ContextMenu.Items.Items)
         {
            if ((item is ToolStripMenuItem) && (item.Text == "Add..."))
            {
               foreach (ToolStripItem subitem in ((ToolStripMenuItem)item).DropDownItems.Items)
               {
                  PaletteMenuItem paletteItem = new PaletteMenuItem();
                  paletteItem.Indent = 0;

                  BuildPaletteMenu(subitem, paletteItem);

                  _paletteMenuItems.Add(paletteItem);
               }
            }
         }
      }
      else if (!(contextMenuItem is ToolStripSeparator))
      {
         if ((contextMenuItem is ToolStripMenuItem) && ((ToolStripMenuItem)contextMenuItem).DropDownItems.Items.Count > 0)
         {
            paletteMenuItem.Name = contextMenuItem.Text.Replace("...", "");
            paletteMenuItem.Items = new List<PaletteMenuItem>();

            foreach (ToolStripItem item in ((ToolStripMenuItem)contextMenuItem).DropDownItems.Items)
            {
               PaletteMenuItem newItem = new PaletteMenuItem();
               newItem.Indent = paletteMenuItem.Indent + 1;
               if (item == null || newItem == null)
               {
                  uScriptDebug.Log("Trying to pass a null parameter to BuildPaletteMenu()!\n", uScriptDebug.Type.Error);
                  return;
               }
               BuildPaletteMenu(item, newItem);
               paletteMenuItem.Items.Add(newItem);
            }
         }
         else
         {
            paletteMenuItem.Name = contextMenuItem.Text.Replace("&", "");
            paletteMenuItem.Tooltip = uScript.FindNodeToolTip( ScriptEditor.FindNodeType(contextMenuItem.Tag as EntityNode) );
            paletteMenuItem.Click = contextMenuItem.Click;
            paletteMenuItem.Tag   = contextMenuItem.Tag;
         }
      }
      else
      {
         uScriptDebug.Log("The contextMenuItem (" + contextMenuItem.Text + ") is a " + contextMenuItem.GetType() + " and is unhandled!\n", uScriptDebug.Type.Warning);
      }
   }

   private void DrawPaletteMenu(PaletteMenuItem item)
   {
      // Local references to uScript
      uScript uScriptInstance = uScript.Instance;
      ScriptEditorCtrl m_ScriptEditorCtrl = uScriptInstance.ScriptEditorCtrl;

      if (item.Hidden)
      {
         return;
      }

      if (item.Items != null)
      {
         // This is should be a folding menu item that contains more buttons
         GUIStyle tmpStyle = new GUIStyle(uScriptGUIStyle.paletteFoldout);
         tmpStyle.margin = new RectOffset(tmpStyle.margin.left + (item.Indent * 12), 0, 0, 0);

         item.Expanded = GUILayout.Toggle(item.Expanded, item.Name, tmpStyle);
         if (item.Expanded)
         {
            foreach (PaletteMenuItem subitem in item.Items)
            {
               DrawPaletteMenu(subitem);
            }
         }
      }
      else
      {
         // This is a simple menu item
         GUIStyle tmpStyle = new GUIStyle(uScriptGUIStyle.paletteButton);
         tmpStyle.margin = new RectOffset(tmpStyle.margin.left + 0 + (item.Indent * 12),
                                       tmpStyle.margin.right,
                                       tmpStyle.margin.top,
                                       tmpStyle.margin.bottom);

         if (GUILayout.Button(new GUIContent(item.Name, item.Tooltip), tmpStyle))
         {
            if (item.Click != null)
            {
               // Create the node on the canvas
               int halfWidth = (int)(uScript.Instance.NodeWindowRect.width / 2.0f);
               int halfHeight = (int)(uScript.Instance.NodeWindowRect.height / 2.0f);
               Point center = new Point(halfWidth, halfHeight);
               m_ScriptEditorCtrl.ContextCursor = center;
               item.OnClick();
               uScriptDebug.Log("Clicked '" + item.Name + "'\n", uScriptDebug.Type.Debug);
            }
            else
            {
               uScriptDebug.Log("Cannot execute menu item: " + item.Name + "\n", uScriptDebug.Type.Debug);
            }
         }
      }
   }

}

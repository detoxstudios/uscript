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
//using System.Linq;
using System.Drawing;




public sealed class uScriptGUIPanelCanvas : uScriptGUIPanel
{
   //
   // Singleton pattern
   //
   static readonly uScriptGUIPanelCanvas _instance = new uScriptGUIPanelCanvas();
   public static uScriptGUIPanelCanvas Instance { get { return _instance; } }
   private uScriptGUIPanelCanvas() { Init(); }


   //
   // Members specific to this panel class
   //
   Rect mapSize = new Rect();
   Rect mapBounds = new Rect();
   Point mapMouse = new Point();

   public static bool mapToggle = false;
   float mapScale = 0.5f;
   Vector2 mapScroll = Vector2.zero;

   public static bool _requestedCloseMap = false;
   public static Point _requestCanvasLocation = Point.Empty;



   // Local references to uScript
   uScript uScriptInstance;
   ScriptEditorCtrl m_ScriptEditorCtrl;
//   bool m_CanvasDragging;






   //
   // Methods common to the panel classes
   //
   public void Init()
   {
      //
      // Called when the class is first instantiated
      //

      // Local references to uScript
      uScriptInstance = uScript.Instance;
      m_ScriptEditorCtrl = uScriptInstance.ScriptEditorCtrl;
//      m_CanvasDragging = uScriptInstance.m_CanvasDragging;
   }

   public void Update()
   {
      //
      // Called whenever member data should be updated
      //
   }

   public override void Draw()
   {
      //
      // Called during OnGUI()
      //

      uScriptInstance = uScript.Instance;
      m_ScriptEditorCtrl = uScriptInstance.ScriptEditorCtrl;
//      m_CanvasDragging = uScriptInstance.m_CanvasDragging;

      Rect rect = EditorGUILayout.BeginVertical(uScriptGUIStyle.panelBox);
      {
         // Toolbar
         //
         Rect toolbarRect = EditorGUILayout.BeginHorizontal(EditorStyles.toolbar, GUILayout.ExpandWidth(true));
         {
            GUILayout.Label("Canvas", uScriptGUIStyle.panelTitle, GUILayout.ExpandWidth(true));
//            GUILayout.FlexibleSpace();



            if ( GUILayout.Button( uScriptGUIContent.toolbarButtonNew, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               if (uScriptInstance.AllowNewFile(true))
               {
                  uScriptInstance.NewScript();
               }
            }

            if ( GUILayout.Button( uScriptGUIContent.toolbarButtonOpen, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               string path = EditorUtility.OpenFilePanel( "Open uScript", uScript.Preferences.UserScripts, "uscript" );
               if ( path.Length > 0 )
               {
                  uScriptInstance.OpenScript( path );
               }
            }

//            _openScriptToggle = GUILayout.Toggle(_openScriptToggle, "Open Active uScripts...", EditorStyles.toolbarButton, GUILayout.ExpandWidth(false));

            if ( GUILayout.Button( uScriptGUIContent.toolbarButtonSave, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               AssetDatabase.StartAssetEditing( );
                  bool saved = uScriptInstance.SaveScript( false );
               AssetDatabase.StopAssetEditing( );

               if (saved) uScriptInstance.RefreshScript( );
            }
            if ( GUILayout.Button( uScriptGUIContent.toolbarButtonSaveAs, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               AssetDatabase.StartAssetEditing( );
                  bool saved = uScriptInstance.SaveScript( true );
               AssetDatabase.StopAssetEditing( );

               if (saved) uScriptInstance.RefreshScript( );
            }
            if ( GUILayout.Button( uScriptGUIContent.toolbarButtonRebuildAll, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               uScriptInstance.RebuildAllScripts( );
            }
            if ( GUILayout.Button( uScriptGUIContent.toolbarButtonRemoveGenerated, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               AssetDatabase.StartAssetEditing( );
               uScriptInstance.RemoveGeneratedCode( uScript.Preferences.GeneratedScripts );
               AssetDatabase.StopAssetEditing( );
               AssetDatabase.Refresh();
            }
            if ( GUILayout.Button( uScriptGUIContent.toolbarButtonPreferences, EditorStyles.toolbarButton, GUILayout.ExpandWidth(false) ) )
            {
               uScriptInstance.m_DoPreferences = true;
            }

            GUILayout.Space(20);

            mapToggle = GUILayout.Toggle(mapToggle, "Map", EditorStyles.toolbarButton);

            if (mapToggle)
            {
               mapScale = GUILayout.HorizontalSlider(mapScale, 0.1f, 0.7f, GUILayout.Width(100));
            }

            GUILayout.FlexibleSpace();

            GUIStyle style2 = new GUIStyle(EditorStyles.boldLabel);
            style2.padding = new RectOffset(16, 4, 2, 2);
            style2.margin = new RectOffset();
            if (m_ScriptEditorCtrl != null && !string.IsNullOrEmpty(m_ScriptEditorCtrl.ScriptName))
            {
               int dot = m_ScriptEditorCtrl.ScriptName.IndexOf(".");
               string filename = m_ScriptEditorCtrl.ScriptName;
               if (dot != -1)
               {
                  filename = m_ScriptEditorCtrl.ScriptName.Substring(0, m_ScriptEditorCtrl.ScriptName.IndexOf("."));
               }

               GUILayout.Label(filename, style2);
            }
         }
         EditorGUILayout.EndHorizontal();

         if (toolbarRect.width != 0 && toolbarRect.height != 0)
         {
            uScriptInstance.m_NodeToolbarRect = toolbarRect;
         }




//
//         else
//         {
//            // Node list
//            //
//            _scrollviewOffset = EditorGUILayout.BeginScrollView(_scrollviewOffset, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, "scrollview", GUILayout.ExpandWidth(true));
//            {
//
//
//




         GUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
         {
            if (mapToggle)
            {
               MiniMapDraw();
            }
            else
            {
               // Canvas
               //
               if ( rect.width != 0 && rect.height != 0 )
               {
                  uScriptInstance.m_NodeWindowRect = rect;
               }

               GUIStyle style = new GUIStyle();
               style.normal.background = uScriptConfig.canvasBackgroundTexture;

               GUI.SetNextControlName ("MainView" );

               _scrollviewOffset = EditorGUILayout.BeginScrollView(_scrollviewOffset, false, false, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar, style, GUILayout.ExpandWidth(true));
               {
                  // Get the bounding area of all nodes on the canvas, plus 64px to
                  // allow for 32px padding around the edges.  This will allow the
                  // scrollbars to span the bounds accurately.
                  //
                  // For each dimension, use the larger of the bounding area and the
                  // canvas mouseRegionRect.
                  //
                  // When zoom is implemented, make sure the results are accurately scaled
                  //
      //            int canvasWidth = (_mouseRegionRect.ContainsKey(MouseRegion.Canvas) ? (int)(_mouseRegionRect[MouseRegion.Canvas].width) : 0);
      //            int canvasHeight = (_mouseRegionRect.ContainsKey(MouseRegion.Canvas) ? (int)(_mouseRegionRect[MouseRegion.Canvas].height-18) : 0);
      //
      //            GUILayout.Box(string.Empty, style, GUILayout.Width(canvasWidth), GUILayout.Height(canvasHeight));
   
                  // Paint the graph (nodes, sockets, links, and comments)
                  PaintEventArgs args = new PaintEventArgs();
                  args.Graphics = new System.Drawing.Graphics();
                  m_ScriptEditorCtrl.GuiPaint(args);
               }
               EditorGUILayout.EndScrollView();
   
               GUI.SetNextControlName ("");

            }
         }
         GUILayout.EndVertical();

         if (Event.current.type == EventType.Repaint)
         {
            uScriptInstance._canvasRect = GUILayoutUtility.GetLastRect();
         }
      }
      EditorGUILayout.EndVertical();

      uScriptGUI.DefineRegion(uScriptGUI.Region.Canvas);
//      uScriptInstance.SetMouseRegion( uScript.MouseRegion.Canvas );//, 3, 1, -2, -4 );
   }


   void MiniMapDraw()
   {
      Node node;
      DisplayNode displayNode;
      
      
      
      //
      // Get the dimensions of the entire map at the specified scale
      //
      mapBounds = new Rect();
      
      // Start with the first ...
      if (m_ScriptEditorCtrl.FlowChart.Nodes.Length > 0)
      {
         node = m_ScriptEditorCtrl.FlowChart.Nodes[0];
         mapBounds = new Rect(node.Bounds.X, node.Bounds.Y, node.Bounds.Width, node.Bounds.Height);
      }
      
      // ... then loop through the remaining nodes ...
      for (int i=1; i < m_ScriptEditorCtrl.FlowChart.Nodes.Length; i++)
      {
         mapBounds.x = Math.Min(mapBounds.x, m_ScriptEditorCtrl.FlowChart.Nodes[i].Bounds.X);
         mapBounds.y = Math.Min(mapBounds.y, m_ScriptEditorCtrl.FlowChart.Nodes[i].Bounds.Y);
         mapBounds.width = Math.Max(mapBounds.width, m_ScriptEditorCtrl.FlowChart.Nodes[i].Bounds.X
                                               + m_ScriptEditorCtrl.FlowChart.Nodes[i].Bounds.Width);
         mapBounds.height = Math.Max(mapBounds.height, m_ScriptEditorCtrl.FlowChart.Nodes[i].Bounds.Y
                                                 + m_ScriptEditorCtrl.FlowChart.Nodes[i].Bounds.Height);
      }
      
      // ... and finally, apply the scaling
      mapBounds.x *= mapScale;
      mapBounds.y *= mapScale;
      mapBounds.width *= mapScale;
      mapBounds.height *= mapScale;
      
      
      //
      // Set the size of the viewRect
      //
      Rect viewRect = new Rect();
      viewRect.width = (mapBounds.width - mapBounds.x);
      viewRect.height = (mapBounds.height - mapBounds.y);

      
      Rect mapRect = new Rect();

      if (uScriptGUI.Regions.ContainsKey(uScriptGUI.Region.HandleContainerCenter))
//      if (uScriptInstance._mouseRegionRect.ContainsKey(uScript.MouseRegion.HandleCanvas))
      {
         mapRect.x = uScriptGUI.ContainerLeftWidth + 3;
         mapRect.y = 17;
         mapRect.width = uScriptInstance.position.width - (uScriptGUI.ContainerLeftWidth + 3);
         mapRect.height = uScriptInstance.position.height - 18 - 2 - 17 - uScriptGUI.ContainerCenterHeight - 8;
      }

//      Debug.Log("_canvasRect: " + _canvasRect + "\t\tposition: " + position + "\n"
//                + "PaletteWidth: " + uScriptGUI.PanelContainerLeft + ", PropertiesHeight: " + uScriptGUI.ContainerCenterHeight + ", StatusbarRect: " + _statusbarRect + ", mapRect: " + mapRect);

      GUI.skin.scrollView.normal.background = uScriptConfig.canvasBackgroundTexture;
      mapScroll = GUI.BeginScrollView(mapRect, mapScroll, viewRect, uScriptGUIStyle.hScrollbar, uScriptGUIStyle.vScrollbar);


      // Get the local mouse coordinates
      mapMouse = new Point((int)Event.current.mousePosition.x, (int)Event.current.mousePosition.y);


      // Temporary box that represents the bounding area
      mapSize = new Rect(0, 0, Math.Abs(mapBounds.width - mapBounds.x), Math.Abs(mapBounds.height - mapBounds.y));
      mapSize.x = (mapSize.width < mapRect.width ? (mapRect.width - mapSize.width) * 0.5f : 0);
      mapSize.y = (mapSize.height < mapRect.height ? (mapRect.height - mapSize.height) * 0.5f : 0);
      GUIStyle tmpStyle = new GUIStyle(GUI.skin.box);
      tmpStyle.margin = new RectOffset();
//      GUI.Box(mapSize, string.Empty, tmpStyle);

//      Debug.Log("CanvasRect: " + mapRect + ", \tMapBounds: " + mapBounds + ",\tScale: " + mapScale + "\nViewRect: " + viewRect + ", \t\t\t\tViewOffset: " + viewOffset
//                + "\t\tmapSize: " + mapSize);


      // Draw the canvas viewport rect
      Rect viewportRect = new Rect(-m_ScriptEditorCtrl.FlowChart.Location.X * mapScale + mapSize.x - mapBounds.x,
                                   -m_ScriptEditorCtrl.FlowChart.Location.Y * mapScale + mapSize.y - mapBounds.y,
                                   mapRect.width * mapScale,
                                   mapRect.height * mapScale);

      // Change the GUI color to tint the viewportRect
      UnityEngine.Color normalColor = GUI.color;
      GUI.color = UnityEngine.Color.green;
      tmpStyle.normal.background = uScriptConfig.minimapScreenBorder;
      GUI.Box(viewportRect, string.Empty, tmpStyle);
      GUI.color = normalColor;

      //
      // Paint the nodes
      //
      foreach (Node n in m_ScriptEditorCtrl.FlowChart.Nodes)
      {
         displayNode = n as DisplayNode;

         Rect nodeRect = new Rect(n.Bounds.X * mapScale + mapSize.x - mapBounds.x,
                                  n.Bounds.Y * mapScale + mapSize.y - mapBounds.y,
                                  n.Bounds.Width * mapScale,
                                  n.Bounds.Height * mapScale );

//         Debug.Log("\tNode -- Location: " + n.Location + ", \tRect: " + nodeRect + ", \t\t" + n.Name + "\n");




         // Style the node by type
         GUIStyle tmpNodeStyle = new GUIStyle(GUI.skin.box);
         UnityEngine.Color nodeTextGrey = new UnityEngine.Color(0.737f, 0.737f, 0.737f);
         if (displayNode is EntityEventDisplayNode)
         {
            tmpNodeStyle.normal.background = uScriptConfig.nodeEventTexture;
            tmpNodeStyle.normal.textColor = nodeTextGrey;
            GUI.Box(nodeRect, n.Name, tmpNodeStyle);
         }
         else if (displayNode is LogicNodeDisplayNode)
         {
            tmpNodeStyle.normal.background = uScriptConfig.nodeDefaultTexture;
            tmpNodeStyle.normal.textColor = nodeTextGrey;
            GUI.Box(nodeRect, n.Name, tmpNodeStyle);
         }
         else if (displayNode is LocalNodeDisplayNode)
         {
            tmpNodeStyle.normal.background = uScriptConfig.nodeVariableTexture;
            tmpNodeStyle.normal.textColor = nodeTextGrey;
            GUI.Box(nodeRect, n.Name, tmpNodeStyle);
         }
         else if (displayNode is CommentDisplayNode)
         {
            //tmpNodeStyle.normal.background = uScriptConfig.nodeDefaultTexture;
            GUI.color = UnityEngine.Color.cyan;
            GUI.Box(nodeRect, n.Name, tmpNodeStyle);
            GUI.color = normalColor;
         }
         else
         {
            tmpNodeStyle.normal.background = uScriptConfig.nodeDefaultTexture;
            GUI.Box(nodeRect, n.Name, tmpNodeStyle);
         }
      }
   

      foreach (Link l in m_ScriptEditorCtrl.FlowChart.Links)
      {
         Handles.color = UnityEngine.Color.black;

         Vector3 start = new Vector3(mapSize.x - mapBounds.x + (l.Source.Node.Location.X + l.Source.Node.Size.Width) * mapScale,
                                     mapSize.y - mapBounds.y + (l.Source.Node.Location.Y + l.Source.Anchor.Y) * mapScale,
                                     0);
         Vector3 end = new Vector3(mapSize.x - mapBounds.x + (l.Destination.Node.Location.X) * mapScale,
                                   mapSize.y - mapBounds.y + (l.Destination.Node.Location.Y + l.Destination.Anchor.Y) * mapScale,
                                   0);

         Handles.DrawLine(start, end);
      }

      GUI.EndScrollView();
      GUI.skin.scrollView.normal.background = null;
   }

   public void MiniMapClick()
   {
      if ( uScriptInstance._canvasRect.Contains( Event.current.mousePosition ) )
      {
         _requestedCloseMap = true;

         // Enter the correct canvas position here using the current mapScale, scrollbar positions, etc.
         _requestCanvasLocation = new Point( (int)((mapMouse.X - (mapSize.x - mapBounds.x)) / mapScale),
                                             (int)((mapMouse.Y - (mapSize.y - mapBounds.y)) / mapScale)
                                           );

                     //  + mapSize.x - mapBounds.x
//         Debug.Log( "RESULT: " + _requestCanvasLocation
//                    + "\n\t ViewportCenter: " + screenBoundsCenter
//                       + "\t\t\tMousePosition: " + mapMouse
//                       + "\t\t\tDiff: " + screenClickOffsetX
//                       + " (" + screenClickOffsetX / mapScale + ")"
//
//                    + "\n\t\tMapScale: " + mapScale + ", \t\tmapScroll: " + mapScroll
//                    + "\nMapBounds: " + mapBounds + ", \t\tMapSize: " + mapSize + "\n");
      }
   }

}

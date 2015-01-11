// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExportPNG.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the ExportPNG type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor
{
   using System;
   using System.Collections.Generic;
   using System.IO;
   using System.Linq;
   using System.Reflection;

   using Detox.Drawing;

   using UnityEngine;

   public static class ExportPNG
   {
      // === Constants ==================================================================

      private const int BoundsPadding = 20;

      // === Fields =====================================================================

      private static ExportPhase phase;

      private static Point originalCanvasLocation;

      private static float originalMapScale;

      private static bool originalPanelState;

      private static Rect targetBounds;

      //static List<string> debugOutput;
      //static GUIStyle debugBoxStyle;

      private static uScript uScriptInstance;

      private static int segmentColumn;

      private static int segmentColumnOverflow;

      private static int segmentColumns;

      private static int segmentRow;

      private static int segmentRowOverflow;

      private static int segmentRows;

      private static int segmentX;

      private static int segmentY;

      private static int segmentWidth;

      private static int segmentHeight;

      private static List<Guid> selectedLinks;

      private static List<Guid> selectedNodes;

      private static FlowChart.Node[] targetNodes;

      private static Texture2D texture;

      private static int viewportX;

      private static int viewportY;

      private static int viewportWidth;

      private static int viewportHeight;

      private static RectOffset viewportBorderSize;

      private static Point textureDimensions;

      private enum ExportPhase
      {
         Idle,

         Initiate,

         OverrideEditorState,

         GenerateSeqmentList,

         NextSegment,

         CaptureSegmentImage,

         ExportCompleteImage,

         RestoreEditorState,

         Finished
      }

      // === Properties =================================================================

      public static bool IsExporting { get; private set; }

      // === Methods ====================================================================

      public static void BeginExport()
      {
         if (CanExport())
         {
            phase = ExportPhase.Initiate;
            IsExporting = true;
            uScript.RequestRepaint();
         }
      }

      // This method must be called from within OnGUI
      public static void ContinueExport()
      {
         uScriptGUI.CheckOnGUI();

         if (Event.current.type != EventType.Repaint)
         {
            return;
         }

         //if (phase != ExportPhase.Idle)
         //{
         //   Debug.Log("PNG Export - " + phase.ToString() + "\n");
         //}

         // Handle the current phase
         switch (phase)
         {
            case ExportPhase.Idle:
               return;

            case ExportPhase.Initiate:
               originalCanvasLocation = uScriptInstance.ScriptEditorCtrl.FlowChart.Location;
               originalMapScale = uScriptInstance.MapScale;
               originalPanelState = uScriptGUI.PanelsHidden;
               //Debug.Log("Exporting the graph to PNG ... This could take a while.\n");

               phase = ExportPhase.OverrideEditorState;
               break;

            case ExportPhase.OverrideEditorState:
               if (originalPanelState == false)
               {
                  uScriptGUI.PanelsHidden = true;
                  uScriptInstance.ScriptEditorCtrl.FlowChart.Location.X += uScriptGUI.PanelLeftWidth
                                                                           + uScriptGUI.PanelDividerThickness;
                  uScriptInstance.ScriptEditorCtrl.RebuildScript(null, false);
               }
               uScriptInstance.MapScale = 1;
               phase = ExportPhase.GenerateSeqmentList;
               break;

            case ExportPhase.RestoreEditorState:
               RestoreSelectedLinks();
               RestoreSelectedNodes();

               if (originalPanelState == false)
               {
                  uScriptGUI.PanelsHidden = false;
                  uScriptInstance.ScriptEditorCtrl.FlowChart.Location.X -= uScriptGUI.PanelLeftWidth
                                                                           + uScriptGUI.PanelDividerThickness;
                  uScriptInstance.ScriptEditorCtrl.RebuildScript(null, false);
               }
               uScriptInstance.MapScale = originalMapScale;
               uScriptInstance.ScriptEditorCtrl.FlowChart.Location = originalCanvasLocation;
               phase = ExportPhase.Finished;
               break;

            case ExportPhase.GenerateSeqmentList:
               {
                  StoreSelectedLinks();
                  StoreSelectedNodes();

                  // Get the viewport dimensions
                  viewportX = (int)uScriptInstance._canvasRect.x;
                  viewportY = (int)uScriptInstance._canvasRect.y;

                  // Create a texture the size of the screen, RGB24 format
                  viewportWidth = (int)uScriptInstance._canvasRect.width - 1;
                  viewportHeight = (int)uScriptInstance._canvasRect.height;

                  // Get the viewport border size from Unity via reflection
                  const BindingFlags Flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
                  var fi = uScript.Instance.GetType().GetField("m_Parent", Flags);
                  if (fi != null)
                  {
                     var parent = fi.GetValue(uScript.Instance);
                     if (parent != null)
                     {
                        var pi = parent.GetType().GetProperty("borderSize", Flags);
                        viewportBorderSize = pi.GetValue(parent, null) as RectOffset;
                     }
                  }

                  // Adjust positions and sizes
                  uScriptDebug.Assert(viewportBorderSize != null, "viewportBorderSize is null");
                  viewportY = Screen.height - viewportHeight - viewportY - viewportBorderSize.top;

                  // Tweaks to handle various dock scenarios - this is stupid
                  viewportX = viewportBorderSize.left;
                  if (viewportBorderSize.bottom == 2)
                  {
                     viewportY -= 2; // 23
                  }

                  if (viewportBorderSize.bottom == 4)
                  {
                     viewportY -= 2; // 25
                  }

                  if (viewportBorderSize.bottom == 5)
                  {
                     viewportY -= 5; // 23
                  }
                  else if (viewportBorderSize.bottom == 7)
                  {
                     viewportY -= 5; // 25
                  }

                  // Determine the segment details
                  segmentColumn = segmentRow = 0;

                  segmentColumnOverflow = (int)targetBounds.width % viewportWidth;
                  segmentRowOverflow = (int)targetBounds.height % viewportHeight;

                  segmentColumns = ((int)targetBounds.width / viewportWidth) + (segmentColumnOverflow > 0 ? 1 : 0);
                  segmentRows = ((int)targetBounds.height / viewportHeight) + (segmentRowOverflow > 0 ? 1 : 0);

                  textureDimensions = new Point((int)targetBounds.width, (int)targetBounds.height);

                  // Create the texture
                  texture = new Texture2D((int)targetBounds.width, (int)targetBounds.height, TextureFormat.RGB24, false);

                  //// Display debug information for the graph
                  //debugOutput.Add("\tCanvas Size:\t\t\t" + viewportWidth.ToString() + ", " + viewportHeight);
                  //debugOutput.Add("\tCanvas Locatiion\t\t" + (-originalCanvasLocation.X) + ", " + (-originalCanvasLocation.Y));

                  //debugOutput.Add(string.Empty);
                  //debugOutput.Add("Graph:");
                  //debugOutput.Add("\tTotal Segments:\t" + segmentColumns + ", " + segmentRows);
                  //debugOutput.Add("\tTotal Size:\t\t\t" + graphBounds.width + ", " + graphBounds.height);
                  //debugOutput.Add("\tOverflow Size:\t\t" + segmentColumnOverflow + ", " + segmentRowOverflow);


                  //var msg = segmentColumns * segmentRows > 1
                  //             ? string.Format(
                  //                "\tStitching together {0} canvas snapshots ...",
                  //                segmentColumns * segmentRows)
                  //             : string.Empty;
                  //if (string.IsNullOrEmpty(msg) == false)
                  //{
                  //   Debug.Log(
                  //      string.Format(
                  //         "\tThe resulting image will be {0}x{1} pixels in size.\n{2}",
                  //         textureDimensions.X,
                  //         textureDimensions.Y,
                  //         msg));
                  //}

                  phase = ExportPhase.NextSegment;
               }
               break;

            case ExportPhase.NextSegment:
               segmentWidth = viewportWidth;
               segmentHeight = viewportHeight;
               if (segmentColumn == segmentColumns - 1)
               {
                  // final column
                  segmentWidth = segmentColumnOverflow;
               }
               else if (segmentColumn == segmentColumns)
               {
                  // next row
                  segmentColumn = 0;
                  segmentRow++;
               }
               if (segmentRow >= segmentRows)
               {
                  // no more segments
                  phase = ExportPhase.ExportCompleteImage;

                  uScriptInstance.ShowNotification(new GUIContent("Saving PNG ...\nThis could take a while."));
               }
               else
               {
                  if (segmentRow == segmentRows - 1)
                  {
                     // final row
                     segmentHeight = segmentRowOverflow;
                  }

                  segmentX = segmentColumn * viewportWidth;
                  segmentY = segmentRow * viewportHeight;

                  // Update the canvas position to point to the segment
                  uScriptInstance.ScriptEditorCtrl.FlowChart.Location.X = -(int)targetBounds.x - segmentX;
                  uScriptInstance.ScriptEditorCtrl.FlowChart.Location.Y = -(int)targetBounds.y - segmentY;

                  segmentY = (int)targetBounds.height - segmentHeight - segmentY;

                  phase = ExportPhase.CaptureSegmentImage;
               }
               break;

            case ExportPhase.CaptureSegmentImage:
               texture.ReadPixels(
                  new Rect(
                     viewportX,
                     viewportY + (viewportHeight - segmentHeight),
                     segmentWidth,
                     //segmentWidth + 1,
                     segmentHeight),
                  segmentX,
                  segmentY);
               segmentColumn++;
               phase = ExportPhase.NextSegment;
               break;

            case ExportPhase.ExportCompleteImage:
               {
                  // Apply the texture changes
                  texture.Apply(false);

                  var path = GeneratePath();
                  texture.SaveAs(path);

                  UnityEngine.Object.DestroyImmediate(texture);

                  var relativePath = uScriptConfig.ConstantPaths.Screenshots;
                  var index1 = relativePath.LastIndexOf('/');
                  var index2 = index1 > 0 ? relativePath.LastIndexOf('/', index1 - 1) : -1;
                  relativePath = string.Format(".{0}/", relativePath.Substring(index2));

                  uScriptDebug.Log(
                     string.Format(
                        "Exported \"{0}{1}\"        ({2}x{3})\n",
                        relativePath,
                        Path.GetFileName(path).Bold(),
                        textureDimensions.X,
                        textureDimensions.Y),
                     uScriptDebug.Type.Message);

                  // Restore the editor to it's previous state
                  phase = ExportPhase.RestoreEditorState;
               }
               break;

            case ExportPhase.Finished:
               uScriptInstance.RemoveNotification();
               IsExporting = false;
               phase = ExportPhase.Idle;
               break;
         }

         uScript.RequestRepaint();
      }

      private static bool CanExport()
      {
         return IsCanvasReady() && IsTargetFound() && IsTargetBoundsValid();
      }

      private static bool IsCanvasReady()
      {
         uScriptInstance = uScript.Instance;
         if (uScriptInstance == null || uScriptInstance.ScriptEditorCtrl == null)
         {
            uScriptDebug.Log("Unable to access the uScript editor control!", uScriptDebug.Type.Error);
            return false;
         }
         return true;
      }

      private static bool IsTargetBoundsValid()
      {
         targetBounds = GetGraphBounds();
         if (targetBounds.width > 8192 || targetBounds.height > 8192)
         {
            uScriptDebug.Log(
               string.Format(
                  "The graph is too large to export. No dimension should be more than 8192 pixels, but the graph is at least {0}x{1}",
                  targetBounds.width,
                  targetBounds.height),
               uScriptDebug.Type.Warning);
            return false;
         }
         return true;
      }

      private static bool IsTargetFound()
      {
         var flowChart = uScript.Instance.ScriptEditorCtrl.FlowChart;
         targetNodes = flowChart.SelectedNodes.Length > 0 ? flowChart.SelectedNodes : flowChart.Nodes;
         if (targetNodes.Length == 0)
         {
            uScriptDebug.Log("The graph contains nothing to export.", uScriptDebug.Type.Warning);
            return false;
         }
         return true;
      }

      private static string GeneratePath()
      {
         var name = Path.GetFileNameWithoutExtension(uScriptInstance.ScriptEditorCtrl.ScriptEditor.Name);
         var path = uScriptConfig.ConstantPaths.Screenshots;
         Directory.CreateDirectory(path);

         return string.Format(
            "{0}/{1}_{2}.png",
            path,
            string.IsNullOrEmpty(name) ? "Untitled" : name,
            DateTime.Now.ToString("yyyyMMdd_HHmmssff"));
      }

      private static Rect GetGraphBounds()
      {
         var rect = new Rect(float.MaxValue, float.MaxValue, float.MinValue, float.MinValue);
         foreach (var node in targetNodes)
         {
            rect.xMin = Math.Min(rect.xMin, node.Location.X - BoundsPadding);
            rect.yMin = Math.Min(rect.yMin, node.Location.Y - BoundsPadding);
            rect.xMax = Math.Max(rect.xMax, node.Location.X + BoundsPadding + node.Size.Width);
            rect.yMax = Math.Max(rect.yMax, node.Location.Y + BoundsPadding + node.Size.Height);
         }
         return rect;
      }

      private static void RestoreSelectedLinks()
      {
         while (selectedLinks.Count > 0)
         {
            var guid = selectedLinks.ElementAt(0);
            selectedLinks.RemoveAt(0);

            var link = uScriptInstance.ScriptEditorCtrl.FlowChart.Links.FirstOrDefault(i => i.Guid == guid);
            uScriptDebug.Assert(link != null);
            link.Selected = true;
         }
      }

      private static void RestoreSelectedNodes()
      {
         while (selectedNodes.Count > 0)
         {
            var guid = selectedNodes.ElementAt(0);
            selectedNodes.RemoveAt(0);

            var node = uScriptInstance.ScriptEditorCtrl.FlowChart.Nodes.FirstOrDefault(i => i.Guid == guid);
            uScriptDebug.Assert(node != null);
            node.Selected = true;
         }
      }

      private static void StoreSelectedLinks()
      {
         selectedLinks = new List<Guid>();
         foreach (var link in uScriptInstance.ScriptEditorCtrl.FlowChart.SelectedLinks)
         {
            selectedLinks.Add(link.Guid);
            link.Selected = false;
         }
      }

      private static void StoreSelectedNodes()
      {
         selectedNodes = new List<Guid>();
         foreach (var node in uScriptInstance.ScriptEditorCtrl.FlowChart.SelectedNodes)
         {
            selectedNodes.Add(node.Guid);
            node.Selected = false;
         }
      }

      ///// <summary>
      ///// This method is temporary.  It is used to display debug information on each segment.
      ///// It might eventually be used to display some optional script information on the finished export.
      ///// </summary>
      //private static void DisplayDebugInformation()
      //{
      //   if (debugBoxStyle == null)
      //   {
      //      UnityEngine.Color color = UnityEngine.Color.white;

      //      Texture2D texture = new Texture2D(4, 4);
      //      for (int y = 0; y < 4; y++)
      //         for (int x = 0; x < 4; x++)
      //            texture.SetPixel(x, y, color);

      //      color = new UnityEngine.Color(0, 0, 0, 0.5f);
      //      texture.SetPixel(1, 1, color);
      //      texture.SetPixel(1, 2, color);
      //      texture.SetPixel(2, 1, color);
      //      texture.SetPixel(2, 2, color);
      //      texture.Apply();

      //      debugBoxStyle = new GUIStyle(GUI.skin.box);
      //      debugBoxStyle.border = new RectOffset(2, 2, 2, 2);
      //      debugBoxStyle.normal.background = texture;
      //   }

      //   GUI.BeginGroup(new Rect(0, 17, 250, debugOutput.Count() * 15 + 10), debugBoxStyle);
      //   {
      //      for (int i = 0; i < debugOutput.Count(); i++)
      //      {
      //         GUI.Label(new Rect(10, 4 + (15 * i), 380, 15), debugOutput[i], EditorStyles.whiteLabel);
      //      }
      //   }
      //   GUI.EndGroup();

      //   GUI.Box(graphBounds, string.Empty);
      //}
   }
}

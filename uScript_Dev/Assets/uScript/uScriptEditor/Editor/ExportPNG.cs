// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExportPNG.cs" company="Detox Studios, LLC">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the ExportPNG type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor
{
   using System;
   using System.IO;
   using System.Reflection;

   using UnityEngine;

   public static class ExportPNG
   {
      // === Constants ==================================================================

      private const int BoundsPadding = 20;

      // === Fields =====================================================================

      private static ExportPhase phase;
      private static Drawing.Point originalCanvasLocation;
      private static float originalMapScale;
      private static bool originalPanelState;
      private static string destinationFileName;
      private static Rect graphBounds;

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
      private static int segmentWidth; // in pixels
      private static int segmentHeight; // in pixels

      // texture
      private static Texture2D texture;

      // Create a texture the size of the screen, RGB24 format
      private static int viewportX;
      private static int viewportY;
      private static int viewportWidth;
      private static int viewportHeight;
      private static RectOffset viewportBorderSize;

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

      public static void Start()
      {
         phase = ExportPhase.Initiate;
         uScript.RequestRepaint();

         uScriptInstance = uScript.Instance;
      }

      // This method must be called from within OnGUI
      public static void ProcessImageExport()
      {
         if (uScriptInstance == null || uScriptInstance.ScriptEditorCtrl == null || Event.current.type != EventType.Repaint)
         {
            return;
         }

         //if (phase != ExportPhase.Idle)
         //{
         //   Debug.Log("PNG Export - " + phase.ToString() + "\n");
         //}

         // Handle the current phase
         if (phase == ExportPhase.Idle)
         {
            // DO NOTHING
            return;
         }

         if (phase == ExportPhase.Initiate)
         {
            // Store the original panel and canvas states
            originalCanvasLocation = uScriptInstance.ScriptEditorCtrl.FlowChart.Location;
            originalMapScale = uScriptInstance.MapScale;
            originalPanelState = uScriptGUI.PanelsHidden;

            //// Clear the debug GUI output
            //debugOutput = new List<string>();
            //debugOutput.Add("Export to PNG");

            destinationFileName = string.Format(
               "{0}_{1}",
               Path.GetFileNameWithoutExtension(uScriptInstance.ScriptEditorCtrl.ScriptEditor.Name),
               DateTime.Now.ToString("yyyyMMdd_HHmmssff"));

            // Disable user input
            IsExporting = true;

            Debug.Log("Exporting the graph to PNG ... This could take a while.\n");

            phase = ExportPhase.OverrideEditorState;
         }
         else if (phase == ExportPhase.OverrideEditorState)
         {
            // Override the panel and canvas states

            // Hide the panels if they are currently visible
            if (originalPanelState == false)
            {
               uScriptGUI.PanelsHidden = true;
               uScriptInstance.ScriptEditorCtrl.FlowChart.Location.X += uScriptGUI.PanelLeftWidth
                                                                        + uScriptGUI.PanelDividerThickness;
               uScriptInstance.ScriptEditorCtrl.RebuildScript(null, false);
            }

            // Set the map scale to normal
            uScriptInstance.MapScale = 1;

            phase = ExportPhase.GenerateSeqmentList;
         }
         else if (phase == ExportPhase.RestoreEditorState)
         {
            // Restore the original panel and canvas state
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

            // There is no need to repaint
            return;
         }
         else if (phase == ExportPhase.GenerateSeqmentList)
         {
            // Deselect all nodes, and determine the number of segments to capture

            // Get the graph bounds and de-select all nodes and links
            graphBounds = new Rect(float.MaxValue, float.MaxValue, float.MinValue, float.MinValue);

            foreach (var link in uScriptInstance.ScriptEditorCtrl.FlowChart.Links)
            {
               link.Selected = false;
            }

            foreach (var node in uScriptInstance.ScriptEditorCtrl.FlowChart.Nodes)
            {
               node.Selected = false;
               graphBounds.xMin = Math.Min(graphBounds.xMin, node.Location.X - BoundsPadding);
               graphBounds.yMin = Math.Min(graphBounds.yMin, node.Location.Y - BoundsPadding);
               graphBounds.xMax = Math.Max(graphBounds.xMax, node.Location.X + BoundsPadding + node.Size.Width);
               graphBounds.yMax = Math.Max(graphBounds.yMax, node.Location.Y + BoundsPadding + node.Size.Height);
            }

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
               object parent = fi.GetValue(uScript.Instance);
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

            segmentColumnOverflow = (int)graphBounds.width % viewportWidth;
            segmentRowOverflow = (int)graphBounds.height % viewportHeight;

            segmentColumns = ((int)graphBounds.width / viewportWidth) + (segmentColumnOverflow > 0 ? 1 : 0);
            segmentRows = ((int)graphBounds.height / viewportHeight) + (segmentRowOverflow > 0 ? 1 : 0);

            // Create the texture
            //         Debug.Log("About to create texture " + _graphBounds.width + " x " + _graphBounds.height + "\n");
            texture = new Texture2D((int)graphBounds.width, (int)graphBounds.height, TextureFormat.RGB24, false);

            //// Display debug information for the graph
            //debugOutput.Add("\tCanvas Size:\t\t\t" + viewportWidth.ToString() + ", " + viewportHeight);
            //debugOutput.Add("\tCanvas Locatiion\t\t" + (-originalCanvasLocation.X) + ", " + (-originalCanvasLocation.Y));

            //debugOutput.Add(string.Empty);
            //debugOutput.Add("Graph:");
            //debugOutput.Add("\tTotal Segments:\t" + segmentColumns + ", " + segmentRows);
            //debugOutput.Add("\tTotal Size:\t\t\t" + graphBounds.width + ", " + graphBounds.height);
            //debugOutput.Add("\tOverflow Size:\t\t" + segmentColumnOverflow + ", " + segmentRowOverflow);

            var msg = segmentColumns * segmentRows > 1 ? string.Format("\tStitching together {0} canvas snapshots ...", segmentColumns * segmentRows) : string.Empty;

            Debug.Log(
               string.Format(
                  "\tThe resulting image will be {0}x{1} pixels in size.\n{2}",
                  (int)graphBounds.width,
                  (int)graphBounds.height,
                  msg));

            phase = ExportPhase.NextSegment;
         }
         else if (phase == ExportPhase.NextSegment)
         {
            // Prepare the next segment for capture
            segmentWidth = viewportWidth;
            segmentHeight = viewportHeight;

            // The last segment column and row may be smaller than the viewport size
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
               uScriptInstance.ScriptEditorCtrl.FlowChart.Location.X = -(int)graphBounds.x - segmentX;
               uScriptInstance.ScriptEditorCtrl.FlowChart.Location.Y = -(int)graphBounds.y - segmentY;

               segmentY = (int)graphBounds.height - segmentHeight - segmentY;

               phase = ExportPhase.CaptureSegmentImage;
            }
         }
         else if (phase == ExportPhase.CaptureSegmentImage)
         {
            //debugOutput.Add(string.Empty);
            //debugOutput.Add("Segment:\t\t" + segmentColumn + ", " + segmentRow);
            //debugOutput.Add("\tOffset:\t\t" + segmentX + ", " + segmentY.ToString());
            //debugOutput.Add("\tLocation:\t" + (-uScriptInstance.ScriptEditorCtrl.FlowChart.Location.X) + ", " + (-uScriptInstance.ScriptEditorCtrl.FlowChart.Location.Y));
            //debugOutput.Add("\tSize:\t\t\t" + segmentWidth + ", " + segmentHeight);

            //DisplayDebugInformation();
            //Debug.Log("Read\tX: " + viewportX
            //           + ", Y: " + (viewportY + (viewportHeight - segmentHeight))
            //           + ", W: " + (segmentWidth + 1)
            //           + ", H: " + segmentHeight
            //           + "\nWrite\tX: " + segmentX + ", Y: " + segmentY);

            // Read segment contents from the screen and store them in the texture
            texture.ReadPixels(
               new Rect(
                  viewportX,
                  viewportY + (viewportHeight - segmentHeight),
                  segmentWidth,
                  //segmentWidth + 1,
                  segmentHeight),
               segmentX,
               segmentY);

            // Prepare to capture the next segment
            segmentColumn++;

            phase = ExportPhase.NextSegment;
         }
         else if (phase == ExportPhase.ExportCompleteImage)
         {
            // Apply the texture changes
            texture.Apply(false);

            // Encode texture into PNG
            byte[] bytes = texture.EncodeToPNG();
            UnityEngine.Object.DestroyImmediate(texture);

            // TODO : Make sure the folder exists.
            System.IO.Directory.CreateDirectory(uScriptConfig.ConstantPaths.Screenshots);

            // Write the file in the project folder
            System.IO.File.WriteAllBytes(
               uScriptConfig.ConstantPaths.Screenshots + "/" + destinationFileName + ".png", bytes);

            string path = Application.dataPath;
            path = path.Substring(0, path.Length - 7);
            path = path.Substring(path.LastIndexOf('/'));
            Debug.Log(
               "\t" + "Saved: \t\"" + destinationFileName + ".png\"" + "\n" + "\t\t" + "at: \t\"." + path
               + "/Screenshots/\"");

            // Restore the editor to it's previous state
            phase = ExportPhase.RestoreEditorState;
         }
         else if (phase == ExportPhase.Finished)
         {
            uScriptInstance.RemoveNotification();
            IsExporting = false;
            phase = ExportPhase.Idle;
         }

         uScript.RequestRepaint();
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

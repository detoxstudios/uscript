using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Reflection;
using Detox.ScriptEditor;

using System.Collections.Generic;
using System.Linq;
using Detox.Data.Tools;
using Detox.Drawing;
using Detox.FlowChart;
using Detox.Windows.Forms;



public static class uScriptExportPNG
{
   enum ExportPhase
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



   static ExportPhase _phase;
   static Detox.Drawing.Point _originalCanvasLocation;
   static float _originalMapScale;
   static bool _originalPanelState;
   static string _destinationFileName;

   static Rect _graphBounds;
//   static List<string> _debugOutput;
//   static GUIStyle _debugBoxStyle;

   private static bool _isExporting;
   public static bool IsExporting { get { return _isExporting; } }

   static uScript _uScript;

   const int BOUNDS_PADDING = 20;

   static int _segmentColumn;
   static int _segmentColumnOverflow;
   static int _segmentColumns;
   static int _segmentRow;
   static int _segmentRowOverflow;
   static int _segmentRows;

   static int _segmentX;
   static int _segmentY;
   static int _segmentWidth;        // in pixels
   static int _segmentHeight;       // in pixels


   // texture
   static Texture2D _texture;


   // Create a texture the size of the screen, RGB24 format
   static int _viewportX;
   static int _viewportY;
   static int _viewportWidth;
   static int _viewportHeight;

   static RectOffset _viewportBorderSize;



   public static void Start()
   {
      _phase = ExportPhase.Initiate;
      uScript.RequestRepaint();

      _uScript = uScript.Instance;
   }

   //
   // This method must be called from within OnGUI
   //
   public static void ProcessImageExport()
   {
      if (_uScript == null || _uScript.ScriptEditorCtrl == null || Event.current.type != EventType.Repaint)
      {
         return;
      }


//      if (_phase != ExportPhase.Idle)
//      {
//         Debug.Log("PNG Export - " + _phase.ToString() + "\n");
//      }

      //
      // Handle the current phase
      //
      if ( _phase == uScriptExportPNG.ExportPhase.Idle )
      {
         //
         // DO NOTHING
         //
         return;
      }
      else if ( _phase == uScriptExportPNG.ExportPhase.Initiate )
      {
         //
         // Store the original panel and canvas states
         //
         _originalCanvasLocation = _uScript.ScriptEditorCtrl.FlowChart.Location;
         _originalMapScale = _uScript.m_MapScale;
         _originalPanelState = uScriptGUI.panelsHidden;

//         // Clear the debug GUI output
//         _debugOutput = new List<string>();
//         _debugOutput.Add("Export to PNG");

         _destinationFileName = System.IO.Path.GetFileNameWithoutExtension(_uScript.CurrentScriptName) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmssff");

         // Disable user input
         _isExporting = true;

         Debug.Log("Exporting the graph to PNG ... This could take a while.\n");


         _phase = ExportPhase.OverrideEditorState;
      }
      else if ( _phase == uScriptExportPNG.ExportPhase.OverrideEditorState )
      {
         //
         // Override the panel and canvas states
         //

         // Hide the panels if they are currently visible
         if (_originalPanelState == false)
         {
            uScriptGUI.panelsHidden = true;
            _uScript.ScriptEditorCtrl.FlowChart.Location.X += uScriptGUI.panelLeftWidth + uScriptGUI.panelDividerThickness;
            _uScript.ScriptEditorCtrl.RefreshScript(null, false);
         }

         // Set the map scale to normal
         _uScript.m_MapScale = 1;

         _phase = ExportPhase.GenerateSeqmentList;
      }
      else if ( _phase == uScriptExportPNG.ExportPhase.RestoreEditorState )
      {
         //
         // Restore the original panel and canvas state
         //
         if (_originalPanelState == false)
         {
            uScriptGUI.panelsHidden = false;
            _uScript.ScriptEditorCtrl.FlowChart.Location.X -= uScriptGUI.panelLeftWidth + uScriptGUI.panelDividerThickness;
            _uScript.ScriptEditorCtrl.RefreshScript(null, false);
         }
         _uScript.m_MapScale = _originalMapScale;
         _uScript.ScriptEditorCtrl.FlowChart.Location = _originalCanvasLocation;

         _phase = ExportPhase.Finished;

         // There is no need to repaint
         return;
      }
      else if ( _phase == uScriptExportPNG.ExportPhase.GenerateSeqmentList )
      {
         //
         // Deselect all nodes, and determine the number of segments to capture
         //

         // Get the graph bounds and de-select all nodes and links
         _graphBounds = new Rect( float.MaxValue, float.MaxValue, float.MinValue, float.MinValue);

         foreach ( Link link in _uScript.ScriptEditorCtrl.FlowChart.Links )
         {
            link.Selected = false;
         }

         foreach ( Node node in _uScript.ScriptEditorCtrl.FlowChart.Nodes )
         {
            node.Selected = false;
            _graphBounds.xMin = Math.Min( _graphBounds.xMin, node.Location.X - BOUNDS_PADDING );
            _graphBounds.yMin = Math.Min( _graphBounds.yMin, node.Location.Y - BOUNDS_PADDING );
            _graphBounds.xMax = Math.Max( _graphBounds.xMax, node.Location.X + BOUNDS_PADDING + node.Size.Width );
            _graphBounds.yMax = Math.Max( _graphBounds.yMax, node.Location.Y + BOUNDS_PADDING + node.Size.Height );
         }

         // Get the viewport dimensions
         _viewportX = (int)_uScript._canvasRect.x;
         _viewportY = (int)_uScript._canvasRect.y;

         // Create a texture the size of the screen, RGB24 format
         _viewportWidth = (int)_uScript._canvasRect.width - 1;
         _viewportHeight = (int)_uScript._canvasRect.height;

         // Get the viewport border size from Unity via reflection
         BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
         FieldInfo fi = uScript.Instance.GetType().GetField("m_Parent", flags);
         if (fi != null)
         {
            object parent = fi.GetValue(uScript.Instance);
            if (parent != null)
            {
               PropertyInfo pi = parent.GetType().GetProperty("borderSize", flags);
               _viewportBorderSize = pi.GetValue(parent, null) as RectOffset;
            }
         }

         // Adjust positions and sizes
         _viewportY = Screen.height - _viewportHeight - _viewportY - _viewportBorderSize.top;

         // Tweaks to handle various dock scenarios - this is stupid
         _viewportX = _viewportBorderSize.left;
         if ( _viewportBorderSize.bottom == 2 )
         {
            _viewportY -= 2;  // 23
         }
         if ( _viewportBorderSize.bottom == 4 )
         {
            _viewportY -= 2;  // 25
         }
         if ( _viewportBorderSize.bottom == 5 )
         {
            _viewportY -= 5;  // 23
         }
         else if ( _viewportBorderSize.bottom == 7 )
         {
            _viewportY -= 5;  // 25
         }

         // Determine the segment details
         _segmentColumn = _segmentRow = 0;

         _segmentColumnOverflow = (int)_graphBounds.width % _viewportWidth;
         _segmentRowOverflow = (int)_graphBounds.height % _viewportHeight;

         _segmentColumns = (int)_graphBounds.width / _viewportWidth + (_segmentColumnOverflow > 0 ? 1 : 0);
         _segmentRows = (int)_graphBounds.height / _viewportHeight + (_segmentRowOverflow > 0 ? 1 : 0);

         // Create the texture
         Debug.Log("About to create texture " + _graphBounds.width + " x " + _graphBounds.height + "\n");
         _texture = new Texture2D((int)_graphBounds.width, (int)_graphBounds.height, TextureFormat.RGB24, false);

//         // Display debug information for the graph
//         _debugOutput.Add( "\tCanvas Size:\t\t\t" + _viewportWidth.ToString() + ", " + _viewportHeight.ToString() );
//         _debugOutput.Add( "\tCanvas Locatiion\t\t" + (-_originalCanvasLocation.X).ToString() + ", " + (-_originalCanvasLocation.Y).ToString() );
//
//         _debugOutput.Add( string.Empty );
//         _debugOutput.Add( "Graph:" );
//         _debugOutput.Add( "\tTotal Segments:\t" + _segmentColumns.ToString() + ", " + _segmentRows.ToString() );
//         _debugOutput.Add( "\tTotal Size:\t\t\t" + _graphBounds.width.ToString() + ", " + _graphBounds.height.ToString() );
//         _debugOutput.Add( "\tOverflow Size:\t\t" + _segmentColumnOverflow.ToString() + ", " + _segmentRowOverflow.ToString() );

         Debug.Log( string.Format( "\tThe resulting image will be {0}x{1} pixels in size.\n{2}",
                                   (int)_graphBounds.width,
                                   (int)_graphBounds.height,
                                   ( _segmentColumns * _segmentRows > 1
                                       ? string.Format( "\tStitching together {0} canvas snapshots ...",
                                                        _segmentColumns * _segmentRows )
                                       : string.Empty
                                   )
                                 )
                  );

         _phase = ExportPhase.NextSegment;
      }
      else if ( _phase == uScriptExportPNG.ExportPhase.NextSegment )
      {
         //
         // Prepare the next segment for capture
         //

         _segmentWidth = _viewportWidth;
         _segmentHeight = _viewportHeight;

         // The last segment column and row may be smaller than the viewport size
         if (_segmentColumn == _segmentColumns - 1)
         {
            // final column
            _segmentWidth = _segmentColumnOverflow;
         }
         else if (_segmentColumn == _segmentColumns)
         {
            // next row
            _segmentColumn = 0;
            _segmentRow++;
         }

         if (_segmentRow >= _segmentRows)
         {
            // no more segments
            _phase = uScriptExportPNG.ExportPhase.ExportCompleteImage;

            _uScript.ShowNotification( new GUIContent( "Saving PNG ...\nThis could take a while." ) );
         }
         else
         {
            if (_segmentRow == _segmentRows - 1)
            {
               // final row
               _segmentHeight = _segmentRowOverflow;
            }
   
            _segmentX = (_segmentColumn * _viewportWidth);
            _segmentY = (_segmentRow * _viewportHeight);
   
            // Update the canvas position to point to the segment
            _uScript.ScriptEditorCtrl.FlowChart.Location.X = -(int)_graphBounds.x - _segmentX;
            _uScript.ScriptEditorCtrl.FlowChart.Location.Y = -(int)_graphBounds.y - _segmentY;
   
            _segmentY = (int)_graphBounds.height - _segmentHeight - _segmentY;
   
            _phase = ExportPhase.CaptureSegmentImage;
         }
      }
      else if ( _phase == uScriptExportPNG.ExportPhase.CaptureSegmentImage )
      {
//         _debugOutput.Add( string.Empty );
//         _debugOutput.Add( "Segment:\t\t" + _segmentColumn.ToString() + ", " + _segmentRow.ToString() );
//         _debugOutput.Add( "\tOffset:\t\t" + _segmentX.ToString() + ", " + _segmentY.ToString() );
//         _debugOutput.Add( "\tLocation:\t" + (-_uScript.ScriptEditorCtrl.FlowChart.Location.X).ToString() + ", " + (-_uScript.ScriptEditorCtrl.FlowChart.Location.Y).ToString() );
//         _debugOutput.Add( "\tSize:\t\t\t" + _segmentWidth.ToString() + ", " + _segmentHeight.ToString() );
//
//         DisplayDebugInformation();
         Debug.Log( "Read\tX: " + _viewportX
                    + ", Y: " + _viewportY + (_viewportHeight - _segmentHeight)
                    + ", W: " + _segmentWidth + 1
                    + ", H: " + _segmentHeight + "\nWrite\tX: " + _segmentX  + ", Y: " + _segmentY);

         // Read segment contents from the screen and store them in the texture
         _texture.ReadPixels( new Rect( _viewportX,
                                        _viewportY + (_viewportHeight - _segmentHeight),
                                        _segmentWidth + 1,
                                        _segmentHeight),
                              _segmentX,
                              _segmentY
                            );

         // Prepare to capture the next segment
         _segmentColumn++;

         _phase = ExportPhase.NextSegment;
      }
      else if ( _phase == uScriptExportPNG.ExportPhase.ExportCompleteImage )
      {
         // Apply the texture changes
         _texture.Apply( false );

         // Encode texture into PNG
         byte[] bytes = _texture.EncodeToPNG();
         UnityEngine.Object.DestroyImmediate(_texture);

      // @TODO : Make sure the folder exists.
         System.IO.Directory.CreateDirectory(uScriptConfig.ConstantPaths.Screenshots);

         // Write the file in the project folder
         System.IO.File.WriteAllBytes(uScriptConfig.ConstantPaths.Screenshots + "/" + _destinationFileName + ".png", bytes);

         string path = Application.dataPath;
         path = path.Substring(0, path.Length - 7);
         path = path.Substring( path.LastIndexOf('/') );
         Debug.Log( "\t" + "Saved: \t\"" + _destinationFileName + ".png\"" + "\n"
                    + "\t\t" + "at: \t\"." + path + "/Screenshots/\"" );

         // Restore the editor to it's previous state
         _phase = uScriptExportPNG.ExportPhase.RestoreEditorState;
      }
      else if ( _phase == uScriptExportPNG.ExportPhase.Finished )
      {
         _uScript.RemoveNotification();
         _isExporting = false;
         _phase = ExportPhase.Idle;
      }

      uScript.RequestRepaint();
   }



   /// <summary>
   /// This method is temporary.  It is used to display debug information on each segment.
   /// It might eventually be used to display some optional script information on the finished export.
   /// </summary>
//   static void DisplayDebugInformation()
//   {
//      if (_debugBoxStyle == null)
//      {
//         UnityEngine.Color color = UnityEngine.Color.white;
//
//         Texture2D texture = new Texture2D( 4, 4 );
//         for (int y = 0; y < 4; y++)
//            for (int x = 0; x < 4; x++)
//               texture.SetPixel( x, y, color );
//
//         color = new UnityEngine.Color(0, 0, 0, 0.5f);
//         texture.SetPixel( 1, 1, color );
//         texture.SetPixel( 1, 2, color );
//         texture.SetPixel( 2, 1, color );
//         texture.SetPixel( 2, 2, color );
//         texture.Apply();
//
//         _debugBoxStyle = new GUIStyle( GUI.skin.box );
//         _debugBoxStyle.border = new RectOffset(2, 2, 2, 2);
//         _debugBoxStyle.normal.background = texture;
//      }
//
//      GUI.BeginGroup(new Rect(0, 17, 250, _debugOutput.Count() * 15 + 10), _debugBoxStyle);
//      {
//         for (int i = 0; i < _debugOutput.Count(); i++)
//         {
//            GUI.Label(new Rect(10, 4 + (15 * i), 380, 15), _debugOutput[i], EditorStyles.whiteLabel);
//         }
//      }
//      GUI.EndGroup();
//
//      GUI.Box( _graphBounds, string.Empty );
//   }
//
}

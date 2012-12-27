namespace Detox.Windows
{
}

namespace Detox.ComponetModel
{
   public class ITypeDescriptorContext
   {}
}

namespace Detox.Windows.Forms.Design
{
   public class FileNameEditor
   {
      //public Object EditValue(
      //   System.ComponetModel.ITypeDescriptorContext context,
      //   System.IServiceProvider provider,
      //   object value
      //)
      //{
      //   return null;
      //}

      //public virtual Detox.Drawing.Design.UITypeEditorEditStyle GetEditStyle(
      //   System.ComponetModel.ITypeDescriptorContext context
      //)
      //{
      //   return UITypeEditorEditStyle.Model;
      //}
   }
}

namespace Detox.Data
{
}

namespace Detox.Drawing.Design
{
   public enum UITypeEditorEditStyle
   {
      Model
   }
}

namespace Detox.DirectX
{
   public struct Matrix
   {
      public float M11;
      public float M12;
      public float M13;
      public float M14;
      public float M21;
      public float M22;
      public float M23;
      public float M24;
      public float M31;
      public float M32;
      public float M33;
      public float M34;
      public float M41;
      public float M42;
      public float M43;
      public float M44;

      static public Matrix Identity = new Matrix( 1, 0, 0, 0, 
                                                  0, 1, 0, 0,
                                                  0, 0, 1, 0,
                                                  0, 0, 0, 1 );

      public Matrix( float m11, float m12, float m13, float m14,
                     float m21, float m22, float m23, float m24,
                     float m31, float m32, float m33, float m34,
                     float m41, float m42, float m43, float m44 )
      {
         M11 = m11;
         M12 = m12;
         M13 = m13;
         M14 = m14;

         M21 = m21;
         M22 = m22;
         M23 = m23;
         M24 = m24;

         M31 = m31;
         M32 = m32;
         M33 = m33;
         M34 = m34;

         M41 = m41;
         M42 = m42;
         M43 = m43;
         M44 = m44;
      }
   }
}

namespace Detox.Application
{
   public class ToolWindow : Detox.Windows.Forms.Form
   {}
}

namespace Detox.Windows.Forms
{
   using System.Reflection;
   using System;
   using System.Collections.Generic;
   using Detox.Windows.Forms;
   using Detox.Drawing;
   using UnityEngine;
   using UnityEditor;
   using Detox.ScriptEditor;

   public class PropertyValueChangedEventArgs : System.EventArgs
   {}

   public delegate void PropertyValueChangedEventHandler (object sender, PropertyValueChangedEventArgs e);
   
   public class PropertyGrid
   {
      public object [] SelectedObjects = new object[ 0 ];
   
      public event PropertyValueChangedEventHandler PropertyValueChanged;
      public void OnPropertyValueChanged( )
      {
         if ( null != PropertyValueChanged ) PropertyValueChanged( this, new PropertyValueChangedEventArgs( ) );
      }

      private Type GetObjectArrayFieldType(string stringType)
      {
         Type type = uScript.MasterComponent.GetType(stringType);
         if ( null == type ) return null;

         if ( typeof(UnityEngine.Object[]).IsAssignableFrom(type) ) return type;

         return null;
      }

      private Type GetObjectFieldType(string stringType)
      {
         Type type = uScript.MasterComponent.GetType(stringType);
         if ( null == type ) return null;

         if ( typeof(UnityEngine.Object).IsAssignableFrom(type) ) return type;

         return null;
      }


      public void OnPaint( )
      {
         bool signalUpdate = false;

         if (SelectedObjects.Length == 0)
         {
            uScriptGUI.ResetFoldouts();
         }

         foreach ( object selectedObject in SelectedObjects )
         {
            PropertyGridParameters parameters = selectedObject as PropertyGridParameters;
            List<Parameter> updatedParameters = new List<Parameter>( );

            if (parameters.Parameters.Length > 1)
            {
               Detox.FlowChart.Node node = parameters.EntityNode != null ? uScript.Instance.ScriptEditorCtrl.GetNode(parameters.EntityNode.Guid) : null;

               if (uScriptGUI.BeginPropertyList(parameters.Description, node))
               {
                  foreach ( Parameter p in parameters.Parameters )
                  {
                     if ( p == Parameter.Empty || (false == p.Input && false == p.Output) ) 
                     {
                        updatedParameters.Add(  p );
                        continue;
                     }

                     Parameter cloned = p;

                     object val = cloned.DefaultAsObject;

                     bool isSocketExposed  = p.IsVisible( );
                     bool isReadOnly = false == p.Input;
                     bool isLocked = true == p.IsLocked( );

                     if (null != node)
                     {
                        if ( false == isLocked )
                        {
                           if ( false == parameters.ScriptEditorCtrl.CanCollapseParameter(parameters.EntityNode.Guid, p) &&
                                false == parameters.ScriptEditorCtrl.CanExpandParameter(p) )
                           {
                              isLocked = true;
                           }
                        }
                     }

                     if ( node == null || false == uScript.GetRequiresLink(parameters.EntityNode, p.Name) )
                     {
                        if ( val.GetType() == typeof(System.Boolean[]) )
                        {
                           val = uScriptGUI.ArrayFoldout<System.Boolean>(p.FriendlyName, (Boolean[]) val, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( val.GetType() == typeof(System.Boolean) )
                        {
                           val = uScriptGUI.BoolField(p.FriendlyName, (bool) val, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( val.GetType() == typeof(System.Int32[]) )
                        {
                           val = uScriptGUI.ArrayFoldout<System.Int32>(p.FriendlyName, (int[]) val, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( val.GetType() == typeof(System.Int32) )
                        {
                           val = uScriptGUI.IntField(p.FriendlyName, (int) val, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( val.GetType() == typeof(System.Single[]) )
                        {
                           val = uScriptGUI.ArrayFoldout<System.Single>(p.FriendlyName, (Single[]) val, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( val.GetType() == typeof(System.Single) )
                        {
                           val = uScriptGUI.FloatField(p.FriendlyName, (float) val, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( val.GetType() == typeof(System.Double[]) )
                        {
                           val = uScriptGUI.ArrayFoldout<System.Double>(p.FriendlyName, (Double[]) val, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( val.GetType() == typeof(System.Double) )
                        {
                           val = (double) uScriptGUI.FloatField(p.FriendlyName, (float) val, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( val.GetType() == typeof(Vector2[]) )
                        {
                           val = uScriptGUI.ArrayFoldout<Vector2>(p.FriendlyName, (Vector2[]) val, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( val.GetType() == typeof(Vector2) )
                        {
                           val = uScriptGUI.Vector2Field(p.FriendlyName, (Vector2) val, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( val.GetType() == typeof(Rect[]) )
                        {
                           val = uScriptGUI.ArrayFoldout<Rect>(p.FriendlyName, (Rect[]) val, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( val.GetType() == typeof(Rect) )
                        {
                           val = uScriptGUI.RectField(p.FriendlyName, (Rect) val, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( val.GetType() == typeof(Vector3[]) )
                        {
                           val = uScriptGUI.ArrayFoldout<Vector3>(p.FriendlyName, (Vector3[]) val, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( val.GetType() == typeof(Vector3) )
                        {
                           val = uScriptGUI.Vector3Field(p.FriendlyName, (Vector3) val, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( val.GetType() == typeof(Vector4[]) )
                        {
                           val = uScriptGUI.ArrayFoldout<Vector4>(p.FriendlyName, (Vector4[]) val, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( val.GetType() == typeof(Vector4) )
                        {
                           val = uScriptGUI.Vector4Field(p.FriendlyName, (Vector4) val, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( val.GetType() == typeof(Quaternion[]) )
                        {
                           val = uScriptGUI.ArrayFoldout<Quaternion>(p.FriendlyName, (Quaternion[]) val, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( val.GetType() == typeof(Quaternion) )
                        {
                           val = uScriptGUI.QuaternionField(p.FriendlyName, (Quaternion) val, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( val.GetType() == typeof(UnityEngine.Color[]) )
                        {
                           val = uScriptGUI.ArrayFoldout<UnityEngine.Color>(p.FriendlyName, (UnityEngine.Color[]) val, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( val.GetType() == typeof(UnityEngine.Color) )
                        {
                           val = uScriptGUI.ColorField(p.FriendlyName, (UnityEngine.Color) val, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( val.GetType() == typeof(GUILayoutOption[]) )
                        {
                           val = uScriptGUI.ArrayFoldout<GUILayoutOption>(p.FriendlyName, (GUILayoutOption[])val, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( val.GetType() == typeof(GUILayoutOption) )
                        {
                           val = uScriptGUI.GUILayoutOptionField(p.FriendlyName, (GUILayoutOption)val, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( val.GetType() == typeof(UnityEngine.LayerMask[]) )
                        {
                           val = uScriptGUI.ArrayFoldout<UnityEngine.LayerMask>(p.FriendlyName, (UnityEngine.LayerMask[]) val, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( typeof(UnityEngine.LayerMask).IsAssignableFrom(val.GetType()) )
                        {
   //                        UnityEngine.LayerMask mask = (UnityEngine.LayerMask)val;
   //                        string layerValue = UnityEngine.LayerMask.LayerToName(mask);
   //
   //                        // build layer list
   //                        List<string> layerList = new List<string>();
   //                        for (int i = 0; i < 32; i++)
   //                        {
   //                           if (!string.IsNullOrEmpty(UnityEngine.LayerMask.LayerToName(i)))
   //                           {
   //                              layerList.Add(UnityEngine.LayerMask.LayerToName(i));
   //                           }
   //                        }
   //
   //                        string returnedName = uScriptGUI.ChoiceField(p.FriendlyName, layerValue, layerList.ToArray(), ref isSocketExposed, isLocked, isReadOnly);
   //
   //                        for (int i = 0; i < 32; i++)
   //                        {
   //                           string name = UnityEngine.LayerMask.LayerToName(i);
   //                           if (!string.IsNullOrEmpty(name) && returnedName == name)
   //                           {
   //                              val = UnityEngine.LayerMask.NameToLayer(returnedName);
   //                              break;
   //                           }
   //                        }

                           val = uScriptGUI.LayerField(p.FriendlyName, (LayerMask)val, ref isSocketExposed, isLocked, isReadOnly);
   //                        // Later, if we support actual LayerMask fields, the popup control should use
   //                        // labels like "xxx" or "xxx, xxx" or "xxx, xxx, xxx" or "Mixed ..."
   //                        //
   //                        // See the Camera Culling Mask in the Inspector for example
   //
   //                        //    Nothing           0
   //                        //    Everything        -1
   //                        // 0  Default           1
   //                        // 1  TransparentFX     2
   //                        // 2  Ignore Raycast    4
   //                        // ...
   //                        // 31  Unnamed 31

                        }
                        else if ( typeof(System.Enum[]).IsAssignableFrom(val.GetType()) )
                        {
                           //use p.Type to figure out the specific type of enum it is, instead of a generic System.Enum
                           System.Type eType = uScript.MasterComponent.GetType(p.Type.ToString().Replace("[]", ""));
                           val = uScriptGUI.ArrayFoldout<System.Enum>(p.FriendlyName, (System.Enum[]) val, ref isSocketExposed, isLocked, isReadOnly, eType);
                        }
                        else if ( typeof(System.Enum).IsAssignableFrom(val.GetType()) )
                        {
                           val = uScriptGUI.EnumTextField(p.FriendlyName, (System.Enum) val, p.Default, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( AssetType.Invalid != uScript.GetAssetPathField(parameters.EntityNode, p.Name) )
                        {
                           val = uScriptGUI.AssetPathField(p.FriendlyName, uScript.GetAssetPathField(parameters.EntityNode, p.Name), p.Default, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( null != GetObjectArrayFieldType(p.Type) )
                        {
                           //arrays are stored as comma delimited string, so parse it now
                           string []values = Parameter.StringToArray(p.Default);
                           values = uScriptGUI.ArrayFoldout<string>(p.FriendlyName, values, ref isSocketExposed, isLocked, isReadOnly, typeof(GameObject));
                           val = Parameter.ArrayToString(values);
                        }
                        else if ( null != GetObjectFieldType(p.Type) )
                        {
                           val = uScriptGUI.ObjectField(p.FriendlyName, null, GetObjectFieldType(p.Type), p.Default, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else if ( uScriptConfig.Variable.FriendlyName(p.Type) == "TextArea" )
                        {
                           val = uScriptGUI.TextArea(p.FriendlyName, p.Default, ref isSocketExposed, isLocked, isReadOnly);
                        }
                        else
                        {
                           //arrays are stored as comma delimited string, so parse it now
                           if ( p.Type.Contains("[]") )
                           {
                              string []values = Parameter.StringToArray(p.Default);
                              val = uScriptGUI.ArrayFoldout<string>(p.FriendlyName, values, ref isSocketExposed, isLocked, isReadOnly);
                           }
                           else
                           {
                              if (p.FriendlyName == "Name")
                              {
                                 val = uScriptGUI.VariableNameField(p.FriendlyName, p.Default, ref isSocketExposed, isLocked, isReadOnly);
                              }
                              else
                              {
                                 val = uScriptGUI.TextField(p.FriendlyName, p.Default, ref isSocketExposed, isLocked, isReadOnly);
                              }
                           }
                        }
                     }
                     else
                     {
                        uScriptGUI.BlankField(p.FriendlyName, "Requires Link", ref isSocketExposed, isLocked);
                     }

                     //remove the old states
                     cloned.State &= ~Parameter.VisibleState.Visible;
                     cloned.State &= ~Parameter.VisibleState.Hidden;

                     //add it back in if selected
                     if ( true == isSocketExposed )
                     {
                        cloned.State |= Parameter.VisibleState.Visible;
                     }
                     else
                     {
                        cloned.State |= Parameter.VisibleState.Hidden;
                     }

                     cloned.DefaultAsObject = val;

                     //they changed the value - the reference guid
                     //must be rebuilt
                     if ( cloned.Default != p.Default )
                     {
                        cloned.ReferenceGuid = "";
                     }

                     signalUpdate |= cloned.Default != p.Default;
                     signalUpdate |= cloned.State   != p.State;

                     updatedParameters.Add( cloned );
                  }

                  parameters.Parameters = updatedParameters.ToArray( );
               }
               uScriptGUI.EndPropertyList();
            }
         }

         if ( true == signalUpdate )
         {
            OnPropertyValueChanged( );
         }
      }
   }

   public class Form : Control
   {
      public void ShowDialog( )
      {}
   }

   public class ItemList
   {
      public List<ToolStripItem> Items = new List<ToolStripItem>( );

      public ToolStripItem Add(string name)
      {
         ToolStripItem newItem = new ToolStripItem( name );

         Items.Add( newItem );

         return newItem;      
      }

      public void AddRange(ToolStripItem []range)
      {
         foreach (ToolStripItem item in range)
         {
            Items.Add( item );
         }
      }

      public void Add(ToolStripItem item)
      {
         Items.Add( item );
      }

      public void Clear( )
      {
         Items.Clear( );
      }
   }

   public class ContextMenuStrip
   {
      public ItemList Items = new ItemList( );
   }

   public class ToolStripSeparator : ToolStripItem
   {
      public ToolStripSeparator() : base("<hr>")
      {}
   }

   public class ToolStripMenuItem : ToolStripItem
   {
      public ItemList DropDownItems = new ItemList( );
      
      public ToolStripMenuItem() : base("")
      {}

      public ToolStripMenuItem(string name) : base(name)
      {}
   }

   public class MenuItem
   {
      public object Tag;
   }

   public class ToolStripItem : MenuItem
   {
      public ToolStripItem(string name)
      {
         Text = name;
      }

      public Size Size;
      public string Text;
      public string Name;

      public System.EventHandler Click;

      public void OnClick( )
      {
         if ( null != Click ) Click( this, new EventArgs( ) );
      }
   }

   public class Control
   {
      static public Keys ModifierKeys;
      static public MouseButtons MouseButtons;
   
      public List<Control> Controls = new List<Control>( );

      private bool     m_MouseIsDown = false;

      public string    Name;
      public string    Text;
      public string    TabText;
      public Region    Region;   
      public Control   Parent;

      public Point Location;
      public Size  Size;

      //important notes about zooming
      //Size/Location do not have the zoom factor
      //to get the zoomed location you need to call PointToScreen
      //which will take into account the child and parent zooms
      //then you can translate back PointToClient

      public float ZoomScale = 1.0f;

      public Size ZoomSize
      {
         get
         {
            return new Size( (int) (Size.Width * ZoomScale), (int) (Size.Height * ZoomScale) );
         }
      }

      public Rectangle Bounds
      {
         get
         {
            return new Rectangle( (int) (Location.X), (int) (Location.Y), (int) (Size.Width), (int) (Size.Height) );
         }
      }

      public Detox.Drawing.Graphics CreateGraphics( )
      {
         return new Detox.Drawing.Graphics( );
      }

      public Point PointToScreen(Point point)
      {
         Point p = new Point( );
      
         Point location = Location;

         if ( null != Parent )
         {
            location = Parent.PointToScreen( location );
         }

         location.X = (int) (location.X * ZoomScale);
         location.Y = (int) (location.Y * ZoomScale);

         p.X = point.X + location.X;
         p.Y = point.Y + location.Y;

         return p;
      }

      public PointF PointToScreen(PointF point)
      {
         PointF p = new PointF( );
      
         Point location = Location;

         if ( null != Parent )
         {
            location = Parent.PointToScreen( location );
         }

         location.X = (int) (location.X * ZoomScale);
         location.Y = (int) (location.Y * ZoomScale);

         p.X = point.X + location.X;
         p.Y = point.Y + location.Y;

         return p;
      }

      public Point PointToClient(Point point)
      {
         Point p = new Point( 0, 0 );

         if ( null != Parent )
         {
            p = Parent.PointToClient( p );
         }

         p.X = (int)(point.X - ((Location.X - p.X) * ZoomScale));
         p.Y = (int)(point.Y - ((Location.Y - p.Y) * ZoomScale));

         return p;
      }

      public PointF PointToClient(PointF point)
      {
         PointF p = new PointF( 0, 0 );

         if ( null != Parent )
         {
            p = Parent.PointToClient( p );
         }

         p.X = point.X - ((Location.X - p.X) * ZoomScale);
         p.Y = point.Y - ((Location.Y - p.Y) * ZoomScale);

         return p;
      }

      public event MouseEventHandler MouseMove;
      public event MouseEventHandler MouseDown;
      public event MouseEventHandler MouseUp;

      public bool OnMouseDown( Detox.Windows.Forms.MouseEventArgs e )
      {
         Control []controls = Controls.ToArray( );
         int i;

         for ( i = controls.Length - 1; i >= 0; i-- )
         {
			   Control control = controls[i];

            if ( true == control.OnMouseDown(e) )
            {
               return true;
            }
         }

         Point point = PointToClient( new Point(e.X, e.Y) );

         bool inRect = point.X > 0 && point.X < ZoomSize.Width &&
                       point.Y > 0 && point.Y < ZoomSize.Height;
         
         if ( false == m_MouseIsDown &&
              true == inRect )
         {
            m_MouseIsDown = true;

            Detox.Windows.Forms.MouseEventArgs args = new Detox.Windows.Forms.MouseEventArgs( );
            args.X = point.X;
            args.Y = point.Y;
            args.Button = e.Button;

            if ( null != MouseDown ) MouseDown( this, args );
         }

         return inRect;
      }

      public void OnMouseUp( Detox.Windows.Forms.MouseEventArgs e )
      {
         if ( true == m_MouseIsDown )
         {
            m_MouseIsDown = false;

            Point point = PointToClient( new Point(e.X, e.Y) );
            
            Detox.Windows.Forms.MouseEventArgs args = new Detox.Windows.Forms.MouseEventArgs( );
            args.X = point.X;
            args.Y = point.Y;
            args.Button = e.Button;

            if ( null != MouseUp ) MouseUp( this, args );
         }

         Control []controls = Controls.ToArray( );

         foreach ( Control control in controls )
         {
            control.OnMouseUp( e );
         }
      }

      public void OnMouseMove( Detox.Windows.Forms.MouseEventArgs e )
      {
         if ( true == m_MouseIsDown )
         {
            Point point = PointToClient( new Point(e.X, e.Y) );
            
            Detox.Windows.Forms.MouseEventArgs args = new Detox.Windows.Forms.MouseEventArgs( );
            args.X = point.X;
            args.Y = point.Y;
            args.Button = e.Button;

            if ( null != MouseMove ) MouseMove( this, args );
         }

         Control []controls = Controls.ToArray( );

         foreach ( Control control in controls )
         {
            control.OnMouseMove( e );
         }
      }

      public virtual void OnPaint(PaintEventArgs e)
      {
         foreach ( Control control in Controls )
         {
            control.OnPaint( e );
         }
      }
   }

   public class UserControl : Control
   {
      public Detox.Drawing.Color BackColor;
      public bool  DoubleBuffered;

      public void Invalidate( /* string description */ )
      {
         if ( null != uScript.Instance )
         {
//            uScript.Instance.Repaint( );
//            Debug.Log( "Invalidate: " + description + "\n" );
            uScript.RequestRepaint();
         }
      }

      public void Focus( )
      {}
   }

   public class Cursor
   {
      static public Point Position;
   }

   public struct Keys
   {
      public int Pressed;

      public const int None    = 0;
      public const int Control = 1 << 0;
      public const int Alt     = 1 << 1;
      public const int Shift   = 1 << 2;

      public const int ControlAlt      = Control + Alt;
      public const int ControlShift    = Control + Shift;
      public const int AltShift        = Alt + Shift;
      public const int ControlAltShift = Control + Alt + Shift;

      public bool Contains(int key)
      {
         return 0 != (key & Pressed);
      }
      
      static public bool operator != (Keys keys, int key)
      {
         return key != keys.Pressed;
      }

      static public bool operator == (Keys keys, int key)
      {
         return key == keys.Pressed;
      }

      public override bool Equals(object o)
      {
         return base.Equals(o);
      }

      public override int GetHashCode()
      {
         return base.GetHashCode( );
      }
   }

   public struct MouseButtons
   {
      public int Buttons;

      public const int Left   = 1 << 0;
      public const int Middle = 1 << 1;
      public const int Right  = 1 << 2;

      public bool Contains(int button)
      {
         return 0 != (button & Buttons);
      }
      
      static public bool operator != (MouseButtons buttons, int button)
      {
         return button != buttons.Buttons;
      }

      static public bool operator == (MouseButtons buttons, int button)
      {
         return button == buttons.Buttons;
      }

      public override bool Equals(object o)
      {
         return base.Equals(o);
      }

      public override int GetHashCode()
      {
         return base.GetHashCode( );
      }
   }

   public class MouseEventArgs : System.EventArgs
   {
      public int X;
      public int Y;
      public int Button;
   }

   public class PaintEventArgs
   {
      public Detox.Drawing.Graphics Graphics;
   }

   public delegate void MouseEventHandler(object sender, MouseEventArgs e);
}

namespace Detox.Drawing
{
   using UnityEditor;
   using UnityEngine;
   using System;

   public struct Point
   {
      static public Point Empty = new Point(0x7fffffff, 0x7fffffff);

      public int X;
      public int Y;

      public Point(int x, int y)
      {
         X = x;
         Y = y;
      }

      static public bool operator == (Point p1, Point p2)
      {
         return (p1.X == p2.X && p1.Y == p2.Y);
      }

      static public bool operator != (Point p1, Point p2)
      {
         return ! (p1.X == p2.X && p1.Y == p2.Y);
      }

      public override bool Equals(System.Object p1)
      {
         if ( false == (p1 is Point) ) return false;

         Point p = (Point) p1;

         return ! (p.X == X && p.Y == Y);
      }

      public override int GetHashCode()
      {
         return base.GetHashCode( );
      }

      public override string ToString ()
      {
         return string.Format ("Point: (X:" + X + ", Y:" + Y + ")");
      }
   }

   public struct PointF
   {
      public float X;
      public float Y;

      public PointF(float x, float y)
      {
         X = x;
         Y = y;
      }
   }

   public struct Size
   {
      public int Width;
      public int Height;

      public Size(int width, int height)
      {
         Width = width;
         Height= height;
      }
   }

   public struct SizeF
   {
      public float Width;
      public float Height;

      public SizeF(float width, float height)
      {
         Width = width;
         Height= height;
      }
   }

   public struct Color
   {
      static public Color Black { get { return new Color(0, 0, 0); } }
      static public Color White { get { return new Color(255, 255, 255); } }
      static public Color LightYellow { get { return new Color(255, 255, 196); } }
      
      public int R;
      public int G;
      public int B;
      public float FR { get { return R / 255.0f; } }
      public float FG { get { return G / 255.0f; } }
      public float FB { get { return B / 255.0f; } }

      static public Color FromArgb(int r, int g, int b)
      {
         Color color = new Color(r, g, b);
         return color;
      }

      public Color(int r, int g, int b)
      {
         R = r;
         G = g;
         B = b;
      }
   }

   public class Font
   {
      public Font(String name, float size)
      {}
   }

   public class SolidBrush
   {
      public Color Color;

      public SolidBrush(Color color)
      {
         Color = color;
      }
   }

   public struct SystemBrushes
   {
      static public SolidBrush ControlLightLight { get { return new SolidBrush( new Color(255, 255, 255)); } }
      static public SolidBrush Black             { get { return new SolidBrush( new Color(  0,   0,   0)); } }
      static public SolidBrush ControlDark       { get { return new SolidBrush( new Color(185, 185, 185)); } }
      static public SolidBrush Variable          { get { return new SolidBrush( new Color(128, 128, 128)); } }
      static public SolidBrush VariableSelected  { get { return new SolidBrush( new Color(255, 255, 128)); } }
   }

   public enum StringAlignment
   {
      Center
   }

   public struct StringFormat
   {
      public StringAlignment Alignment;
      public StringAlignment LineAlignment;
   }

   public class Pen
   {
      public Color Color;
      public float Width;

      public void Dispose( )
      {}

      public Pen( Color color, float width )
      {
         Color = color;
         Width = width;
      }
   }

   public struct Rectangle
   {
      public int X;
      public int Y;
      public int Width;
      public int Height;

      public int Left  { get { return X;} }
      public int Top   { get { return Y; } }
      public int Right { get { return Width + X; } }
      public int Bottom{ get { return Height + Y; } }

      public Rectangle(int x, int y, int width, int height)
      {
         X = x;
         Y = y;
         Width  = width;
         Height = height;
      }

      public bool IntersectsWith(Rectangle rectangle)
      {
         if ( Right  < rectangle.Left ) return false;
         if ( Left   > rectangle.Right ) return false;
         if ( Bottom < rectangle.Top ) return false;
         if ( Top    > rectangle.Bottom ) return false;

         return true;
      }
   }

   public struct RectangleF
   {
      public float X;
      public float Y;
      public float Width;
      public float Height;

      public float Left  { get { return X;} }
      public float Top   { get { return Y; } }
      public float Right { get { return Width + X; } }
      public float Bottom{ get { return Height + Y; } }

      public RectangleF(float x, float y, float width, float height)
      {
         X = x;
         Y = y;
         Width  = width;
         Height = height;
      }

      public bool IntersectsWith(Rectangle rectangle)
      {
         if ( Right  < rectangle.Left ) return false;
         if ( Left   > rectangle.Right ) return false;
         if ( Bottom < rectangle.Top ) return false;
         if ( Top    > rectangle.Bottom ) return false;

         return true;
      }
   }

   public class Region
   {
      private RectangleF m_Bounds;

      public RectangleF GetBounds(Graphics g)  { return m_Bounds; }
      public void SetBounds(RectangleF bounds) { m_Bounds = bounds; }

      public Region(Rectangle rectangle)
      {}

      public void Union(Region region)
      {}

      public void Union(Rectangle rectangle)
      {}
   }

   public class Graphics
   {
      public void DrawRectangle( Pen pen, int x, int y, int width, int height )
      {
         // Box Selection
         UnityEngine.Color NormalColor = GUI.color;
         GUI.color = new UnityEngine.Color(1f, 1f, 0.753f, .5f);
         //GUI.backgroundColor = UnityEngine.Color.white;
         GUI.Box( new Rect(x, y, width, height), "", uScriptConfig.Style.Get("selectionbox"));
         GUI.color = NormalColor;
      }

      public void FillRectangle( string styleName, Rectangle rectangle, string nodeName, Detox.FlowChart.Node node )
      {
         if (styleName.Contains("comment"))
         {
            // Comment box
            GUIStyle commentStyle = uScriptConfig.Style.Get(styleName);

            // Tint the comment box
            if ( ((Detox.ScriptEditor.DisplayNode)node).EntityNode is Detox.ScriptEditor.CommentNode )
            {
               Detox.ScriptEditor.CommentNode comment = (Detox.ScriptEditor.CommentNode) ((Detox.ScriptEditor.DisplayNode)node).EntityNode;

               GUI.backgroundColor = (UnityEngine.Color) comment.NodeColor.DefaultAsObject;
            }

            // Draw the box without the title
            GUI.Box(new Rect(rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height), string.Empty, commentStyle);

            GUI.backgroundColor = UnityEngine.Color.white;

            GUIContent titleContent = new GUIContent(nodeName);

            // Setup the title style and draw it
            GUIStyle titleStyle = new GUIStyle(commentStyle);
            titleStyle.fontSize = 12;
            titleStyle.normal.background = null;
//            titleStyle.normal.textColor = UnityEngine.Color.black;

            Vector2 titleSize = Vector2.zero;
            titleSize = titleStyle.CalcSize(titleContent);

            GUI.Label(new Rect(rectangle.Left, rectangle.Top,
                               titleSize.x, titleSize.y), titleContent, titleStyle);
         }
         else
         {
            // Nodes
            GUIContent nameContent = new GUIContent(nodeName);
            GUIStyle nodeStyle = uScriptConfig.Style.Get(styleName);
            Vector2 nameSize = Vector2.zero;

            GUI.Box(new Rect(rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height), string.Empty, nodeStyle);

            GUIStyle nameStyle = new GUIStyle(nodeStyle);
            nameStyle.normal.background = null;
            nameSize = nameStyle.CalcSize(nameContent);

            if (nameSize.x < rectangle.Width * 1.5f)
            {
               // use rectanble.Height instead of nameSize.y, because
               // named variables should have their name beneath the node.
               //
               GUI.Label(new Rect(rectangle.Left + (rectangle.Width * 0.5f) - (nameSize.x * 0.5f), rectangle.Top,
                                  nameSize.x, rectangle.Height), nameContent, nameStyle);
            }
         }
      }

      public void DrawLine( Pen pen, Point start, Point end )
      {
         Handles.color = new UnityEngine.Color( pen.Color.FR, pen.Color.FG, pen.Color.FB );
         Handles.DrawLine( new UnityEngine.Vector3(start.X, start.Y, 0), new UnityEngine.Vector3(end.X, end.Y, 0) );
      }

      public void DrawString( string s, string styleName, PointF point)
      {
         string [] subString = s.Split( '\n' );

         foreach ( string sub in subString )
         {
            string style = styleName;
            Vector2 size = uScriptConfig.Style.Get(style).CalcSize( new UnityEngine.GUIContent(sub) );

            GUI.Label( new Rect(point.X, point.Y, size.x, size.y), sub, uScriptConfig.Style.Get(style) );
            point.Y += size.y;			
         }
      }

      public void Dispose( )
      {}

      public static SizeF sMeasureString( string s, string styleName )
      {    
         string [] subString = s.Split( '\n' );

         float x = 0;
         float y = 0;

         foreach ( string sub in subString )
         {
            string style = styleName;

            Vector2 size = uScriptConfig.Style.Get(style).CalcSize( new UnityEngine.GUIContent(sub) );
   
            if ( size.x > x ) x = size.x;
            y += size.y;
         }

         return new SizeF( x, y );
      }
   }
}


﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Reflection;

using Detox.Utility;
using Detox.Data;
using Detox.Data.ScriptEditor;

using UnityEngine;

namespace Detox.ScriptEditor
{
   public struct Plug
   {
      public string Name;
      public string FriendlyName;

      public Detox.Data.ScriptEditor.Plug ToPlugData( )
      {
         Detox.Data.ScriptEditor.Plug data = new Detox.Data.ScriptEditor.Plug( );

         data.Name = Name;
         data.FriendlyName = FriendlyName;

         return data;
      }

      public Plug( Detox.Data.ScriptEditor.Plug plugData )
      {
         Name = plugData.Name;
         FriendlyName = plugData.FriendlyName;
      }

      public override int GetHashCode( )
      {
         return base.GetHashCode( );
      }

      public override bool Equals(object o)
      {
         if ( false == (o is Plug) ) return false;
         
         return (((Plug)o) == this);
      }

      public static bool operator == (Plug a, Plug b)
      {
         if ( a.Name != b.Name ) return false; 
         if ( a.FriendlyName != b.FriendlyName ) return false; 
         
         return true;
      }

      public static bool operator != (Plug a, Plug b)
      {
         return ! (a == b);
      }
   }

   public struct Parameter
   {
      [Flags]
      public enum VisibleState
      {
         Visible = 0x1,
         Hidden  = 0x2,
         Locked  = 0x4,
      }

      public static Parameter Empty;

      public VisibleState State;
      public string       Name;
      public string       FriendlyName;
      public string       Default;
      public string       Type;
      public bool         Input;
      public bool         Output;

      public bool IsVisible( ) { return 0 != (State & VisibleState.Visible); }
      public bool IsHidden( )  { return 0 != (State & VisibleState.Hidden); }
      public bool IsLocked( )  { return 0 != (State & VisibleState.Locked); }

      public object DefaultAsObject
      {
         //hardcoded mappings to/from property grid types
         //this should be stored in a mapping file
         get 
         { 
            string type = uScriptConfig.Variable.FriendlyName(Type);

            //Arrays (lists) can't be set through a property grid, only through multiple links
            //which means we never worry about our Default value being an array
            //so we are safe to parse the "List" part out of the type and treat it as
            //if it was just a single value
            type = type.Replace( " List", "" );
            type = type.Trim( );

            if ( type == "Bool" )
            {
               return "true" == Default;
            }
            if ( type == "Color" )
            {
               try
               {
                  string []values = Default.Split( ',' );
                  return new UnityEngine.Color( Single.Parse(values[0]), values.Length > 1 ? Single.Parse(values[1]) : 0, values.Length > 2 ? Single.Parse(values[2]) : 0 );
               }
               catch 
               {
                  return new UnityEngine.Color(0, 0, 0);
               }
            }
            if ( type == "Float" )
            {
               try
               {
                  return Single.Parse(Default);
               }
               catch 
               {
                  return 0.0f;
               }
            }
            if ( type == "Int" )
            {
               try
               {
                  return Int32.Parse(Default);
               }
               catch 
               {
                  return 0.0f;
               }
            }
            if ( type == "Vector2" )
            {
               try
               {
                  string []values = Default.Split( ',' );
                  return new Vector2( Single.Parse(values[0]), values.Length > 1 ? Single.Parse(values[1]) : 0 );
               }
               catch 
               {
                  return new Vector2(0, 0);
               }
            }
            if ( type == "Vector3" )
            {
               try
               {
                  string []values = Default.Split( ',' );
                  return new Vector3( Single.Parse(values[0]), values.Length > 1 ? Single.Parse(values[1]) : 0, values.Length > 2 ? Single.Parse(values[2]) : 0 );
               }
               catch 
               {
                  return new Vector3(0, 0, 0);
               }
            }
            if ( type == "Vector4" )
            {
               try
               {
                  string []values = Default.Split( ',' );
                  return new Vector4( Single.Parse(values[0]), values.Length > 1 ? Single.Parse(values[1]) : 0, 
                                      values.Length > 2 ? Single.Parse(values[2]) : 0, values.Length > 3 ? Single.Parse(values[3]) : 0 );
               }
               catch 
               {
                  return new Vector4(0, 0, 0, 0);
               }
            }
            if ( type == "Rect" )
            {
               try
               {
                  string []values = Default.Split( ',' );
                  return new Rect( Single.Parse(values[0]), values.Length > 1 ? Single.Parse(values[1]) : 0, 
                                      values.Length > 2 ? Single.Parse(values[2]) : 0, values.Length > 3 ? Single.Parse(values[3]) : 0 );
               }
               catch 
               {
                  return new Rect(0, 0, 0, 0);
               }
            }
            if ( type == "Quaternion" )
            {
               try
               {
                  string []values = Default.Split( ',' );
                  return new Quaternion( Single.Parse(values[0]), values.Length > 1 ? Single.Parse(values[1]) : 0, 
                                      values.Length > 2 ? Single.Parse(values[2]) : 0, values.Length > 3 ? Single.Parse(values[3]) : 0 );
               }
               catch 
               {
                  return new Quaternion(0, 0, 0, 0);
               }
            }
            if ( type == "String" )
            {
               return Default;
            }
            System.Type eType = uScript.Instance.GetType(this.Type);
            if (eType == null)
            {
               eType = uScript.Instance.GetAssemblyQualifiedType(this.Type);
               if (eType != null)
               {
                  uScript.Instance.AddType(eType);
               }
            }
            if ( eType != null && typeof(System.Enum).IsAssignableFrom(eType) )
            {
               try
               {
                  return System.Enum.Parse(eType, Default);
               }
               catch 
               {
                  return System.Enum.Parse(eType, System.Enum.GetNames(eType)[0]);
               }
            }

            // should never get here - this is to satisfy the compiler ;)
            return Default;
         }
         set
         {
            string type = uScriptConfig.Variable.FriendlyName(Type);

            //Arrays (lists) can't be set through a property grid, only through multiple links
            //which means we never worry about our Default value being an array
            //so we are safe to parse the "List" part out of the type and treat it as
            //if it was just a single value
            type = type.Replace( " List", "" );
            type = type.Trim( );

            if ( type == "Bool" )  
            {
               try
               {
                  Default = ((bool)value) == true ? "true" : "false";
               }
               catch (Exception)
               {
                  Default = "false";
               }
               return;
            }
            if ( type == "Float" )
            {
               Default = "" + value;
               return;
            }
            if ( type == "Int" )
            {
               Default = "" + value;
               return;
            }
            if ( type == "Vector2" )
            {
               try
               {
                  Vector2 v = (Vector2) value;
                  Default = v.x + "," + v.y;
               }
               catch ( Exception )
               {
                  Default = "0,0";
               }
               return;
            }
            if ( type == "Vector3" )
            {
               try
               {
                  Vector3 v = (Vector3) value;
                  Default = v.x + "," + v.y + "," + v.z;
               }
               catch ( Exception )
               {
                  Default = "0,0,0";
               }
               return;
            }
            if ( type == "Vector4" )
            {
               try
               {
                  Vector4 v = (Vector4) value;
                  Default = v.x + "," + v.y + "," + v.z + "," + v.w;
               }
               catch ( Exception )
               {
                  Default = "0,0,0,0";
               }
               return;
            }
            if ( type == "Rect" )
            {
               try
               {
                  Rect v = (Rect) value;
                  Default = v.x + "," + v.y + "," + v.width + "," + v.height;
               }
               catch ( Exception )
               {
                  Default = "0,0,0,0";
               }
               return;
            }
            if ( type == "Quaternion" )
            {
               try
               {
                  Quaternion v = (Quaternion) value;
                  Default = v.x + "," + v.y + "," + v.z + "," + v.w;
               }
               catch ( Exception )
               {
                  Default = "0,0,0,0";
               }
               return;
            }
            if ( type == "Color" )
            {
               try
               {
                  UnityEngine.Color v = (UnityEngine.Color) value;
                  Default = v.r + "," + v.g + "," + v.b;
               }
               catch ( Exception )
               {
                  Default = "0,0,0";
               }
               return;
            }
            if ( type == "String" )
            {
               Default = value.ToString( );
               return;
            }

            System.Type eType = uScript.Instance.GetType(this.Type);
            if (eType == null)
            {
               eType = uScript.Instance.GetAssemblyQualifiedType(this.Type);
               if (eType != null)
               {
                  uScript.Instance.AddType(eType);
               }
            }
            if ( eType != null && typeof(System.Enum).IsAssignableFrom(eType) )
            {
               Default = value.ToString();
               return;
            }

            // should never get here...
            Default = value.ToString( );
            return;
         }
      }
      
      public override int GetHashCode( )
      {
         return base.GetHashCode( );
      }

      public override bool Equals(object o)
      {
         if ( false == (o is Parameter) ) return false;
         
         return (((Parameter)o) == this);
      }

      public static bool operator == (Parameter a, Parameter b)
      {
         if ( a.Output != b.Output  ) return false; 
         if ( a.Input  != b.Input   ) return false; 
         if ( a.Name   != b.Name    ) return false; 
         if ( a.Type   != b.Type    ) return false; 
         if ( a.Default!= b.Default ) return false; 
         if ( a.State  != b.State   ) return false;
         if ( a.FriendlyName != b.FriendlyName ) return false; 
         
         return true;
      }

      public static bool operator != (Parameter a, Parameter b)
      {
         return ! (a == b);
      }

      public bool IsCompatibleWith(Parameter p)
      {
         if ( Output != p.Output  ) return false; 
         if ( Input  != p.Input   ) return false; 
         if ( Name   != p.Name    ) return false; 
         if ( Type   != p.Type    ) return false; 

         return true;
      }

      public Detox.Data.ScriptEditor.Parameter ToParameterData( )
      {
         Detox.Data.ScriptEditor.Parameter data = new Detox.Data.ScriptEditor.Parameter( );

         data.Output  = Output;
         data.Input   = Input;
         data.Default = Default;
         data.Name    = Name;
         data.Type    = Type;
         data.State   = State != 0 ? (Detox.Data.ScriptEditor.Parameter.VisibleState) (int) State : Detox.Data.ScriptEditor.Parameter.VisibleState.Visible;
         data.FriendlyName = FriendlyName;

         return data;
      }

      public Parameter( Detox.Data.ScriptEditor.Parameter parameterData )
      {
         Output  = parameterData.Output;
         Input   = parameterData.Input;
         Default = parameterData.Default;
         Name    = parameterData.Name;
         Type    = parameterData.Type;
         State   = parameterData.State != 0 ? (Parameter.VisibleState) parameterData.State : Parameter.VisibleState.Visible;
         FriendlyName = parameterData.FriendlyName;
      }
   }
   public interface EntityNode
   {
      Guid Guid { get; set; }
      Point Position { get; set; }
      EntityNodeData NodeData { get; } 
      Parameter[] Parameters { get; set; }

      Parameter ShowComment { get; set; }
      Parameter Comment { get; set; }
      Parameter Instance { get; set; }

      EntityNode Copy( );
   }

   public struct EntityDesc
   {
      public EntityMethod   [] Methods;
      public EntityEvent    [] Events;
      public EntityProperty [] Properties;
      public string Type;
   }

   class ArrayUtil
   {
      static public Parameter[] CopyCompatibleParameters(Parameter []reflectedParameters, Parameter []savedParameters)
      {
         List<Parameter> parameters = new List<Parameter>( );

         foreach ( Parameter reflectedParameter in reflectedParameters )
         {
            bool found = false;

            foreach ( Parameter savedParameter in savedParameters )
            {
               if ( true == reflectedParameter.IsCompatibleWith(savedParameter) )
               {
                  Parameter clone = reflectedParameter;
                  
                  clone.Default = savedParameter.Default;
                  clone.State   = savedParameter.State;

                  parameters.Add( clone );                  
                  found = true;

                  break;
               }
            }

            //can't find a matching default
            //then use the blank one
            if ( false == found )
            {               
               parameters.Add( reflectedParameter );
            }
         }

         return parameters.ToArray( );
      }
      
      static public bool ParametersAreCompatible(Parameter []a, Parameter []b)
      {
         if ( null == a && null != b ) return false;
         if ( null != a && null == b ) return false;

         if ( a.Length != b.Length ) return false;

         for ( int i = 0; i < a.Length; i++ )
         {
            if ( false == a[i].IsCompatibleWith(b[i]) ) return false;
         }

         return true;
      }

      static public bool ArraysAreEqual(string []a, string []b)
      {
         if ( null == a && null != b ) return false;
         if ( null != a && null == b ) return false;

         if ( a.Length != b.Length ) return false;

         for ( int i = 0; i < a.Length; i++ )
         {
            if ( a[i] != b[i] ) return false; 
         }

         return true;
      }

      static public bool ArraysAreEqual(Parameter []a, Parameter []b)
      {
         if ( null == a && null != b ) return false;
         if ( null != a && null == b ) return false;

         if ( a.Length != b.Length ) return false;

         for ( int i = 0; i < a.Length; i++ )
         {
            if ( a[i] != b[i] ) return false;
         }

         return true;
      }

      static public bool ArraysAreEqual(Plug []a, Plug []b)
      {
         if ( null == a && null != b ) return false;
         if ( null != a && null == b ) return false;

         if ( a.Length != b.Length ) return false;

         for ( int i = 0; i < a.Length; i++ )
         {
            if ( a[i] != b[i] ) return false;
         }

         return true;
      }

      static public Detox.Data.ScriptEditor.Parameter []ToParameterDatas(Parameter []p)
      {
         List<Detox.Data.ScriptEditor.Parameter> data = new List<Detox.Data.ScriptEditor.Parameter>( );

         foreach ( Parameter parameter in p )
         {
            data.Add( parameter.ToParameterData( ) );
         }

         return data.ToArray( );
      }

      static public Parameter []ToParameters(Detox.Data.ScriptEditor.Parameter []p)
      {
         List<Parameter> parameters = new List<Parameter>( );

         foreach ( Detox.Data.ScriptEditor.Parameter data in p )
         {
            parameters.Add( new Parameter(data) );
         }

         return parameters.ToArray( );
      }

      static public Detox.Data.ScriptEditor.Plug []ToPlugDatas(Plug []p)
      {
         List<Detox.Data.ScriptEditor.Plug> data = new List<Detox.Data.ScriptEditor.Plug>( );

         foreach ( Plug plug in p )
         {
            data.Add( plug.ToPlugData( ) );
         }

         return data.ToArray( );
      }

      static public Plug []ToPlugs(Detox.Data.ScriptEditor.Plug []p)
      {
         List<Plug> plugs = new List<Plug>( );

         foreach ( Detox.Data.ScriptEditor.Plug data in p )
         {
            plugs.Add( new Plug(data) );
         }

         return plugs.ToArray( );
      }
   }

   public struct LinkNode : EntityNode
   {
      public struct Connection
      {
         public Guid   Guid;
         public string Anchor;
      }

      public override int GetHashCode()
      {
         return base.GetHashCode();
      }

      public override bool Equals(object obj)
      {
         if ( obj.GetType() != typeof(LinkNode) ) return false;

         LinkNode node = (LinkNode) obj;

         if ( Source.Anchor != node.Source.Anchor ) return false;
         if ( Source.Guid   != node.Source.Guid )   return false;

         if ( Destination.Anchor != node.Destination.Anchor ) return false;
         if ( Destination.Guid   != node.Destination.Guid )   return false;

         if ( Guid != node.Guid ) return false;

         return true;
      }

      public Parameter Instance { get { return Parameter.Empty; } set {} }
      public Parameter[] Parameters { get { return new Parameter[ 0 ]; } set { } }

      public EntityNode Copy( )
      {
         LinkNode linkNode   = new LinkNode( );
         linkNode.Source     = Source;
         linkNode.Destination= Destination;
         linkNode.Guid       = Guid.NewGuid( );

         return linkNode;
      }

      public EntityNodeData NodeData
      { 
         get
         {
            LinkNodeData nodeData = new LinkNodeData( );
            nodeData.Guid     = m_Guid;
            nodeData.Source.Guid   = Source.Guid;
            nodeData.Source.Anchor = Source.Anchor;
            nodeData.Destination.Guid   = Destination.Guid;
            nodeData.Destination.Anchor = Destination.Anchor;

            return nodeData;
         }
      }


      public Parameter ShowComment 
      {
         get { return Parameter.Empty; }
         set { ; } 
      }

      public Parameter Comment 
      {
         get { return Parameter.Empty; }
         set { ; } 
      }

      private Guid m_Guid;
      public Guid Guid
      {
         get { return m_Guid; }
         set { m_Guid = value; }
      }

      public Connection Source;
      public Connection Destination;

      public Point Position { get { throw new Exception("Link has no position"); } set { throw new Exception("Link has no position"); } }

      public LinkNode(Guid source, string sourceAnchor, Guid dest, string destAnchor )
      {
         m_Guid = Guid.NewGuid( );
 
         Source.Guid   = source;
         Source.Anchor = sourceAnchor;

         Destination.Guid  = dest;
         Destination.Anchor= destAnchor;
      }

      public LinkNode(LinkNodeData data)
      {
         m_Guid = data.Guid;
         Source.Guid   = data.Source.Guid;
         Source.Anchor = data.Source.Anchor;
         Destination.Guid   = data.Destination.Guid;
         Destination.Anchor = data.Destination.Anchor;
      }
   }

   public struct ExternalConnection : EntityNode
   {
      public EntityNode Copy( )
      {
         ExternalConnection connection = new ExternalConnection( );
         connection.Connection     = Connection;
         connection.Position       = Position;
         connection.Guid           = Guid.NewGuid( );
         connection.Name           = Name;
         connection.ShowComment    = ShowComment;
         connection.Comment        = Comment;

         return connection;
      }
   
      public EntityNodeData NodeData
      {
         get
         {
            ExternalConnectionData nodeData = new ExternalConnectionData( );
            nodeData.Position.X = Position.X;
            nodeData.Position.Y = Position.Y;
            nodeData.Name       = Name.ToParameterData( );
            nodeData.Guid       = Guid;
            nodeData.ShowComment= ShowComment.ToParameterData( );
            nodeData.Comment    = Comment.ToParameterData( );
            return nodeData;
         }
      }

      public override int GetHashCode()
      {
         return base.GetHashCode();
      }

      public override bool Equals(object obj)
      {
         if ( obj.GetType() != typeof(ExternalConnection) ) return false;

         ExternalConnection node = (ExternalConnection) obj;

         if ( Connection    != node.Connection    ) return false;
         if ( Guid          != node.Guid )          return false;
         if ( Position      != node.Position )      return false;
         if ( Name          != node.Name )          return false;
         if ( false == ArrayUtil.ArraysAreEqual(Parameters, node.Parameters) ) return false;

         return true;
      }
      
      public Parameter Instance { get { return Parameter.Empty; } set {} }

      private Parameter m_ShowComment;
      private Parameter m_Comment;

      public Parameter ShowComment 
      {
         get { return m_ShowComment; }
         set { m_ShowComment = value; } 
      }

      public Parameter Comment 
      {
         get { return m_Comment; }
         set { m_Comment = value; } 
      }

      public Parameter Name;

      public Parameter[] Parameters 
      { 
         get { return new Parameter[] { Name }; } 
         set { Name = value[ 0 ]; }
      }
      
      public string Connection;

      private Point m_Position;
      public Point Position { get { return m_Position; } set { m_Position = value; } }

      private Guid m_Guid;
      public Guid Guid
      {
         get { return m_Guid; }
         set { m_Guid = value; }
      }

      public ExternalConnection( Guid guid )
      {
         m_Guid = guid;
         m_Position = Point.Empty;
         Connection = "Connection";

         Name = new Parameter( );
         Name.Name    = "Name";
         Name.FriendlyName = "Name";
         Name.Default = "";
         Name.Type    = "String";
         Name.Input   = true;
         Name.Output  = false;
         Name.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;

         m_ShowComment = new Parameter( );
         m_ShowComment.Name    = "Output Comment";
         m_ShowComment.FriendlyName = "Output Comment";
         m_ShowComment.Default = "false";
         m_ShowComment.Type    = "Bool";
         m_ShowComment.Input   = true;
         m_ShowComment.Output  = false;
         m_ShowComment.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;

         m_Comment = new Parameter( );
         m_Comment.Name    = "Comment";
         m_Comment.FriendlyName = "Comment";
         m_Comment.Default = "";
         m_Comment.Type    = "String";
         m_Comment.Input   = true;
         m_Comment.Output  = false;
         m_Comment.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
      }
   }

   public struct OwnerConnection : EntityNode
   {
      public EntityNode Copy( )
      {
         OwnerConnection connection = new OwnerConnection( );
         connection.Connection     = Connection;
         connection.Position       = Position;
         connection.Guid           = Guid.NewGuid( );
         connection.ShowComment    = ShowComment;
         connection.Comment        = Comment;

         return connection;
      }
   
      public EntityNodeData NodeData
      {
         get
         {
            OwnerConnectionData nodeData = new OwnerConnectionData( );
            nodeData.Position.X = Position.X;
            nodeData.Position.Y = Position.Y;
            nodeData.Guid       = Guid;
            nodeData.ShowComment= ShowComment.ToParameterData( );
            nodeData.Comment    = Comment.ToParameterData( );
            return nodeData;
         }
      }

      public override int GetHashCode()
      {
         return base.GetHashCode();
      }

      public override bool Equals(object obj)
      {
         if ( obj.GetType() != typeof(OwnerConnection) ) return false;

         OwnerConnection node = (OwnerConnection) obj;

         if ( Connection    != node.Connection    ) return false;
         if ( Guid          != node.Guid )          return false;
         if ( Position      != node.Position )      return false;
         if ( false == ArrayUtil.ArraysAreEqual(Parameters, node.Parameters) ) return false;

         return true;
      }
      
      public Parameter Instance { get { return Parameter.Empty; } set {} }

      private Parameter m_ShowComment;
      private Parameter m_Comment;

      public Parameter ShowComment 
      {
         get { return m_ShowComment; }
         set { m_ShowComment = value; } 
      }

      public Parameter Comment 
      {
         get { return m_Comment; }
         set { m_Comment = value; } 
      }

      public Parameter Connection;

      public Parameter[] Parameters 
      { 
         get { return new Parameter[1] { Connection }; } 
         set { }
      }
      
      private Point m_Position;
      public Point Position { get { return m_Position; } set { m_Position = value; } }

      private Guid m_Guid;
      public Guid Guid
      {
         get { return m_Guid; }
         set { m_Guid = value; }
      }

      public OwnerConnection( Guid guid )
      {
         m_Guid = guid;
         m_Position = Point.Empty;
      
         m_ShowComment = new Parameter( );
         m_ShowComment.Name    = "Output Comment";
         m_ShowComment.FriendlyName = "Output Comment";
         m_ShowComment.Default = "false";
         m_ShowComment.Type    = "Bool";
         m_ShowComment.Input   = true;
         m_ShowComment.Output  = false;
         m_ShowComment.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;;

         m_Comment = new Parameter( );
         m_Comment.Name    = "Comment";
         m_Comment.FriendlyName = "Comment";
         m_Comment.Default = "";
         m_Comment.Type    = "String";
         m_Comment.Input   = true;
         m_Comment.Output  = false;
         m_Comment.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;;

         Connection = new Parameter( );
         Connection.Name = "Connection";
         Connection.FriendlyName = "Connection";
         Connection.Default = "";
         Connection.State  = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         Connection.Input  = false;
         Connection.Output = true;
         Connection.Type   = typeof(UnityEngine.GameObject).ToString( );
      }
   }
   
   public struct EntityMethod : EntityNode
   {
      public EntityNode Copy( )
      {
         EntityMethod method = new EntityMethod( );
         method.Instance  = Instance;
         method.Parameters= Parameters;
         method.Input     = Input;
         method.Output    = Output;
         method.Position  = Position;
         method.Guid      = Guid.NewGuid( );
         method.ComponentType = ComponentType;
         return method;
      }

      public EntityNodeData NodeData 
      { 
         get
         {
            EntityMethodData nodeData = new EntityMethodData( );
            nodeData.Instance      = Instance.ToParameterData( );
            nodeData.ComponentType = ComponentType;
            nodeData.Input     = Input.ToPlugData( );
            nodeData.Output    = Output.ToPlugData( );
            nodeData.Position.X= Position.X;
            nodeData.Position.Y= Position.Y;
            nodeData.Guid      = Guid;
            nodeData.Parameters  = ArrayUtil.ToParameterDatas( Parameters );

            return nodeData;
         }
      }

      public override int GetHashCode()
      {
         return base.GetHashCode();
      }

      public override bool Equals(object obj)
      {
         if ( obj.GetType() != typeof(EntityMethod) ) return false;

         EntityMethod node = (EntityMethod) obj;

         if ( Instance != node.Instance ) return false;
         if ( ComponentType != node.ComponentType ) return false;
         
         if ( false == ArrayUtil.ArraysAreEqual(node.Parameters, Parameters) ) return false;

         if ( Input  != node.Input ) return false;
         if ( Output != node.Output ) return false;
         if ( Guid   != node.Guid ) return false;
         if ( Position != node.Position ) return false;
         if ( Comment != node.Comment ) return false;
         if ( ShowComment != node.ShowComment ) return false;
         return true;
      }

      private Parameter m_ShowComment;
      private Parameter m_Comment;

      public Parameter ShowComment 
      {
         get { return m_ShowComment; }
         set { m_ShowComment = value; } 
      }

      public Parameter Comment 
      {
         get { return m_Comment; }
         set { m_Comment = value; } 
      }

      public Plug Input;
      public Plug Output;

      public Parameter m_Instance;
      public Parameter Instance { get { return m_Instance; } set { m_Instance = value; } }

      private Parameter[] m_Parameters;
      public Parameter[] Parameters 
      { 
         get { return m_Parameters; } 
         set { m_Parameters = value; } 
      }

      private Point m_Position;
      public Point Position { get { return m_Position; } set { m_Position = value; } }

      private Guid m_Guid;
      public Guid Guid
      {
         get { return m_Guid; }
         set { m_Guid = value; }
      }

      public string ComponentType;

      public EntityMethod(string type, string name, string friendlyName)       
      { 
         ComponentType = type;

         m_Instance.Default = "";
         m_Instance.Type   = typeof(UnityEngine.GameObject).ToString( );
         m_Instance.Input  = true;
         m_Instance.Output = false;
         m_Instance.State  = Parameter.VisibleState.Visible;
         m_Instance.Name   = "Instance";
         m_Instance.FriendlyName = "Instance";
         
         m_ShowComment = new Parameter( );
         m_ShowComment.Name    = "Output Comment";
         m_ShowComment.FriendlyName = "Output Comment";
         m_ShowComment.Default = "false";
         m_ShowComment.Type    = "Bool";
         m_ShowComment.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         m_ShowComment.Input   = true;
         m_ShowComment.Output  = false;

         m_Comment = new Parameter( );
         m_Comment.Name    = "Comment";
         m_Comment.FriendlyName = "Comment";
         m_Comment.Default = "";
         m_Comment.Type    = "String";
         m_Comment.Input   = true;
         m_Comment.Output  = false;
         m_Comment.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;

         m_Guid = Guid.NewGuid( );

         Input.Name = name;
         Input.FriendlyName = name;

         Output.Name = "Output";
         Output.FriendlyName = "Output";

         m_Position = Point.Empty; 
         m_Parameters = new Parameter[ 0 ];
      }

      public EntityMethod(EntityMethodData data)       
      { 
         ComponentType = data.ComponentType;

         m_Instance    = new Parameter( data.Instance );
         m_ShowComment = new Parameter( data.ShowComment );
         m_Comment     = new Parameter( data.Comment );

         m_Guid = data.Guid;

         Input  = new Plug( data.Input );
         Output = new Plug( data.Output );

         m_Position = data.Position; 
         m_Parameters = ArrayUtil.ToParameters( data.Parameters );
      }
   }

   public struct CommentNode : EntityNode
   {
      public EntityNode Copy( )
      {
         CommentNode commentNode = new CommentNode( );
         commentNode.Parameters = Parameters;
         commentNode.Position   = Position;
         commentNode.Guid       = Guid.NewGuid( );
 
         return commentNode;
      }

      public EntityNodeData NodeData
      { 
         get
         {
            CommentNodeData nodeData = new CommentNodeData( );
            nodeData.BodyText       = BodyText.ToParameterData( );
            nodeData.BodyTextColor  = BodyTextColor.ToParameterData( );
            nodeData.TitleText      = TitleText.ToParameterData( );
            nodeData.TitleTextColor = TitleTextColor.ToParameterData( );
            nodeData.NodeColor      = NodeColor.ToParameterData( );
            nodeData.Size       = Size.ToParameterData( );
            nodeData.Position.X = Position.X;
            nodeData.Position.Y = Position.Y;
            nodeData.Guid       = Guid;
         
            return nodeData;
         }
      }

      public override int GetHashCode()
      {
         return base.GetHashCode();
      }

      public override bool Equals(object obj)
      {
         if ( obj.GetType() != typeof(CommentNode) ) return false;

         CommentNode node = (CommentNode) obj;

         if ( false == ArrayUtil.ArraysAreEqual(Parameters, node.Parameters) ) return false;
         if ( Position != node.Position ) return false;
         if ( Guid != node.Guid ) return false;

         return true;
      }

      public Parameter Instance { get { return Parameter.Empty; } set {} }

      public Parameter ShowComment 
      {
         get { return Parameter.Empty; }
         set { ; } 
      }

      public Parameter Comment 
      {
         get { return Parameter.Empty; }
         set { ; } 
      }

      private Parameter m_BodyText;
      private Parameter m_BodyTextColor;
      private Parameter m_TitleText;
      private Parameter m_TitleTextColor;
      private Parameter m_NodeColor;
      private Parameter m_Size;

      public Parameter[] Parameters 
      { 
         get { return new Parameter[] { m_TitleText, m_TitleTextColor, m_BodyText, m_BodyTextColor, m_NodeColor, m_Size}; } 
         set { m_TitleText = value[ 0 ]; m_TitleTextColor = value[ 1 ]; m_BodyText = value[ 2 ]; m_BodyTextColor = value[ 3 ]; m_NodeColor = value[ 4 ]; m_Size = value[ 5 ]; } 
      }
      
      public Parameter BodyText       { get { return m_BodyText; } set { m_BodyText = value; } }
      public Parameter BodyTextColor  { get { return m_BodyTextColor; } set { m_BodyTextColor = value; } }
      public Parameter TitleText      { get { return m_TitleText; } set { m_TitleText = value; } }
      public Parameter TitleTextColor { get { return m_TitleTextColor; } set { m_TitleTextColor = value; } }
      public Parameter NodeColor      { get { return m_NodeColor; } set { m_NodeColor= value; } }

      public Parameter Size { get { return m_Size; } set { m_Size = value; } }

      private Point m_Position;
      public Point Position { get { return m_Position; } set { m_Position = value; } }

      private Guid m_Guid;
      public Guid Guid
      {
         get { return m_Guid; }
         set { m_Guid = value; }
      }

      public CommentNode(string titleText)
      { 
         m_Position = Point.Empty;
         m_Guid     = Guid.NewGuid( );

         m_TitleText = new Parameter( );
         m_TitleText.State = Parameter.VisibleState.Visible;
         m_TitleText.Name = "Title";
         m_TitleText.FriendlyName = "Title";
         m_TitleText.Default = "Comment";
         m_TitleText.Type = "String";
         m_TitleText.Input = true;
         m_TitleText.Output = false;

         m_TitleTextColor = new Parameter( );
         m_TitleTextColor.State = Parameter.VisibleState.Visible;
         m_TitleTextColor.Name = "TitleColor";
         m_TitleTextColor.FriendlyName = "Title Color";
         m_TitleTextColor.Default = "50, 50, 127";
         m_TitleTextColor.Type = "Color";
         m_TitleTextColor.Input = true;
         m_TitleTextColor.Output = false;

         m_BodyText = new Parameter( );
         m_BodyText.State = Parameter.VisibleState.Visible;
         m_BodyText.Name = "Body";
         m_BodyText.FriendlyName = "Body";
         m_BodyText.Default = "";
         m_BodyText.Type = "TextArea";
         m_BodyText.Input = true;
         m_BodyText.Output = false;

         m_BodyTextColor = new Parameter( );
         m_BodyTextColor.State = Parameter.VisibleState.Visible;
         m_BodyTextColor.Name = "BodyColor";
         m_BodyTextColor.FriendlyName = "Body Color";
         m_BodyTextColor.Default = "50, 127, 50";
         m_BodyTextColor.Type = "Color";
         m_BodyTextColor.Input = true;
         m_BodyTextColor.Output = false;

         m_NodeColor = new Parameter( );
         m_NodeColor.State = Parameter.VisibleState.Visible;
         m_NodeColor.Name = "NodeColor";
         m_NodeColor.FriendlyName = "Node Color";
         m_NodeColor.Default = "127, 127, 127";
         m_NodeColor.Type = "Color";
         m_NodeColor.Input = true;
         m_NodeColor.Output = false;

         m_Size.Name  = "Size";
         m_Size.State = Parameter.VisibleState.Visible;
         m_Size.FriendlyName = "Size";
         m_Size.Type  = "Int[]";
         m_Size.Input = true;
         m_Size.Output= false;
         m_Size.Default = "0, 0";
      }
   }

   public struct EntityEvent : EntityNode
   {
      //assumes the caller knows the parameters match up
      //and the entities should be consolidated
      public static EntityEvent Consolidator(EntityEvent []events)
      {
         EntityEvent consolidatedEvent = events[ 0 ];

         List<Plug> outputs = new List<Plug>( );

         foreach ( EntityEvent entityEvent in events )
         {
            foreach ( Plug output in entityEvent.Outputs )
            {
               outputs.Add( output );
            }
         }

         consolidatedEvent.Outputs = outputs.ToArray( );

         return consolidatedEvent;
      }

      public EntityNode Copy( )
      {
         EntityEvent entityEvent   = new EntityEvent( );
         entityEvent.Instance      = Instance;
         entityEvent.EventArgs     = EventArgs;
         entityEvent.Parameters    = Parameters;
         entityEvent.Position      = Position;
         entityEvent.FriendlyType  = FriendlyType;
         entityEvent.ComponentType = ComponentType;
         entityEvent.Outputs       = Outputs;
         entityEvent.Guid          = Guid.NewGuid( );
         entityEvent.Comment       = Comment;
         entityEvent.ShowComment   = ShowComment;
      
         return entityEvent;
      }

      public EntityNodeData NodeData
      { 
         get
         {
            EntityEventData nodeData = new EntityEventData( );
            nodeData.Position.X= Position.X;
            nodeData.Position.Y= Position.Y;
            nodeData.EventArgs = EventArgs;
            nodeData.Instance  = Instance.ToParameterData( );
            nodeData.Outputs   = ArrayUtil.ToPlugDatas( Outputs );
            nodeData.Guid      = Guid;
            nodeData.Parameters= ArrayUtil.ToParameterDatas( Parameters );
            nodeData.Comment       = Comment.ToParameterData( );
            nodeData.ShowComment   = ShowComment.ToParameterData( );
            nodeData.ComponentType = ComponentType;

            return nodeData;
         }
      }

      public override int GetHashCode()
      {
         return base.GetHashCode();
      }
         
      public override bool Equals(object obj)
      {
         if ( obj.GetType() != typeof(EntityEvent) ) return false;

         EntityEvent node = (EntityEvent) obj;

         if ( Instance != node.Instance ) return false;

         if ( false == ArrayUtil.ArraysAreEqual(node.Parameters, Parameters) ) return false;

         if ( Position != node.Position ) return false;
         if ( Guid != node.Guid ) return false;

         if ( FriendlyType != node.FriendlyType ) return false;

         if ( false == ArrayUtil.ArraysAreEqual(Outputs, node.Outputs) ) return false;

         if ( ShowComment != node.ShowComment ) return false;
         if ( Comment != node.Comment ) return false;

         if ( ComponentType != node.ComponentType ) return false;

         return true;
      }

      private Parameter m_ShowComment;
      private Parameter m_Comment;

      public Parameter ShowComment 
      {
         get { return m_ShowComment; }
         set { m_ShowComment = value; } 
      }

      public Parameter Comment 
      {
         get { return m_Comment; }
         set { m_Comment = value; } 
      }

      public string EventArgs;
      public string FriendlyType;

      public Parameter m_Instance;
      public Parameter Instance { get { return m_Instance; } set { m_Instance = value; } }

      public Plug []Outputs;
      
      private Parameter[] m_Parameters;
      public Parameter[] Parameters { get { return m_Parameters; } set { m_Parameters = value; } }

      private Point m_Position;
      public Point Position { get { return m_Position; } set { m_Position = value; } }

      public string ComponentType;

      private Guid m_Guid;
      public Guid Guid
      {
         get { return m_Guid; }
         set { m_Guid = value; }
      }

      public EntityEvent(string type, string friendlyType, Plug [] outputs)
      { 
         Outputs = outputs;

         FriendlyType = friendlyType;

         ComponentType = type;

         m_Instance.Name  = "Instance";
         m_Instance.State = Parameter.VisibleState.Visible;
         m_Instance.FriendlyName = "Instance";
         m_Instance.Type    = typeof(UnityEngine.GameObject).ToString( );
         m_Instance.Input   = true;
         m_Instance.Output  = false;
         m_Instance.Default = "";

         m_Guid   = Guid.NewGuid( ); 
         
         m_Position = Point.Empty; 
         m_Parameters  = new Parameter[ 0 ];

         m_ShowComment = new Parameter( );
         m_ShowComment.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         m_ShowComment.Name    = "Output Comment";
         m_ShowComment.FriendlyName = "Output Comment";
         m_ShowComment.Default = "false";
         m_ShowComment.Type    = "Bool";
         m_ShowComment.Input   = true;
         m_ShowComment.Output  = false;

         m_Comment = new Parameter( );
         m_Comment.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         m_Comment.Name    = "Comment";
         m_Comment.FriendlyName = "Comment";
         m_Comment.Default = "";
         m_Comment.Type    = "String";
         m_Comment.Input   = true;
         m_Comment.Output  = false;

         EventArgs = "System.EventArgs";
      }

      public EntityEvent(EntityEventData data)
      { 
         Outputs = ArrayUtil.ToPlugs( data.Outputs );

         FriendlyType  = data.Instance.Type;
         ComponentType = data.Instance.Type;

         m_Guid     = data.Guid; 
         m_Position = data.Position; 

         m_Instance    = new Parameter( data.Instance );
         m_ShowComment = new Parameter( data.ShowComment );
         m_Comment     = new Parameter( data.Comment );
         m_Parameters  = ArrayUtil.ToParameters( data.Parameters );

         EventArgs = data.EventArgs;
      }
   }

   public struct LogicNode : EntityNode
   {
      public EntityNode Copy( )
      {
         LogicNode node = new LogicNode( );
         node.Type      = Type;
         node.FriendlyName = FriendlyName;
         node.Inputs    = Inputs;
         node.Parameters= Parameters;
         node.Outputs   = Outputs;
         node.Position  = Position;
         node.Events    = Events;
         node.Drivens   = Drivens;
         node.Guid      = Guid.NewGuid( );
         node.Comment    = Comment;
         node.ShowComment= ShowComment;
         return node;
      }

      public EntityNodeData NodeData
      { 
         get
         {
            LogicNodeData nodeData = new LogicNodeData( );
            nodeData.Type      = Type;
            nodeData.FriendlyName = FriendlyName;
            nodeData.Position.X= Position.X;
            nodeData.Position.Y= Position.Y;
            nodeData.Parameters= ArrayUtil.ToParameterDatas( Parameters );
            nodeData.Inputs    = ArrayUtil.ToPlugDatas( Inputs );
            nodeData.Outputs   = ArrayUtil.ToPlugDatas( Outputs );
            nodeData.Events    = ArrayUtil.ToPlugDatas( Events );
            nodeData.Drivens   = Drivens;
            nodeData.Guid      = Guid;
            nodeData.Comment     = Comment.ToParameterData( );
            nodeData.ShowComment = ShowComment.ToParameterData( );

            return nodeData;
         }
      }

      public override int GetHashCode()
      {
         return base.GetHashCode();
      }

      public override bool Equals(object obj)
      {
         if ( obj.GetType() != typeof(LogicNode) ) return false;

         LogicNode node = (LogicNode) obj;

         if ( Type != node.Type ) return false;
         if ( FriendlyName != node.FriendlyName ) return false;
         
         if ( false == ArrayUtil.ArraysAreEqual(node.Inputs, Inputs) ) return false;
         if ( false == ArrayUtil.ArraysAreEqual(node.Parameters, Parameters) ) return false;
         if ( false == ArrayUtil.ArraysAreEqual(node.Outputs, Outputs) ) return false;
         if ( false == ArrayUtil.ArraysAreEqual(node.Events, Events) ) return false;
         if ( false == ArrayUtil.ArraysAreEqual(node.Drivens, Drivens) ) return false;

         if ( Position != node.Position ) return false;
         if ( Guid != node.Guid ) return false;

         if ( ShowComment != node.ShowComment ) return false;
         if ( Comment != node.Comment ) return false;

         return true;
      }

      public string    Type;
      public string    FriendlyName;
      public Plug    []Inputs;
      public Plug    []Outputs;
      public Plug    []Events;
      public string  []Drivens;

      private Parameter m_ShowComment;
      private Parameter m_Comment;

      public Parameter ShowComment 
      {
         get { return m_ShowComment; }
         set { m_ShowComment = value; } 
      }

      public Parameter Comment 
      {
         get { return m_Comment; }
         set { m_Comment = value; } 
      }

      public Parameter Instance { get { return Parameter.Empty; } set {} }

      private Parameter[] m_Parameters;
      public Parameter[] Parameters { get { return m_Parameters; } set { m_Parameters = value; } }

      private Point m_Position;
      public Point Position { get { return m_Position; } set { m_Position = value; } }

      private Guid m_Guid;

      public Guid Guid
      {
         get { return m_Guid; }
         set { m_Guid = value; }
      }

      public LogicNode(string type, string friendlyName)       
      { 
         Type = type; 
         FriendlyName = friendlyName;

         m_Guid = Guid.NewGuid( );

         Drivens      = new string[ 0 ];
         Inputs       = new Plug[ 0 ];
         Outputs      = new Plug[ 0 ];
         Events       = new Plug[ 0 ];
         m_Parameters = new Parameter[ 0 ];

         m_Position = Point.Empty; 

         m_ShowComment = new Parameter( );
         m_ShowComment.Name    = "Output Comment";
         m_ShowComment.FriendlyName = "Output Comment";
         m_ShowComment.Default = "false";
         m_ShowComment.Type    = "Bool";
         m_ShowComment.Input   = true;
         m_ShowComment.Output  = false;
         m_ShowComment.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;

         m_Comment = new Parameter( );
         m_Comment.Name    = "Comment";
         m_Comment.FriendlyName = "Comment";
         m_Comment.Default = "";
         m_Comment.Type    = "String";
         m_Comment.Input   = true;
         m_Comment.Output  = false;
         m_Comment.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
      }

      public LogicNode(LogicNodeData data)       
      { 
         Type = data.Type; 
         FriendlyName = data.FriendlyName;

         m_Guid = data.Guid;

         Drivens      = data.Drivens;
         Inputs       = ArrayUtil.ToPlugs(data.Inputs);
         Outputs      = ArrayUtil.ToPlugs(data.Outputs);
         Events       = ArrayUtil.ToPlugs(data.Events);
         m_Parameters = ArrayUtil.ToParameters(data.Parameters);

         m_Position = data.Position; 

         m_ShowComment = new Parameter(data.ShowComment);
         m_Comment     = new Parameter(data.Comment);
      }
   }

   public struct EntityProperty : EntityNode
   {
      public EntityNode Copy( )
      {
         EntityProperty entityProperty = new EntityProperty( );
         entityProperty.Instance  = Instance;
         entityProperty.Parameter = Parameter;
         entityProperty.Position  = Position;
         entityProperty.Guid      = Guid.NewGuid( );
      
         return entityProperty;
      }

      public EntityNodeData NodeData
      { 
         get
         {
            EntityPropertyData nodeData = new EntityPropertyData( );
            nodeData.Instance  = Instance.ToParameterData( );
            nodeData.Parameter = Parameter.ToParameterData( );
            nodeData.Position.X= Position.X;
            nodeData.Position.Y= Position.Y;
            nodeData.Guid      = Guid;
            
            return nodeData;
         }
      }

      public override int GetHashCode()
      {
         return base.GetHashCode();
      }

      public override bool Equals(object obj)
      {
         if ( obj.GetType() != typeof(EntityProperty) ) return false;

         EntityProperty node = (EntityProperty) obj;

         if ( Instance != node.Instance ) return false;
         if ( Parameter!= node.Parameter ) return false;
         if ( Position != node.Position ) return false;
         if ( Guid != node.Guid ) return false;

         return true;
      }

      public Parameter ShowComment 
      {
         get { return Parameter.Empty; }
         set { ; } 
      }

      public Parameter Comment 
      {
         get { return Parameter.Empty; }
         set { ; } 
      }

      private Parameter m_Parameter;
      public Parameter[] Parameters { get { return new Parameter[] { m_Parameter }; } set { m_Parameter = value[ 0 ]; } }
      public Parameter Parameter { get { return m_Parameter; } set { m_Parameter = value; } }

      public Parameter m_Instance;
      public Parameter Instance { get { return m_Instance; } set { m_Instance = value; } }

      private Point m_Position;
      public Point Position { get { return m_Position; } set { m_Position = value; } }

      private Guid m_Guid;
      public Guid Guid
      {
         get { return m_Guid; }
         set { m_Guid = value; }
      }

      public EntityProperty(string name, string friendlyName, string entityType, string valueType, bool input, bool output)
      { 
         m_Instance.Name   = "Instance";
         m_Instance.FriendlyName = "Instance";
         m_Instance.State  = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         m_Instance.Type   = entityType;
         m_Instance.Input  = true;
         m_Instance.Output = false;
         m_Instance.Default= "";

         m_Parameter = new Parameter( );
         m_Parameter.Name    = name;
         m_Parameter.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         m_Parameter.FriendlyName = friendlyName;
         m_Parameter.Input   = input;
         m_Parameter.Output  = output;
         m_Parameter.Default = "";
         m_Parameter.Type    = valueType;

         m_Position = Point.Empty; 
         m_Guid     = Guid.NewGuid( ); 
      }

      public EntityProperty(EntityPropertyData data)
      { 
         m_Instance  = new Parameter( data.Instance );
         m_Parameter = new Parameter( data.Parameter );

         m_Position = data.Position; 
         m_Guid     = data.Guid; 
      }
   }

   public struct LocalNode : EntityNode
   {
      public EntityNode Copy( )
      {
         LocalNode localNode  = new LocalNode( );
         localNode.Parameters = Parameters;
         localNode.Position   = Position;
         localNode.Guid       = Guid.NewGuid( );
         
         return localNode;
      }

      public EntityNodeData NodeData
      { 
         get
         {
            LocalNodeData nodeData = new LocalNodeData( );
            nodeData.Parameters = ArrayUtil.ToParameterDatas( Parameters );
            nodeData.Position.X = Position.X;
            nodeData.Position.Y = Position.Y;
            nodeData.Guid       = Guid;

            return nodeData;
         }
      }

      public override int GetHashCode()
      {
         return base.GetHashCode();
      }

      public override bool Equals(object obj)
      {
         if ( obj.GetType() != typeof(LocalNode) ) return false;

         LocalNode node = (LocalNode) obj;

         if ( false == ArrayUtil.ArraysAreEqual(Parameters, node.Parameters) ) return false;

         if ( Position != node.Position ) return false;
         if ( Guid != node.Guid ) return false;
         
         return true;
      }

      public Parameter Instance { get { return Parameter.Empty; } set {} }

      public Parameter[] Parameters { get { return new Parameter[] {m_Name, m_Value}; } set { m_Name = value[0]; m_Value = value[1];} }

      private Parameter m_Name;
      private Parameter m_Value;

      public Parameter Name
      {
         get { return m_Name; }
         set { m_Name = value; }
      }

      public Parameter Value
      {
         get { return m_Value; }
         set { m_Value = value; }
      }

      private Guid m_Guid;
      public Guid Guid
      {
         get { return m_Guid; }
         set { m_Guid = value; }
      }

      private Point m_Position;
      public Point Position { get { return m_Position; } set { m_Position = value; } }
      
      public Parameter ShowComment 
      {
         get { return Parameter.Empty; }
         set { ; } 
      }

      public Parameter Comment 
      {
         get { return Parameter.Empty; }
         set { ; } 
      }

      public LocalNode(string name, string type, string defaultValue)
      { 
         m_Value.Default = defaultValue;
         m_Value.FriendlyName = "Value";
         m_Value.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         m_Value.Input   = true;
         m_Value.Output  = true;
         m_Value.Name    = "Value";
         m_Value.Type    = type;

         m_Name.Default = name;
         m_Name.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         m_Name.Input   = true;
         m_Name.Output  = false;
         m_Name.Name    = "Name";
         m_Name.FriendlyName = "Name";
         m_Name.Type    = "String";

         m_Position = Point.Empty; 
         m_Guid = Guid.NewGuid( ); 
      }
   }

   public class ScriptEditor
   {
      private string m_Name  = "";

      public EntityNode [] EntityNodes
      {
         get 
         {
            List<EntityNode> nodes = new List<EntityNode>( );
            
            foreach( EntityNode node in m_Nodes.Values )
            {
               nodes.Add( node );
            }

            return nodes.ToArray( );
         }
      }

      public EntityNode [] DeprecatedNodes
      {
         get 
         {
            List<EntityNode> nodes = new List<EntityNode>( );
            
            foreach( EntityNode node in m_Nodes.Values )
            {
               nodes.Add( node );
            }

            return nodes.ToArray( );
         }
      }

      public CommentNode [] Comments
      {
         get 
         {
            List<CommentNode> comments = new List<CommentNode>( );
            
            foreach( EntityNode node in m_Nodes.Values )
            {
               if ( node is CommentNode ) comments.Add( (CommentNode) node );
            }

            return comments.ToArray( );
         }
      }

      public EntityEvent [] Events
      {
         get 
         {
            List<EntityEvent> events = new List<EntityEvent>( );
            
            foreach( EntityNode node in m_Nodes.Values )
            {
               if ( node is EntityEvent ) events.Add( (EntityEvent) node );
            }

            return events.ToArray( );
         }
      }

      public EntityMethod [] Methods
      {
         get 
         {
            List<EntityMethod> methods = new List<EntityMethod>( );
            
            foreach( EntityNode node in m_Nodes.Values )
            {
               if ( node is EntityMethod ) methods.Add( (EntityMethod) node );
            }

            return methods.ToArray( );
         }
      }

      public EntityProperty [] Properties
      {
         get 
         {
            List<EntityProperty> properties = new List<EntityProperty>( );
            
            foreach( EntityNode node in m_Nodes.Values )
            {
               if ( node is EntityProperty ) properties.Add( (EntityProperty) node );
            }

            return properties.ToArray( );
         }
      }

      public LogicNode [] Logics
      {
         get 
         {
            List<LogicNode> logics = new List<LogicNode>( );
            
            foreach( EntityNode node in m_Nodes.Values )
            {
               if ( node is LogicNode ) logics.Add( (LogicNode) node );
            }

            return logics.ToArray( );
         }
      }

      public ExternalConnection [] Externals
      {
         get 
         {
            List<ExternalConnection> externals = new List<ExternalConnection>( );
            
            foreach( EntityNode node in m_Nodes.Values )
            {
               if ( node is ExternalConnection ) externals.Add( (ExternalConnection) node );
            }

            return externals.ToArray( );
         }
      }

      public OwnerConnection [] Owners
      {
         get 
         {
            List<OwnerConnection> owners = new List<OwnerConnection>( );
            
            foreach( EntityNode node in m_Nodes.Values )
            {
               if ( node is OwnerConnection ) owners.Add( (OwnerConnection) node );
            }

            return owners.ToArray( );
         }
      }

      public LocalNode [] Locals
      {
         get 
         {
            List<LocalNode> locals = new List<LocalNode>( );
            
            foreach( EntityNode node in m_Nodes.Values )
            {
               if ( node is LocalNode ) locals.Add( (LocalNode) node );
            }

            return locals.ToArray( );
         }
      }

      public LocalNode [] UniqueLocals
      {
         get 
         {
            Dictionary<string, LocalNode> uniqueLocals = new Dictionary<string, LocalNode>( );
            
            foreach( EntityNode node in m_Nodes.Values )
            {
               if ( node is LocalNode ) 
               {
                  LocalNode local = (LocalNode) node;
                  
                  if ( "" != local.Name.Default )
                  {
                     uniqueLocals[ local.Name.Default + local.Value.Type ] = local;
                  }
                  else
                  {
                     uniqueLocals[ local.Guid.ToString( ) ] = local;
                  }
               }
            }

            return uniqueLocals.Values.ToArray( );
         }
      }

      public LinkNode [] Links
      {
         get 
         {
            List<LinkNode> links = new List<LinkNode>( );
            
            foreach( EntityNode node in m_Nodes.Values )
            {
               if ( node is LinkNode ) links.Add( (LinkNode) node );
            }

            return links.ToArray( );
         }
      }

      public string Name 
      { 
         get { return m_Name; } 
      }

      public string SceneName = "";

      Hashtable m_Nodes = new Hashtable( );
      Hashtable m_DeprecatedNodes = new Hashtable( );

      public bool IsNodeInstanceDeprecated( EntityNode node )
      {
         return m_DeprecatedNodes.Contains(node.Guid);
      }

      private EntityDesc []m_EntityDescs = new EntityDesc[ 0 ];
      private LogicNode  []m_LogicNodes  = new LogicNode [ 0 ];

      public EntityDesc [] EntityDescs
      {
         set { m_EntityDescs = value; }
         get { return m_EntityDescs; }
      }

      public LogicNode [] LogicNodes
      {
         set { m_LogicNodes = value; }
         get { return m_LogicNodes; }
      }

      public string [] Types
      {
         get 
         { 
            Hashtable typeHash = new Hashtable( );
            
            if ( null != EntityDescs )
            {
               foreach ( EntityDesc desc in EntityDescs )
               {
                  foreach ( EntityEvent node in desc.Events )
                  {
                     foreach ( Parameter p in node.Parameters )
                     {
                        typeHash[ p.Type ] = p.Type;
                     }

                     typeHash[ node.Instance.Type ] = node.Instance.Type;
                     typeHash[ node.ComponentType ] = node.ComponentType;
                  }
                  foreach ( EntityMethod node in desc.Methods )
                  {
                     foreach ( Parameter p in node.Parameters )
                     {
                        typeHash[ p.Type ] = p.Type;
                     }

                     typeHash[ node.Instance.Type ] = node.Instance.Type;
                     typeHash[ node.ComponentType ] = node.ComponentType;
                  }
                  foreach ( EntityProperty node in desc.Properties )
                  {
                     foreach ( Parameter p in node.Parameters )
                     {
                        typeHash[ p.Type ] = p.Type;
                     }

                     typeHash[ node.Instance.Type ] = node.Instance.Type;
                  }
               }

               foreach ( LogicNode node in LogicNodes )
               {
                  foreach ( Parameter p in node.Parameters )
                  {
                     typeHash[ p.Type ] = p.Type;
                  }
               }
            }
            else
            {
               foreach ( EntityEvent node in Events )
               {
                  foreach ( Parameter p in node.Parameters )
                  {
                     typeHash[ p.Type ] = p.Type;
                  }

                  typeHash[ node.Instance.Type ] = node.Instance.Type;
                  typeHash[ node.ComponentType ] = node.ComponentType;
               }
               foreach ( EntityMethod node in Methods )
               {
                  foreach ( Parameter p in node.Parameters )
                  {
                     typeHash[ p.Type ] = p.Type;
                  }

                  typeHash[ node.Instance.Type ] = node.Instance.Type;
                  typeHash[ node.ComponentType ] = node.ComponentType;
               }
               foreach ( EntityProperty node in Properties )
               {
                  foreach ( Parameter p in node.Parameters )
                  {
                     typeHash[ p.Type ] = p.Type;
                  }

                  typeHash[ node.Instance.Type ] = node.Instance.Type;
               }

               foreach ( LogicNode node in Logics )
               {
                  foreach ( Parameter p in node.Parameters )
                  {
                     typeHash[ p.Type ] = p.Type;
                  }
               }
            }

            List<string> types = new List<string>( );

            foreach ( object o in typeHash.Values )
            {
               types.Add( (string) o );
            }

            return types.ToArray( );
         }
      }

      public override int GetHashCode()
      {
         return base.GetHashCode();
      }

      public override bool Equals(object obj)
      {
         ScriptEditor script = obj as ScriptEditor;
         if ( null == script ) return false;

         if ( script.m_Nodes.Count != m_Nodes.Count ) return false;

         foreach ( EntityNode node in m_Nodes.Values )
         {
            if ( false == script.m_Nodes.Contains(node.Guid) ) return false;             
            if ( false == node.Equals(script.m_Nodes[node.Guid]) ) return false;
         }

         return true;
      }

      public ScriptEditor(string name, EntityDesc []descs, LogicNode []nodes)
      {
         m_Name = name;
         m_EntityDescs = descs;
         m_LogicNodes  = nodes;
      }

      public bool FailOnEvent( LinkNode link )
      {
         //if node can't be found we won't need to fail on the backtrace
         if ( false == m_Nodes.Contains(link.Source.Guid) ) return true;
      
         EntityNode node = m_Nodes[ link.Source.Guid ] as EntityNode;
         
         if ( node is EntityEvent )
         {
            return false;
         }

         if ( node is LogicNode )
         {
            LogicNode logic = (LogicNode) node;

            foreach ( Plug eventPlug in logic.Events )
            {
               if ( eventPlug.Name == link.Source.Anchor )
               {
                  return false;
               }
            }
         }

         //local nodes trigger no signals, so we can stop here
         if ( node is LocalNode ) return true;

         foreach ( LinkNode sourceLink in Links )
         {
            if ( sourceLink.Destination.Guid == node.Guid )
            {
               bool result = FailOnEvent( sourceLink );            
               if ( false == result ) return false;
            }
         }

         return true;
      }

      public bool BacktraceExternalOutput( LinkNode link )
      {
         //if node can't be found we won't need to fail on the backtrace
         if ( false == m_Nodes.Contains(link.Source.Guid) ) return true;
      
         EntityNode node = m_Nodes[ link.Source.Guid ] as EntityNode;
      
         //if its first output is a method
         //then see if it'll get hung up on an event
         if ( node is EntityMethod || node is LogicNode )
         {
            if ( node is LogicNode )
            {
               LogicNode logic = (LogicNode) node;

               //if it's hooked up to a logic event
               //that's ok because the user doesn't assume
               //it's an immediate output
               foreach ( Plug eventPlug in logic.Events )
               {
                  if ( eventPlug.Name == link.Source.Anchor )
                  {
                     return true;
                  }
               }
            }

            foreach ( LinkNode sourceLink in Links )
            {
               if ( sourceLink.Destination.Guid == node.Guid )
               {
                  bool result = FailOnEvent( sourceLink );            
                  if ( false == result ) return false;
               }
            }
         }

         return true;
      }

      public Parameter FindNodeParameter(EntityNode node, string parameterName)
      {
         foreach ( Parameter p in node.Parameters )
         {
            if ( p.Name == parameterName ) return p;
         }

         if ( node.Instance.Name == parameterName ) return node.Instance;

         return Parameter.Empty;
      }


      public void VerifyAllLinks( )
      {
         //re-add the links
         //to make sure all the node connections still exist
         LinkNode []links = this.Links;

         foreach ( LinkNode link in links )
         {
            RemoveNode( link );
         }

         foreach ( LinkNode link in links )
         {
            AddNode( link );
         }
      }
      
      public bool VerifyLink( LinkNode link, out string reason )
      {
         reason = "";

         if ( false == m_Nodes.Contains(link.Source.Guid) ||
              false == m_Nodes.Contains(link.Destination.Guid) ) 
         {
            return false;
         }

         //fail if a link already exists
         foreach ( LinkNode existingLink in Links )
         {
            if ( existingLink.Source.Guid        == link.Source.Guid &&
                 existingLink.Source.Anchor      == link.Source.Anchor &&
                 existingLink.Destination.Guid   == link.Destination.Guid &&
                 existingLink.Destination.Anchor == link.Destination.Anchor ) 
            {
               return false;
            }
         }

         EntityNode source = (EntityNode) m_Nodes[ link.Source.Guid ];
         EntityNode dest   = (EntityNode) m_Nodes[ link.Destination.Guid ];

         if ( source is ExternalConnection )
         {
            foreach ( LinkNode existingLinks in Links )
            {
               if ( existingLinks.Source.Guid == source.Guid )
               {
                  //we already source out to another one
                  //let's see if the dest types match
                  EntityNode node = GetNode( existingLinks.Destination.Guid );

                  Parameter existingParam = FindNodeParameter(node, existingLinks.Destination.Anchor);
                  Parameter myParam       = FindNodeParameter(dest, link.Destination.Anchor);

                  if ( existingParam.Type != myParam.Type )
                  {
                     reason = "An External Node can't link to two different types";
                     return false;
                  }                  

                  if ( Parameter.Empty == existingParam )
                  {
                     reason = "An External Node can't link to two different inputs";
                     return false;
                  }
               }
               else if (existingLinks.Destination.Guid == source.Guid )
               {
                  //someone is linking to us so
                  //see if their source matches our dest type
                  EntityNode node = GetNode( existingLinks.Source.Guid );

                  Parameter existingParam = FindNodeParameter(node, existingLinks.Source.Anchor);
                  Parameter myParam       = FindNodeParameter(dest, link.Destination.Anchor);

                  if ( Parameter.Empty == existingParam )
                  {
                     reason = "An External Node can't link to an input and an output";
                     return false;
                  }

                  if ( existingParam.Type != myParam.Type )
                  {
                     reason = "An External Node can't link to two different types";
                     return false;
                  }

                  //see if the source can also be an input (because we are being created as an input)
                  if ( true != existingParam.Input )
                  {
                     reason = "An External Node can't link to multiple variables in which some are input/output and some are output only";
                     return false;
                  }
               }
            }
         }
         if ( dest is ExternalConnection )
         {
            foreach ( LinkNode existingLinks in Links )
            {
               if ( existingLinks.Source.Guid == dest.Guid )
               {
                  //someone is linking to us so
                  //see if their dest matches our source type
                  EntityNode node = GetNode( existingLinks.Destination.Guid );

                  Parameter existingParam = FindNodeParameter(node,   existingLinks.Destination.Anchor);
                  Parameter myParam       = FindNodeParameter(source, link.Source.Anchor);

                  if ( Parameter.Empty == existingParam )
                  {
                     reason = "An External Node can't link to an input and an output";
                     return false;
                  }

                  if ( existingParam.Type != myParam.Type )
                  {
                     reason = "An External Node can't link to two different types";
                     return false;
                  }

                  //see if the destintation can also be an output (because we are being created as an output)
                  if ( true != existingParam.Output )
                  {
                     reason = "An External Node can't link to multiple variables in which some are input/output and some are output only";
                     return false;
                  }
               }
               else if (existingLinks.Destination.Guid == dest.Guid )
               {
                  //we already dest out to another one
                  //let's see if the source types match
                  EntityNode node = GetNode( existingLinks.Source.Guid );

                  Parameter existingParam = FindNodeParameter(node,   existingLinks.Source.Anchor);
                  Parameter myParam       = FindNodeParameter(source, link.Source.Anchor);

                  if ( Parameter.Empty == existingParam )
                  {
                     reason = "An External Node can't link to two different outputs";
                     return false;
                  }

                  if ( existingParam.Type != myParam.Type )
                  {
                     reason = "An External Node can't link to two different types";
                     return false;
                  }                  
               }
            }

            if ( source is EntityEvent )
            {
               ExternalConnection destConnection = (ExternalConnection) dest;

               EntityEvent sourceEvent = (EntityEvent) source;

               foreach ( Parameter p in sourceEvent.Parameters )
               {
                  if ( p.Output == false ) continue;

                  //don't allow parameter outputs of events to be exposed externally
                  //it makes the nested script node too confusing as to which are output parameters
                  //and which are event output parameters
                  //plus it makes the code more complex to generate
                  if ( p.Name == link.Source.Anchor && 
                       destConnection.Connection == link.Destination.Anchor )
                  {
                     reason = "Externals cannot connect to Event Node Parameters";
                     return false;
                  }
               }
            }
         }

         Parameter sourceParam = new Parameter( );

         Parameter destParam  = sourceParam;
         Parameter emptyParam = sourceParam;

         foreach ( Parameter p in source.Parameters )
         {
            if ( link.Source.Anchor == p.Name )
            {
               sourceParam = p;
               break;
            }
         }

         if ( link.Destination.Anchor == "Instance" )
         {
            if ( dest is EntityMethod )
            {
               destParam = ((EntityMethod)dest).Instance;
            }
            else if ( dest is EntityEvent )
            {
               destParam = ((EntityEvent)dest).Instance;
            }
            else if ( dest is EntityProperty )
            {
               destParam = ((EntityProperty)dest).Instance;
            }

            if ( dest is EntityMethod )
            {
               EntityMethod em = (EntityMethod) dest;

               bool allowOnlyOne = false;

               foreach ( Parameter parameter in em.Parameters )
               {
                  if ( true == parameter.Output &&
                       false== parameter.Input  &&
                       parameter.Name == "Return"
                     )
                  {
                     allowOnlyOne = true;
                     break;
                  }
               }

               if ( true == allowOnlyOne )
               {
                  //fail if something is already linked to our instance socket
                  foreach ( LinkNode existingLink in Links )
                  {
                     if ( existingLink.Destination.Guid   == link.Destination.Guid &&
                          existingLink.Destination.Anchor == link.Destination.Anchor ) 
                     {
                        reason = "Only one link can be connected per Instance socket if the destination has a return value";
                        return false;
                     }
                  }
               }
            }
         }
         else
         {
            foreach ( Parameter p in dest.Parameters )
            {
               if ( link.Destination.Anchor == p.Name )
               {
                  destParam = p;
                  break;
               }
            }
         }

         if ( source is ExternalConnection && dest is ExternalConnection ) 
         {
            reason = "External Connections cannot be linked together";
            return false;
         }

         if ( source is OwnerConnection && dest is ExternalConnection ) 
         {
            reason = "Owners and External Connections cannot be linked together";
            return false;
         }

         if ( source is ExternalConnection ) return true;
         
         if ( dest is ExternalConnection )
         {
            if ( false == BacktraceExternalOutput(link) )
            {
               reason = "External Connections linked to an immediate output cannot also have an event in the same link chain. " +
                        "This is because the parent script will be expecting an immediate output however the nested script will block on the event.";
               return false;
            }

            return true;
         }

         //Out socket (right side) connected to an In (left side)
         if ( sourceParam == emptyParam &&
              destParam   == emptyParam )
         {
            bool sourceFound = false;

            if ( source is EntityMethod )
            {
               if ( link.Source.Anchor == ((EntityMethod)source).Output.Name ) 
               {
                  sourceFound = true;
               }
            }
            else if ( source is LogicNode )
            {
               LogicNode logic = (LogicNode) source;

               foreach ( Plug output in logic.Outputs )
               {
                  if ( link.Source.Anchor == output.Name )
                  {
                     sourceFound = true;
                     break;
                  }
               }
               foreach ( Plug eventPlug in logic.Events )
               {
                  if ( link.Source.Anchor == eventPlug.Name )
                  {
                     sourceFound = true;
                     break;
                  }
               }
            }
            else if ( source is EntityEvent )
            {
               EntityEvent entityEvent = (EntityEvent) source;
      
               foreach ( Plug output in entityEvent.Outputs )
               {
                  if ( link.Source.Anchor == output.Name )
                  {
                     sourceFound = true;
                     break;
                  }
               }
            }

            if ( false == sourceFound )
            {
               reason = "Output socket " + link.Source.Anchor + " is no longer available";
               return false;
            }

            bool destFound = false;

            if ( dest is EntityMethod )
            {
               if ( link.Destination.Anchor == ((EntityMethod)dest).Input.Name ) 
               {
                  destFound = true;
               }
            }
            else if ( dest is LogicNode )
            {
               LogicNode logic = (LogicNode) dest;

               foreach ( Plug input in logic.Inputs )
               {
                  if ( link.Destination.Anchor == input.Name )
                  {
                     destFound = true;
                     break;
                  }
               }
            }

            if ( false == destFound )
            {
               reason = "Input socket " + link.Source.Anchor + " is no longer available";
               return false;
            }

            return true;
         }
         
         //don't let parameters hook directly to others without going throug a variable
         //this fixes some script generation errors when dealing with outputting and inputting arrays
         if ( (source is EntityMethod || source is EntityEvent || source is LogicNode) &&
              (dest   is EntityMethod || dest   is EntityEvent || dest   is LogicNode) ) 
         {
            reason = "Parameters must be linked to Variable Nodes, they cannot be linked directly to other Action Nodes";
            return false;
         }

         //source must be output and dest must be input
         if ( true != sourceParam.Output || true != destParam.Input ) 
         {
            //UnityEngine.Debug.Log( "source = " + sourceParam.Name );
            //UnityEngine.Debug.Log( "dest   = " + destParam.Input );

            reason = "The source link must allow an output and the destination must allow an input";
            return false;
         }

         //if source param is an array and dest param is an array
         //remove both array qualifiers because we only care if the types are compatible
         if ( true == destParam.Type.Contains("[]") &&
              true == sourceParam.Type.Contains("[]") )
         {
            destParam.Type   = destParam.Type.Replace("[]", "");
            sourceParam.Type = sourceParam.Type.Replace("[]", "");
         }
         //else if source isn't an array but dest is, remove the array qualifier
         //because source doesn't have to be an array to be a compatible type
         else if ( true == destParam.Type.Contains("[]") )
         {
            destParam.Type = destParam.Type.Replace("[]", "");
         }

         //query unity objects which might not be loaded yet so we can't just use Type.GetType
         Type sourceType = uScript.Instance.GetType( sourceParam.Type );
         Type destType   = uScript.Instance.GetType( destParam.Type );

         if ( null == destType ) 
         {
            reason = "Type " + destParam.Type + " could not be found in the Unity system";
            return false;
         }

         if ( null == sourceType ) 
         {
            reason = "Type " + sourceParam.Type + " could not be found in the Unity system";
            return false;
         }

         //allow link if the types are compatible somewhere in the derived chain
         if ( false == destType.IsAssignableFrom(sourceType) )
         {
            reason = "Type " + destType + " cannot be assigned from " + sourceType;
            return false;
         }

         return true;
      }

      public void AddNode(EntityNode node)
      {
         bool allow = true;

         if ( node is LinkNode )
         {
            string reason;
            allow = VerifyLink( (LinkNode) node, out reason );

            if ( false == allow )
            {
               Status.Info( reason );
            }
         }

         if ( true == allow )
         {
            if ( node is LocalNode )
            {
               LocalNode localNode = (LocalNode) node;

               bool isGlobal = ("" != localNode.Name.Default);

               if ( true == isGlobal )
               {
                  bool hasValue = ("" != localNode.Value.Default);
   
                  //if they modified a local node
                  //go through the list and update all matching nodes
                  if ( true == hasValue )
                  {
                     List<LocalNode> updates = new List<LocalNode>( );

                     foreach ( LocalNode clone in Locals )
                     {
                        //if the node has a shared name with other nodes
                        //of that type, then update their values
                        if ( localNode.Name.Default == clone.Name.Default &&
                             localNode.Value.Type   == clone.Value.Type )
                        {
                           LocalNode copy = clone;

                           copy.Parameters = localNode.Parameters;
                           updates.Add( copy );
                        }
                     }

                     foreach ( LocalNode clone in updates )
                     {
                        m_Nodes[ clone.Guid ] = clone;
                     }
                  }
                  else
                  {
                     //it's a blank node so if there is a matchine name/type
                     //update our value
                     foreach ( LocalNode existing in Locals )
                     {
                        if ( localNode.Name.Default == existing.Name.Default &&
                             localNode.Value.Type   == existing.Value.Type )
                        {
                           node.Parameters = existing.Parameters;
                           break;
                        }
                     }
                  }
               }
            }

            m_Nodes[ node.Guid ] = node;

            //now it's fully added - reverify our graph
            //to make sure it's compatible with all externals
            bool rejected = false;

            foreach ( ExternalConnection connection in Externals )
            {
               foreach ( LinkNode link in Links )
               {
                  if ( link.Destination.Guid == connection.Guid )
                  {
                     if ( false == BacktraceExternalOutput(link) )
                     {
                        m_Nodes.Remove( node.Guid );
                        rejected = true;
                        break;
                     }
                  }
               }

               if ( true == rejected ) break;
            }

            if ( true == rejected )
            {
               string reason = "This link would cause an External to be linked to an immediate output and to an event in the same link chain. " +
                               "This is not allowed because the parent script will be expecting an immediate output however the nested script will block on the event.";
               
               //warn instead of info because breaking this link
               //won't be clear to the user and I want them to see the message
               Status.Warning( reason );

            }
         }
      }

      public LinkNode []GetLinksByDestination(Guid destGuid, string destAnchor)
      {
         List<LinkNode> links = new List<LinkNode>( );

         foreach ( LinkNode link in this.Links )
         {
            if ( link.Destination.Guid == destGuid && link.Destination.Anchor == destAnchor )
            {
               links.Add( link );
            }
         }

         return links.ToArray( );
      }

      public LinkNode []GetLinksBySource(Guid sourceGuid, string sourceAnchor)
      {
         List<LinkNode> links = new List<LinkNode>( );

         foreach ( LinkNode link in this.Links )
         {
            if ( link.Source.Guid == sourceGuid && link.Source.Anchor == sourceAnchor )
            {
               links.Add( link );
            }
         }

         return links.ToArray( );
      }

      public EntityNode GetNode(Guid guid)
      {
         if ( m_Nodes.Contains(guid) )
         {
            return (EntityNode) m_Nodes[ guid ];
         }

         return null;
      }

      public void RemoveNode(EntityNode removeNode)
      {
         List<EntityNode> references = new List<EntityNode>( );

         if ( m_Nodes.Contains(removeNode.Guid) )
         {
            references.Add( removeNode );
         }

         foreach ( EntityNode node in m_Nodes.Values )
         {
            if ( node is LinkNode )
            {
               if ( ((LinkNode)node).Destination.Guid == removeNode.Guid )
               {
                  references.Add( node );
               }
               else if ( ((LinkNode)node).Source.Guid == removeNode.Guid )
               {
                  references.Add( node );
               }
            }
         }

         foreach( EntityNode node in references )
         {
            m_Nodes.Remove( node.Guid );
         }

         if ( m_DeprecatedNodes.Contains(removeNode.Guid) )
         {
            m_DeprecatedNodes.Remove(removeNode.Guid);
         }
      }

      public void UpgradeNode( EntityNode oldNode )
      {
         if ( m_DeprecatedNodes.Contains(oldNode.Guid) )
         {         
            Type newType = uScript.GetNodeUpgradeType(oldNode);
            if ( null == newType ) newType = uScript.Instance.GetAssemblyQualifiedType(ScriptEditor.FindNodeType(oldNode));

            if ( null != newType )
            {
               bool upgraded = false;
               
               foreach ( EntityDesc desc in EntityDescs )
               {
                  foreach ( EntityEvent eventNode in desc.Events )
                  {
                     if ( ScriptEditor.FindNodeType(eventNode) == newType.ToString( ) )
                     {
                        EntityEvent cloned = (EntityEvent) eventNode.Copy( );
                        
                        //copy everything compatible from the old node to the new node
                        cloned.Parameters = ArrayUtil.CopyCompatibleParameters(cloned.Parameters, oldNode.Parameters );
                        cloned.Instance   = ArrayUtil.CopyCompatibleParameters( new Parameter[]{cloned.Instance}, 
                                                                                new Parameter[]{oldNode.Instance} )[ 0 ];

                        if ( oldNode is EntityEvent )
                        {
                           cloned.EventArgs = ((EntityEvent)oldNode).EventArgs;
                        }
                        
                        cloned.Guid        = oldNode.Guid;
                        cloned.Position    = oldNode.Position;
                        cloned.ShowComment = oldNode.ShowComment;
                        cloned.Comment     = oldNode.Comment;         
                     
                        //guid matches the old one so this will replace the old node
                        AddNode( cloned );
                        VerifyAllLinks( );

                        upgraded = true;
                        break;
                     }
                  }
               }

               foreach ( LogicNode logicNode in LogicNodes )
               {
                  if ( ScriptEditor.FindNodeType(logicNode) == newType.ToString( ) )
                  {
                     LogicNode cloned = (LogicNode) logicNode.Copy( );

                     //copy everything compatible from the old node to the new node
                     cloned.Parameters = ArrayUtil.CopyCompatibleParameters(cloned.Parameters, oldNode.Parameters);                  

                     cloned.Guid       = oldNode.Guid;
                     cloned.Position   = oldNode.Position;
                     cloned.ShowComment= oldNode.ShowComment;
                     cloned.Comment    = oldNode.Comment;

                     //guid matches the old one so this will replace the old node
                     AddNode( cloned );
                     VerifyAllLinks( );

                     upgraded = true;
                     break;
                  }
               }

               if ( true == upgraded )
               {
                  m_DeprecatedNodes.Remove( oldNode.Guid );
               }
               else
               {
                  Status.Error( "Node " + ScriptEditor.FindNodeType(oldNode) + " could not automatically upgraded" );
               }
            }
            else
            {
               //if deprecated attribute doesn't exist then the reflection values changed and the script hasn't been resaved
               //we know the user acknowledged it - so now allow them to upgrade it
               if ( false == uScript.IsNodeTypeDeprecated(oldNode) )
               {
                  m_DeprecatedNodes.Remove( oldNode.Guid );
               }
               else
               {
                  Status.Error( "Node " + ScriptEditor.FindNodeType(oldNode) + " had no registered upgradable type" );
               }
            }
         }
      }

      public ScriptEditorData ScriptEditorData
      {
         get 
         { 
            ScriptEditorData data = new ScriptEditorData( );

            List<EntityNodeData> nodeDatas = new List<EntityNodeData>( );

            foreach ( object value in m_Nodes.Values )
            {
               EntityNode node = (EntityNode) value;
               nodeDatas.Add( node.NodeData );
            }

            data.NodeDatas = nodeDatas.ToArray( );
            data.SceneName = SceneName;

            return data;
         }

         set
         {
            foreach ( EntityNodeData data in value.NodeDatas )
            {
               EntityNode node = null;

               if ( data is EntityEventData )
               {
                  node = CreateEntityEvent( data as EntityEventData );
               }
               else if ( data is CommentNodeData )
               {
                  node = CreateCommentNode( data as CommentNodeData );
               }
               else if ( data is LinkNodeData )
               {
                  node = CreateLinkNode( data as LinkNodeData );
               }
               else if ( data is EntityMethodData )
               {
                  node = CreateEntityMethod( data as EntityMethodData );
               }
               else if ( data is LocalNodeData )
               {
                  node = CreateLocalNode( data as LocalNodeData );
               }
               else if ( data is EntityPropertyData )
               {
                  node = CreateEntityProperty( data as EntityPropertyData );
               }
               else if ( data is LogicNodeData )
               {
                  node = CreateLogicNode( data as LogicNodeData );
               }
               else if ( data is ExternalConnectionData )
               {
                  node = CreateExternalConnection( data as ExternalConnectionData );
               }
               else if ( data is OwnerConnectionData )
               {
                  node = CreateOwnerConnection( data as OwnerConnectionData );
               }
               else
               {
                  Status.Error( "Unrecognized script node " + data.GetType().ToString() );
               }

               if ( null != node )
               {
                  m_Nodes.Add( node.Guid, node );
               }
            }

            SceneName = value.SceneName;
         }
      }

      public bool Read(MemoryStream stream)
      {
         BinaryReader reader = new BinaryReader( stream );
         object data = null;

         ObjectSerializer serializer = new ObjectSerializer( );
         if ( false == serializer.Load(reader, out data) ) return false;

         ScriptEditorData readData = data as ScriptEditorData;
         if ( null == readData ) return false;

         ScriptEditorData = data as ScriptEditorData;

         VerifyAllLinks( );

         return true;
      }

      public bool Write(MemoryStream stream)
      {
         BinaryWriter writer = new BinaryWriter( stream );

         ObjectSerializer serializer = new ObjectSerializer( );
         if ( false == serializer.Save(writer, ScriptEditorData) ) return false;

         return true;
      }

      public string ToBase64( )
      {
         MemoryStream stream = new MemoryStream( );

         if ( false == Write(stream) ) 
         {
            Status.Error( "Could not write script data to a memory stream" );
            return null;
         }

         string base64 = Convert.ToBase64String( stream.GetBuffer( ) );

         stream.Close( );

         return base64;
      }

      public bool OpenFromBase64(string name, string base64)
      {
         try
         {
            string contents = base64;

            byte[] binary = Convert.FromBase64String( contents );

            MemoryStream stream = new MemoryStream( binary );
            if ( false == Read(stream) ) 
            {
               Status.Error( "Failed to load " + name );
               return false;
            }

            m_Name = name;

            return true;
         }
         catch (Exception e)
         {
            Status.Error( "Failed to load " + name + ". Exception: " + e.Message );
            return false;
         }
      }

      public bool Open(string fullPath)
      {
         StreamReader streamReader = null;

         try
         {
            streamReader = File.OpenText( fullPath );
            string contents = streamReader.ReadToEnd( );
            
            streamReader.Close( );

            string start = "/*[[BEGIN BASE64\r\n";
            string end   = "\r\nEND BASE64]]*/";
            contents = contents.Substring( contents.IndexOf(start) );
            contents = contents.Substring( start.Length );
            contents = contents.Substring( 0, contents.Length - end.Length );

            return OpenFromBase64( Path.GetFileName(fullPath), contents );
         }
         catch (Exception e)
         {
            if ( null != streamReader ) streamReader.Close( );

            Status.Error( "Failed to load " + fullPath + ". Exception: " + e.Message );
            return false;
         }
      }

      public ScriptEditor Copy( )
      {
         ScriptEditor script = new ScriptEditor( Name, EntityDescs, LogicNodes );
         script.ScriptEditorData = ScriptEditorData;
      
         return script;
      }

      public bool Save(string binaryFile, string logicFile, string wrapperFile)
      {
         string base64 = ToBase64( );

         StreamWriter streamWriter = null;
         
         try
         {
            m_Name = Path.GetFileNameWithoutExtension( binaryFile );

            streamWriter = File.CreateText( binaryFile );
            streamWriter.Write( "/*[[BEGIN BASE64\r\n" + base64 + "\r\nEND BASE64]]*/" );
            streamWriter.Close( );
         }
         catch (Exception e)
         {
            if ( null != streamWriter ) streamWriter.Close( );

            Status.Error( "Failed to write to " + binaryFile + ". Exception: " + e.Message );
            return false;
         }

         string logicClass = System.IO.Path.GetFileNameWithoutExtension( logicFile );

         streamWriter = null;

         try
         {
            UnityCSharpGenerator codeGenerator = new UnityCSharpGenerator( );

            streamWriter = File.CreateText( wrapperFile );
            streamWriter.Write( codeGenerator.GenerateGameObjectScript(logicClass, this) );
            streamWriter.Close( );
         }
         catch (Exception e)
         {
            if ( null != streamWriter ) streamWriter.Close( );

            Status.Error( "Failed to write to " + wrapperFile + ". Exception: " + e.Message );
            return false;
         }

         streamWriter = null;

         try
         {
            UnityCSharpGenerator codeGenerator = new UnityCSharpGenerator( );

            streamWriter = File.CreateText( logicFile );
            streamWriter.Write( codeGenerator.GenerateLogicScript(logicClass, this) );
            streamWriter.Close( );
         }
         catch (Exception e)
         {
            if ( null != streamWriter ) streamWriter.Close( );

            Status.Error( "Failed to write to " + logicFile + ". Exception: " + e.Message );
            return false;
         }

         return true;
      }

      public string [] Filter( string [] assets, string filter )
      {
         List<string> results = new List<string>( );

         foreach ( string asset in assets )
         {
            if ( asset.EndsWith(filter) )
            {
               results.Add( asset );
            }
         }

         return results.ToArray( );
      }

      private CommentNode CreateCommentNode( CommentNodeData data )
      {
         CommentNode local = new CommentNode( "" );
         local.Guid        = data.Guid;
         local.Position    = data.Position;
         local.Size        = new Parameter( data.Size );
         local.ShowComment = new Parameter( data.ShowComment );
         local.Comment     = new Parameter( data.Comment );
         local.BodyText    = new Parameter( data.BodyText );
         local.BodyTextColor  = new Parameter( data.BodyTextColor );
         local.TitleText      = new Parameter( data.TitleText );
         local.TitleTextColor = new Parameter( data.TitleTextColor );
         local.NodeColor      = new Parameter( data.NodeColor );
         return local;
      }

      private EntityEvent CreateEntityEvent( EntityEventData data )
      {
         EntityEvent cloned;

         if ( null == m_EntityDescs )
         {
            cloned = new EntityEvent( data );
         }
         else
         {
            cloned = new EntityEvent( data.Instance.Type, data.Instance.Type, ArrayUtil.ToPlugs(data.Outputs) );
            
            bool exactMatch = false;

            foreach ( EntityDesc desc in m_EntityDescs )
            {
               foreach ( EntityEvent entityEvent in desc.Events )
               {
                  if ( entityEvent.Instance.Type == data.Instance.Type &&
                       entityEvent.ComponentType == data.ComponentType &&
                       true == ArrayUtil.ArraysAreEqual(entityEvent.Outputs, ArrayUtil.ToPlugs(data.Outputs)) )
                  {
                     cloned = entityEvent;
                     
                     if ( true == ArrayUtil.ParametersAreCompatible(ArrayUtil.ToParameters(data.Parameters), entityEvent.Parameters) )
                     {
                        exactMatch = true;
                     }

                     cloned.Parameters = ArrayUtil.CopyCompatibleParameters(cloned.Parameters, ArrayUtil.ToParameters(data.Parameters) );
                     cloned.Instance   = ArrayUtil.CopyCompatibleParameters( new Parameter[]{cloned.Instance}, 
                                                                              ArrayUtil.ToParameters(new Data.ScriptEditor.Parameter[]{data.Instance}) )[ 0 ];
                     break;
                  }
               }
            }

            cloned.EventArgs   = data.EventArgs;
            cloned.Guid        = data.Guid;
            cloned.Position    = data.Position;
            cloned.ShowComment = new Parameter( data.ShowComment );
            cloned.Comment     = new Parameter( data.Comment );         
         
            if ( false == exactMatch || uScript.IsNodeTypeDeprecated(cloned) )
            {
               //Status.Warning( "Matching EntityEvent " + data.ComponentType + " could not be found" );
               m_DeprecatedNodes[ cloned.Guid ] = cloned;
            }
         }

         return cloned;
      }

      private EntityMethod CreateEntityMethod( EntityMethodData data )
      {
         EntityMethod cloned;
         
         if ( null == m_EntityDescs )
         {
            cloned = new EntityMethod( data );
         }
         else
         {
            cloned = new EntityMethod( data.Instance.Type, data.Input.Name, data.Input.FriendlyName );
            bool exactMatch = false;

            //entities might have overloaded methods so we need to go through all
            //and if we don't find an exact match then just use the first potential one we come across
            List<EntityMethod> potentialMatches = new List<EntityMethod>( );

            foreach ( EntityDesc desc in m_EntityDescs )
            {
               foreach ( EntityMethod entityMethod in desc.Methods )
               {
                  if ( entityMethod.ComponentType == data.ComponentType &&
                       entityMethod.Instance.Type == data.Instance.Type &&
                       entityMethod.Input.Name == data.Input.Name )
                  {
                     cloned = entityMethod;
                     
                     if ( true == ArrayUtil.ParametersAreCompatible(ArrayUtil.ToParameters(data.Parameters), entityMethod.Parameters) )
                     {
                        exactMatch = true;
                     }
                     else
                     {
                        potentialMatches.Add(entityMethod);                     
                        continue;
                     }

                     cloned.Parameters = ArrayUtil.CopyCompatibleParameters(cloned.Parameters, ArrayUtil.ToParameters(data.Parameters) );
                     cloned.Instance   = ArrayUtil.CopyCompatibleParameters( new Parameter[]{cloned.Instance}, 
                                                                              ArrayUtil.ToParameters(new Data.ScriptEditor.Parameter[]{data.Instance}) )[ 0 ];
                     break;
                  }
               }
            }


            if ( false == exactMatch )
            {
               if ( potentialMatches.Count > 0 )
               {
                  cloned.Parameters = ArrayUtil.CopyCompatibleParameters(cloned.Parameters, ArrayUtil.ToParameters(data.Parameters) );
                  cloned.Instance   = ArrayUtil.CopyCompatibleParameters( new Parameter[]{cloned.Instance}, 
                                                                           ArrayUtil.ToParameters(new Data.ScriptEditor.Parameter[]{data.Instance}) )[ 0 ];
               }
            }

            cloned.Guid        = data.Guid;
            cloned.Position    = data.Position;
            cloned.ShowComment = new Parameter( data.ShowComment );
            cloned.Comment     = new Parameter( data.Comment );
            
            if ( false == exactMatch || uScript.IsNodeTypeDeprecated(cloned) )
            {
               //Status.Warning( "Matching EntityMethod " + data.ComponentType + " " + data.Input.Name + " could not be found" );
               m_DeprecatedNodes[ cloned.Guid ] = cloned;
            }
         }

         return cloned;
      }

      private EntityProperty CreateEntityProperty( EntityPropertyData data )
      {
         EntityProperty cloned;
         
         if ( null == m_EntityDescs )
         {
            cloned = new EntityProperty( data );
         }
         else
         {
            cloned = new EntityProperty( data.Parameter.Name, data.Parameter.FriendlyName, data.Instance.Type, 
                                         data.Parameter.Default, data.Parameter.Input, data.Parameter.Output );
            bool exactMatch = false;

            foreach ( EntityDesc desc in m_EntityDescs )
            {
               foreach ( EntityProperty entityProperty in desc.Properties )
               {
                  if ( entityProperty.Instance.Type == data.Instance.Type &&
                       entityProperty.Parameter.Name == data.Parameter.Name )
                  {
                     cloned = entityProperty;
                     
                     if ( true == ArrayUtil.ParametersAreCompatible(ArrayUtil.ToParameters(new Data.ScriptEditor.Parameter[]{data.Parameter}), 
                                                                    new Parameter[]{entityProperty.Parameter}) )
                     {
                        exactMatch = true;
                     }

                     cloned.Parameter  = ArrayUtil.CopyCompatibleParameters( new Parameter[]{cloned.Parameter}, 
                                                                              ArrayUtil.ToParameters(new Data.ScriptEditor.Parameter[]{data.Parameter}) )[ 0 ];
                     cloned.Instance   = ArrayUtil.CopyCompatibleParameters( new Parameter[]{cloned.Instance}, 
                                                                              ArrayUtil.ToParameters(new Data.ScriptEditor.Parameter[]{data.Instance}) )[ 0 ];

                     break;
                  }
               }
            }

            cloned.Guid        = data.Guid;
            cloned.Position    = data.Position;
            cloned.ShowComment = new Parameter( data.ShowComment );
            cloned.Comment     = new Parameter( data.Comment );

            if ( false == exactMatch || uScript.IsNodeTypeDeprecated(cloned) )
            {
               //Status.Warning( "Matching EntityProperty " + data.Instance.Name + " " + data.Parameter.Name + " could not be found" );
               m_DeprecatedNodes[ cloned.Guid ] = cloned;
            }
         }

         return cloned;
      }

      private LogicNode CreateLogicNode( LogicNodeData data )
      {
         LogicNode cloned;

         //no reflection information so use
         //everything straight from the data file
         if ( null == m_LogicNodes )
         {
            cloned = new LogicNode( data );
         }
         else
         {
            cloned = new LogicNode( data.Type, data.FriendlyName );

            bool exactMatch = false;
   
            foreach ( LogicNode node in m_LogicNodes )
            {
               if ( node.Type == data.Type )
               {
                  cloned = node;
                  
                  if ( true == ArrayUtil.ParametersAreCompatible(ArrayUtil.ToParameters(data.Parameters), node.Parameters) &&
                       true == ArrayUtil.ArraysAreEqual(node.Inputs, ArrayUtil.ToPlugs(data.Inputs)) &&
                       true == ArrayUtil.ArraysAreEqual(node.Outputs, ArrayUtil.ToPlugs(data.Outputs)) &&
                       true == ArrayUtil.ArraysAreEqual(node.Events, ArrayUtil.ToPlugs(data.Events)) )
                  {
                     exactMatch = true;
                  }

                  cloned.Parameters = ArrayUtil.CopyCompatibleParameters(cloned.Parameters, ArrayUtil.ToParameters(data.Parameters) );                  
                  break;
               }
            }

            cloned.Guid       = data.Guid;
            cloned.Position   = data.Position;
            cloned.ShowComment= new Parameter( data.ShowComment );
            cloned.Comment    = new Parameter( data.Comment );

            if ( false == exactMatch || uScript.IsNodeTypeDeprecated(cloned) )
            {
               //Status.Warning( "Matching LogicNode " + data.Type + " could not be found" );
               m_DeprecatedNodes[ cloned.Guid ] = cloned;
            }
         }

         return cloned;
      }
      
      private ExternalConnection CreateExternalConnection( ExternalConnectionData data )
      {
         ExternalConnection external = new ExternalConnection( );

         external.Connection = "Connection";
         external.Guid       = data.Guid;
         external.Position   = data.Position;
         external.Name       = new Parameter( data.Name );
         external.ShowComment= new Parameter( data.ShowComment );
         external.Comment    = new Parameter( data.Comment );

         return external;
      }

      private OwnerConnection CreateOwnerConnection( OwnerConnectionData data )
      {
         OwnerConnection owner = new OwnerConnection( data.Guid );

         owner.Guid       = data.Guid;
         owner.Position   = data.Position;
         owner.ShowComment= new Parameter( data.ShowComment );
         owner.Comment    = new Parameter( data.Comment );

         return owner;
      }

      private LocalNode CreateLocalNode( LocalNodeData data )
      {
         LocalNode local  = new LocalNode( );
         local.Guid       = data.Guid;
         local.Position   = data.Position;
         local.Parameters = ArrayUtil.ToParameters( data.Parameters );
         local.ShowComment= new Parameter( data.ShowComment );
         local.Comment    = new Parameter( data.Comment );

         return local;
      }

      private LinkNode CreateLinkNode( LinkNodeData data )
      {
         return new LinkNode( data );
      }

      public static string FindNodeType(EntityNode node)
      {
         if ( node is EntityEvent )
         {
            EntityEvent entityEvent = (EntityEvent) node;         
            return entityEvent.ComponentType;
         }
         else if ( node is LogicNode )
         {
            LogicNode logicNode = (LogicNode) node;         
            return logicNode.Type;
         }

         return "";
      }
   }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Detox.Drawing;
using Detox.Utility;

namespace Detox.Data.ScriptEditor
{
   public class ScriptEditorData : ISerializable
   {
      private EntityNodeData []m_NodeDatas = null;
      public string SceneName = "";
      public bool GeneratedCodeIsStale = false;
      public bool SavedForDebugging = false;

      public Parameter FriendlyName;
      public Parameter Description;

      static ScriptEditorData( )
      {
         ObjectSerializer.AddTypeSerializer( new ParameterSerializer( ) );
         ObjectSerializer.AddTypeSerializer( new ParameterArraySerializer( ) );
         ObjectSerializer.AddTypeSerializer( new PlugSerializer( ) );
         ObjectSerializer.AddTypeSerializer( new PlugArraySerializer( ) );
      }

      public ScriptEditorData( )
      {
      }

      public EntityNodeData [] NodeDatas
      {
         get 
         { 
            List<EntityNodeData> list = new List<EntityNodeData>( );

            foreach ( EntityNodeData nodeData in m_NodeDatas )
            {
               EntityNodeData newData = (EntityNodeData) Activator.CreateInstance( nodeData.GetType( ) );
               newData.Clone( nodeData );
               list.Add( newData );
            }

            return list.ToArray( );
         }

         set 
         {
            List<EntityNodeData> list = new List<EntityNodeData>( );

            foreach ( EntityNodeData nodeData in value )
            {
               EntityNodeData newData = (EntityNodeData) Activator.CreateInstance( nodeData.GetType( ) );
               newData.Clone( nodeData );
               list.Add( newData );
            }

            m_NodeDatas = list.ToArray( );
         }
      }


      public int Version { get { return 5; } }

      public void Load(ObjectSerializer serializer)
      {
         object []array;
         array = (object[]) serializer.LoadNamedObjects( "NodeDatas" );
      
         List<EntityNodeData> list = new List<EntityNodeData>( );

         foreach ( object o in array )
         {
            list.Add( o as EntityNodeData );
         }

         m_NodeDatas = list.ToArray( );

         if ( serializer.CurrentVersion > 1 )
         {
            SceneName = (string) serializer.LoadNamedObject( "SceneName" );
         }

         if ( serializer.CurrentVersion > 2 )
         {
            GeneratedCodeIsStale = (bool) serializer.LoadNamedObject( "GeneratedCodeIsStale" );
         }

         if ( serializer.CurrentVersion > 3 )
         {
            SavedForDebugging = (bool) serializer.LoadNamedObject( "SavedForDebugging" );
         }

         if ( serializer.CurrentVersion > 4 )
         {
            FriendlyName = (Parameter) serializer.LoadNamedObject( "FriendlyName" );
            Description  = (Parameter) serializer.LoadNamedObject( "Description" );
         }
         else
         {
            FriendlyName = new Parameter( );
            FriendlyName.Name = "FriendlyName";
            FriendlyName.FriendlyName = "Friendly Name";
            FriendlyName.Default = "";
            FriendlyName.Type    = typeof(string).ToString( );
            FriendlyName.Input   = true;
            FriendlyName.Output  = false;
            FriendlyName.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;

            Description = new Parameter( );
            Description.Name = "Description";
            Description.FriendlyName = "Description";
            Description.Default = "";
            Description.Type    = typeof(string).ToString( );
            Description.Input   = true;
            Description.Output  = false;
            Description.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         }
      }

      public void Save(ObjectSerializer serializer)
      {
         serializer.SaveNamedObjects( "NodeDatas", m_NodeDatas ); 
         serializer.SaveNamedObject ( "SceneName", SceneName ); 
         serializer.SaveNamedObject ( "GeneratedCodeIsStale", GeneratedCodeIsStale );
         serializer.SaveNamedObject ( "SavedForDebugging",    SavedForDebugging );
         serializer.SaveNamedObject ( "FriendlyName",    FriendlyName );
         serializer.SaveNamedObject ( "Description",     Description );
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

      public VisibleState State;
      public string FriendlyName;
      public string Name;
      public string Default;
      public string Type;
      public string ReferenceGuid;
      public bool   Input;
      public bool   Output;

      public static char ArrayDelimeter { get { return (char) 31; } }
   }

   public struct Plug
   {
      public string FriendlyName;
      public string Name;
   }

   public abstract class EntityNodeData : ISerializable
   {
      public Guid  Guid;
      public Point Position;
      
      public Parameter ShowComment;
      public Parameter Comment;

      public EntityNodeData( )
      {
         ShowComment = new Parameter( );
         ShowComment.FriendlyName = "Output Comment";
         ShowComment.Name         = "Output Comment";
         ShowComment.Default      = "false";
         ShowComment.Type         = typeof(bool).ToString( );
         ShowComment.Input        = true;
         ShowComment.Output       = false;
         ShowComment.State        = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;

         Comment = new Parameter( );
         Comment.FriendlyName = "Comment";
         Comment.Name         = "Comment";
         Comment.Default      = "";
         Comment.Type         = typeof(String).ToString( );
         Comment.Input        = true;
         Comment.Output       = false;
         Comment.State        = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
      }

      public virtual void Clone(EntityNodeData cloneFrom)
      {
         Guid        = cloneFrom.Guid;
         Position    = cloneFrom.Position;
         ShowComment = cloneFrom.ShowComment;
         Comment     = cloneFrom.Comment;
      }

      public int Version { get { return 2; } }

      public void Load(ObjectSerializer serializer)
      {
         Guid     = (Guid)  serializer.LoadNamedObject( "Guid" );
         Position.X = (int) serializer.LoadNamedObject( "X" );
         Position.Y = (int) serializer.LoadNamedObject( "Y" );

         if ( serializer.CurrentVersion > 1 )
         {
            ShowComment = (Parameter) serializer.LoadNamedObject( "ShowComment" );
            Comment     = (Parameter) serializer.LoadNamedObject( "Comment" );
         }
         else
         {
            ShowComment = new Parameter( );
            ShowComment.FriendlyName = "Output Comment";
            ShowComment.Name         = "Output Comment";
            ShowComment.Default      = "false";
            ShowComment.Type         = typeof(bool).ToString( );
            ShowComment.Input        = true;
            ShowComment.Output       = false;
            ShowComment.State        = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;

            Comment = new Parameter( );
            Comment.FriendlyName = "Comment";
            Comment.Name         = "Comment";
            Comment.Default      = "";
            Comment.Type         = typeof(String).ToString( );
            Comment.Input        = true;
            Comment.Output       = false;
            Comment.State        = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         }
      }

      public void Save(ObjectSerializer serializer)
      {
         serializer.SaveNamedObject( "Guid", Guid );
         serializer.SaveNamedObject( "X", Position.X );
         serializer.SaveNamedObject( "Y", Position.Y );

         serializer.SaveNamedObject( "ShowComment", ShowComment );
         serializer.SaveNamedObject( "Comment", Comment );
      }
   }

   public class LinkNodeData : EntityNodeData
   {
      public struct Connection
      {
         public Guid  Guid;
         public string Anchor;
      }

      public Connection Source;
      public Connection Destination;

      public override void Clone(EntityNodeData cloneFrom)
      {
         base.Clone( cloneFrom );

         LinkNodeData linkData = cloneFrom as LinkNodeData;
         if ( null == linkData ) return;

         Source      = linkData.Source;
         Destination = linkData.Destination;
      }

      public new int Version { get { return 1; } }

      public new void Load(ObjectSerializer serializer)
      {
         serializer.LoadBaseObject( this, typeof(EntityNodeData) );
      
         Source.Guid = (Guid) serializer.LoadNamedObject( "SourceGuid" );
         Source.Anchor = (string) serializer.LoadNamedObject( "SourceAnchor" );
         Destination.Guid = (Guid) serializer.LoadNamedObject( "DestinationGuid" );
         Destination.Anchor = (string) serializer.LoadNamedObject( "DestinationAnchor" );
      }

      public new void Save(ObjectSerializer serializer)
      {
         serializer.SaveBaseObject( this, typeof(EntityNodeData) );

         serializer.SaveNamedObject( "SourceGuid", Source.Guid );
         serializer.SaveNamedObject( "SourceAnchor", Source.Anchor );
         serializer.SaveNamedObject( "DestinationGuid", Destination.Guid );
         serializer.SaveNamedObject( "DestinationAnchor", Destination.Anchor );
      }
   }

   public class ExternalConnectionData : EntityNodeData
   {
      public Parameter Name;
      public Parameter Description;
      public Parameter Order;

      public override void Clone(EntityNodeData cloneFrom)
      {
         base.Clone( cloneFrom );

         ExternalConnectionData data = cloneFrom as ExternalConnectionData;
         if ( null == data ) return;
      
         Name = data.Name;
         Order= data.Order;
         Description = data.Description;
      }

      public new int Version { get { return 3; } }

      public new void Load(ObjectSerializer serializer)
      {
         serializer.LoadBaseObject( this, typeof(EntityNodeData) );
      
         if ( serializer.CurrentVersion > 1 )
         {
            Name = (Parameter) serializer.LoadNamedObject( "Name" );
         }
         else
         {
            Name = new Parameter( );
            Name.Name         = "Name";
            Name.FriendlyName = "Name";
            Name.Input   = false;
            Name.Output  = false;
            Name.Type    = typeof(String).ToString( );
            Name.Default = "";
            Name.State   = Parameter.VisibleState.Visible;
         }

         if ( serializer.CurrentVersion > 2 )
         {
            Order       = (Parameter) serializer.LoadNamedObject( "Order" );
            Description = (Parameter) serializer.LoadNamedObject( "Description" );
         }
         else
         {
            Order = new Parameter( );
            Order.Name    = "Order";
            Order.FriendlyName = "Order";
            Order.Default = "0";
            Order.Type    = typeof(int).ToString( );
            Order.Input   = true;
            Order.Output  = false;
            Order.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;

            Description = new Parameter( );
            Description.Name    = "Description";
            Description.FriendlyName = "Description";
            Description.Default = "";
            Description.Type    = typeof(string).ToString( );
            Description.Input   = true;
            Description.Output  = false;
            Description.State   = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
         }

      }

      public new void Save(ObjectSerializer serializer)
      {
         serializer.SaveBaseObject( this, typeof(EntityNodeData) );

         serializer.SaveNamedObject( "Name", Name );
         serializer.SaveNamedObject( "Order", Order );
         serializer.SaveNamedObject( "Description", Description );
      }
   }

   public class OwnerConnectionData : EntityNodeData
   {
      public override void Clone(EntityNodeData cloneFrom)
      {
         base.Clone( cloneFrom );

         OwnerConnectionData data = cloneFrom as OwnerConnectionData;
         if ( null == data ) return;
      }

      public new int Version { get { return 1; } }

      public new void Load(ObjectSerializer serializer)
      {
         serializer.LoadBaseObject( this, typeof(EntityNodeData) );      
      }

      public new void Save(ObjectSerializer serializer)
      {
         serializer.SaveBaseObject( this, typeof(EntityNodeData) );
      }
   }
   
   public class EntityMethodData : EntityNodeData
   {
      public Plug Input;
      public Plug Output;

      public bool IsStatic;
      public string ComponentType;

      public Parameter Instance;
      public Parameter []Parameters;
    
      public override void Clone(EntityNodeData cloneFrom)
      {
         base.Clone( cloneFrom );

         EntityMethodData data = cloneFrom as EntityMethodData;
         if ( null == data ) return;

         Instance   = data.Instance;
         Input      = data.Input;
         Output     = data.Output;
         IsStatic   = data.IsStatic;
         ComponentType = data.ComponentType;
         Parameters    = data.Parameters;
      }

      public new int Version { get { return 6; } }

      public new void Load(ObjectSerializer serializer)
      {
         serializer.LoadBaseObject( this, typeof(EntityNodeData) );
      
         Instance   = (Parameter)serializer.LoadNamedObject( "Instance" );
         Parameters = (Parameter[]) serializer.LoadNamedObject( "Parameters" );

         if ( serializer.CurrentVersion == 1 )
         {
            Output.Name = (string) serializer.LoadNamedObject( "Output" );
            Output.FriendlyName = Output.Name;

            Input.Name = (string) serializer.LoadNamedObject( "MethodName" );
            Input.FriendlyName = Output.Name;
         }
         else if ( serializer.CurrentVersion == 2 )
         {
            Input.Name = (string) serializer.LoadNamedObject( "Input" );
            Input.FriendlyName = Input.Name;

            Output.Name = (string) serializer.LoadNamedObject( "Output" );
            Output.FriendlyName = Output.Name;  
         }
         else
         {
            Input = (Plug) serializer.LoadNamedObject( "Input" );
            Output= (Plug) serializer.LoadNamedObject( "Output" );
         }

         if ( serializer.CurrentVersion < 5 )
         {
            ComponentType = Instance.Type;
            Instance.Type = typeof(UnityEngine.GameObject).ToString( );
         }
         else
         {
            ComponentType = (string) serializer.LoadNamedObject( "ComponentType" );
         }

         if ( serializer.CurrentVersion < 6 )
         {
            IsStatic = false;
         }
         else
         {
            IsStatic = (bool) serializer.LoadNamedObject( "IsStatic" );
         }
      }

      public new void Save(ObjectSerializer serializer)
      {
         serializer.SaveBaseObject( this, typeof(EntityNodeData) );

         serializer.SaveNamedObject( "Instance", Instance );
         serializer.SaveNamedObject( "Input", Input );
         serializer.SaveNamedObject( "Output", Output );
         serializer.SaveNamedObject( "Parameters", Parameters );
         serializer.SaveNamedObject( "ComponentType", ComponentType );
         serializer.SaveNamedObject( "IsStatic", IsStatic );
      }
   }

   public class EntityEventData : EntityNodeData
   {
      public Plug[] Outputs;
      public string EventArgs;
      public string ComponentType;

      public Parameter Instance;
      public Parameter []Parameters;

      public override void Clone(EntityNodeData cloneFrom)
      {
         base.Clone( cloneFrom );

         EntityEventData data = cloneFrom as EntityEventData;
         if ( null == data ) return;

         Instance     = data.Instance;
         EventArgs    = data.EventArgs;

         ComponentType = data.ComponentType;

         Outputs = new Plug[ data.Outputs.Length ];
         data.Outputs.CopyTo( Outputs, 0 );

         Parameters = new Parameter[ data.Parameters.Length ];
         data.Parameters.CopyTo( Parameters, 0 );
      }

      public new int Version { get { return 7; } }

      public new void Load(ObjectSerializer serializer)
      {
         serializer.LoadBaseObject( this, typeof(EntityNodeData) );
      
         Instance  = (Parameter) serializer.LoadNamedObject( "Instance" );
         
         if ( serializer.CurrentVersion == 1 )
         {
            Outputs = new Plug[ 1 ];

            Outputs[ 0 ].Name = (string) serializer.LoadNamedObject( "EventName" );
            Outputs[ 0 ].FriendlyName = Outputs[ 0 ].Name;
         }
         else if ( serializer.CurrentVersion == 2 )
         {
            Outputs = new Plug[ 1 ];

            Outputs[ 0 ].Name = (string) serializer.LoadNamedObject( "Output" );
            Outputs[ 0 ].FriendlyName = Outputs[ 0 ].Name;
         }
         else if ( serializer.CurrentVersion < 5 )
         {
            Outputs = new Plug[ 1 ];
            Outputs[ 0 ] = (Plug) serializer.LoadNamedObject( "Output" );
         }
         else
         {
            Outputs = (Plug[]) serializer.LoadNamedObject( "Outputs" );
         }

         if ( serializer.CurrentVersion > 3 )
         {
            EventArgs = (string) serializer.LoadNamedObject( "EventArgs" );
         }
         else
         {
            EventArgs = "System.EventArgs";
         }

         Parameters = (Parameter[]) serializer.LoadNamedObject( "Parameters" );

         if ( serializer.CurrentVersion < 7 )
         {
            ComponentType = Instance.Type;
            Instance.Type = typeof(UnityEngine.GameObject).ToString( );
         }
         else
         {
            ComponentType = (string) serializer.LoadNamedObject( "ComponentType" );
         }
      }

      public new void Save(ObjectSerializer serializer)
      {
         serializer.SaveBaseObject( this, typeof(EntityNodeData) );

         serializer.SaveNamedObject( "Outputs",    Outputs );
         serializer.SaveNamedObject( "Instance",   Instance );
         serializer.SaveNamedObject( "Parameters", Parameters );
         serializer.SaveNamedObject( "EventArgs",  EventArgs );
         serializer.SaveNamedObject( "ComponentType", ComponentType );
      }
   }

   public class LogicNodeData : EntityNodeData
   {
      public string Type;
      public string FriendlyName;
      public string EventArgs;
      public Plug   []Inputs;
      public Plug   []Outputs;
      public Plug   []Events;
      public string []Drivens;
      public string []RequiredMethods;

      public Parameter InspectorName;
      public Parameter []Parameters;
      public Parameter []EventParameters;
      
      public override void Clone(EntityNodeData cloneFrom)
      {
         base.Clone( cloneFrom );

         LogicNodeData data = cloneFrom as LogicNodeData;
         if ( null == data ) return;

         Type = data.Type;
         FriendlyName = data.FriendlyName;
         Inputs  = data.Inputs;
         Outputs = data.Outputs;
         Parameters = data.Parameters;
         Events = data.Events;   
         Drivens = data.Drivens;
         RequiredMethods = data.RequiredMethods;
         InspectorName = data.InspectorName;
         EventArgs = data.EventArgs;
         EventParameters = data.EventParameters;
      }

      public new int Version { get { return 8; } }

      public new void Load(ObjectSerializer serializer)
      {
         serializer.LoadBaseObject( this, typeof(EntityNodeData) );
      
         Type = (string)serializer.LoadNamedObject( "Type" );
         
         if ( serializer.CurrentVersion > 1 )
         {
            FriendlyName = (string)serializer.LoadNamedObject( "FriendlyName" );
         }
         else
         {
            FriendlyName = Type;
         }

         if ( serializer.CurrentVersion == 1 )
         {
            string []inputs  = (string[]) serializer.LoadNamedObject( "Inputs" ); 
            string []outputs = (string[]) serializer.LoadNamedObject( "Outputs" ); 
            string []events  = (string[]) serializer.LoadNamedObject( "Events" ); 
         
            List<Plug> plugs = new List<Plug>( );
            foreach ( string s in inputs )
            {
               Plug plug;
               plug.Name = s;
               plug.FriendlyName = s;

               plugs.Add( plug );
            }

            Inputs = plugs.ToArray( );
            
            plugs.Clear( );
            foreach ( string s in outputs )
            {
               Plug plug;
               plug.Name = s;
               plug.FriendlyName = s;

               plugs.Add( plug );
            }

            Outputs = plugs.ToArray( );

            plugs.Clear( );
            foreach ( string s in events )
            {
               Plug plug;
               plug.Name = s;
               plug.FriendlyName = s;

               plugs.Add( plug );
            }

            Events = plugs.ToArray( );

            Drivens = new string[0];
         }
         else
         {
            Inputs = (Plug[]) serializer.LoadNamedObject( "Inputs" ); 
            Outputs= (Plug[]) serializer.LoadNamedObject( "Outputs" ); 
            Events = (Plug[]) serializer.LoadNamedObject( "Events" ); 
         
            if ( serializer.CurrentVersion > 2 )
            {
               Drivens = (string[]) serializer.LoadNamedObject( "Drivens" );
            }
            else
            {
               Drivens = new string[0];
            }

            if ( serializer.CurrentVersion > 4 )
            {
               RequiredMethods = (string[]) serializer.LoadNamedObject( "RequiredMethods" );
            }
            else
            {
               RequiredMethods = new string[0];
            }

            if ( serializer.CurrentVersion > 5 )
            {
               InspectorName = (Parameter) serializer.LoadNamedObject( "InspectorName" );
            }
            else
            {
               InspectorName = new Parameter( );
               InspectorName.Name         = "Inspector Name";
               InspectorName.FriendlyName = "Inspector Name";
               InspectorName.Type         = typeof(string).ToString( );
               InspectorName.Input        = true;
               InspectorName.Output       = false;
               InspectorName.Default      = "";
               InspectorName.State        = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;
            }

            if ( serializer.CurrentVersion > 6 )
            {
               EventParameters = (Parameter[]) serializer.LoadNamedObject( "EventParameters" );
               EventArgs = (string) serializer.LoadNamedObject( "EventArgs" );
            }
            else
            {
               EventParameters = new Parameter[ 0 ];
            }

            if (EventArgs == null || EventArgs == "")
            {
               EventArgs = "System.EventArgs";
            }
         }

         Parameters = (Parameter[]) serializer.LoadNamedObject( "Parameters" ); 
      }

      public new void Save(ObjectSerializer serializer)
      {
         serializer.SaveBaseObject( this, typeof(EntityNodeData) );

         serializer.SaveNamedObject( "Type", Type );
         serializer.SaveNamedObject( "FriendlyName", FriendlyName );
         serializer.SaveNamedObject( "Inputs", Inputs );
         serializer.SaveNamedObject( "Outputs", Outputs );         
         serializer.SaveNamedObject( "Events", Events );         
         serializer.SaveNamedObject( "Parameters", Parameters );
         serializer.SaveNamedObject( "EventArgs", EventArgs );
         serializer.SaveNamedObject( "EventParameters", EventParameters );
         serializer.SaveNamedObject( "Drivens", Drivens );
         serializer.SaveNamedObject( "RequiredMethods", RequiredMethods );
         serializer.SaveNamedObject( "InspectorName", InspectorName );
      }
   }

   public class EntityPropertyData : EntityNodeData
   {
      public Parameter Instance;
      public Parameter Parameter;
      public string    ComponentType;

      public override void Clone(EntityNodeData cloneFrom)
      {
         base.Clone( cloneFrom );

         EntityPropertyData data = cloneFrom as EntityPropertyData;
         if ( null == data ) return;

         Instance      = data.Instance;
         Parameter     = data.Parameter; 
         ComponentType = data.ComponentType;
      }

      public new int Version { get { return 2; } }

      public new void Load(ObjectSerializer serializer)
      {
         serializer.LoadBaseObject( this, typeof(EntityNodeData) );
      
         Instance  = (Parameter) serializer.LoadNamedObject( "Instance" );
         Parameter = (Parameter) serializer.LoadNamedObject( "Parameter" );
      
         if ( serializer.CurrentVersion > 1 )
         {
            ComponentType = (string) serializer.LoadNamedObject( "ComponentType" );
         }
         else
         {
            ComponentType = Instance.Type;
            Instance.Type = typeof(UnityEngine.GameObject).ToString( );
         }
      }

      public new void Save(ObjectSerializer serializer)
      {
         serializer.SaveBaseObject( this, typeof(EntityNodeData) );

         serializer.SaveNamedObject( "Instance", Instance );
         serializer.SaveNamedObject( "Parameter", Parameter );
         serializer.SaveNamedObject( "ComponentType", ComponentType );
      }
   }

   public class CommentNodeData : EntityNodeData
   {
      public Parameter TitleText;
      public Parameter TitleTextColor;
      public Parameter BodyText;
      public Parameter BodyTextColor;
      public Parameter NodeColor;         
      public Parameter Width;
      public Parameter Height;

      public CommentNodeData( )
      {
      }

      public override void Clone(EntityNodeData cloneFrom)
      {
         base.Clone( cloneFrom );

         CommentNodeData data = cloneFrom as CommentNodeData;
         if ( null == data ) return;

         TitleText = data.TitleText;
         TitleTextColor = data.TitleTextColor;
         BodyText = data.BodyText;
         BodyTextColor = data.BodyTextColor;
         NodeColor = data.NodeColor;
         Width = data.Width;
         Height = data.Height;
      }

      public new int Version { get { return 4; } }

      public new void Load(ObjectSerializer serializer)
      {
         serializer.LoadBaseObject( this, typeof(EntityNodeData) );
      
         if ( 1 == serializer.CurrentVersion )
         {
            BodyText = (Parameter) serializer.LoadNamedObject( "Parameter" );
         }
         else if ( 2 == serializer.CurrentVersion )
         {
            BodyText = (Parameter) serializer.LoadNamedObject( "UserComment" );
         }
         else
         {
            BodyText       = (Parameter) serializer.LoadNamedObject( "BodyText" );
            BodyTextColor  = (Parameter) serializer.LoadNamedObject( "BodyTextColor" );
            TitleText      = (Parameter) serializer.LoadNamedObject( "TitleText" );
            TitleTextColor = (Parameter) serializer.LoadNamedObject( "TitleTextColor" );
            NodeColor      = (Parameter) serializer.LoadNamedObject( "NodeColor" );
         }

         if ( serializer.CurrentVersion > 3 )
         {
            Width = (Parameter) serializer.LoadNamedObject( "Width" );
            Height = (Parameter) serializer.LoadNamedObject( "Height" );
         }
         else if ( serializer.CurrentVersion > 1 )
         {
            Parameter size = (Parameter) serializer.LoadNamedObject( "Size" );
            string []intArray = size.Default.Split( ',' );

            Width = new Parameter( );
            Width.Name    = "Width";
            Width.FriendlyName = "Width";
            Width.Type         = typeof(int).ToString( );
            Width.Input        = true;
            Width.Output       = false;
            Width.Default      = intArray[0];
            Width.State        = Parameter.VisibleState.Visible;

            Height = new Parameter( );
            Height.Name    = "Height";
            Height.FriendlyName = "Height";
            Height.Type         = typeof(int).ToString( );
            Height.Input        = true;
            Height.Output       = false;
            Height.Default      = intArray.Length > 1 ? intArray[1] : "0";
            Height.State        = Parameter.VisibleState.Visible;
         }
         else
         {
            Width = new Parameter( );
            Width.Name    = "Width";
            Width.FriendlyName = "Width";
            Width.Type         = typeof(int).ToString( );
            Width.Input        = true;
            Width.Output       = false;
            Width.Default      = "0";
            Width.State        = Parameter.VisibleState.Visible;

            Height = new Parameter( );
            Height.Name    = "Height";
            Height.FriendlyName = "Height";
            Height.Type         = typeof(int).ToString( );
            Height.Input        = true;
            Height.Output       = false;
            Height.Default      = "0";
            Height.State        = Parameter.VisibleState.Visible;
         }
      }

      public new void Save(ObjectSerializer serializer)
      {
         serializer.SaveBaseObject( this, typeof(EntityNodeData) );

         serializer.SaveNamedObject( "BodyText",       BodyText );
         serializer.SaveNamedObject( "BodyTextColor",  BodyTextColor );
         serializer.SaveNamedObject( "TitleText",      TitleText );
         serializer.SaveNamedObject( "TitleTextColor", TitleTextColor );
         serializer.SaveNamedObject( "NodeColor",      NodeColor );
         serializer.SaveNamedObject( "Width",          Width );
         serializer.SaveNamedObject( "Height",         Height );
      }
   }

   public class LocalNodeData : EntityNodeData
   {
      public Parameter []Parameters;

      public override void Clone(EntityNodeData cloneFrom)
      {
         base.Clone( cloneFrom );

         LocalNodeData data = cloneFrom as LocalNodeData;
         if ( null == data ) return;

         Parameters = data.Parameters;
      }

      public new int Version { get { return 3; } }

      public new void Load(ObjectSerializer serializer)
      {
         serializer.LoadBaseObject( this, typeof(EntityNodeData) );
      
         if ( serializer.CurrentVersion == 1 ) 
         {
            Parameter parameter = (Parameter) serializer.LoadNamedObject( "Parameter" );
            
            Parameter name = new Parameter( );
            name.Default      = Guid.NewGuid( ).ToString( );
            name.Input        = true;
            name.Output       = false;
            name.Name         = "Name";
            name.FriendlyName = "Name";
            name.State        = Parameter.VisibleState.Visible;
            name.Type         = typeof(string).ToString( );

            Parameters = new Parameter[] { parameter, name };
         }
         else
         {
            Parameters = (Parameter[]) serializer.LoadNamedObject( "Parameters" );
         
            if ( serializer.CurrentVersion < 3 )
            {
               Parameter externaled = new Parameter( );

               externaled.Default      = "false";
               externaled.Input        = true;
               externaled.Output       = false;
               externaled.Name         = "Expose to Unity";
               externaled.FriendlyName = "Expose to Unity";
               externaled.State        = Parameter.VisibleState.Locked | Parameter.VisibleState.Hidden;
               externaled.Type         = typeof(bool).ToString( );

               Array.Resize<Parameter>( ref Parameters, Parameters.Length + 1 );            
               Parameters[ Parameters.Length - 1 ] = externaled; 
            }
         }
      }

      public new void Save(ObjectSerializer serializer)
      {
         serializer.SaveBaseObject( this, typeof(EntityNodeData) );

         serializer.SaveNamedObject( "Parameters", Parameters );
      }
   }

   public class ParameterSerializer : ITypeSerializer
   {
      public int Version { get { return 8; } }
      public string SerializableType { get { return typeof(Parameter).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         object value;

         serializer.GetData( out value );
         byte [] data = value as byte[];
      
         MemoryStream stream = new MemoryStream( data );
         BinaryReader reader = new BinaryReader( stream );

         Parameter parameter;

         parameter.Name = reader.ReadString( );

         if ( serializer.CurrentVersion > 1 )
         {
            parameter.FriendlyName = reader.ReadString( );
         }
         else
         {
            parameter.FriendlyName = parameter.Name;
         }

         parameter.Default = reader.ReadString( );
         parameter.Type    = reader.ReadString( );
         parameter.Input   = reader.ReadBoolean( );
         parameter.Output  = reader.ReadBoolean( );

         if ( serializer.CurrentVersion < 5 )
         {
            if ( "Int"    == parameter.Type ) parameter.Type = typeof(int).ToString( );
            if ( "String" == parameter.Type ) parameter.Type = typeof(String).ToString( );
            if ( "Color"  == parameter.Type ) parameter.Type = typeof(UnityEngine.Color).ToString( );
            if ( "Bool"   == parameter.Type ) parameter.Type = typeof(bool).ToString( );
         }

         if ( serializer.CurrentVersion > 2 )
         {
            parameter.State = (Parameter.VisibleState) Enum.Parse(typeof(Parameter.VisibleState), reader.ReadString( ));
         }
         else
         {
            parameter.State = Parameter.VisibleState.Visible;
         }

         if ( serializer.CurrentVersion > 3 )
         {
            parameter.ReferenceGuid = reader.ReadString( );
         }
         else
         {
            parameter.ReferenceGuid = "";
         }

         if ( serializer.CurrentVersion < 6 )
         {
            if ( parameter.Type.Contains("[]") )
            {
               parameter.Default = parameter.Default.Replace( ',', Parameter.ArrayDelimeter );
            }
         }

         if ( serializer.CurrentVersion < 7 )
         {
            if ( parameter.Type.Contains("[]") && parameter.Default.Length > 0 )
            {
               parameter.Default = Parameter.ArrayDelimeter + parameter.Default;
            }
         }

         if ( serializer.CurrentVersion < 8 )
         {
            if (parameter.Type == typeof(UnityEngine.LayerMask).ToString())
            {
               try
               {
                  //convert old layer masks to bit shifted values
                  Int32 index = Int32.Parse(parameter.Default);
                  index = 1 << index;

                  parameter.Default = index.ToString();
               }
               catch (Exception)
               {}
            }
         }

         reader.Close( );

         return parameter;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Parameter value = (Parameter) data;

         MemoryStream stream = new MemoryStream( );
         BinaryWriter writer = new BinaryWriter( stream );

         writer.Write( value.Name );
         writer.Write( value.FriendlyName );
         writer.Write( value.Default );
         writer.Write( value.Type );
         writer.Write( value.Input );
         writer.Write( value.Output );
         writer.Write( value.State.ToString( ) );
         writer.Write( value.ReferenceGuid != null ? value.ReferenceGuid : "" );
         serializer.SetData( stream.ToArray( ) );

         writer.Close( );
      }
   }

   public class ParameterArraySerializer : ITypeSerializer
   {
      public int Version { get { return 9; } }
      public string SerializableType { get { return typeof(Parameter[]).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         object value;

         serializer.GetData( out value );
         byte [] data = value as byte[];
      
         MemoryStream stream = new MemoryStream( data );
         BinaryReader reader = new BinaryReader( stream );

         int i, count = reader.ReadInt32( );

         Parameter []parameters = new Parameter[ count ];

         for ( i = 0; i < count; i++ )
         {
            parameters[ i ].Name    = reader.ReadString( );

            if ( serializer.CurrentVersion > 1 )
            {
               parameters[ i ].FriendlyName = reader.ReadString( );
            }
            else
            {
               parameters[ i ].FriendlyName = parameters[ i ].Name;
            }

            parameters[ i ].Default = reader.ReadString( );
            parameters[ i ].Type    = reader.ReadString( );
            parameters[ i ].Input   = reader.ReadBoolean( );
            parameters[ i ].Output  = reader.ReadBoolean( );

            if ( serializer.CurrentVersion < 5 )
            {
               if ( "Int"    == parameters[ i ].Type ) parameters[ i ].Type = typeof(int).ToString( );
               if ( "String" == parameters[ i ].Type ) parameters[ i ].Type = typeof(String).ToString( );
               if ( "Color"  == parameters[ i ].Type ) parameters[ i ].Type = typeof(UnityEngine.Color).ToString( );
               if ( "Bool"   == parameters[ i ].Type ) parameters[ i ].Type = typeof(bool).ToString( );
            }

            if ( serializer.CurrentVersion > 2 )
            {
               parameters[ i ].State = (Parameter.VisibleState) Enum.Parse(typeof(Parameter.VisibleState), reader.ReadString( ));
            }
            else
            {
               parameters[ i ].State = Parameter.VisibleState.Visible;
            }

            if ( serializer.CurrentVersion > 3 )
            {
               parameters[ i ].ReferenceGuid = reader.ReadString( );
            }
            else
            {
               parameters[ i ].ReferenceGuid = "";
            }

            if ( serializer.CurrentVersion < 7 )
            {
               if ( parameters[i].Type.Contains("[]") )
               {
                  parameters[i].Default = parameters[i].Default.Replace( ',', Parameter.ArrayDelimeter );
               }
            }

            if ( serializer.CurrentVersion < 8 )
            {
               if ( parameters[i].Type.Contains("[]") && parameters[i].Default.Length > 0 )
               {
                  parameters[i].Default = Parameter.ArrayDelimeter + parameters[i].Default;
               }
            }

            if ( serializer.CurrentVersion < 9 )
            {
               if (parameters[i].Type == typeof(UnityEngine.LayerMask).ToString())
               {
                  try
                  {
                     //convert old layer masks to bit shifted values
                     Int32 index = Int32.Parse(parameters[i].Default);
                     index = 1 << index;
                     
                     parameters[i].Default = index.ToString();
                  }
                  catch (Exception)
                  {}
               }
            }
         }

         reader.Close( );

         return parameters;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Parameter []parameters = (Parameter[]) data;

         MemoryStream stream = new MemoryStream( );
         BinaryWriter writer = new BinaryWriter( stream );

         writer.Write( (int) parameters.Length );

         foreach (Parameter p in parameters)
         {
            writer.Write( p.Name );
            writer.Write( p.FriendlyName );
            writer.Write( p.Default );
            writer.Write( p.Type );
            writer.Write( p.Input );
            writer.Write( p.Output );
            writer.Write( p.State.ToString( ));
            writer.Write( p.ReferenceGuid != null ? p.ReferenceGuid : "" );
         }

         serializer.SetData( stream.ToArray() );

         writer.Close( );
      }
   }

   public class PlugSerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(Plug).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         object value;

         serializer.GetData( out value );
         byte [] data = value as byte[];
      
         MemoryStream stream = new MemoryStream( data );
         BinaryReader reader = new BinaryReader( stream );

         Plug plug;

         plug.Name = reader.ReadString( );
         plug.FriendlyName = reader.ReadString( );

         reader.Close( );

         return plug;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Plug value = (Plug) data;

         MemoryStream stream = new MemoryStream( );
         BinaryWriter writer = new BinaryWriter( stream );

         writer.Write( value.Name );
         writer.Write( value.FriendlyName );

         serializer.SetData( stream.ToArray( ) );

         writer.Close( );
      }
   }

   public class PlugArraySerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(Plug[]).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         object value;

         serializer.GetData( out value );
         byte [] data = value as byte[];
      
         MemoryStream stream = new MemoryStream( data );
         BinaryReader reader = new BinaryReader( stream );

         int i, count = reader.ReadInt32( );

         Plug []plugs = new Plug[ count ];

         for ( i = 0; i < count; i++ )
         {
            plugs[ i ].Name         = reader.ReadString( );
            plugs[ i ].FriendlyName = reader.ReadString( );
         }

         reader.Close( );

         return plugs;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Plug []plugs = (Plug[]) data;

         MemoryStream stream = new MemoryStream( );
         BinaryWriter writer = new BinaryWriter( stream );

         writer.Write( (int) plugs.Length );

         foreach (Plug p in plugs)
         {
            writer.Write( p.Name );
            writer.Write( p.FriendlyName );
         }

         serializer.SetData( stream.ToArray() );

         writer.Close( );
      }
   }
}

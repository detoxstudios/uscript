using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using Detox.Utility;

namespace Detox.Data.ScriptEditor
{
   public class ScriptEditorData : ISerializable
   {
      private EntityNodeData []m_NodeDatas = null;
      public string SceneName = "";

      static ScriptEditorData( )
      {
         ObjectSerializer.AddTypeSerializer( new ParameterSerializer( ) );
         ObjectSerializer.AddTypeSerializer( new ParameterArraySerializer( ) );
         ObjectSerializer.AddTypeSerializer( new PlugSerializer( ) );
         ObjectSerializer.AddTypeSerializer( new PlugArraySerializer( ) );
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


      public int Version { get { return 2; } }

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
      }

      public void Save(ObjectSerializer serializer)
      {
         serializer.SaveNamedObjects( "NodeDatas", m_NodeDatas ); 
         serializer.SaveNamedObject ( "SceneName", SceneName ); 
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
      public bool   Input;
      public bool   Output;
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
         ShowComment.Type         = "Bool";
         ShowComment.Input        = true;
         ShowComment.Output       = false;
         ShowComment.State        = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;

         Comment = new Parameter( );
         Comment.FriendlyName = "Comment";
         Comment.Name         = "Comment";
         Comment.Default      = "";
         Comment.Type         = "String";
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
            ShowComment.Type         = "Bool";
            ShowComment.Input        = true;
            ShowComment.Output       = false;
            ShowComment.State        = Parameter.VisibleState.Hidden | Parameter.VisibleState.Locked;

            Comment = new Parameter( );
            Comment.FriendlyName = "Comment";
            Comment.Name         = "Comment";
            Comment.Default      = "";
            Comment.Type         = "String";
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

      public override void Clone(EntityNodeData cloneFrom)
      {
         base.Clone( cloneFrom );

         ExternalConnectionData data = cloneFrom as ExternalConnectionData;
         if ( null == data ) return;
      
         Name = data.Name;
      }

      public new int Version { get { return 2; } }

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
            Name.Type    = "String";
            Name.Default = "";
            Name.State   = Parameter.VisibleState.Visible;
         }
      }

      public new void Save(ObjectSerializer serializer)
      {
         serializer.SaveBaseObject( this, typeof(EntityNodeData) );

         serializer.SaveNamedObject( "Name", Name );
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

         ComponentType = data.ComponentType;
         Parameters    = data.Parameters;
      }

      public new int Version { get { return 5; } }

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
      }

      public new void Save(ObjectSerializer serializer)
      {
         serializer.SaveBaseObject( this, typeof(EntityNodeData) );

         serializer.SaveNamedObject( "Instance", Instance );
         serializer.SaveNamedObject( "Input", Input );
         serializer.SaveNamedObject( "Output", Output );
         serializer.SaveNamedObject( "Parameters", Parameters );
         serializer.SaveNamedObject( "ComponentType", ComponentType );
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
      public Plug   []Inputs;
      public Plug   []Outputs;
      public Plug   []Events;
      public string []Drivens;

      public Parameter []Parameters;

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
      }

      public new int Version { get { return 3; } }

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
         serializer.SaveNamedObject( "Drivens", Drivens );
      }
   }

   public class EntityPropertyData : EntityNodeData
   {
      public Parameter Instance;
      public Parameter Parameter;

      public override void Clone(EntityNodeData cloneFrom)
      {
         base.Clone( cloneFrom );

         EntityPropertyData data = cloneFrom as EntityPropertyData;
         if ( null == data ) return;

         Instance  = data.Instance;
         Parameter = data.Parameter; 
      }

      public new int Version { get { return 1; } }

      public new void Load(ObjectSerializer serializer)
      {
         serializer.LoadBaseObject( this, typeof(EntityNodeData) );
      
         Instance  = (Parameter) serializer.LoadNamedObject( "Instance" );
         Parameter = (Parameter) serializer.LoadNamedObject( "Parameter" );
      }

      public new void Save(ObjectSerializer serializer)
      {
         serializer.SaveBaseObject( this, typeof(EntityNodeData) );

         serializer.SaveNamedObject( "Instance", Instance );
         serializer.SaveNamedObject( "Parameter", Parameter );
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
            Width.Type         = "Int";
            Width.Input        = true;
            Width.Output       = false;
            Width.Default      = intArray[0];
            Width.State        = Parameter.VisibleState.Visible;

            Height = new Parameter( );
            Height.Name    = "Height";
            Height.FriendlyName = "Height";
            Height.Type         = "Int";
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
            Width.Type         = "Int";
            Width.Input        = true;
            Width.Output       = false;
            Width.Default      = "0";
            Width.State        = Parameter.VisibleState.Visible;

            Height = new Parameter( );
            Height.Name    = "Height";
            Height.FriendlyName = "Height";
            Height.Type         = "Int";
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

      public new int Version { get { return 2; } }

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
      public int Version { get { return 3; } }
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

         if ( serializer.CurrentVersion > 2 )
         {
            parameter.State = (Parameter.VisibleState) Enum.Parse(typeof(Parameter.VisibleState), reader.ReadString( ));
         }
         else
         {
            parameter.State = Parameter.VisibleState.Visible;
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

         serializer.SetData( stream.ToArray( ) );

         writer.Close( );
      }
   }

   public class ParameterArraySerializer : ITypeSerializer
   {
      public int Version { get { return 3; } }
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

            if ( serializer.CurrentVersion > 2 )
            {
               parameters[ i ].State = (Parameter.VisibleState) Enum.Parse(typeof(Parameter.VisibleState), reader.ReadString( ));
            }
            else
            {
               parameters[ i ].State = Parameter.VisibleState.Visible;
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

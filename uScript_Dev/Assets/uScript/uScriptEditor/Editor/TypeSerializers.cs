using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using Detox.DirectX;
using Detox.Utility;

namespace Detox.Data
{
   public class IntSerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(int).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         object value;
         serializer.GetData( out value );
      
         return (int) value;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         int value = (int) data;
         serializer.SetData( value );
      }
   }

   public class AnimationCurveSerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(UnityEngine.AnimationCurve).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         UnityEngine.AnimationCurve curve = new UnityEngine.AnimationCurve( );

         curve.keys        = (UnityEngine.Keyframe[]) serializer.LoadNamedObject( "Keys" );
         curve.preWrapMode = (UnityEngine.WrapMode)   serializer.LoadNamedObject( "PreWrapMode" );
         curve.postWrapMode= (UnityEngine.WrapMode)   serializer.LoadNamedObject( "PostWrapMode" );
      
         return curve;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         UnityEngine.AnimationCurve curve = (UnityEngine.AnimationCurve) data;

         serializer.SaveNamedObject( "Keys",         curve.keys );
         serializer.SaveNamedObject( "PreWrapMode",  curve.preWrapMode );
         serializer.SaveNamedObject( "PostWrapMode", curve.postWrapMode );
      }
   }

   public class KeyframeArraySerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(UnityEngine.Keyframe[]).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         object value;

         serializer.GetData( out value );
         byte [] data = value as byte[];
      
         MemoryStream stream = new MemoryStream( data );
         BinaryReader reader = new BinaryReader( stream );

         int i, count = reader.ReadInt32( );

         UnityEngine.Keyframe []keyframes = new UnityEngine.Keyframe[ count ];

         for ( i = 0; i < count; i++ )
         {
            keyframes[ i ].time      = reader.ReadSingle( );
            keyframes[ i ].value     = reader.ReadSingle( );
            keyframes[ i ].inTangent = reader.ReadSingle( );
            keyframes[ i ].outTangent= reader.ReadSingle( );
         }

         reader.Close( );
         return keyframes;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         UnityEngine.Keyframe []keyframes = (UnityEngine.Keyframe[]) data;

         MemoryStream stream = new MemoryStream( );
         BinaryWriter writer = new BinaryWriter( stream );

         writer.Write( (int) keyframes.Length );

         foreach (UnityEngine.Keyframe keyframe in keyframes)
         {
            writer.Write( keyframe.time );
            writer.Write( keyframe.value );
            writer.Write( keyframe.inTangent );
            writer.Write( keyframe.outTangent );
         }

         serializer.SetData( stream.ToArray() );

         writer.Close( );
      }
   }

   public class SystemIdSerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(SystemId).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         object value;
         serializer.GetData( out value );
      
         return new SystemId( value as string );
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         string value = ((SystemId) data).ToString( );
         serializer.SetData( value );
      }
   }

   public class EnumSerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(Enum).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         object value;

         serializer.GetData( out value );
         byte [] data = value as byte[];
      
         MemoryStream stream = new MemoryStream( data );
         BinaryReader reader = new BinaryReader( stream );

         string type  = reader.ReadString( );
         string enumValue = reader.ReadString( );

         reader.Close( );

         return Enum.Parse(Type.GetType(type), enumValue);
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         MemoryStream stream = new MemoryStream( );
         BinaryWriter writer = new BinaryWriter( stream );

         writer.Write( data.GetType().AssemblyQualifiedName );
         writer.Write( data.ToString( ) );

         serializer.SetData( stream.ToArray() );

         writer.Close( );
      }
   }

   public class FloatSerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(float).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         object value;
         serializer.GetData( out value );
      
         return (float) value;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         float value = (float) data;
         serializer.SetData( value );
      }
   }

   public class GuidSerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(Guid).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         object value;
         serializer.GetData( out value );
      
         return new Guid( value as string );
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Guid value = (Guid) data;
         serializer.SetData( value.ToString() );
      }
   }

   public class BoolSerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(bool).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         object value;
         serializer.GetData( out value );
      
         return (bool) value;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         bool value = (bool) data;
         serializer.SetData( value );
      }
   }

   public class StringSerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(string).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         object value;
         serializer.GetData( out value );
      
         return (string) value;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         string value = data as string;
         serializer.SetData( value );
      }
   }

   public class StringArraySerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(string[]).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         object value;

         serializer.GetData( out value );
         byte [] data = value as byte[];
      
         MemoryStream stream = new MemoryStream( data );
         BinaryReader reader = new BinaryReader( stream );

         int i, count = reader.ReadInt32( );

         string []strings = new string[ count ];

         for ( i = 0; i < count; i++ )
         {
            strings[ i ] = reader.ReadString( );
         }

         reader.Close( );

         return strings;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         string []strings = (string[]) data;

         MemoryStream stream = new MemoryStream( );
         BinaryWriter writer = new BinaryWriter( stream );

         writer.Write( (int) strings.Length );

         foreach (string s in strings)
         {
            writer.Write( s );
         }

         serializer.SetData( stream.ToArray() );

         writer.Close( );
      }
   }

   public class AnimExportSettingsSerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(Detox.Data.Anim.AnimExportSettings).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         Detox.Data.Anim.AnimExportSettings settings;

         settings.filename = (string) serializer.LoadNamedObject( "Filename" );
         settings.id       = (int)    serializer.LoadNamedObject( "Id" );
         settings.fullRange= (int)    serializer.LoadNamedObject( "FullRange" );
         settings.startTime= (int)    serializer.LoadNamedObject( "StartTime" );
         settings.endTime  = (int)    serializer.LoadNamedObject( "EndTime" );
      
         return settings;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Detox.Data.Anim.AnimExportSettings settings = (Detox.Data.Anim.AnimExportSettings) data;

         serializer.SaveNamedObject( "Filename",  settings.filename );         
         serializer.SaveNamedObject( "Id",        settings.id );         
         serializer.SaveNamedObject( "FullRange", settings.fullRange );         
         serializer.SaveNamedObject( "StartTime", settings.startTime );         
         serializer.SaveNamedObject( "EndTime",   settings.endTime );         
      }
   }

   public class AnimExportSettingsArraySerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(Detox.Data.Anim.AnimExportSettings[]).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         object value;

         serializer.GetData( out value );
         byte [] data = value as byte[];
      
         MemoryStream stream = new MemoryStream( data );
         BinaryReader reader = new BinaryReader( stream );

         int i, count = reader.ReadInt32( );

         Detox.Data.Anim.AnimExportSettings []settings = new Detox.Data.Anim.AnimExportSettings[ count ];

         for ( i = 0; i < count; i++ )
         {
            settings[ i ].filename   = reader.ReadString( );
            settings[ i ].id         = reader.ReadInt32( );
            settings[ i ].fullRange  = reader.ReadInt32( );
            settings[ i ].startTime  = reader.ReadInt32( );
            settings[ i ].endTime    = reader.ReadInt32( );
         }

         reader.Close( );
         return settings;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Detox.Data.Anim.AnimExportSettings []settings = (Detox.Data.Anim.AnimExportSettings[]) data;

         MemoryStream stream = new MemoryStream( );
         BinaryWriter writer = new BinaryWriter( stream );

         writer.Write( (int) settings.Length );

         foreach (Detox.Data.Anim.AnimExportSettings setting in settings)
         {
            writer.Write( setting.filename );
            writer.Write( setting.id );
            writer.Write( setting.fullRange );
            writer.Write( setting.startTime );
            writer.Write( setting.endTime );
         }

         serializer.SetData( stream.ToArray() );

         writer.Close( );
      }
   }

   public class ColorSerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(UnityEngine.Color).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         UnityEngine.Color color;

         object value;
         
         serializer.GetData( out value );
         byte[] data = value as byte[];

         color.r = BitConverter.ToSingle( data, 0 );
         color.g = BitConverter.ToSingle( data, 4 );
         color.b = BitConverter.ToSingle( data, 8 );
         color.a = BitConverter.ToSingle( data, 12 );

         return color;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         UnityEngine.Color color = (UnityEngine.Color) data;

         byte[] array = new byte[ 4 * 4 ];
         
         BitConverter.GetBytes( color.r ).CopyTo( array, 0 );
         BitConverter.GetBytes( color.g ).CopyTo( array, 4 );
         BitConverter.GetBytes( color.b ).CopyTo( array, 8 );
         BitConverter.GetBytes( color.a ).CopyTo( array, 12 );

         serializer.SetData( array );
      }
   }


   public class MatrixSerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(Matrix).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         Matrix matrix;

         object value;

         serializer.GetData( out value );
         byte [] data = value as byte[];

         matrix.M11 = BitConverter.ToSingle( data, 0 );
         matrix.M12 = BitConverter.ToSingle( data, 4 );
         matrix.M13 = BitConverter.ToSingle( data, 8 );
         matrix.M14 = BitConverter.ToSingle( data, 12 );

         matrix.M21 = BitConverter.ToSingle( data, 16 );
         matrix.M22 = BitConverter.ToSingle( data, 20 );
         matrix.M23 = BitConverter.ToSingle( data, 24 );
         matrix.M24 = BitConverter.ToSingle( data, 28 );

         matrix.M31 = BitConverter.ToSingle( data, 32 );
         matrix.M32 = BitConverter.ToSingle( data, 36 );
         matrix.M33 = BitConverter.ToSingle( data, 40 );
         matrix.M34 = BitConverter.ToSingle( data, 44 );

         matrix.M41 = BitConverter.ToSingle( data, 48 );
         matrix.M42 = BitConverter.ToSingle( data, 52 );
         matrix.M43 = BitConverter.ToSingle( data, 56 );
         matrix.M44 = BitConverter.ToSingle( data, 60 );

         return matrix;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Matrix matrix = (Matrix) data;

         byte[] array = new byte[ 4 * 4 * 4 ];
         
         BitConverter.GetBytes( matrix.M11 ).CopyTo( array, 0 );
         BitConverter.GetBytes( matrix.M12 ).CopyTo( array, 4 );
         BitConverter.GetBytes( matrix.M13 ).CopyTo( array, 8 );
         BitConverter.GetBytes( matrix.M14 ).CopyTo( array, 12 );

         BitConverter.GetBytes( matrix.M21 ).CopyTo( array, 16 );
         BitConverter.GetBytes( matrix.M22 ).CopyTo( array, 20 );
         BitConverter.GetBytes( matrix.M23 ).CopyTo( array, 24 );
         BitConverter.GetBytes( matrix.M24 ).CopyTo( array, 28 );

         BitConverter.GetBytes( matrix.M31 ).CopyTo( array, 32 );
         BitConverter.GetBytes( matrix.M32 ).CopyTo( array, 36 );
         BitConverter.GetBytes( matrix.M33 ).CopyTo( array, 40 );
         BitConverter.GetBytes( matrix.M34 ).CopyTo( array, 44 );

         BitConverter.GetBytes( matrix.M41 ).CopyTo( array, 48 );
         BitConverter.GetBytes( matrix.M42 ).CopyTo( array, 52 );
         BitConverter.GetBytes( matrix.M43 ).CopyTo( array, 56 );
         BitConverter.GetBytes( matrix.M44 ).CopyTo( array, 60 );

         serializer.SetData( array );
      }
   }

   public class MatrixArraySerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(Matrix[]).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         object value;

         serializer.GetData( out value );
         byte [] data = value as byte[];
      
         MemoryStream stream = new MemoryStream( data );
         BinaryReader reader = new BinaryReader( stream );

         int i, count = reader.ReadInt32( );

         Matrix []matrices = new Matrix[ count ];

         for ( i = 0; i < count; i++ )
         {
            matrices[ i ].M11 = reader.ReadSingle( );
            matrices[ i ].M12 = reader.ReadSingle( );
            matrices[ i ].M13 = reader.ReadSingle( );
            matrices[ i ].M14 = reader.ReadSingle( );

            matrices[ i ].M21 = reader.ReadSingle( );
            matrices[ i ].M22 = reader.ReadSingle( );
            matrices[ i ].M23 = reader.ReadSingle( );
            matrices[ i ].M24 = reader.ReadSingle( );

            matrices[ i ].M31 = reader.ReadSingle( );
            matrices[ i ].M32 = reader.ReadSingle( );
            matrices[ i ].M33 = reader.ReadSingle( );
            matrices[ i ].M34 = reader.ReadSingle( );

            matrices[ i ].M41 = reader.ReadSingle( );
            matrices[ i ].M42 = reader.ReadSingle( );
            matrices[ i ].M43 = reader.ReadSingle( );
            matrices[ i ].M44 = reader.ReadSingle( );
         }

         reader.Close( );

         return matrices;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Matrix []matrices = (Matrix[]) data;

         MemoryStream stream = new MemoryStream( );
         BinaryWriter writer = new BinaryWriter( stream );

         writer.Write( (int) matrices.Length );

         foreach (Matrix matrix in matrices)
         {
            writer.Write( matrix.M11 );
            writer.Write( matrix.M12 );
            writer.Write( matrix.M13 );
            writer.Write( matrix.M14 );

            writer.Write( matrix.M21 );
            writer.Write( matrix.M22 );
            writer.Write( matrix.M23 );
            writer.Write( matrix.M24 );

            writer.Write( matrix.M31 );
            writer.Write( matrix.M32 );
            writer.Write( matrix.M33 );
            writer.Write( matrix.M34 );

            writer.Write( matrix.M41 );
            writer.Write( matrix.M42 );
            writer.Write( matrix.M43 );
            writer.Write( matrix.M44 );
         }

         serializer.SetData( stream.ToArray() );

         writer.Close( );
      }
   }

   public class SampleSerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(Detox.Data.Anim.Sample).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         Detox.Data.Anim.Sample sample = new Detox.Data.Anim.Sample( );

         sample.bone = (int) serializer.LoadNamedObject( "Bone" );
         sample.matrices = (Matrix[]) serializer.LoadNamedObject( "Matrices" );      

         return sample;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Detox.Data.Anim.Sample sample = (Detox.Data.Anim.Sample) data;
         
         serializer.SaveNamedObject( "Bone",   sample.bone );
         serializer.SaveNamedObject( "Matrices", sample.matrices );
      }
   }

   public class HashtableSerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(Hashtable).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         Hashtable hashtable = new Hashtable( );

         object []keys = null;
         keys = serializer.LoadNamedObjects( "Keys" );
      
         object []values = null;
         values = serializer.LoadNamedObjects( "Values" );

         int i = 0;

         foreach (object key in keys)
         {
            hashtable[ key as string ] = values[ i++ ];
         }

         return hashtable;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Hashtable table = data as Hashtable;

         List<object> values = new List<object>( );

         foreach ( object value in table.Keys )
         {
            values.Add( value );
         }

         serializer.SaveNamedObjects( "Keys", values.ToArray( ) );
         values.Clear( );

         foreach ( object value in table.Values )
         {
            values.Add( value );
         }

         serializer.SaveNamedObjects( "Values", values.ToArray( ) );
         values.Clear( );
      }
   }
}


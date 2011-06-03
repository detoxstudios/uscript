using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using Microsoft.DirectX;
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

   public class Vector2Serializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(Vector2).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         Vector2 vector;

         object value;

         serializer.GetData( out value );
         byte[] data = value as byte[];
         
         vector.X = BitConverter.ToSingle( data, 0 );
         vector.Y = BitConverter.ToSingle( data, 4 );
      
         return vector;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Vector2 vector = (Vector2) data;

         byte[] array = new byte[ 4 * 2];
         
         BitConverter.GetBytes( vector.X ).CopyTo( array, 0 );
         BitConverter.GetBytes( vector.Y ).CopyTo( array, 4 );

         serializer.SetData( array );
      }
   }

   public class Vector2ArraySerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(Vector2[]).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         object value;

         serializer.GetData( out value );
         byte [] data = value as byte[];
      
         MemoryStream stream = new MemoryStream( data );
         BinaryReader reader = new BinaryReader( stream );

         int i, count = reader.ReadInt32( );

         Vector2 []vectors = new Vector2[ count ];

         for ( i = 0; i < count; i++ )
         {
            vectors[ i ].X = reader.ReadSingle( );
            vectors[ i ].Y = reader.ReadSingle( );
         }

         reader.Close( );
         return vectors;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Vector2 []vectors = (Vector2[]) data;

         MemoryStream stream = new MemoryStream( );
         BinaryWriter writer = new BinaryWriter( stream );

         writer.Write( (int) vectors.Length );

         foreach (Vector2 vector in vectors)
         {
            writer.Write( vector.X );
            writer.Write( vector.Y );
         }

         serializer.SetData( stream.ToArray() );

         writer.Close( );
      }
   }

   public class Vector3Serializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(Vector3).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         Vector3 vector;

         object value;
         
         serializer.GetData( out value );
         byte[] data = value as byte[];

         vector.X = BitConverter.ToSingle( data, 0 );
         vector.Y = BitConverter.ToSingle( data, 4 );
         vector.Z = BitConverter.ToSingle( data, 8 );

         return vector;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Vector3 vector = (Vector3) data;

         byte[] array = new byte[ 4 * 3 ];
         
         BitConverter.GetBytes( vector.X ).CopyTo( array, 0 );
         BitConverter.GetBytes( vector.Y ).CopyTo( array, 4 );
         BitConverter.GetBytes( vector.Z ).CopyTo( array, 8 );

         serializer.SetData( array );
      }
   }

   public class Vector3ArraySerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(Vector3[]).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         object value;

         serializer.GetData( out value );
         byte [] data = value as byte[];
      
         MemoryStream stream = new MemoryStream( data );
         BinaryReader reader = new BinaryReader( stream );

         int i, count = reader.ReadInt32( );

         Vector3 []vectors = new Vector3[ count ];

         for ( i = 0; i < count; i++ )
         {
            vectors[ i ].X = reader.ReadSingle( );
            vectors[ i ].Y = reader.ReadSingle( );
            vectors[ i ].Z = reader.ReadSingle( );
         }

         reader.Close( );

         return vectors;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Vector3 []vectors = (Vector3[]) data;

         MemoryStream stream = new MemoryStream( );
         BinaryWriter writer = new BinaryWriter( stream );

         writer.Write( (int) vectors.Length );

         foreach (Vector3 vector in vectors)
         {
            writer.Write( vector.X );
            writer.Write( vector.Y );
            writer.Write( vector.Z );
         }

         serializer.SetData( stream.ToArray() );

         writer.Close( );
      }
   }

   public class Vector4Serializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(Vector4).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         object data;
         serializer.GetData( out data );

         byte [] array = data as byte[];

         Vector4 vector;

         vector.X = System.BitConverter.ToSingle( array, 0 );
         vector.Y = System.BitConverter.ToSingle( array, 4 );
         vector.Z = System.BitConverter.ToSingle( array, 8 );
         vector.W = System.BitConverter.ToSingle( array, 12 );

         return vector;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Vector4 vector = (Vector4) data;
         
         byte[] array = new byte[ 4 * 4 ];
         
         System.BitConverter.GetBytes( vector.X ).CopyTo( array, 0 );
         System.BitConverter.GetBytes( vector.Y ).CopyTo( array, 4 );
         System.BitConverter.GetBytes( vector.Z ).CopyTo( array, 8 );
         System.BitConverter.GetBytes( vector.W ).CopyTo( array, 12 );

         serializer.SetData( array );
      }
   }

   public class Vector4ArraySerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(Vector4[]).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         object value;
         serializer.GetData( out value );
         
         byte [] data = value as byte[];
      
         MemoryStream stream = new MemoryStream( data );
         BinaryReader reader = new BinaryReader( stream );

         int i, count = reader.ReadInt32( );

         Vector4 []vectors = new Vector4[ count ];

         for ( i = 0; i < count; i++ )
         {
            vectors[ i ].X = reader.ReadSingle( );
            vectors[ i ].Y = reader.ReadSingle( );
            vectors[ i ].Z = reader.ReadSingle( );
            vectors[ i ].W = reader.ReadSingle( );
         }

         reader.Close( );

         return vectors;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Vector4 []vectors = (Vector4[]) data;

         MemoryStream stream = new MemoryStream( );
         BinaryWriter writer = new BinaryWriter( stream );

         writer.Write( (int) vectors.Length );

         foreach (Vector4 vector in vectors)
         {
            writer.Write( vector.X );
            writer.Write( vector.Y );
            writer.Write( vector.Z );
            writer.Write( vector.W );
         }

         serializer.SetData( stream.ToArray() );

         writer.Close( );
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

   public class BoneSerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(Detox.Data.Model.Bone).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         Detox.Data.Model.Bone bone = new Detox.Data.Model.Bone( );

         bone.name   = (String) serializer.LoadNamedObject( "Name" );
         bone.parent = (int)    serializer.LoadNamedObject( "Parent" );
         bone.matrix = (Matrix) serializer.LoadNamedObject( "Matrix" );
      
         return bone;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Detox.Data.Model.Bone bone = (Detox.Data.Model.Bone) data;
         
         serializer.SaveNamedObject( "Name",   bone.name );
         serializer.SaveNamedObject( "Parent", bone.parent );
         serializer.SaveNamedObject( "Matrix", bone.matrix );
      }
   }

   public class BoneArraySerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(Detox.Data.Model.Bone[]).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         object value;

         serializer.GetData( out value );
         byte [] data = value as byte[];
      
         MemoryStream stream = new MemoryStream( data );
         BinaryReader reader = new BinaryReader( stream );

         int i, count = reader.ReadInt32( );

         Detox.Data.Model.Bone []bones = new Detox.Data.Model.Bone[ count ];

         for ( i = 0; i < count; i++ )
         {
            bones[ i ].name   = reader.ReadString( );
            bones[ i ].matrix.M11 = reader.ReadSingle( );
            bones[ i ].matrix.M12 = reader.ReadSingle( );
            bones[ i ].matrix.M13 = reader.ReadSingle( );
            bones[ i ].matrix.M14 = reader.ReadSingle( );

            bones[ i ].matrix.M21 = reader.ReadSingle( );
            bones[ i ].matrix.M22 = reader.ReadSingle( );
            bones[ i ].matrix.M23 = reader.ReadSingle( );
            bones[ i ].matrix.M24 = reader.ReadSingle( );

            bones[ i ].matrix.M31 = reader.ReadSingle( );
            bones[ i ].matrix.M32 = reader.ReadSingle( );
            bones[ i ].matrix.M33 = reader.ReadSingle( );
            bones[ i ].matrix.M34 = reader.ReadSingle( );

            bones[ i ].matrix.M41 = reader.ReadSingle( );
            bones[ i ].matrix.M42 = reader.ReadSingle( );
            bones[ i ].matrix.M43 = reader.ReadSingle( );
            bones[ i ].matrix.M44 = reader.ReadSingle( );
         
            bones[ i ].parent = reader.ReadInt32( );
         }

         reader.Close( );

         return bones;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Detox.Data.Model.Bone []bones = (Detox.Data.Model.Bone[]) data;

         MemoryStream stream = new MemoryStream( );
         BinaryWriter writer = new BinaryWriter( stream );

         writer.Write( (int) bones.Length );

         foreach (Detox.Data.Model.Bone bone in bones)
         {
            writer.Write( bone.name );
            writer.Write( bone.matrix.M11 );
            writer.Write( bone.matrix.M12 );
            writer.Write( bone.matrix.M13 );
            writer.Write( bone.matrix.M14 );

            writer.Write( bone.matrix.M21 );
            writer.Write( bone.matrix.M22 );
            writer.Write( bone.matrix.M23 );
            writer.Write( bone.matrix.M24 );

            writer.Write( bone.matrix.M31 );
            writer.Write( bone.matrix.M32 );
            writer.Write( bone.matrix.M33 );
            writer.Write( bone.matrix.M34 );
            
            writer.Write( bone.matrix.M41 );
            writer.Write( bone.matrix.M42 );
            writer.Write( bone.matrix.M43 );
            writer.Write( bone.matrix.M44 );

            writer.Write( bone.parent );
         }

         serializer.SetData( stream.ToArray() );

         writer.Close( );
      }
   }

   public class BoneDescSerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(Detox.Data.Model.BoneDesc).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         Detox.Data.Model.BoneDesc boneDesc = new Detox.Data.Model.BoneDesc( );

         boneDesc.bone   = (int)   serializer.LoadNamedObject( "Bone" );
         boneDesc.vertex = (int)   serializer.LoadNamedObject( "Vertex" );
         boneDesc.weight = (float) serializer.LoadNamedObject( "Weight" );
      
         return boneDesc;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Detox.Data.Model.BoneDesc boneDesc = (Detox.Data.Model.BoneDesc) data;
         
         serializer.SaveNamedObject( "Bone",   boneDesc.bone );
         serializer.SaveNamedObject( "Vertex", boneDesc.vertex );
         serializer.SaveNamedObject( "Weight", boneDesc.weight );
      }
   }

   public class BoneDescArraySerializer : ITypeSerializer
   {
      public int Version { get { return 1; } }
      public string SerializableType { get { return typeof(Detox.Data.Model.BoneDesc[]).ToString( ); } }

      public object Load(ObjectSerializer serializer)
      {
         object value;

         serializer.GetData( out value );
         byte [] data = value as byte[];
      
         MemoryStream stream = new MemoryStream( data );
         BinaryReader reader = new BinaryReader( stream );

         int i, count = reader.ReadInt32( );

         Detox.Data.Model.BoneDesc []boneDescs = new Detox.Data.Model.BoneDesc[ count ];

         for ( i = 0; i < count; i++ )
         {
            boneDescs[ i ].bone   = reader.ReadInt32( );
            boneDescs[ i ].vertex = reader.ReadInt32( );
            boneDescs[ i ].weight = reader.ReadSingle( );
         }

         reader.Close( );

         return boneDescs;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Detox.Data.Model.BoneDesc []boneDescs = (Detox.Data.Model.BoneDesc[]) data;

         MemoryStream stream = new MemoryStream( );
         BinaryWriter writer = new BinaryWriter( stream );

         writer.Write( (int) boneDescs.Length );

         foreach (Detox.Data.Model.BoneDesc boneDesc in boneDescs)
         {
            writer.Write( boneDesc.bone );
            writer.Write( boneDesc.vertex );
            writer.Write( boneDesc.weight );
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


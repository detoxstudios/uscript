using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using Detox.DirectX;
using Detox.Utility;
using System.Xml;

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
      
         if (serializer.TextMode) return int.Parse(value as string);

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

         UnityEngine.Keyframe []keyframes;
         if (serializer.TextMode)
         {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(value as string);

            var keyframeNodes = doc.SelectNodes("//Keyframe");
            keyframes = new UnityEngine.Keyframe[keyframeNodes.Count];
            int index = 0;

            foreach (XmlNode node in keyframeNodes)
            {
               keyframes[ index ].time      = Single.Parse(node.SelectSingleNode("Time").InnerText);
               keyframes[ index ].value     = Single.Parse(node.SelectSingleNode("Value").InnerText);
               keyframes[ index ].inTangent = Single.Parse(node.SelectSingleNode("InTangent").InnerText);
               keyframes[ index ].outTangent= Single.Parse(node.SelectSingleNode("OutTangent").InnerText);
               index++;
            }
         }
         else
         {
            byte [] data = value as byte[];
      
            MemoryStream stream = new MemoryStream( data );
            BinaryReader reader = new BinaryReader( stream );
                
            int i, count = reader.ReadInt32( );

            keyframes = new UnityEngine.Keyframe[ count ];

            for ( i = 0; i < count; i++ )
            {
               keyframes[ i ].time      = reader.ReadSingle( );
               keyframes[ i ].value     = reader.ReadSingle( );
               keyframes[ i ].inTangent = reader.ReadSingle( );
               keyframes[ i ].outTangent= reader.ReadSingle( );
            }

            reader.Close( );
         }

         return keyframes;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         UnityEngine.Keyframe []keyframes = (UnityEngine.Keyframe[]) data;

         MemoryStream stream = new MemoryStream( );
         if (serializer.TextMode)
         {
            XmlWriter writer = XmlWriter.Create( stream, new XmlWriterSettings()
            {
               OmitXmlDeclaration = true,
               ConformanceLevel = ConformanceLevel.Fragment,
               CloseOutput = true,
               Encoding = Encoding.Unicode
            });

            foreach (UnityEngine.Keyframe keyframe in keyframes)
            {
               writer.WriteStartElement("Keyframe");
               writer.WriteElementString("Time", keyframe.time.ToString());
               writer.WriteElementString("Value", keyframe.value.ToString());
               writer.WriteElementString("InTangent", keyframe.inTangent.ToString());
               writer.WriteElementString("OutTangent", keyframe.outTangent.ToString());
               writer.WriteEndElement();
            }
            writer.Flush();

            string dataStream = Encoding.Unicode.GetString(stream.GetBuffer());
            serializer.SetData(dataStream.Trim());

            writer.Close();
         }
         else
         {
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

         string type, enumValue;
         if (serializer.TextMode)
         {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(value as string);

            type      = doc.FirstChild.SelectSingleNode("AssemblyQualifiedName").InnerText;
            enumValue = doc.FirstChild.SelectSingleNode("Value").InnerText;
         }
         else
         {
            byte [] data = value as byte[];
      
            MemoryStream stream = new MemoryStream( data );
            BinaryReader reader = new BinaryReader( stream );

            type  = reader.ReadString( );
            enumValue = reader.ReadString( );

            reader.Close( );
         }

         return Enum.Parse(Type.GetType(type), enumValue);
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         MemoryStream stream = new MemoryStream( );
         if (serializer.TextMode)
         {
            XmlWriter writer = XmlWriter.Create( stream, new XmlWriterSettings()
            {
               OmitXmlDeclaration = true,
               ConformanceLevel = ConformanceLevel.Fragment,
               CloseOutput = true,
               Encoding = Encoding.Unicode
            });

            writer.WriteElementString("AssemblyQualifiedName", data.GetType().AssemblyQualifiedName);
            writer.WriteElementString("Value", data.ToString());
            writer.Flush();

            string dataStream = Encoding.Unicode.GetString(stream.GetBuffer());
            serializer.SetData(dataStream.Trim());

            writer.Close();
         }
         else
         {
            BinaryWriter writer = new BinaryWriter( stream );

            writer.Write( data.GetType().AssemblyQualifiedName );
            writer.Write( data.ToString( ) );

            serializer.SetData( stream.ToArray() );

            writer.Close( );
         }
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
      
         if (serializer.TextMode) return float.Parse(value as string);

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
      
         if (serializer.TextMode) return bool.Parse(value as string);

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

         string []strings;
         if (serializer.TextMode)
         {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(value as string);

            var stringNodes = doc.SelectNodes("//String");
            strings = new string[stringNodes.Count];
            int index = 0;

            foreach (XmlNode node in stringNodes)
            {
               strings[ index ] = node.SelectSingleNode("Value").InnerText;
               index++;
            }
         }
         else
         {
            byte [] data = value as byte[];
      
            MemoryStream stream = new MemoryStream( data );
            BinaryReader reader = new BinaryReader( stream );

            int i, count = reader.ReadInt32( );

            strings = new string[ count ];

            for ( i = 0; i < count; i++ )
            {
               strings[ i ] = reader.ReadString( );
            }

            reader.Close( );
         }

         return strings;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         string []strings = (string[]) data;

         MemoryStream stream = new MemoryStream( );
         if (serializer.TextMode)
         {
            XmlWriter writer = XmlWriter.Create( stream, new XmlWriterSettings()
            {
               OmitXmlDeclaration = true,
               ConformanceLevel = ConformanceLevel.Fragment,
               CloseOutput = true,
               Encoding = Encoding.Unicode
            });

            foreach (string s in strings)
            {
               writer.WriteStartElement("String");
               writer.WriteElementString("Value", s);
               writer.WriteEndElement();
            }
            writer.Flush();

            string dataStream = Encoding.Unicode.GetString(stream.GetBuffer());
            serializer.SetData(dataStream.Trim());

            writer.Close();
         }
         else
         {
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

         Detox.Data.Anim.AnimExportSettings []settings;
         if (serializer.TextMode)
         {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(value as string);

            var settingNodes = doc.SelectNodes("//Setting");
            settings = new Detox.Data.Anim.AnimExportSettings[settingNodes.Count];
            int index = 0;

            foreach (XmlNode node in settingNodes)
            {
               settings[ index ].filename  = node.SelectSingleNode("Filename").InnerText;
               settings[ index ].id        = int.Parse(node.SelectSingleNode("Id").InnerText);
               settings[ index ].fullRange = int.Parse(node.SelectSingleNode("FullRange").InnerText);
               settings[ index ].startTime = int.Parse(node.SelectSingleNode("StartTime").InnerText);
               settings[ index ].endTime   = int.Parse(node.SelectSingleNode("EndTime").InnerText);
               index++;
            }
         }
         else
         {
            byte [] data = value as byte[];
      
            MemoryStream stream = new MemoryStream( data );
            BinaryReader reader = new BinaryReader( stream );

            int i, count = reader.ReadInt32( );

            settings = new Detox.Data.Anim.AnimExportSettings[ count ];

            for ( i = 0; i < count; i++ )
            {
               settings[ i ].filename   = reader.ReadString( );
               settings[ i ].id         = reader.ReadInt32( );
               settings[ i ].fullRange  = reader.ReadInt32( );
               settings[ i ].startTime  = reader.ReadInt32( );
               settings[ i ].endTime    = reader.ReadInt32( );
            }

            reader.Close( );
         }

         return settings;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Detox.Data.Anim.AnimExportSettings []settings = (Detox.Data.Anim.AnimExportSettings[]) data;

         MemoryStream stream = new MemoryStream( );
         if (serializer.TextMode)
         {
            XmlWriter writer = XmlWriter.Create( stream, new XmlWriterSettings()
            {
               OmitXmlDeclaration = true,
               ConformanceLevel = ConformanceLevel.Fragment,
               CloseOutput = true,
               Encoding = Encoding.Unicode
            });

            foreach (Detox.Data.Anim.AnimExportSettings setting in settings)
            {
               writer.WriteStartElement("Setting");
               writer.WriteElementString("Filename", setting.filename);
               writer.WriteElementString("Id", setting.id.ToString());
               writer.WriteElementString("FullRange", setting.fullRange.ToString());
               writer.WriteElementString("StartTime", setting.startTime.ToString());
               writer.WriteElementString("EndTime", setting.endTime.ToString());
               writer.WriteEndElement();
            }
            writer.Flush();

            string dataStream = Encoding.Unicode.GetString(stream.GetBuffer());
            serializer.SetData(dataStream.Trim());

            writer.Close();
         }
         else
         {
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

         if (serializer.TextMode)
         {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(value as string);

            color.r = float.Parse(doc.FirstChild.SelectSingleNode("R").InnerText);
            color.g = float.Parse(doc.FirstChild.SelectSingleNode("G").InnerText);
            color.b = float.Parse(doc.FirstChild.SelectSingleNode("B").InnerText);
            color.a = float.Parse(doc.FirstChild.SelectSingleNode("A").InnerText);
         }
         else
         {
            byte[] data = value as byte[];

            color.r = BitConverter.ToSingle( data, 0 );
            color.g = BitConverter.ToSingle( data, 4 );
            color.b = BitConverter.ToSingle( data, 8 );
            color.a = BitConverter.ToSingle( data, 12 );
         }

         return color;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         UnityEngine.Color color = (UnityEngine.Color) data;

         if (serializer.TextMode)
         {
            StringBuilder sb = new StringBuilder();
            XmlWriter writer = XmlWriter.Create( sb, new XmlWriterSettings()
            {
               OmitXmlDeclaration = true,
               ConformanceLevel = ConformanceLevel.Fragment,
               CloseOutput = true,
               Encoding = Encoding.Unicode
            });

            writer.WriteElementString("R", color.r.ToString());
            writer.WriteElementString("G", color.g.ToString());
            writer.WriteElementString("B", color.b.ToString());
            writer.WriteElementString("A", color.a.ToString());
            writer.Flush();

            string dataStream = sb.ToString();
            serializer.SetData(dataStream.Trim());

            writer.Close();
         }
         else
         {
            byte[] array = new byte[ 4 * 4 ];
         
            BitConverter.GetBytes( color.r ).CopyTo( array, 0 );
            BitConverter.GetBytes( color.g ).CopyTo( array, 4 );
            BitConverter.GetBytes( color.b ).CopyTo( array, 8 );
            BitConverter.GetBytes( color.a ).CopyTo( array, 12 );

            serializer.SetData( array );
         }
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

         if (serializer.TextMode)
         {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(value as string);

            LoadPropertiesFromXml(doc.FirstChild, out matrix);
         }
         else
         {
            byte [] data = value as byte[];

            LoadPropertiesFromBinary(data, out matrix);
         }

         return matrix;
      }
      
      public static void LoadPropertiesFromXml(XmlNode node, out Matrix matrix)
      {
         matrix.M11 = float.Parse(node.SelectSingleNode("M11").InnerText);
         matrix.M12 = float.Parse(node.SelectSingleNode("M12").InnerText);
         matrix.M13 = float.Parse(node.SelectSingleNode("M13").InnerText);
         matrix.M14 = float.Parse(node.SelectSingleNode("M14").InnerText);

         matrix.M21 = float.Parse(node.SelectSingleNode("M21").InnerText);
         matrix.M22 = float.Parse(node.SelectSingleNode("M22").InnerText);
         matrix.M23 = float.Parse(node.SelectSingleNode("M23").InnerText);
         matrix.M24 = float.Parse(node.SelectSingleNode("M24").InnerText);

         matrix.M31 = float.Parse(node.SelectSingleNode("M31").InnerText);
         matrix.M32 = float.Parse(node.SelectSingleNode("M32").InnerText);
         matrix.M33 = float.Parse(node.SelectSingleNode("M33").InnerText);
         matrix.M34 = float.Parse(node.SelectSingleNode("M34").InnerText);

         matrix.M41 = float.Parse(node.SelectSingleNode("M41").InnerText);
         matrix.M42 = float.Parse(node.SelectSingleNode("M42").InnerText);
         matrix.M43 = float.Parse(node.SelectSingleNode("M43").InnerText);
         matrix.M44 = float.Parse(node.SelectSingleNode("M44").InnerText);
      }

      public static void LoadPropertiesFromBinary(byte[] data, out Matrix matrix)
      {
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
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Matrix matrix = (Matrix) data;

         MemoryStream stream = new MemoryStream( );
         if (serializer.TextMode)
         {
            XmlWriter writer = XmlWriter.Create( stream, new XmlWriterSettings()
            {
               OmitXmlDeclaration = true,
               ConformanceLevel = ConformanceLevel.Fragment,
               CloseOutput = true,
               Encoding = Encoding.Unicode
            });

            SavePropertiesToXml(matrix, writer);
            writer.Flush();

            string dataStream = Encoding.Unicode.GetString(stream.GetBuffer());
            serializer.SetData(dataStream.Trim());

            writer.Close();
         }
         else
         {
            byte[] array = new byte[ 4 * 4 * 4 ];

            SavePropertiesToBinary(matrix, array);

            serializer.SetData( array );
         }
      }

      public static void SavePropertiesToXml(Matrix value, XmlWriter writer)
      {
         writer.WriteElementString("M11", value.M11.ToString());
         writer.WriteElementString("M12", value.M11.ToString());
         writer.WriteElementString("M13", value.M11.ToString());
         writer.WriteElementString("M14", value.M11.ToString());

         writer.WriteElementString("M21", value.M11.ToString());
         writer.WriteElementString("M22", value.M11.ToString());
         writer.WriteElementString("M23", value.M11.ToString());
         writer.WriteElementString("M24", value.M11.ToString());

         writer.WriteElementString("M31", value.M11.ToString());
         writer.WriteElementString("M32", value.M11.ToString());
         writer.WriteElementString("M33", value.M11.ToString());
         writer.WriteElementString("M34", value.M11.ToString());

         writer.WriteElementString("M41", value.M11.ToString());
         writer.WriteElementString("M42", value.M11.ToString());
         writer.WriteElementString("M43", value.M11.ToString());
         writer.WriteElementString("M44", value.M11.ToString());
      }

      public static void SavePropertiesToBinary(Matrix matrix, byte[] array)
      {
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

         Matrix []matrices;
         if (serializer.TextMode)
         {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(value as string);

            var matrixNodes = doc.SelectNodes("//Matrix");
            matrices = new Matrix[matrixNodes.Count];
            int index = 0;

            foreach (XmlNode node in matrixNodes)
            {
               MatrixSerializer.LoadPropertiesFromXml(node, out matrices[ index ]);
               index++;
            }
         }
         else
         {
            byte [] data = value as byte[];
      
            MemoryStream stream = new MemoryStream( data );
            BinaryReader reader = new BinaryReader( stream );

            int i, count = reader.ReadInt32( );

            matrices = new Matrix[ count ];

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
         }

         return matrices;
      }

      public void Save(ObjectSerializer serializer, object data)
      {
         Matrix []matrices = (Matrix[]) data;

         MemoryStream stream = new MemoryStream( );
         if (serializer.TextMode)
         {
            XmlWriter writer = XmlWriter.Create( stream, new XmlWriterSettings()
            {
               OmitXmlDeclaration = true,
               ConformanceLevel = ConformanceLevel.Fragment,
               CloseOutput = true,
               Encoding = Encoding.Unicode
            });

            foreach (Matrix matrix in matrices)
            {
               writer.WriteStartElement("Matrix");
               MatrixSerializer.SavePropertiesToXml(matrix, writer);
               writer.WriteEndElement();
            }
            writer.Flush();

            string dataStream = Encoding.Unicode.GetString(stream.GetBuffer());
            serializer.SetData(dataStream.Trim());

            writer.Close();
         }
         else
         {
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


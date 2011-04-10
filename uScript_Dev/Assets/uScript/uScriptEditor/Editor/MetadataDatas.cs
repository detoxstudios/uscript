using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Detox.Utility;
using System.ComponentModel;

namespace Detox.Data.Metadatas
{
   public class MetadataData : EditableObject, ISerializable
   {
      public override string Description { get { return "Metadata"; } }
      public override Attribute[] GetAttributes(string propertyName) { return new Attribute[] { }; }

      public static MetadataData CreateDefault(string assetType)
      {
         string typeName = assetType + "MetadataData";
         typeName = typeName.Substring( 0, 1 ).ToUpper( ) + typeName.Substring( 1 );
         typeName = "Detox.Data.Metadatas." + typeName;

         Type type = Type.GetType( typeName );

         if ( null != type )
         {
            return Activator.CreateInstance( type ) as MetadataData;
         }

         //no metadata so return the default empty
         return new MetadataData( );
      }

      public int Version { get { return 0; } }

      public void Load(ObjectSerializer serializer)
      {
      }

      public void Save(ObjectSerializer serializer)
      {
      }
   }

   public class WinBmpSettings : EditableObject, ISerializable
   {
      public enum CompressionType
      {
         Compressed,
         NormalMaps,
         Uncompressed16Bit,
         Uncompressed32Bit
      }

      public override string Description { get { return "Windows"; } }
      public override Attribute[] GetAttributes(string propertyName) { return new Attribute[] { }; }

      private CompressionType m_Compression = CompressionType.Compressed;

      [ReadOnly(false)]
      [Category("Compression")]
      public CompressionType Compression { get { return m_Compression; } set { m_Compression = value; } }

      public int Version { get { return 1; } }

      public void Load(ObjectSerializer serializer)
      {
         m_Compression = (CompressionType) Enum.Parse(typeof(CompressionType), (string) serializer.LoadNamedObject("CompressionType"));
      }

      public void Save(ObjectSerializer serializer)
      {
         serializer.SaveNamedObject( "CompressionType", m_Compression.ToString() );
      }
   }

   public class iOSBmpSettings : EditableObject, ISerializable
   {
      public enum CompressionType
      {
         RGBAHighQuality,
         RGBALowQuality,
         Uncompressed16Bit,
         Uncompressed32Bit
      }

      public override string Description { get { return "iOS"; } }
      public override Attribute[] GetAttributes(string propertyName) { return new Attribute[] { }; }

      private CompressionType m_Compression = CompressionType.RGBAHighQuality;

      [ReadOnly(false)]
      [Category("Compression")]
      public CompressionType Compression { get { return m_Compression; } set { m_Compression = value; } }

      public int Version { get { return 1; } }

      public void Load(ObjectSerializer serializer)
      {
         m_Compression = (CompressionType) Enum.Parse(typeof(CompressionType), (string) serializer.LoadNamedObject("CompressionType"));
      }

      public void Save(ObjectSerializer serializer)
      {
         serializer.SaveNamedObject( "CompressionType", m_Compression.ToString() );
      }
   }

   public class BmpMetadataData : MetadataData
   {
      public override string Description { get { return "Texture Settings"; } }

      private WinBmpSettings m_WinBmpSettings = new WinBmpSettings( );
      private iOSBmpSettings m_iOSBmpSettings = new iOSBmpSettings( );

      [ReadOnly(false)]
      [Category("Bmp Settings")]
      public WinBmpSettings Windows { get { return m_WinBmpSettings; } set { m_WinBmpSettings = value; } } 

      [ReadOnly(false)]
      [Category("Bmp Settings")]
      public iOSBmpSettings iOS     { get { return m_iOSBmpSettings; } set { m_iOSBmpSettings = value; } }

      public new int Version { get { return 1; } }

      public new void Load(ObjectSerializer serializer)
      {
         serializer.LoadBaseObject(this, typeof(MetadataData));
      
         m_WinBmpSettings = (WinBmpSettings) serializer.LoadNamedObject("Windows");
         m_iOSBmpSettings = (iOSBmpSettings) serializer.LoadNamedObject("iOS");
      }

      public new void Save(ObjectSerializer serializer)
      {
         serializer.SaveBaseObject(this, typeof(MetadataData));
      
         serializer.SaveNamedObject("Windows", m_WinBmpSettings);
         serializer.SaveNamedObject("iOS",     m_iOSBmpSettings);
      }
   }

   public class FramemapMetadataData : MetadataData
   {
      public override string Description { get { return "FrameMap Settings"; } }

      private BmpMetadataData m_BmpMetadataData = new BmpMetadataData( );

      [ReadOnly(false)]
      [Category("Bmp Settings")]
      public BmpMetadataData BmpMetadataData { get { return m_BmpMetadataData; } set { m_BmpMetadataData = value; } } 

      public new int Version { get { return 1; } }

      public new void Load(ObjectSerializer serializer)
      {
         serializer.LoadBaseObject(this, typeof(MetadataData));
      
         m_BmpMetadataData = (BmpMetadataData) serializer.LoadNamedObject("BmpMetadataData");
      }

      public new void Save(ObjectSerializer serializer)
      {
         serializer.SaveBaseObject(this, typeof(MetadataData));
      
         serializer.SaveNamedObject("BmpMetadataData", m_BmpMetadataData);
      }
   }

   public class WinWavSettings : EditableObject, ISerializable
   {
      public enum CompressionType
      {
         CompressedOgg,
         Uncompressed
      }

      public override string Description { get { return "Windows"; } }
      public override Attribute[] GetAttributes(string propertyName) { return new Attribute[] { }; }

      private CompressionType m_Compression = CompressionType.Uncompressed;
      public CompressionType Compression { get { return m_Compression; } set { m_Compression = value; } }

      private int m_CompressionQuality = 3;
      public int CompressionQuality { get { return m_CompressionQuality; } set { m_CompressionQuality = value; } }

      private bool m_Streaming = false;
      public bool Streaming { get { return m_Streaming; } set { m_Streaming = value; } }

      public int Version { get { return 1; } }

      public void Load(ObjectSerializer serializer)
      {
         m_Compression = (CompressionType)Enum.Parse(typeof(CompressionType), (string)serializer.LoadNamedObject("CompressionType"));
         m_CompressionQuality = (int)serializer.LoadNamedObject("CompressionQuality");
         m_Streaming = (bool)serializer.LoadNamedObject("Streaming");
      }

      public void Save(ObjectSerializer serializer)
      {
         serializer.SaveNamedObject("CompressionType", m_Compression.ToString());
         serializer.SaveNamedObject("CompressionQuality", m_CompressionQuality);
         serializer.SaveNamedObject("Streaming", m_Streaming);
      }
   }

   public class iOSWavSettings : EditableObject, ISerializable
   {
      public enum CompressionType
      {
         CompressedOgg,
         Uncompressed
      }

      public override string Description { get { return "iOS"; } }
      public override Attribute[] GetAttributes(string propertyName) { return new Attribute[] { }; }

      private CompressionType m_Compression = CompressionType.Uncompressed;
      public CompressionType Compression { get { return m_Compression; } set { m_Compression = value; } }

      private int m_CompressionQuality = 3;
      public int CompressionQuality { get { return m_CompressionQuality; } set { m_CompressionQuality = value; } }

      private bool m_Streaming = false;
      public bool Streaming { get { return m_Streaming; } set { m_Streaming = value; } }

      public int Version { get { return 1; } }

      public void Load(ObjectSerializer serializer)
      {
         m_Compression = (CompressionType)Enum.Parse(typeof(CompressionType), (string)serializer.LoadNamedObject("CompressionType"));
         m_CompressionQuality = (int)serializer.LoadNamedObject("CompressionQuality");
         m_Streaming = (bool)serializer.LoadNamedObject("Streaming");
      }

      public void Save(ObjectSerializer serializer)
      {
         serializer.SaveNamedObject("CompressionType", m_Compression.ToString());
         serializer.SaveNamedObject("CompressionQuality", m_CompressionQuality);
         serializer.SaveNamedObject("Streaming", m_Streaming);
      }
   }

   public class WavMetadataData : MetadataData
   {
      public override string Description { get { return "Wav Settings"; } }

      private WinWavSettings m_WinWavSettings = new WinWavSettings();
      private iOSWavSettings m_iOSWavSettings = new iOSWavSettings();

      public WinWavSettings Windows { get { return m_WinWavSettings; } set { m_WinWavSettings = value; } }
      public iOSWavSettings iOS { get { return m_iOSWavSettings; } set { m_iOSWavSettings = value; } }

      public new int Version { get { return 1; } }

      public new void Load(ObjectSerializer serializer)
      {
         serializer.LoadBaseObject(this, typeof(MetadataData));

         m_WinWavSettings = (WinWavSettings)serializer.LoadNamedObject("Windows");
         m_iOSWavSettings = (iOSWavSettings)serializer.LoadNamedObject("iOS");
      }

      public new void Save(ObjectSerializer serializer)
      {
         serializer.SaveBaseObject(this, typeof(MetadataData));

         serializer.SaveNamedObject("Windows", m_WinWavSettings);
         serializer.SaveNamedObject("iOS", m_iOSWavSettings);
      }
   }

}

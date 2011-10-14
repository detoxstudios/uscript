using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

using Detox.DirectX;

namespace Detox.Data.Anim
{
   public struct AnimExportSettings
   {
      public string filename;
      public int id;
      public int fullRange;
      public int startTime;
      public int endTime;
   };

   public class AnimExportData : ISerializable
   {
      private Hashtable m_QuickExportSettings = new Hashtable( );

      public AnimExportSettings [] AnimExportSettings
      {
         get
         {
            List<AnimExportSettings> settings = new List<AnimExportSettings>( );
            foreach ( object value in m_QuickExportSettings.Values )
            {
               settings.Add( (AnimExportSettings) value );
            }

            return settings.ToArray( );
         }
      }

      public void RemoveAnimExportSettings(string filename)
      {
         m_QuickExportSettings.Remove( filename );
      }

      public void AddAnimExportSettings(AnimExportSettings settings)
      {
         m_QuickExportSettings[ settings.filename ] = settings;
      }

      public int Version { get { return 1; } }

      public void Load(ObjectSerializer serializer)
      {
         m_QuickExportSettings = (Hashtable) serializer.LoadNamedObject( "AnimExportSettings" );
      }

      public void Save(ObjectSerializer serializer)
      {
         serializer.SaveNamedObject( "AnimExportSettings", m_QuickExportSettings );
      }
   };

   public class Sample
   {
      public int bone;
      public Matrix[] matrices;
   }

   public class AnimData : ISerializable
   {
      private float m_Framerate = 29.97f;
      private List<Sample> m_Samples = new List<Sample>( );
      
      public float Framerate
      {
         get { return m_Framerate; }
         set { m_Framerate = value; }
      }

      public Sample[] Samples
      {
         get
         {
            return m_Samples.ToArray( );
         }
      }

      public void SetSamples( int bone, Matrix[] matrices )
      {
         Sample sample = new Sample( );

         sample.bone = bone;
         sample.matrices = new Matrix[ matrices.Length ];
 
         matrices.CopyTo( sample.matrices, 0 );
      
         //if there is already a sample matching this bone
         //then remove it from the list so it can be replaced
         List<Sample> newSamples = new List<Sample>( );

         foreach (Sample existingSample in m_Samples)
         {
            if ( existingSample.bone != bone )
            {
               newSamples.Add( existingSample );
            }
         }

         m_Samples = new List<Sample>( newSamples.ToArray( ) );
         m_Samples.Add( sample );
      }

      public int Version { get { return 1; } }

      public void Load(ObjectSerializer serializer)
      {
         m_Samples.Clear( );

         m_Framerate = (float) serializer.LoadNamedObject( "Framerate" );
         
         object []array = serializer.LoadNamedObjects( "Samples" );
      
         foreach ( object sample in array )
         {
            m_Samples.Add( sample as Sample );
         }
      }

      public void Save(ObjectSerializer serializer)
      {
         serializer.SaveNamedObject ( "Framerate", m_Framerate );
         serializer.SaveNamedObjects( "Samples", m_Samples.ToArray( ) );
      }
   }
}


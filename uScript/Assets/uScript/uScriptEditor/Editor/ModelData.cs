using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using Microsoft.DirectX;

namespace Detox.Data.Model
{
   public struct Bone
   {
      public string name;
      public int    parent;
      public Matrix matrix;
   }

   public struct BoneDesc
   {
      public int   vertex;
      public int   bone;
      public float weight;
   }

   public class SurfaceData : ISerializable
   {
      private int m_MaterialId = 0;
      
      private Vector4 [] m_Positions = new Vector4 [ 0 ];
      private Vector4 [] m_Colors    = new Vector4 [ 0 ];
      private Vector3 [] m_Normals   = new Vector3 [ 0 ];
      private Vector2 [] m_UVs       = new Vector2 [ 0 ];
      private BoneDesc[] m_BoneDescs = new BoneDesc[ 0 ];

      public int MaterialId 
      { 
         set { m_MaterialId = value; } 
         get { return m_MaterialId; } 
      }
    
      public Vector4 [] Positions
      {
         get
         {
            Vector4[] array = new Vector4[m_Positions.Length];
            m_Positions.CopyTo(array, 0);
            return array;
         }
         set 
         {
            m_Positions = new Vector4[ value.Length ];
            value.CopyTo( m_Positions, 0 );
         }
      }

      public Vector4 [] Colors
      {
         get
         {
            Vector4[] array = new Vector4[m_Colors.Length];
            m_Colors.CopyTo(array, 0);
            return array;
         }
         set 
         {
            m_Colors = new Vector4[ value.Length ];
            value.CopyTo( m_Colors, 0 );
         }
      }

      public Vector3 [] Normals
      {
         get
         {
            Vector3[] array = new Vector3[m_Normals.Length];
            m_Normals.CopyTo(array, 0);
            return array;
         }
         set 
         {
            m_Normals = new Vector3[ value.Length ];
            value.CopyTo( m_Normals, 0 );
         }
      }

      public Vector2 [] UVs
      {
         get
         {
            Vector2[] array = new Vector2[m_UVs.Length];
            m_UVs.CopyTo(array, 0);
            return array;
         }
         set 
         {
            m_UVs = new Vector2[ value.Length ];
            value.CopyTo( m_UVs, 0 );
         }
      }

      public BoneDesc [] BoneDescs
      {
         get
         {
            BoneDesc[] array = new BoneDesc[m_BoneDescs.Length];
            m_BoneDescs.CopyTo(array, 0);
            return array;
         }
         set 
         {
            m_BoneDescs = new BoneDesc[ value.Length ];
            value.CopyTo( m_BoneDescs, 0 );
         }
      }

      public void Copy(SurfaceData copyFrom)
      {
         m_MaterialId = copyFrom.m_MaterialId;
         
         Positions = copyFrom.Positions;
         Colors    = copyFrom.Colors;
         Normals   = copyFrom.Normals;
         UVs       = copyFrom.UVs;
         BoneDescs = copyFrom.BoneDescs;
      }

      public int Version { get { return 2; } }

      public void Load(ObjectSerializer serializer)
      {
         m_Positions  = null;
         m_Normals    = null;
         m_UVs        = null;
         m_BoneDescs  = null;
         m_Colors     = null;

         m_Positions  = (Vector4[]) serializer.LoadNamedObject( "Positions" );
         m_Normals    = (Vector3[]) serializer.LoadNamedObject( "Normals" );
         m_UVs        = (Vector2[]) serializer.LoadNamedObject( "UVs" );
         m_BoneDescs  = (BoneDesc[])serializer.LoadNamedObject( "BoneDescs" );
         m_MaterialId = (int) serializer.LoadNamedObject( "MaterialId" );
      
         if ( serializer.CurrentVersion >= 2 )
         {
            m_Colors = (Vector4[]) serializer.LoadNamedObject( "Colors" );
         }
         else
         {
            m_Colors = new Vector4[ m_Positions.Length ];
            
            for ( int i = 0; i < m_Colors.Length; i++ )
            {
               m_Colors[ i ] = new Vector4( 1, 1, 1, 1 );
            }
         }
      }

      public void Save(ObjectSerializer serializer)
      {
         serializer.SaveNamedObject( "Positions", m_Positions );
         serializer.SaveNamedObject( "Colors",    m_Colors );
         serializer.SaveNamedObject( "Normals",   m_Normals );
         serializer.SaveNamedObject( "UVs",       m_UVs );
         serializer.SaveNamedObject( "BoneDescs", m_BoneDescs );
         serializer.SaveNamedObject( "MaterialId",m_MaterialId );
      }
   }

   public class ModelData : ISerializable
   {
      private List<String>      m_Materials = new List<String>( );
      private List<SurfaceData> m_Surfaces  = new List<SurfaceData>( );
      private Bone [] m_Bones = new Bone[0];

      private Matrix  m_WorldMatrix = Matrix.Identity;

      public Matrix WorldMatrix
      {
         get { return m_WorldMatrix; }
         set { m_WorldMatrix = value; }
      }

      public void AddSurface(SurfaceData surfaceData)
      {
         SurfaceData data = new SurfaceData( );
         data.Copy( surfaceData );

         m_Surfaces.Add( data );
      }

      public SurfaceData[] Surfaces
      {
         get
         {
            return m_Surfaces.ToArray( );
         }
      }

      public String [] Materials
      {
         get
         {
            return m_Materials.ToArray( );
         }
         set
         {
            m_Materials = new List<String>( value );
         }
      }

      public Bone [] Bones
      {
         get
         {
            Bone[] array = new Bone[m_Bones.Length];
            m_Bones.CopyTo(array, 0);
            return array;
         }
         set 
         {
            m_Bones = new Bone[ value.Length ];
            value.CopyTo( m_Bones, 0 );
         }
      }

      public int Version { get { return 2; } }

      public void Load(ObjectSerializer serializer)
      {
         m_Materials.Clear( );
         m_Surfaces. Clear( );

         object [] array;
         array = serializer.LoadNamedObjects( "Materials" );
         
         foreach (object o in array)
         {
            m_Materials.Add( o as string );
         }

         array = serializer.LoadNamedObjects( "Surfaces" );

         foreach (object o in array)
         {
            m_Surfaces.Add( o as SurfaceData );
         }

         m_Bones = (Bone[]) serializer.LoadNamedObject( "Bones" );
      
         if ( serializer.CurrentVersion >= 2 )
         {
            m_WorldMatrix = (Matrix) serializer.LoadNamedObject( "WorldMatrix" );
         }
      }

      public void Save(ObjectSerializer serializer)
      {
         serializer.SaveNamedObject( "Bones", m_Bones );
         serializer.SaveNamedObject( "WorldMatrix", m_WorldMatrix );

         serializer.SaveNamedObjects( "Materials", m_Materials.ToArray( ) );
         serializer.SaveNamedObjects( "Surfaces",  m_Surfaces.ToArray( ) );
      }
   }
}


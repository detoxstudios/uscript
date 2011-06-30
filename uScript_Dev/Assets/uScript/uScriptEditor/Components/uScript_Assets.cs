// uScript utilty class
// (C) 2011 Detox Studios LLC
// Desc: Manage/track a collection of assets.

using UnityEngine;
using System.Collections.Generic;

public class uScript_Assets : MonoBehaviour
{
   public static uScript_Assets LatestAssets = null;

   public UnityEngine.Object [] Assets;

   public string [] Keys;

   public void Awake( )
   {
      LatestAssets = this;
   }

   public void Add(string key, UnityEngine.Object o)
   {  
      if ( null == Assets || null == Keys )
      {
         Assets = new UnityEngine.Object[ 1 ];
         Keys   = new string[ 1 ];
      }

      int i;

      for ( i = 0; i < Keys.Length; i++ )
      {
         if ( Keys[i] == key ) 
         {
            Assets[ i ] = o;
            break;
         }
      }

      if ( i == Keys.Length )
      {
         System.Array.Resize( ref Assets, Assets.Length + 1 );
         System.Array.Resize( ref Keys, Keys.Length + 1 );

         Assets[ Assets.Length - 1 ] = o;
         Keys[ Keys.Length - 1 ] = key;
      }
   }

   public UnityEngine.Object Find(string key)
   {
      if ( null == Assets || null == Keys ) return null;

      for ( int i = 0; i < Keys.Length; i++ )
      {
         if ( Keys[i] == key ) return Assets[ i ];
      }

      return null;
   }
}

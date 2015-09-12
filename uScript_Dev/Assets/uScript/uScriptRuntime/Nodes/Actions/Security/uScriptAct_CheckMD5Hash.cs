// uScript Action Node
// (C) 2011 Detox Studios LLC

#if (UNITY_FLASH || UNITY_WP8 || UNITY_WP8_1 || UNITY_WSA || UNITY_WSA_8_0 || UNITY_WSA_8_1 || UNITY_WINRT || UNITY_WINRT_8_0 || UNITY_WINRT_8_1)

   // This node is not supported on Flash at this time. This compiler directive is needed for the project to compile for these devices without error.

#else

using UnityEngine;
using System.Collections;
using System.Text;
using System.Security.Cryptography;

[NodePath("Actions/Security")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if the Key string generates the provided MD5 Hash string.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Check MD5 Hash", "Checks to see if the Key string is a match for the provided MD5 Hash string.")]
public class uScriptAct_CheckMD5Hash : uScriptLogic
{
   private bool m_GoodHash = false;

   public bool Good { get { return m_GoodHash; } }
   public bool Bad { get { return !m_GoodHash; } }

   public void In(
      [FriendlyName("Key", "The string to be used to check against the provided MD5 hash.")]
      string Key,
      
      [FriendlyName("MD5 Hash", "The MD5 Hash to check the key against.")]
      string Hash
      )
   {

      if (Key != "" && Hash != "")
      {
         UTF8Encoding ue = new UTF8Encoding();
         byte[] bytes = ue.GetBytes(Key);

         // encrypt bytes
         MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
         byte[] hashBytes = md5.ComputeHash(bytes);

         // Convert the encrypted bytes back to a string (base 16)
         string tmpHash = "";

         for (int i = 0; i < hashBytes.Length; i++)
         {
            tmpHash += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
         }

         string finalHash = tmpHash.PadLeft(32, '0');

         if (finalHash == Hash)
         {
            m_GoodHash = true;
         }
      }


   }
}

#endif

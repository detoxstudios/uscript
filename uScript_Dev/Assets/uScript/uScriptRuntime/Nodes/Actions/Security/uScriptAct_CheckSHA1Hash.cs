// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Checks to see if the Key string generates the provided SHA1 Hash string.

using UnityEngine;
using System.Collections;
using System.Text;
using System.Security.Cryptography;

[NodePath("Actions/Security")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Checks to see if the Key string generates the provided SHA1 Hash string.")]
[NodeDescription("Checks to see if the Key string is a match for the provided SHA1 Hash string.\n\nKey: The string to be used to check against the provided SHA1 hash.\nSHA1 Hash: The SHA1 Hash to check the key against.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Check SHA1 Hash")]
public class uScriptAct_CheckSHA1Hash : uScriptLogic
{
   private bool m_GoodHash = false;

   public bool Good { get { return m_GoodHash; } }
   public bool Bad { get { return !m_GoodHash; } }

   public void In([FriendlyName("Key")] string Key, [FriendlyName("SHA1 Hash")] string Hash)
   {
      

      if (Key != "" && Hash != "")
      {
         UTF8Encoding ue = new UTF8Encoding();
         byte[] bytes = ue.GetBytes(Key);

         // encrypt bytes
         SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
         byte[] hashBytes = sha1.ComputeHash(bytes);

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
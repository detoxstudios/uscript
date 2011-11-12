// uScript Action Node
// (C) 2011 Detox Studios LLC
// Desc: Adds two integer variables together and returns the result.

using UnityEngine;
using System.Collections;

[NodePath("Actions/Utilities")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Shuffles a list.")]
[NodeDescription("Takes an input list, shuffles it and puts the result into Shuffled List.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Shuffle_List")]

[FriendlyName("Shuffle List")]
public class uScriptAct_ShuffleList : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In([FriendlyName("List")] object [] list, [FriendlyName("Shuffled List")] out object [] shuffled)
   {
      shuffled = new object[ list.Length ];
      
      int remain = list.Length;

      for ( int i = 0; i < shuffled.Length; i++ )
      {
         int index = UnityEngine.Random.Range( 0, remain );
         shuffled[ i ] = list[ index ];

         --remain;
         list[ index ] = list[ remain ];
      }
   }
}
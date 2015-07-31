// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Variables/Lists")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip( "Shuffles a list.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Shuffle List", "Takes an input list, shuffles it and puts the result into Shuffled List.")]
public class uScriptAct_ShuffleList : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("List", "The list to shuffle.")]
      object [] list,
      
      [FriendlyName("Shuffled List", "The shuffled list.")]
      out object [] shuffled
      )
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
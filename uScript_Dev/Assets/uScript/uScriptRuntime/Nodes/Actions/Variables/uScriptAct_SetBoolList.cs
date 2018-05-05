// uScript Action Node
// (C) 2018 Detox Studios LLC

[NodePath("Actions/Variables/Bool")]

[NodeCopyright("Copyright 2018 by Detox Studios LLC")]
[NodeToolTip("Sets a list of booleans to the defined value.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Set Bool (List)", "Sets a list of booleans to the defined value.")]
public class uScriptAct_SetBoolList : uScriptLogic
{
   // ================================================================================
   //    Output Sockets
   // ================================================================================
   //
   public bool Out { get { return true; } }

   private bool _setTrue = false;

   [FriendlyName("Set True", "Fired only if the list was set to true.")]
   public bool SetTrue { get { return _setTrue; } }

   private bool _setFalse = false;

   [FriendlyName("Set False", "Fired only if the list was set to false.")]
   public bool SetFalse { get { return _setFalse; } }


   // ================================================================================
   //    Input Sockets and Node Parameters
   // ================================================================================
   //
   // Parameter Attributes are applied below in False()
   public void True(bool[] Target)
   {
      _setFalse = false;
      _setTrue = false;

      for (int i = 0; i < Target.Length; i++) { Target[i] = true; }
      _setTrue = true;

   }

   public void False(
      [FriendlyName("Target", "The value that has been set for this variable list.")]
      bool[] Target
      )
   {
      _setFalse = false;
      _setTrue = false;

      for (int i = 0; i < Target.Length; i++) { Target[i] = false; }
      _setFalse = true;
   }


   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
   //
}

// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Detox Studios, LLC" file="uScriptCon_CompareBoolState.cs">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Compare Bool State - uScript Conditional Node
// </summary>
// --------------------------------------------------------------------------------------------------------------------

[NodePath("Conditions/Comparison")]

[NodeCopyright("Copyright 2013 by Detox Studios LLC")]
[NodeToolTip("Examines the target boolean variable and fires the appropriate output link depending on how it compares to its previous state.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Compare Bool State", "Examines the target boolean variable and fires the appropriate output link depending on how it compares to its previous state.")]
public class uScriptCon_CompareBoolState : uScriptLogic
{
   // ================================================================================
   //    Output Sockets
   // ================================================================================

   public bool Out { get; private set; }

   [FriendlyName("Is True", "Fired only if the variable is true.")]
   public bool IsTrue { get; private set; }

   [FriendlyName("Is False", "Fired only if the variable is to false.")]
   public bool IsFalse { get; private set; }

   [FriendlyName("Was True", "Fired only if the variable was formerly true.")]
   public bool WasTrue { get; private set; }

   [FriendlyName("Was False", "Fired only if the variable was formerly false.")]
   public bool WasFalse { get; private set; }

   // ================================================================================
   //    Input Sockets and Node Parameters
   // ================================================================================

   public void In(
      [FriendlyName("Bool", "The boolean value to examine.")]
      bool target,
      [FriendlyName("Previous State", "The previous bool state and initial value.")]
      [SocketState(false, false)]
      ref bool previousState)
   {
      this.Out = true;

      this.WasTrue = false;
      this.WasFalse = false;

      if (previousState != target)
      {
         if (previousState)
         {
            this.WasTrue = true;
         }
         else
         {
            this.WasFalse = true;
         }

         previousState = target;
      }

      this.IsTrue = target;
      this.IsFalse = !target;
   }

   // ================================================================================
   //    Miscellaneous Node Functionality
   // ================================================================================
}

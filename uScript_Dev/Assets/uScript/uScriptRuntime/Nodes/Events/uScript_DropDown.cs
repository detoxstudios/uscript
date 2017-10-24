// uScript uScript_DropDown.cs
// (C) 2015 Detox Studios LLC

//Unity 5.2 and above only
#if !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_1 && !UNITY_4_2 && !UNITY_4_3 && !UNITY_4_4 && !UNITY_4_5 && !UNITY_5_0 && !UNITY_5_1

[NodePath("Events/UI Events")]

[NodeCopyright("Copyright 2015 by Detox Studios LLC")]
[NodeToolTip("Fires an event signal when a drop-down item is selected.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("UI DropDown Events", "Fires an event signal when Instance DropDown receives an item selected event.")]
public class uScript_DropDown : uScriptEvent
{
   public delegate void uScriptEventHandler(object sender, DropDownEventArgs args);

   public class DropDownEventArgs : System.EventArgs
   {
      public int SelectedIndex { get; set; }

      public DropDownEventArgs(int selectedIndex)
      {
         SelectedIndex = selectedIndex;
      }
   }

   [FriendlyName("On Item Selected")]
   public event uScriptEventHandler OnItemSelected;

   private UnityEngine.UI.Dropdown m_DropDown;

   public void Start()
   {
      m_DropDown = GetComponent<UnityEngine.UI.Dropdown>();
      m_DropDown.onValueChanged.RemoveAllListeners();
      m_DropDown.onValueChanged.AddListener(HandleValueChanged);
   }

   private void HandleValueChanged(int arg0)
   {
      if (OnItemSelected != null) OnItemSelected(this, new DropDownEventArgs(arg0));
   }
}

#endif

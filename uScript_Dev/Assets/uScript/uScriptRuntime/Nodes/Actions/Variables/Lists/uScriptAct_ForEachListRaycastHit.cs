// uScript Action Node
// (C) 2017 Detox Studios LLC

using UnityEngine;

[NodePath("Actions/Variables/Lists/RaycastHit")]

[NodeCopyright("Copyright 2017 by Detox Studios LLC")]
[NodeToolTip("Iterate through each RaycastHit in a RaycastHit List (uScript events must drive each iteration). Note that the list will be stored until all items have been iterated through or Reset is hit with a new list (which can only be done using named list variables).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("For Each In List (RaycastHit)", "Iterates through a list, one item at a time, and returns the current item.\n\nNote: uScript events must drive each iteration.")]
public class uScriptAct_ForEachListRaycastHit : uScriptLogic
{
    private RaycastHit[] m_List = null;
    private int m_CurrentIndex = 0;
    private bool m_Done = false;
    private bool m_ImmediateDone = false;

    // ================================================================================
    //    Output Sockets
    // ================================================================================
    //
    public bool Immediate
    {
        get
        {
            if (!m_ImmediateDone)
            {
                m_ImmediateDone = true;
                return true;
            }

            return false;
        }
    }

    [FriendlyName("Done Iterating")]
    public bool Done { get { return m_Done; } }

    [FriendlyName("Iteration")]
    public bool Iteration { get { return m_List != null && m_CurrentIndex <= m_List.Length && m_CurrentIndex != 0; } }


    // ================================================================================
    //    Input Sockets and Node Parameters
    // ================================================================================
    //
    // Parameter Attributes are applied below in In()
    [FriendlyName("Reset")]
    public void Reset(RaycastHit[] List, out RaycastHit Value, out int currentIndex)
    {
        Value = default(RaycastHit);
        m_List = List;

        m_CurrentIndex = 0;
        currentIndex = m_CurrentIndex;
        m_Done = false;

        m_ImmediateDone = false;
    }

    public void In(
       [FriendlyName("List", "The list to iterate over.")]
      RaycastHit[] List,

       [FriendlyName("Current", "The item for the current loop iteration.")]
      out RaycastHit Value,

       [FriendlyName("Current Index", "The index value for the current loop iteration.")]
      [SocketState(false, false)]
      out int currentIndex
       )
    {
        if (m_List == null)
        {
            m_List = List;

            m_CurrentIndex = 0;
            m_Done = false;
        }

        m_ImmediateDone = !(m_List != null && m_CurrentIndex == 0);
        Value = default(RaycastHit);
        currentIndex = m_CurrentIndex;
        if (m_List != null)
        {
            if (m_CurrentIndex < m_List.Length)
            {
                Value = m_List[m_CurrentIndex];
                currentIndex = m_CurrentIndex;
            }
            m_CurrentIndex++;

            // done iterating
            if (m_CurrentIndex > m_List.Length)
            {
                m_List = null;
                m_Done = true;
            }
        }
    }


    // ================================================================================
    //    Miscellaneous Node Functionality
    // ================================================================================
    //
}

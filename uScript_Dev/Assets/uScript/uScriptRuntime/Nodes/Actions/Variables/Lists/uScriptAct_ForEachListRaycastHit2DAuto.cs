// uScript Action Node
// (C) 2017 Detox Studios LLC

using UnityEngine;

[NodePath("Actions/Variables/Lists/RaycastHit2D")]

[NodeCopyright("Copyright 2017 by Detox Studios LLC")]
[NodeToolTip("Iterate through each RaycastHit2D in a RaycastHit2D List (node will automatically iterate through the list).")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("For Each In List Auto (RaycastHit2D)", "Iterate through each RaycastHit2D in a RaycastHit2D List (node will automatically iterate through the list).")]
public class uScriptAct_ForEachListRaycastHit2DAuto : uScriptLogic
{
    private RaycastHit2D[] m_List = null;
    private int m_CurrentIndex = 0;
    private bool m_Done = false;
    private bool m_ImmediateDone = false;

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

    public void In(
       [FriendlyName("RaycastHit2D List", "The list of RaycastHit2D variables to iterate over.")]
      RaycastHit2D[] List,

       [FriendlyName("Current RaycastHit2D", "The RaycastHit2D for the current loop iteration.")]
      out RaycastHit2D Value,

       [FriendlyName("Current Index", "The index value for the current loop iteration.")]
      [SocketState(false, false)]
      out int currentIndex
       )
    {
        m_List = List;

        m_CurrentIndex = 0;
        m_Done = false;

        Value = default(RaycastHit2D);
        currentIndex = m_CurrentIndex;
        if (m_List != null)
        {
            if (m_CurrentIndex < m_List.Length)
            {
                Value = m_List[m_CurrentIndex];
                currentIndex = m_CurrentIndex;
            }
            m_CurrentIndex++;
        }

        m_ImmediateDone = false;
    }

    [Driven]
    public bool Driven(out RaycastHit2D Value, out int CurrentIndex)
    {
        Value = default(RaycastHit2D);
        CurrentIndex = m_CurrentIndex;
        if (!m_Done && m_List != null)
        {
            if (m_CurrentIndex < m_List.Length)
            {
                Value = m_List[m_CurrentIndex];
                CurrentIndex = m_CurrentIndex;
            }
            m_CurrentIndex++;

            // done iterating
            if (m_CurrentIndex > m_List.Length)
            {
                m_List = null;
                m_Done = true;
            }

            return true;
        }

        return false;
    }
}

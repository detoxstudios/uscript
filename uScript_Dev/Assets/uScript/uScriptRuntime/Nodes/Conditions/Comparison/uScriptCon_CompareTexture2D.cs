// uScript Action Node
// (C) 2019 Detox Studios LLC

using UnityEngine;

[NodePath("Conditions/Comparison")]

[NodeCopyright("Copyright 2019 by Detox Studios LLC")]
[NodeToolTip("Compares the InstanceID of the attached Texture2D variables and outputs accordingly.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Compare Texture2D", "Compares the unique InstanceID of the attached Texture2D variables and outputs accordingly.")]
public class uScriptCon_CompareTexture2D : uScriptLogic
{
    private bool m_CompareValue = false;

    public bool Same { get { return m_CompareValue; } }
    public bool Different { get { return !m_CompareValue; } }

    public void In(
       [FriendlyName("A", "The first Texture2D.")]
      Texture2D A,

       [FriendlyName("B", "The second Texture2D.")]
      Texture2D B,

       [FriendlyName("Report Null", "Whether or not to report null Texture2Ds in the console.")]
      [SocketState(false, false)]
      [DefaultValue(false)]
      bool ReportNull
       )
    {
        m_CompareValue = false;

        if (ReportNull)
        {
            if (null == A)
            {
                uScriptDebug.Log("Compare Texture2Ds A is null", uScriptDebug.Type.Warning);
            }

            if (null == B)
            {
                uScriptDebug.Log("Compare Texture2Ds B is null", uScriptDebug.Type.Warning);
            }
        }

        if (null == A && null == B)
            m_CompareValue = true;
        else if (null != A && null != B)
            m_CompareValue = A.GetInstanceID() == B.GetInstanceID();
    }
}
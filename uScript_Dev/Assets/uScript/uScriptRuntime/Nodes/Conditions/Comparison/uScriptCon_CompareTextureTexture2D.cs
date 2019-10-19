// uScript Action Node
// (C) 2019 Detox Studios LLC

using UnityEngine;

[NodePath("Conditions/Comparison")]

[NodeCopyright("Copyright 2019 by Detox Studios LLC")]
[NodeToolTip("Compares the InstanceID of the attached Texture and Texture2D variables and outputs accordingly.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://docs.uscript.net/#3-Working_With_uScript/3.4-Nodes.htm")]

[FriendlyName("Compare Texture to Texture2D", "Compares the unique InstanceID of the attached Texture and Texture2D variables and outputs accordingly.")]
public class uScriptCon_CompareTextureTexture2D : uScriptLogic
{
    private bool m_CompareValue = false;

    public bool Same { get { return m_CompareValue; } }
    public bool Different { get { return !m_CompareValue; } }

    public void In(
       [FriendlyName("A", "The Texture.")]
      Texture A,

       [FriendlyName("B", "The Texture2D.")]
      Texture2D B,

       [FriendlyName("Report Null", "Whether or not to report null Textures in the console.")]
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
                uScriptDebug.Log("Compare TextureTexture2Ds A is null", uScriptDebug.Type.Warning);
            }

            if (null == B)
            {
                uScriptDebug.Log("Compare TextureTexture2Ds B is null", uScriptDebug.Type.Warning);
            }
        }

        if (null == A && null == B)
            m_CompareValue = true;
        else if (null != A && null != B)
            m_CompareValue = A.GetInstanceID() == B.GetInstanceID();
    }
}
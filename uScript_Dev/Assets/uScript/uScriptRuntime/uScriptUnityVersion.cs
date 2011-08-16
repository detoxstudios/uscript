
public class uScriptUnityVersion : uScriptIUnityVersion
{
#if UNITY_3_0
	public string Version { get { return "3.0"; } }
#elif UNITY_3_1
	public string Version { get { return "3.1"; } }
#elif UNITY_3_2
	public string Version { get { return "3.2"; } }
#elif UNITY_3_3
	public string Version { get { return "3.3"; } }
#elif UNITY_4_0
	public string Version { get { return "4.0"; } }
#else
 	public string Version { get { return "0.0"; } }
#endif
}
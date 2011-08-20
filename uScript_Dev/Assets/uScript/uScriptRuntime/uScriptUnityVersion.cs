
public class uScriptUnityVersion : uScriptIUnityVersion
{
#if UNITY_3_0
	public float Version { get { return 3.0f; } }
#elif UNITY_3_1
	public float Version { get { return 3.1f; } }
#elif UNITY_3_2
	public float Version { get { return 3.2f; } }
#elif UNITY_3_3
	public float Version { get { return 3.3f; } }
#elif UNITY_3_4
	public float Version { get { return 3.4f; } }
#else
 	public float Version { get { return 0.0f; } }
#endif
}
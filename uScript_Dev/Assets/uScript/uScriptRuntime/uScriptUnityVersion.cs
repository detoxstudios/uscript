// --------------------------------------------------------------------------------------------------------------------
// <copyright file="uScriptUnityVersion.cs" company="Detox Studios, LLC">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the uScriptUnityVersion type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

public class uScriptUnityVersion : uScriptIUnityVersion
{
#if UNITY_3_5
   public float Version { get { return 3.5f; } }
#elif UNITY_4_0
   public float Version { get { return 4.0f; } }
#elif UNITY_4_1
   public float Version { get { return 4.1f; } }
#elif UNITY_4_2
   public float Version { get { return 4.2f; } }
#elif UNITY_4_3
   public float Version { get { return 4.3f; } }
#elif UNITY_4_4
   public float Version { get { return 4.4f; } }
#elif UNITY_4_5
   public float Version { get { return 4.5f; } }
#else
   public float Version { get { return 0.0f; } }
#endif
}

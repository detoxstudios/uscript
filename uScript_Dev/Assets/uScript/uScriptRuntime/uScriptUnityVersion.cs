// --------------------------------------------------------------------------------------------------------------------
// <copyright file="uScriptUnityVersion.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the uScriptUnityVersion type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

public class uScriptUnityVersion : uScriptIUnityVersion
{
#if UNITY_3_5
   public float Version { get { return 3.5f; } }
#elif UNITY_4_6
   public float Version { get { return 4.6f; } }
#elif UNITY_5_0
   public float Version { get { return 5.0f; } }
#elif UNITY_5_1
   public float Version { get { return 5.1f; } }
#elif UNITY_5_2
   public float Version { get { return 5.2f; } }
#elif UNITY_5_3
   public float Version { get { return 5.3f; } }
#elif UNITY_5_4
   public float Version { get { return 5.4f; } }
#elif UNITY_5_5
   public float Version { get { return 5.5f; } }
#else
   public float Version { get { return 0.0f; } }
#endif
}

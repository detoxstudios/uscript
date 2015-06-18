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
#if UNITY_3
   public float Version { get { return 3.5f; } }
#elif UNITY_4
   public float Version { get { return 4.6f; } }
#elif UNITY_5
   public float Version { get { return 5.0f; } }
#else
   public float Version { get { return 0.0f; } }
#endif
}

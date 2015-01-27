// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuildInfo.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the BuildInfo type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor
{
   public struct BuildInfo
   {
      public BuildInfo(int major, int minor, int revision)
         : this()
      {
         this.Major = major;
         this.Minor = minor;
         this.Revision = revision;
      }

      public int Major { get; private set; }

      public int Minor { get; private set; }

      public int Revision { get; private set; }

      public static bool TryParse(string buildNumber, out BuildInfo result)
      {
         var numbers = buildNumber.Split('.');
         if (numbers.Length == 3)
         {
            int major, minor, revision;
            if (int.TryParse(numbers[0], out major) && int.TryParse(numbers[1], out minor)
                && int.TryParse(numbers[2], out revision))
            {
               result = new BuildInfo(major, minor, revision);
               return true;
            }
         }

         result = new BuildInfo();
         return false;
      }

      public static bool operator ==(BuildInfo a, BuildInfo b)
      {
         return a.Equals(b);
      }

      public static bool operator !=(BuildInfo a, BuildInfo b)
      {
         return !a.Equals(b);
      }

      public static bool operator >(BuildInfo a, BuildInfo b)
      {
         return a.Compare(b) > 0;
      }

      public static bool operator <(BuildInfo a, BuildInfo b)
      {
         return a.Compare(b) < 0;
      }

      public static bool operator >=(BuildInfo a, BuildInfo b)
      {
         return a.Compare(b) >= 0;
      }

      public static bool operator <=(BuildInfo a, BuildInfo b)
      {
         return a.Compare(b) <= 0;
      }

      public static int Compare(BuildInfo a, BuildInfo b)
      {
         if (a.Major != b.Major)
         {
            return a.Major < b.Major ? -1 : 1;
         }

         if (a.Minor != b.Minor)
         {
            return a.Minor < b.Minor ? -1 : 1;
         }

         if (a.Revision != b.Revision)
         {
            return a.Revision < b.Revision ? -1 : 1;
         }

         return 0;
      }

      public int Compare(BuildInfo other)
      {
         return Compare(this, other);
      }

      public bool Equals(BuildInfo other)
      {
         return this.Major == other.Major && this.Minor == other.Minor && this.Revision == other.Revision;
      }

      public override bool Equals(object obj)
      {
         if (!(obj is BuildInfo))
         {
            return false;
         }

         return this.Equals((BuildInfo)obj);
      }

      public override int GetHashCode()
      {
         var calc = this.Major + this.Minor + this.Revision;
         return calc;
      }

      public override string ToString()
      {
         return string.Format("{0}.{1}.{2}", this.Major, this.Minor, this.Revision);
      }
   }
}

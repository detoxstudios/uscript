// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Promotion.cs" company="Detox Studios, LLC">
//   Copyright 2010-2015 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the Promotion type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Detox.Editor
{
   using System;

   using UnityEngine;

   public class Promotion
   {
      public const string DateFormat = "yyyy-MM-dd";

      public Promotion()
      {
         this.Edition = uScriptBuild.EditionType.Basic;
         this.StartDate = DateTime.Now.Date.ToString(DateFormat);
         this.EndDate = this.StartDate;

         this.ImagePath = string.Empty;
         this.LinkPath = string.Empty;
      }

      public int ID { get; set; }

      public uScriptBuild.EditionType Edition { get; set; }

      public string StartDate { get; set; }

      public string EndDate { get; set; }

      public Texture2D Image { get; set; }

      public string ImageData { get; set; }

      public string ImagePath { get; set; }

      public string LinkPath { get; set; }

      public Promotion DeepClone()
      {
         var other = (Promotion)this.MemberwiseClone();
         return other;
      }

      public override int GetHashCode()
      {
         unchecked
         {
            var hashCode = this.ID;
            hashCode = (hashCode * 397) ^ (int)this.Edition;
            hashCode = (hashCode * 397) ^ (this.StartDate != null ? this.StartDate.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (this.EndDate != null ? this.EndDate.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (this.Image != null ? this.Image.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (this.ImageData != null ? this.ImageData.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (this.ImagePath != null ? this.ImagePath.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (this.LinkPath != null ? this.LinkPath.GetHashCode() : 0);
            return hashCode;
         }
      }

      public override bool Equals(object obj)
      {
         if (ReferenceEquals(null, obj))
         {
            return false;
         }

         if (ReferenceEquals(this, obj))
         {
            return true;
         }

         return obj.GetType() == this.GetType() && this.Equals((Promotion)obj);
      }

      private bool Equals(Promotion p)
      {
         return this.ID == p.ID && this.Edition == p.Edition && string.Equals(this.StartDate, p.StartDate)
                && string.Equals(this.EndDate, p.EndDate) /* && Equals(this.Image, p.Image) */
                && string.Equals(this.ImageData, p.ImageData) && string.Equals(this.ImagePath, p.ImagePath)
                && string.Equals(this.LinkPath, p.LinkPath);
      }
   }
}

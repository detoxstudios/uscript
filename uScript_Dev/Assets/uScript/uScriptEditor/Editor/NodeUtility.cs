// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NodeUtility.cs" company="Detox Studios, LLC">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines static methods for retrieving Node metadata and testing node states or conditions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

using Detox.ScriptEditor;

using EntityNode = Detox.ScriptEditor.EntityNode;

public sealed partial class uScript
{
   public static string FindNodeAuthorName(string type)
   {
      var uScriptType = uScript.Instance.GetType(type);

      if (uScriptType != null)
      {
         var attributes = uScriptType.GetCustomAttributes(false);

         foreach (var a in attributes.OfType<NodeAuthor>())
         {
            return a.Value;
         }
      }

      return string.Empty;
   }

   public static string FindNodeAuthorURL(string type)
   {
      var uScriptType = uScript.Instance.GetType(type);

      if (uScriptType != null)
      {
         var attributes = uScriptType.GetCustomAttributes(false);

         foreach (var a in attributes.OfType<NodeAuthor>())
         {
            return a.URL;
         }
      }

      return string.Empty;
   }

   public static bool FindNodeAutoAssignMasterInstance(string type)
   {
      var uScriptType = uScript.Instance.GetType(type);

      if (uScriptType != null)
      {
         var attributes = uScriptType.GetCustomAttributes(false);

         return attributes.OfType<NodeAutoAssignMasterInstance>().Select(a => a.Value).FirstOrDefault();
      }

      return false;
   }

   public static string FindNodeCopyright(string type)
   {
      var uScriptType = uScript.Instance.GetType(type);

      if (uScriptType != null)
      {
         var attributes = uScriptType.GetCustomAttributes(false);

         foreach (var a in attributes.OfType<NodeCopyright>())
         {
            return a.Value;
         }
      }

      return string.Empty;
   }

   public static string FindNodeDescription(string type, EntityNode node)
   {
      // Check non-logic, non-event types first...
      // Structs can't have attributes, so we have to specify this information here, explicitly
      if (type == "CommentNode")
      {
         return "Use a comment box to comment or hint at what a particular block of uScript nodes"
                + " does. Comment boxes can be resized so that they surround the nodes that they are"
                + " referencing.\n\nTo resize a comment box, drag the bottom-right corner of the comment"
                + " box or set its width/height properties explicitly in the Properties panel.";
      }

      if (type == "ExternalConnection")
      {
         return "Use External Connections to create nested uScript graphs that show up as a single"
                + " node in other graphs they are used in. An External Connection node"
                + " will turn into a socket when the current graph is used as a nested node inside"
                + " other graphs. The type of socket it turns into will be determined by the type of"
                + " socket it is connected to in this uScript.\n\nTo place this uScript graph in another"
                + " uScript as a nested node, save it and then look for it under the \"Graphs\" section"
                + " of the Toolbox panel or 'Add' context menu.";
      }

      if (type == "OwnerConnection")
      {
         return "Owner GameObject variables are a special kind of GameObject variable. They"
                + " represent the GameObject that this uScript is attached to.";
      }

      if (type == "LocalNode")
      {
         var variable = (LocalNode)node;
         var friendlyType = uScriptConfig.Variable.FriendlyName(variable.Value.Type);

         switch (friendlyType)
         {
            case "Bool":
               return "A Boolean variable, which stores the value of True or False.";

            case "Color":
               return
                  "A Color variable. The color is defined in RGB color space and contains an Alpha (opacity) channel.";

            case "Float":
               return "A floating-point variable may store a real number (e.g., 1.234, 5.0, -3.21).";

            case "Int":
               return "An integer variable may store a whole number (e.g., 1, 0, -3).";

            case "Vector2":
               return "A Vector2 variable represents a 2-dimensional point in space (x,y).";

            case "Vector3":
               return "A Vector3 variable represents a 3-dimensional point or direction in space (x,y,z).";

            case "Vector4":
               return
                  "A Vector4 variable represents a 3-dimensional point or direction in space with an additional 'W' component (x,y,z,w).";

            case "Rect":
               return "A Rect variable represents a 2-dimensional position (x,y) and an area (width, height).";

            case "Quaternion":
               return "A Quaternion variable stores a quaternion representation of a rotation in space.";

            case "GameObject":
               return "A GameObject variable that stores a refernce to a GameObject in the scene.\n\n"
                      + "Note that if a GameObject is being used as a node's input parameter, it is set"
                      + " by name and when this is done, it must be unique in the scene.";

            case "String":
               return "A String variable, which stores text data.";

            default:
               return "Use variables to store data in your uScript.";
         }
      }

      var uScriptType = uScript.Instance.GetType(type);

      if (uScriptType != null)
      {
         var attributes = uScriptType.GetCustomAttributes(false);

         foreach (var a in attributes.OfType<FriendlyNameAttribute>().Where(a => a.Desc != string.Empty))
         {
            return a.Desc;
         }

         foreach (var a in attributes.OfType<NodeDescription>())
         {
            return a.Value;
         }
      }
      else if (node is LogicNode)
      {
         // This could be a nested script due to the null uScriptType

         if (m_RawDescription.Contains(((LogicNode)node).Type))
         {
            return m_RawDescription[((LogicNode)node).Type] as string;
         }
      }

      var entityType = "method";
      if (node is EntityProperty)
      {
         entityType = "property";
      }
      else if (node is EntityEvent)
      {
         entityType = "event";
      }

      return
         string.Format(
            "This node appears to have been generated by reflection. It allows access to the {0} \"{1}\"."
            + "\n\nPlease refer to the appropriate resource, such as MSDN or the"
            + " Unity Script Reference, for usage and behavior information.",
            entityType,
            GetNodeSignature(node));
   }

   public static string FindNodeHelp(string type, EntityNode node)
   {
      // check non-logic, non-event types first...
      // structs can't have attributes, so we have to specify this information here, explicitly
      if (type == "CommentNode")
      {
         return "http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Comment_Node";
      }

      if (type == "ExternalConnection")
      {
         return "http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#External_Connection";
      }

      if (type == "LocalNode")
      {
         return "http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Variable_Nodes";
      }

      if (type == "OwnerConnection")
      {
         return "http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Owner_Variable";
      }

      var uScriptType = uScript.Instance.GetType(type);

      if (uScriptType != null)
      {
         var attributes = uScriptType.GetCustomAttributes(false);

         foreach (var a in attributes.OfType<NodeHelp>())
         {
            return a.Value;
         }
      }

      return string.Empty;
   }

   //public static string FindNodeLicense(string type)
   //{
   //   Type uScriptType = uScript.uScript.Instance.GetType(type);
   //   if (uScriptType != null)
   //   {
   //      object[] attributes = uScriptType.GetCustomAttributes(false);
   //      if (null == attributes) return "";
   //      foreach (object a in attributes)
   //      {
   //         if (a is NodeLicense)
   //         {
   //            return ((NodeLicense)a).Value;
   //         }
   //      }
   //   }
   //   return "";
   //}

   public static string FindNodeName(string type, EntityNode node)
   {
      // Check non-logic, non-event types first, because structs can't have attributes,
      // so we have to specify this information here, explicitly

      if (type == "CommentNode")
      {
         return "Comment";
      }

      if (type == "ExternalConnection")
      {
         return "External Connection";
      }

      if (type == "OwnerConnection")
      {
         return "Owner GameObject";
      }

      if (type == "LocalNode")
      {
         return uScriptConfig.Variable.FriendlyName(((LocalNode)node).Value.Type).Replace("UnityEngine.", string.Empty);
      }

      var uScriptType = uScript.Instance.GetType(type);

      if (uScriptType != null)
      {
         var attributes = uScriptType.GetCustomAttributes(false);
         foreach (var a in attributes.OfType<FriendlyNameAttribute>())
         {
            return a.Name;
         }
      }

      // If there is no name at this point, the node is likely reflected
      if (node is EntityMethod)
      {
         return string.Format("Reflected {0} action", type.Replace("UnityEngine.", string.Empty));
      }

      if (node is EntityProperty)
      {
         return string.Format("Reflected {0} property", type.Replace("UnityEngine.", string.Empty));
      }

      return string.Empty;
   }

   public static string FindNodePath(string defaultCategory, string type)
   {
      var uScriptType = uScript.Instance.GetType(type);

      if (uScriptType != null)
      {
         var attributes = uScriptType.GetCustomAttributes(false);

         foreach (var a in attributes.OfType<NodePath>())
         {
            return a.Value;
         }
      }

      return defaultCategory;
   }

   public static string FindNodePropertiesPath(string defaultCategory, string type)
   {
      var uScriptType = uScript.Instance.GetType(type);

      if (uScriptType != null)
      {
         var attributes = uScriptType.GetCustomAttributes(false);

         foreach (var a in attributes.OfType<NodePropertiesPath>())
         {
            return a.Value;
         }
      }

      return defaultCategory;
   }

   public static string FindNodeToolTip(string type)
   {
      var uScriptType = uScript.Instance.GetType(type);

      if (uScriptType != null)
      {
         var attributes = uScriptType.GetCustomAttributes(false);

         foreach (var a in attributes.OfType<NodeToolTip>())
         {
            return a.Value;
         }
      }

      return string.Empty;
   }

   /// <summary>Get the unique signature for the specified EntityNode.</summary>
   /// <returns>The node signature.</returns>
   /// <param name='node'>The node to analyze.</param>
   public static string GetNodeSignature(EntityNode node)
   {
      if (node is CommentNode
         || node is ExternalConnection
         || node is OwnerConnection)
      {
         return node.GetType().Name;
      }

      if (node is LocalNode)
      {
         return ScriptEditorCtrl.GetTypeAlias(((LocalNode)node).Value.Type);
      }

      if (node is EntityEvent)
      {
         // TODO: Do reflected events nodes need to have their signature included?
         return ((EntityEvent)node).ComponentType;
      }

      if (node is EntityMethod)
      {
         var m = (EntityMethod)node;
         return string.Format("{0}.{1}{2}", m.ComponentType, m.Input.Name, ScriptEditorCtrl.GetMethodSignature(m));
      }

      if (node is EntityProperty)
      {
         var p = (EntityProperty)node;
         return string.Format("{0}.{1}", p.ComponentType, p.Parameter.Name);
      }

      if (node is LogicNode)
      {
         return ((LogicNode)node).Type;
      }

      if (node != null)
      {
         uScriptDebug.Log("Cannot generate node signature. Unhandled EntityNode type: " + node.GetType(), uScriptDebug.Type.Error);
      }

      return string.Empty;
   }

   public static string GetNodeType(EntityNode node)
   {
      if (node is CommentNode || node is ExternalConnection || node is OwnerConnection || node is LocalNode)
      {
         return node.GetType().Name;
      }

      return ScriptEditor.FindNodeType(node);
   }

   public static Type GetNodeUpgradeType(EntityNode node)
   {
      var type = ScriptEditor.FindNodeType(node);
      if (type == string.Empty)
      {
         return null;
      }

      var uScriptType = uScript.Instance.GetType(type);
      if (uScriptType == null)
      {
         return null;
      }

      var attributes = uScriptType.GetCustomAttributes(false);

      return attributes.OfType<NodeDeprecated>().Select(a => a.UpgradeType).FirstOrDefault();
   }

   public static bool IsNodeTypeDeprecated(EntityNode node)
   {
      var type = ScriptEditor.FindNodeType(node);
      if (type == string.Empty)
      {
         return false;
      }

      var uScriptType = uScript.Instance.GetType(type);
      if (uScriptType == null)
      {
         return false;
      }

      var attributes = uScriptType.GetCustomAttributes(false);

      return attributes.OfType<NodeDeprecated>().Any();
   }
}

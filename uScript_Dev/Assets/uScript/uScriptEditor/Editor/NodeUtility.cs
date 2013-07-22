// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NodeUtility.cs" company="Detox Studios, LLC">
//   Copyright 2010-2013 Detox Studios, LLC. All rights reserved.
// </copyright>
// <summary>
//   Defines the PanelScript type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Detox.ScriptEditor;

using EntityNode = Detox.ScriptEditor.EntityNode;

public sealed partial class uScript
{
   public static string FindNodeAuthorName(string type)
   {
      Type uscriptType = MasterComponent.GetType(type);

      if (uscriptType != null)
      {
         object[] attributes = uscriptType.GetCustomAttributes(false);
         if (null == attributes) return "";

         foreach (object a in attributes)
         {
            if (a is NodeAuthor)
            {
               return ((NodeAuthor)a).Value;
            }
         }
      }

      return "";
   }

   public static string FindNodeAuthorURL(string type)
   {
      Type uscriptType = MasterComponent.GetType(type);

      if (uscriptType != null)
      {
         object[] attributes = uscriptType.GetCustomAttributes(false);
         if (null == attributes) return string.Empty;

         foreach (object a in attributes)
         {
            if (a is NodeAuthor)
            {
               return ((NodeAuthor)a).URL;
            }
         }
      }

      return string.Empty;
   }

   public static bool FindNodeAutoAssignMasterInstance(string type)
   {
      Type uscriptType = MasterComponent.GetType(type);

      if (uscriptType != null)
      {
         object[] attributes = uscriptType.GetCustomAttributes(false);
         if (null == attributes) return false;

         foreach (object a in attributes)
         {
            if (a is NodeAutoAssignMasterInstance)
            {
               return ((NodeAutoAssignMasterInstance)a).Value;
            }
         }
      }

      return false;
   }

   public static string FindNodeCopyright(string type)
   {
      Type uscriptType = MasterComponent.GetType(type);

      if (uscriptType != null)
      {
         object[] attributes = uscriptType.GetCustomAttributes(false);
         if (null == attributes) return "";

         foreach (object a in attributes)
         {
            if (a is NodeCopyright)
            {
               return ((NodeCopyright)a).Value;
            }
         }
      }

      return "";
   }
   
   public static string FindNodeDescription(string type, EntityNode node)
   {
      // check non-logic, non-event types first...
      // structs can't have attributes, so we have to specify this information here, explicitly
      if (type == "CommentNode")
      {
         return "Use a comment box to comment or hint at what a particular block of uScript nodes" +
            " does. Comment boxes can be resized so that they surround the nodes that they are" +
            " referencing.\n\nTo resize a comment box, drag the bottom-right corner of the comment" +
            " box or set its width/height properties explicitly in the Properties panel.";
      }
      else if (type == "ExternalConnection")
      {
         return "Use External Connections to create nested uScript graphs that show up as a single node in other graphs they are used in. An External Connection node" +
            " will turn into a socket when the current graph is used as a nested node inside" +
            " other graphs. The type of socket it turns into will be determined by the type of" +
            " socket it is connected to in this uScript.\n\nTo place this uScript graph in another" +
            " uScript as a nested node, save it and then look for it under the \"Graphs\" section" +
            " of the Toolbox panel or 'Add' context menu.";
      }
      else if (type == "OwnerConnection")
      {
         return "Owner GameObject variables are a special kind of GameObject variable. They" +
            " represent the GameObject that this uScript is attached to.";
      }
      else if (type == "LocalNode")
      {
         LocalNode variable = (LocalNode)node;
         string friendlyType = uScriptConfig.Variable.FriendlyName(variable.Value.Type);

         switch (friendlyType)
         {
            case "Bool":
               return "A Boolean variable, which stores the value of True or False.";
            case "Color":
               return "A Color variable. The color is defined in RGB color space and contains an Alpha (opacity) channel.";
            case "Float":
               return "A floating-point variable may store a real number (e.g., 1.234, 5.0, -3.21).";
            case "Int":
               return "An integer variable may store a whole number (e.g., 1, 0, -3).";
            case "Vector2":
               return "A Vector2 variable represents a 2-dimensional point in space (x,y).";
            case "Vector3":
               return "A Vector3 variable represents a 3-dimensional point or direction in space (x,y,z).";
            case "Vector4":
               return "A Vector4 variable represents a 3-dimensional point or direction in space with an additional 'W' component (x,y,z,w).";
            case "Rect":
               return "A Rect variable represents a 2-dimensional position (x,y) and an area (width, height).";
            case "Quaternion":
               return "A Quaternion variable stores a quaternion representation of a rotation in space.";
            case "GameObject":
               return "A GameObject variable that stores a refernce to a GameObject in the scene.\n\nNote that if a GameObject is being used as a node's input parameter, it is set by name and when this is done, it must be unique in the scene.";
            case "String":
               return "A String variable, which stores text data.";
            default:
               return "Use variables to store data in your uScript.";
         }
      }

      Type uscriptType = MasterComponent.GetType(type);

      if (uscriptType != null)
      {
         object[] attributes = uscriptType.GetCustomAttributes(false);
         if (null == attributes) return "Z";

         foreach (object a in attributes)
         {
            if (a is FriendlyNameAttribute)
            {
               if (((FriendlyNameAttribute)a).Desc != String.Empty)
               {
                  return ((FriendlyNameAttribute)a).Desc;
               }
            }
         }

         foreach (object a in attributes)
         {
            if (a is NodeDescription)
            {
               return ((NodeDescription)a).Value;
            }
         }
      }
      //if type was null it could be a nested script
      else if (node is LogicNode)
      {
         if (m_RawDescription.Contains(((LogicNode)node).Type))
         {
            return m_RawDescription[((LogicNode)node).Type] as string;
         }
      }

      string entityType = "method";
      if (node is EntityProperty)
      {
         entityType = "property";
      }
      else if (node is EntityEvent)
      {
         entityType = "event";
      }

      return "This node appears to have been generated by reflection. It allows access to the " + entityType + " \"" + GetNodeSignature(node) + "\"."
         + "\n\nPlease refer to the appropriate resource, such as MSDN or the Unity Script Reference, for usage and behavior information.";
   }

   public static string FindNodeHelp(string type, EntityNode node)
   {
      // check non-logic, non-event types first...
      // structs can't have attributes, so we have to specify this information here, explicitly
      if (type == "CommentNode")
      {
         return "http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Comment_Node";
      }
      else if (type == "ExternalConnection")
      {
         return "http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#External_Connection";
      }
      else if (type == "LocalNode")
      {
         return "http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Variable_Nodes";
      }
      else if (type == "OwnerConnection")
      {
         return "http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Owner_Variable";
      }

      Type uscriptType = MasterComponent.GetType(type);

      if (uscriptType != null)
      {
         object[] attributes = uscriptType.GetCustomAttributes(false);
         if (null == attributes) return string.Empty;

         foreach (object a in attributes)
         {
            if (a is NodeHelp)
            {
               return ((NodeHelp)a).Value;
            }
         }
      }

      return string.Empty;
   }

   //public static string FindNodeLicense(string type)
   //{
   //   Type uscriptType = uScript.MasterComponent.GetType(type);
   //   if (uscriptType != null)
   //   {
   //      object[] attributes = uscriptType.GetCustomAttributes(false);
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
      else if (type == "ExternalConnection")
      {
         return "External Connection";
      }
      else if (type == "OwnerConnection")
      {
         return "Owner GameObject";
      }
      else if (type == "LocalNode")
      {
         return uScriptConfig.Variable.FriendlyName(((LocalNode)node).Value.Type).Replace("UnityEngine.", String.Empty);
      }

      Type uscriptType = MasterComponent.GetType(type);

      if (uscriptType != null)
      {
         object[] attributes = uscriptType.GetCustomAttributes(false);
         foreach (object a in attributes)
         {
            if (a is FriendlyNameAttribute)
            {
               return ((FriendlyNameAttribute)a).Name;
            }
         }
      }

      // If there is no name at this point, the node is likely reflected
      if (node is EntityMethod)
      {
         return "Reflected " + type.Replace("UnityEngine.", String.Empty) + " action";
      }
      else if (node is EntityProperty)
      {
         return "Reflected " + type.Replace("UnityEngine.", String.Empty) + " property";
      }

      return String.Empty;
   }

   public static string FindNodePath(string defaultCategory, string type)
   {
      Type uscriptType = MasterComponent.GetType(type);

      if (uscriptType != null)
      {
         object[] attributes = uscriptType.GetCustomAttributes(false);
         if (null == attributes) return "";

         foreach (object a in attributes)
         {
            if (a is NodePath)
            {
               return ((NodePath)a).Value;
            }
         }
      }

      return defaultCategory;
   }

   public static string FindNodePropertiesPath(string defaultCategory, string type)
   {
      Type uscriptType = MasterComponent.GetType(type);

      if (uscriptType != null)
      {
         object[] attributes = uscriptType.GetCustomAttributes(false);
         if (null == attributes) return "";

         foreach (object a in attributes)
         {
            if (a is NodePropertiesPath)
            {
               return ((NodePropertiesPath)a).Value;
            }
         }
      }

      return defaultCategory;
   }

   public static string FindNodeToolTip(string type)
   {
      Type uscriptType = MasterComponent.GetType(type);

      if (uscriptType != null)
      {
         object[] attributes = uscriptType.GetCustomAttributes(false);
         if (null == attributes) return "";

         foreach (object a in attributes)
         {
            if (a is NodeToolTip)
            {
               return ((NodeToolTip)a).Value;
            }
         }
      }

      return "";
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
         EntityMethod m = (EntityMethod)node;
         return m.ComponentType + "." + m.Input.Name + ScriptEditorCtrl.GetMethodSignature(m);
      }

      if (node is EntityProperty)
      {
         EntityProperty p = (EntityProperty)node;
         return p.ComponentType + "." + p.Parameter.Name;
      }

      if (node is LogicNode)
      {
         return ((LogicNode)node).Type;
      }

      if (node != null)
      {
         uScriptDebug.Log("Cannot generate node signature. Unhandled EntityNode type: " + node.GetType().ToString(), uScriptDebug.Type.Error);
      }
      return String.Empty;
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
      string type = ScriptEditor.FindNodeType(node);
      if ("" == type) return null;

      Type uscriptType = MasterComponent.GetType(type);
      if (null == uscriptType) return null;

      object[] attributes = uscriptType.GetCustomAttributes(false);
      if (null == attributes) return null;

      foreach (object a in attributes)
      {
         if (a is NodeDeprecated)
         {
            return ((NodeDeprecated)a).UpgradeType;
         }
      }

      return null;
   }

   public static bool IsNodeTypeDeprecated(EntityNode node)
   {
      string type = ScriptEditor.FindNodeType(node);
      if ("" == type) return false;

      Type uscriptType = MasterComponent.GetType(type);
      if (null == uscriptType) return false;

      object[] attributes = uscriptType.GetCustomAttributes(false);
      if (null == attributes) return false;

      foreach (object a in attributes)
      {
         if (a is NodeDeprecated)
         {
            return true;
         }
      }

      return false;
   }
}

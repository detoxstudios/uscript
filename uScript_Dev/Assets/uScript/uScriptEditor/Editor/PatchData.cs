using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

using Detox.DirectX;
using Detox.Data;

namespace Detox.Patch
{
   public abstract class PatchData : ISerializable
   {
      public string Name = "";

      public PatchData()
      {}

      public PatchData(string name)
      {
         Name = name;
      }

      public int Version { get { return 1; } }
   
      public string ToBase64( )
      {
         ObjectSerializer s = new ObjectSerializer( );
         
         MemoryStream stream = new MemoryStream( );
         BinaryWriter writer = new BinaryWriter( stream );

         s.Save( writer, this );

         return Convert.ToBase64String( stream.GetBuffer( ) );
      }

      public void Load(ObjectSerializer serializer)
      {
         Name = (string) serializer.LoadNamedObject( "Name" );
      }

      public void Save(ObjectSerializer serializer)
      {
         serializer.SaveNamedObject( "Name", Name );
      }

      public abstract void Apply ( ScriptEditor.ScriptEditor scriptEditor );
      public abstract void Remove( ScriptEditor.ScriptEditor scriptEditor );

      public abstract void Apply ( ScriptEditor.ScriptEditorCtrl scriptEditorCtrl );
      public abstract void Remove( ScriptEditor.ScriptEditorCtrl scriptEditorCtrl );
   };

   public class EntityNode : PatchData
   {
      Data.ScriptEditor.EntityNodeData OldNode;
      Data.ScriptEditor.EntityNodeData NewNode;

      public EntityNode( )
      {}

      public EntityNode(string name, ScriptEditor.EntityNode oldNode, ScriptEditor.EntityNode newNode) : base(name)
      {
         OldNode = oldNode != null ? oldNode.NodeData : null;
         NewNode = newNode != null ? newNode.NodeData : null;
      }

      public new void Load(ObjectSerializer serializer)
      {
         serializer.LoadBaseObject( this, typeof(PatchData) );

         //could be null
         OldNode = serializer.LoadNamedObject( "OldNode" ) as Data.ScriptEditor.EntityNodeData;
         NewNode = serializer.LoadNamedObject( "NewNode" ) as Data.ScriptEditor.EntityNodeData;
      }

      public new void Save(ObjectSerializer serializer)
      {
         serializer.SaveBaseObject( this, typeof(PatchData) );

         if ( null != OldNode )
         {
            serializer.SaveNamedObject( "OldNode", OldNode );
         }
         
         if ( null != NewNode )
         {
            serializer.SaveNamedObject( "NewNode", NewNode );
         }
      }

      public override void Apply( ScriptEditor.ScriptEditor scriptEditor )
      {
         if ( null != NewNode )
         {
            scriptEditor.AddNode( scriptEditor.CreateEntityNode(NewNode) );
         }
         else
         {
            scriptEditor.RemoveNode( scriptEditor.CreateEntityNode(OldNode) );
         }
      }

      public override void Apply( ScriptEditor.ScriptEditorCtrl scriptEditorCtrl )
      {
         if ( null != NewNode )
         {
            scriptEditorCtrl.UpdateNodeDisplay( NewNode.Guid );
         }
         else
         {
            scriptEditorCtrl.RemoveNodeDisplay( OldNode.Guid );
         }
      }

      public override void Remove( ScriptEditor.ScriptEditor scriptEditor )
      {
         if ( null != OldNode )
         {
            scriptEditor.AddNode( scriptEditor.CreateEntityNode(OldNode) );
         }
         else
         {
            scriptEditor.RemoveNode( scriptEditor.CreateEntityNode(NewNode) );
         }
      }

      public override void Remove( ScriptEditor.ScriptEditorCtrl scriptEditorCtrl )
      {
         if ( null != OldNode )
         {
            scriptEditorCtrl.UpdateNodeDisplay( OldNode.Guid );
         }
         else
         {
            scriptEditorCtrl.RemoveNodeDisplay( NewNode.Guid );
         }
      }
   }

   public class Batch : PatchData
   {
      public bool HasPatches { get { return (null == Patches) ? false : (Patches.Count > 0); } }

      List<PatchData> Patches;

      public Batch( )
      {}

      public Batch(string name) : base(name)
      {
         Patches = new List<PatchData>( );
      }

      public void Add(PatchData patch)
      {
         Patches.Add( patch );
      }

      public new void Load(ObjectSerializer serializer)
      {
         serializer.LoadBaseObject( this, typeof(PatchData) );

         Patches = new List<PatchData>( );

         object []array = serializer.LoadNamedObjects( "Patches" );

         foreach ( object value in array )
         {
            Patches.Add( value as PatchData );
         }
      }

      public new void Save(ObjectSerializer serializer)
      {
         serializer.SaveBaseObject( this, typeof(PatchData) );

         serializer.SaveNamedObjects( "Patches", Patches.ToArray( ) );
      }

      public override void Apply( ScriptEditor.ScriptEditor scriptEditor )
      {
         foreach ( PatchData patch in Patches )
         {
            patch.Apply( scriptEditor );
         }
      }

      public override void Apply( ScriptEditor.ScriptEditorCtrl scriptEditorCtrl )
      {
         foreach ( PatchData patch in Patches )
         {
            patch.Apply( scriptEditorCtrl );
         }
      }

      public override void Remove( ScriptEditor.ScriptEditor scriptEditor )
      {
         //remove them in reverse order they were added
         //so it simulates each step a user makes
         //if a user did A, B, C we remove it as C, B, A
         for (int i = Patches.Count - 1; i >= 0; i-- )
         {
            Patches[i].Remove( scriptEditor );
         }
      }

      public override void Remove( ScriptEditor.ScriptEditorCtrl scriptEditorCtrl )
      {
         //remove them in reverse order they were added
         //so it simulates each step a user makes
         //if a user did A, B, C we remove it as C, B, A
         for (int i = Patches.Count - 1; i >= 0; i-- )
         {
            Patches[i].Remove( scriptEditorCtrl );
         }
      }
   }
}


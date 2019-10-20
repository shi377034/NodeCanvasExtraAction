#if UNITY_EDITOR

using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEditor;
using UnityEngine;


namespace NodeCanvas.Editor{

	[CustomEditor(typeof(Struct))]
	public class StructInspector : UnityEditor.Editor {

		private Struct bb
        {
			get {return (Struct)target;}
		}

		public override void OnInspectorGUI(){
            var Parent = (Struct)EditorGUILayout.ObjectField("Parent", bb.Parent, typeof(Struct), false);
            if(Parent != bb.Parent && Parent == bb)
            {
                Debug.LogError("The parent node cannot be itself");
            }
            if(Parent != bb)
            {
                bb.Parent = Parent;
            }    
            bb.IsStatic = EditorGUILayout.Toggle("Static", bb.IsStatic);
			BlackboardEditor.ShowVariables(bb, bb);
			EditorUtils.EndOfInspector();
			if (Application.isPlaying || Event.current.isMouse){
				Repaint();
			}
		}
	}
}

#endif
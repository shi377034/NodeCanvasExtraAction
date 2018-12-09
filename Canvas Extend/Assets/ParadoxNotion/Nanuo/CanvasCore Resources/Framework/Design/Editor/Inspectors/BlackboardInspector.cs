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
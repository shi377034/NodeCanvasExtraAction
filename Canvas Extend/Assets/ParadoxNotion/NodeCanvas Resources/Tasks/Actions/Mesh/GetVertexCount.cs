using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Mesh")]
	public class GetVertexCount : ActionTask<MeshFilter>{
        [BlackboardOnly]
        public BBParameter<int> storeCount;

        protected override void OnExecute(){
            storeCount.value = agent.mesh.vertexCount;
            EndAction();
		}
	}
}
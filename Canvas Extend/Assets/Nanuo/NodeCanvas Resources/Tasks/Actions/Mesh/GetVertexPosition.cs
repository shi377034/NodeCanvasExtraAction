using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Mesh")]
    public class GetVertexPosition : ActionTask<MeshFilter>
    {

        public BBParameter<int> vertexIndex;
        public BBParameter<Space> space;
        [BlackboardOnly]
        public BBParameter<Vector3> storePosition;
        protected override void OnExecute()
        {
            switch (space.value)
            {
                case Space.World:
                    var position = agent.mesh.vertices[vertexIndex.value];
                    storePosition.value = agent.transform.TransformPoint(position);
                    break;
                case Space.Self:
                    storePosition.value = agent.mesh.vertices[vertexIndex.value];
                    break;
            }
            EndAction();
        }
    }
}
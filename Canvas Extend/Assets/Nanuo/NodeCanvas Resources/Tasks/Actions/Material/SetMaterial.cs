using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Material")]
	public class SetMaterial : ActionTask<Renderer>{
        public BBParameter<int> materialIndex;
        public BBParameter<Material> material;

        protected override void OnExecute(){
            if (materialIndex.value == 0)
            {
                agent.material = material.value;
            }
            else if (agent.materials.Length > materialIndex.value)
            {
                var materials = agent.materials;
                materials[materialIndex.value] = material.value;
                agent.materials = materials;
            }
            EndAction();
		}
	}
}
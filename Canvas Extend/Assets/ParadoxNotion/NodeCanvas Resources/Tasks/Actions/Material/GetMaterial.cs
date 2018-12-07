using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Material")]
	public class GetMaterial : ActionTask<Renderer>{
        public BBParameter<int> materialIndex;
        public BBParameter<bool> getSharedMaterial;
        [BlackboardOnly]
        public BBParameter<Material> material;

        protected override void OnExecute(){
            if (materialIndex.value == 0 && !getSharedMaterial.value)
            {
                material.value = agent.material;
            }

            else if (materialIndex.value == 0 && getSharedMaterial.value)
            {
                material.value = agent.sharedMaterial;
            }

            else if (agent.materials.Length > materialIndex.value && !getSharedMaterial.value)
            {
                var materials = agent.materials;
                material.value = materials[materialIndex.value];
                agent.materials = materials;
            }

            else if (agent.materials.Length > materialIndex.value && getSharedMaterial.value)
            {
                var materials = agent.sharedMaterials;
                material.value = materials[materialIndex.value];
                agent.sharedMaterials = materials;
            }
            EndAction();
		}
	}
}
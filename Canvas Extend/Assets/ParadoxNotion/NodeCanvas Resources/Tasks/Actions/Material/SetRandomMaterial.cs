using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions{

	[Category("Material")]
	public class SetRandomMaterial : ActionTask<Renderer>{
        public BBParameter<int> materialIndex;
        public BBParameter<List<Material>> materials;

        protected override void OnExecute(){
            if (materials.value.Count == 0)
            {
                EndAction();
                return;
            }

            if (agent.material == null)
            {
                Debug.LogError("Missing Material!");
                EndAction(false);
                return;
            }

            if (materialIndex.value == 0)
            {
                agent.material = materials.value[Random.Range(0, materials.value.Count)];
            }
            else if (agent.materials.Length > materialIndex.value)
            {
                var newMaterials = agent.materials;
                newMaterials[materialIndex.value] = materials.value[Random.Range(0, materials.value.Count)];
                agent.materials = newMaterials;
            }
            EndAction();
		}
	}
}
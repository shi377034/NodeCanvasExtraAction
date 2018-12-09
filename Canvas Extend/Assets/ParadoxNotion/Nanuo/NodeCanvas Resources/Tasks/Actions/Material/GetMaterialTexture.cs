using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Material")]
	public class GetMaterialTexture : ActionTask<Renderer>{
        public BBParameter<int> materialIndex;
        public BBParameter<string> namedTexture = "_MainTex";
        public BBParameter<bool> getFromSharedMaterial;
        [BlackboardOnly]
        public BBParameter<Texture> storedTexture;
        protected override void OnExecute(){
            var namedTex = namedTexture.value;
            if (namedTex == "")
            {
                namedTex = "_MainTex";
            }

            if (materialIndex.value == 0 && !getFromSharedMaterial.value)
            {
                storedTexture.value = agent.material.GetTexture(namedTex);
            }

            else if (materialIndex.value == 0 && getFromSharedMaterial.value)
            {
                storedTexture.value = agent.sharedMaterial.GetTexture(namedTex);
            }

            else if (agent.materials.Length > materialIndex.value && !getFromSharedMaterial.value)
            {
                var materials = agent.materials;
                storedTexture.value = agent.materials[materialIndex.value].GetTexture(namedTex);
                agent.materials = materials;
            }

            else if (agent.materials.Length > materialIndex.value && getFromSharedMaterial.value)
            {
                var materials = agent.sharedMaterials;
                storedTexture.value = agent.sharedMaterials[materialIndex.value].GetTexture(namedTex);
                agent.materials = materials;
            }
            EndAction();
		}
	}
}
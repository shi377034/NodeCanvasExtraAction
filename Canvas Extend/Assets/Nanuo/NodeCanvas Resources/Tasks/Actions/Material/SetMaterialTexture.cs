using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{

	[Category("Material")]
	public class SetMaterialTexture : ActionTask<Renderer>{
        public BBParameter<int> materialIndex;
        public BBParameter<Material> material;
        [RequiredField]
        public BBParameter<string> namedTexture = "_MainTex";
        public BBParameter<Texture> texture;

        protected override void OnExecute(){
            var namedTex = namedTexture.value;
            if (namedTex == "") namedTex = "_MainTex";

            if (material.value != null)
            {
                material.value.SetTexture(namedTex, texture.value);
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
                agent.material.SetTexture(namedTex, texture.value);
            }
            else if (agent.materials.Length > materialIndex.value)
            {
                var materials = agent.materials;
                materials[materialIndex.value].SetTexture(namedTex, texture.value);
                agent.materials = materials;
            }
            EndAction();
		}
	}
}
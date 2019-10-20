using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{

	[Category("Material")]
	public class SetTextureOffset : ActionTask<Renderer>{
        public BBParameter<int> materialIndex;
        public BBParameter<string> namedTexture = "_MainTex";
        public BBParameter<float> offsetX;
        public BBParameter<float> offsetY;
        protected override void OnExecute(){
            if (agent.material == null)
            {
                Debug.LogError("Missing Material!");
                EndAction(false);
                return;
            }

            if (materialIndex.value == 0)
            {
                agent.material.SetTextureOffset(namedTexture.value, new Vector2(offsetX.value, offsetY.value));
            }
            else if (agent.materials.Length > materialIndex.value)
            {
                var materials = agent.materials;
                materials[materialIndex.value].SetTextureOffset(namedTexture.value, new Vector2(offsetX.value, offsetY.value));
                agent.materials = materials;
            }
            EndAction();
		}
	}
}
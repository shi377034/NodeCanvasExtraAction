using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
namespace NodeCanvas.Tasks.Actions{

	[Category("Material")]
	public class SetTextureScale : ActionTask<Renderer>{
        public BBParameter<int> materialIndex;
        public BBParameter<string> namedTexture = "_MainTex";
        public BBParameter<float> scaleX;
        public BBParameter<float> scaleY;
        protected override void OnExecute(){
            if (agent.material == null)
            {
                Debug.LogError("Missing Material!");
                EndAction(false);
                return;
            }

            if (materialIndex.value == 0)
            {
                agent.material.SetTextureScale(namedTexture.value, new Vector2(scaleX.value, scaleY.value));
            }
            else if (agent.materials.Length > materialIndex.value)
            {
                var materials = agent.materials;
                materials[materialIndex.value].SetTextureScale(namedTexture.value, new Vector2(scaleX.value, scaleY.value));
                agent.materials = materials;
            }
            EndAction();
		}
	}
}
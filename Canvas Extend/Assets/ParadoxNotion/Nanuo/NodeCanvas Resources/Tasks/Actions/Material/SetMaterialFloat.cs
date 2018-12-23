using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Material")]
	public class SetMaterialFloat : ActionTask<Renderer>{
        public BBParameter<int> materialIndex;
        public BBParameter<Material> material;
        [RequiredField]
        public BBParameter<string> namedFloat;
        public BBParameter<float> floatValue;

        protected override void OnExecute(){
            if (material.value != null)
            {
                material.value.SetFloat(namedFloat.value, floatValue.value);
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
                agent.material.SetFloat(namedFloat.value, floatValue.value);
            }
            else if (agent.materials.Length > materialIndex.value)
            {
                var materials = agent.materials;
                materials[materialIndex.value].SetFloat(namedFloat.value, floatValue.value);
                agent.materials = materials;
            }
            EndAction();
		}
	}
}
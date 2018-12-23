using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Material")]
	public class SetMaterialColor : ActionTask<Renderer>{
        public BBParameter<int> materialIndex;
        public BBParameter<Material> material;
        public BBParameter<string> namedColor = "_Color";
        public BBParameter<Color> color = Color.black;
        protected override void OnExecute(){
            var colorName = namedColor.value;
            if (colorName == "") colorName = "_Color";

            if (material.value != null)
            {
                material.value.SetColor(colorName, color.value);
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
                agent.material.SetColor(colorName, color.value);
            }
            else if (agent.materials.Length > materialIndex.value)
            {
                var materials = agent.materials;
                materials[materialIndex.value].SetColor(colorName, color.value);
                agent.materials = materials;
            }
            EndAction();
		}
	}
}
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NodeCanvas.Tasks.Conditions{

	[Category("Scene")]
	public class CheckSceneIsDirty : ConditionTask {
        [RequiredField]
        public BBParameter<Scene> scene;
        public BBParameter<bool> value;
        protected override string info{
			get{return string.Format("{0}.isDirty == {1} ", scene, value);}
		}

		protected override bool OnCheck(){
			return scene.value.isDirty == value.value;
		}       
    }
}
using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;
#if (UNITY_4_3 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2)
#define UNITY_PRE_5_3
#endif

#if !UNITY_PRE_5_3
using UnityEngine.SceneManagement;
#endif

namespace NodeCanvas.Tasks.Conditions{

	[Category("Level")]
	public class CheckActiveSceneChanged : ConditionTask{
        [BlackboardOnly]
        public BBParameter<Scene> scene0;
        [BlackboardOnly]
        public BBParameter<Scene> scene1;
        protected override string OnInit()
        {
            SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
            return null;
        }

        private void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
        {
            scene0.value = arg0;
            scene1.value = arg1;
            YieldReturn(true);
        }

        protected override bool OnCheck(){
			return false;					
		}
        protected override void OnDisable()
        {
            SceneManager.activeSceneChanged -= SceneManager_activeSceneChanged;
        }
    }
}
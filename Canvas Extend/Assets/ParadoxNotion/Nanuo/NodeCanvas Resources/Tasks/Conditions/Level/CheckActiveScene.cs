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
	public class CheckActiveScene : ConditionTask{
        [RequiredField]
        public BBParameter<string> levelName;

        protected override bool OnCheck(){
            return SceneManager.GetActiveScene().name == levelName.value;
		}
    }
}
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NodeCanvas.Tasks.Actions{
    [Category("Scene")]
    public class GetSceneCount : ActionTask
    {
        [BlackboardOnly]
        public BBParameter<int> sceneCount;
        protected override void OnExecute()
        {
            sceneCount.value = SceneManager.sceneCount;
            EndAction();
        }
    }
}
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NodeCanvas.Tasks.Actions{
    [Category("Scene")]
    public class GetSceneName : ActionTask
    {
        [RequiredField]
        public BBParameter<Scene> scene;
        [BlackboardOnly]
        public BBParameter<string> sceneName;
        protected override void OnExecute()
        {
            sceneName.value = scene.value.name;
            EndAction();
        }
    }
}
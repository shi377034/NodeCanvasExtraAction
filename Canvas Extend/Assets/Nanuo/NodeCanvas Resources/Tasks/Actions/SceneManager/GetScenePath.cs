using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NodeCanvas.Tasks.Actions{
    [Category("Scene")]
    public class GetScenePath : ActionTask
    {
        [RequiredField]
        public BBParameter<Scene> scene;
        [BlackboardOnly]
        public BBParameter<string> path;
        protected override void OnExecute()
        {
            path.value = scene.value.path;
            EndAction();
        }
    }
}
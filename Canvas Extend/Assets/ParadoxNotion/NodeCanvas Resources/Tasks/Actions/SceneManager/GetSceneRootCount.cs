using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NodeCanvas.Tasks.Actions{
    [Category("Scene")]
    public class GetSceneRootCount : ActionTask
    {
        [RequiredField]
        public BBParameter<Scene> scene;
        [BlackboardOnly]
        public BBParameter<int> rootCount;
        protected override void OnExecute()
        {
            rootCount.value = scene.value.rootCount;
            EndAction();
        }
    }
}
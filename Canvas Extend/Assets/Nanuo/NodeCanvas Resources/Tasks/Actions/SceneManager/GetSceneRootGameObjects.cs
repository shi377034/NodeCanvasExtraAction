using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NodeCanvas.Tasks.Actions{
    [Category("Scene")]
    public class GetSceneRootGameObjects : ActionTask
    {
        [RequiredField]
        public BBParameter<Scene> scene;
        [BlackboardOnly]
        public BBParameter<GameObject[]> rootGameObjects;
        protected override void OnExecute()
        {
            rootGameObjects.value = scene.value.GetRootGameObjects();
            EndAction();
        }
    }
}
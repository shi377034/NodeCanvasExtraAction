using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Actions{
    [Category("Scene")]
    public class GetSceneProperties : ActionTask
    {
        [RequiredField]
        public BBParameter<Scene> scene;
        [BlackboardOnly]
        public BBParameter<string> sceneName;
        [BlackboardOnly]
        public BBParameter<string> path;
        [BlackboardOnly]
        public BBParameter<int> buildIndex;
        [BlackboardOnly]
        public BBParameter<bool> isValid;
        [BlackboardOnly]
        public BBParameter<bool> isLoaded;
        [BlackboardOnly]
        public BBParameter<bool> isDirty;
        [BlackboardOnly]
        public BBParameter<int> rootCount;
        [BlackboardOnly]
        public BBParameter<GameObject[]> rootGameObjects;
        protected override void OnExecute()
        {
            sceneName.value = scene.value.name;
            path.value = scene.value.path;
            buildIndex.value = scene.value.buildIndex;
            isValid.value = scene.value.IsValid();
            isLoaded.value = scene.value.isLoaded;
            isDirty.value = scene.value.isDirty;
            rootCount.value = scene.value.rootCount;
            rootGameObjects.value = scene.value.GetRootGameObjects();
            EndAction();
        }
    }
}
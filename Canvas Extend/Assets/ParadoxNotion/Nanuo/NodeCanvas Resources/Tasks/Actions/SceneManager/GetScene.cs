using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NodeCanvas.Tasks.Actions{
    [Category("Scene")]
    public class GetScene : ActionTask
    {
        public enum SceneAllReferenceOptions { ActiveScene, SceneAtIndex, SceneByName, SceneByPath, SceneByGameObject };
        public SceneAllReferenceOptions sourceReference = SceneAllReferenceOptions.SceneByName;
        [ShowIf("sourceReference", (int)SceneAllReferenceOptions.SceneAtIndex)]
        public BBParameter<int> sourceAtIndex;
        [ShowIf("sourceReference", (int)SceneAllReferenceOptions.SceneByName)]
        public BBParameter<string> sourceByName;
        [ShowIf("sourceReference", (int)SceneAllReferenceOptions.SceneByPath)]
        public BBParameter<string> sourceByPath;
        [ShowIf("sourceReference", (int)SceneAllReferenceOptions.SceneByGameObject)]
        public BBParameter<GameObject> sourceByGameObject;
        [BlackboardOnly]
        public BBParameter<Scene> scene;
        protected override void OnExecute()
        {
            switch (sourceReference)
            {
                case SceneAllReferenceOptions.ActiveScene:
                    scene.value = SceneManager.GetActiveScene();
                    break;
                case SceneAllReferenceOptions.SceneAtIndex:
                    scene.value = SceneManager.GetSceneAt(sourceAtIndex.value);
                    break;
                case SceneAllReferenceOptions.SceneByName:
                    scene.value = SceneManager.GetSceneByName(sourceByName.value);
                    break;
                case SceneAllReferenceOptions.SceneByPath:
                    scene.value = SceneManager.GetSceneByPath(sourceByPath.value);
                    break;
                case SceneAllReferenceOptions.SceneByGameObject:
                    scene.value = sourceByGameObject.value.scene;
                    break;
            }
            EndAction();
        }
    }
}
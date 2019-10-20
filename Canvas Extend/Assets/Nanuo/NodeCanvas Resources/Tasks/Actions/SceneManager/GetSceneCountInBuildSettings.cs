using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NodeCanvas.Tasks.Actions{
    [Category("Scene")]
    public class GetSceneCountInBuildSettings : ActionTask
    {
        [BlackboardOnly]
        public BBParameter<int> sceneCountInBuildSettings;
        protected override void OnExecute()
        {
            sceneCountInBuildSettings.value = SceneManager.sceneCountInBuildSettings;
            EndAction();
        }
    }
}
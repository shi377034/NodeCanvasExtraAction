using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
#if (UNITY_4_3 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2)
#define UNITY_PRE_5_3
#endif

#if !UNITY_PRE_5_3
using UnityEngine.SceneManagement;
#endif

namespace NodeCanvas.Tasks.Actions{

	[Category("Level")]
	public class LoadLevel : ActionTask{
        [RequiredField]
        public BBParameter<string> levelName;
        public BBParameter<LoadSceneMode> mode;
        public BBParameter<bool> async;
        [Tooltip("Keep this GameObject in the new level. NOTE: The GameObject and components is disabled then enabled on load; uncheck Reset On Disable to keep the active state.")]
        public BBParameter<bool> dontDestroyOnLoad;
        public BBParameter<string> loadedEvent;
        public BBParameter<string> failedEvent;
        [BlackboardOnly]
        public BBParameter<float> progress;
        private AsyncOperation asyncOperation;
        protected override void OnExecute(){
            if (!Application.CanStreamedLevelBeLoaded(levelName.value))
            {
                this.SendEvent(failedEvent.value);
                EndAction();
                return;
            }
            if (dontDestroyOnLoad.value)
            {
                var root = agent.transform.root;
                Object.DontDestroyOnLoad(root.gameObject);
            }
            progress.value = 0;
            if (async.value)
            {
#if UNITY_PRE_5_3
                asyncOperation = LoadSceneAsync(levelName.value, mode.value);
#else
                asyncOperation = SceneManager.LoadSceneAsync(levelName.value, mode.value);
#endif
                Debug.Log(string.Format("LoadLevelAsyc{0}:{1} ", mode.value.ToString(), levelName.value));
            }
            else
            {
#if UNITY_PRE_5_3
                LoadScene(levelName.value, mode.value);
#else
                SceneManager.LoadScene(levelName.value, mode.value);
#endif

                Debug.Log(string.Format("LoadLevel{0}:{1} " , mode.value.ToString(), levelName.value));
                progress.value = 1f;
                this.SendEvent(loadedEvent.value);
                EndAction();
            }
		}
        protected override void OnUpdate()
        {
            if(asyncOperation == null)
            {
                EndAction();
                return;
            }
            progress.value = asyncOperation.progress;
            if (asyncOperation.isDone)
            {
                this.SendEvent(loadedEvent.value);
                EndAction();
            }
        }
#if UNITY_PRE_5_3
        private AsyncOperation LoadSceneAsync(string name, LoadSceneMode mode)
        {
            switch (mode)
            {
                case LoadSceneMode.Single:
                    return Application.LoadLevelAsync(name);
                case LoadSceneMode.Additive:
                    return Application.LoadLevelAdditiveAsync(name);
            }
            return null;
        }

        private void LoadScene(string name, LoadSceneMode mode)
        {

            switch(mode)
            {
                case LoadSceneMode.Single:
                    Application.LoadLevel(name);
                    break;
                case LoadSceneMode.Additive:
                    Application.LoadLevelAdditive(name);
                    break;
            }
        }
    }
#endif
    }
}
using DG.Tweening;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

    [Category("Tween")]
    [Icon("DOTTween", true)]
    public class TweenScale : ActionTask<Transform> {

        public BBParameter<Vector3> vector;
        public BBParameter<float> delay = 0f;
        public BBParameter<float> duration = 0.5f;
        public Ease easeType = Ease.Linear;
        public bool relative = false;
        public bool waitActionFinish = true;

        private string id;

        protected override string info{
            get {return string.Format("Tween {0} Scale {1} {2}", agentInfo, relative? "By":"To", vector);}
        }

        protected override void OnExecute() {

            if ( !relative && (agent.localScale == vector.value )){
                EndAction();
                return;
            }

            var tween = agent.DOScale(vector.value, duration.value);
            tween.SetDelay(delay.value);
            tween.SetEase(easeType);
            id = System.Guid.NewGuid().ToString();
            tween.SetId(id);
            if (relative)
                tween.SetRelative();

            if (!waitActionFinish) EndAction();
        }

        protected override void OnUpdate() {
            if (elapsedTime >= duration.value + delay.value)
                EndAction();
        }

        protected override void OnStop(){
            if (waitActionFinish){
                DG.Tweening.DOTween.Kill(id);
            }
        }
    }
}
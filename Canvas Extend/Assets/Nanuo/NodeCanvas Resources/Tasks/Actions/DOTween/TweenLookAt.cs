using DG.Tweening;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

    [Category("Tween")]
    [Icon("DOTTween", true)]
    public class TweenLookAt : ActionTask<Transform> {

        public BBParameter<Vector3> vector;
        public BBParameter<float> delay = 0f;
        public BBParameter<float> duration = 0.5f;
        public BBParameter<AxisConstraint> axisConstraint = AxisConstraint.None;
        public Ease easeType = Ease.Linear;
        public bool waitActionFinish = true;

        private string id;

        protected override string info{
            get {return string.Format("Tween {0} LookAt {1}", agentInfo, vector);}
        }

        protected override void OnExecute() {

            var tween = agent.DOLookAt(vector.value, duration.value, axisConstraint.value);
            tween.SetDelay(delay.value);
            tween.SetEase(easeType);
            id = System.Guid.NewGuid().ToString();
            tween.SetId(id);

            if (!waitActionFinish) EndAction();
        }

        protected override void OnUpdate() {
            if (elapsedTime >= duration.value + delay.value){
                EndAction();
            }
        }

        protected override void OnStop(){
            if (waitActionFinish){
                DG.Tweening.DOTween.Kill(id);
            }
        }
    }
}
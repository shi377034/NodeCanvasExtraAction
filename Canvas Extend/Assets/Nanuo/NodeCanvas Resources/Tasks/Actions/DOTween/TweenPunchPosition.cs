using DG.Tweening;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

    [Category("Tween")]
    [Icon("DOTTween", true)]
    public class TweenPunchPosition : ActionTask<Transform> {

        public BBParameter<Vector3> ammount;
        public BBParameter<float> delay = 0f;
        public BBParameter<float> duration = 0.5f;
        public Ease easeType = Ease.Linear;
        public int vibrato = 10;
        public float elasticity = 1f;
        public bool useSnapping = false;
        public bool waitActionFinish = true;

        private string id;

        protected override string info{
            get {return string.Format("Punch {0} Position By {1}", agentInfo, ammount);}
        }

        protected override void OnExecute() {

            var tween = agent.DOPunchPosition(ammount.value, duration.value, vibrato, elasticity, useSnapping);
            tween.SetDelay(delay.value);
            tween.SetEase(easeType);
            id = System.Guid.NewGuid().ToString();
            tween.SetId(id);

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
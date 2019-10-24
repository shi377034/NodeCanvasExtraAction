using DG.Tweening;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{

    [Category("Tween")]
    [Icon("DOTTween", true)]
    public class TweenColor : ActionTask<Renderer> {

        public BBParameter<Color>   color;
        public BBParameter<float>   delay = 0f;
        public BBParameter<float>   duration = 0.5f;
        public Ease                 easeType = Ease.Linear;
        public bool                 waitActionFinish = true;
        
        private string id;

    	protected override void OnExecute() {
            var tween = agent.material.DOColor(color.value, duration.value);
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

    [Category("Tween")]
    [Icon("DOTTween", true)]
    public class TweenSpriteColor : ActionTask<SpriteRenderer>
    {

        public BBParameter<Color> color;
        public BBParameter<float> delay = 0f;
        public BBParameter<float> duration = 0.5f;
        public Ease easeType = Ease.Linear;
        public bool waitActionFinish = true;

        private string id;

        protected override void OnExecute()
        {
            
            var tween = agent.DOColor(color.value, duration.value);
            tween.SetDelay(delay.value);
            tween.SetEase(easeType);
            id = System.Guid.NewGuid().ToString();
            tween.SetId(id);

            if (!waitActionFinish) EndAction();
        }

        protected override void OnUpdate()
        {
            if (elapsedTime >= duration.value + delay.value)
            {
                EndAction();
            }
        }

        protected override void OnStop()
        {
            if (waitActionFinish)
            {
                DG.Tweening.DOTween.Kill(id);
            }
        }

    }

    [Category("Tween")]
    [Icon("DOTTween", true)]
    public class TweenColorVariable : ActionTask
    {

        public BBParameter<Color> colorVariable;
        public BBParameter<Color> toColor;
        public BBParameter<float> delay = 0f;
        public BBParameter<float> duration = 0.5f;
        public Ease easeType = Ease.Linear;
        public bool waitActionFinish = true;

        private string id;

        protected override void OnExecute()
        {
            var tween = DOTween.To(() => colorVariable.value,x=> colorVariable.value=x, toColor.value, duration.value);
            //var tween = colorVariable.value.(toColor.value, duration.value);
            tween.SetDelay(delay.value);
            tween.SetEase(easeType);
            id = System.Guid.NewGuid().ToString();
            tween.SetId(id);

            if (!waitActionFinish) EndAction();
        }

        protected override void OnUpdate()
        {
            if (elapsedTime >= duration.value + delay.value)
            {
                EndAction();
            }
        }

        protected override void OnStop()
        {
            if (waitActionFinish)
            {
                DG.Tweening.DOTween.Kill(id);
            }
        }

    }
}



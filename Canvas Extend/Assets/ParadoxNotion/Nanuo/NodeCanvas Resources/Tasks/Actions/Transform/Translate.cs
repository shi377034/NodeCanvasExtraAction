using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Transform")]
    public class Translate : ActionTask<Transform>
    {
        public BBParameter<Vector3> vector;
        public Space space = Space.Self;
        public BBParameter<bool> perSecond;
        protected override string info {
            get
            {
                return string.Format("Translate({0},{1}) {2}", vector, space, (perSecond.value ? " Per Second" : ""));
            }
        }
        protected override void OnExecute()
        {
            DoTranslate();
            EndAction();
        }
        void DoTranslate()
        {
            // init

            var go = agent.gameObject;

            // Use vector if specified

            var translate = vector.value;

            // apply

            if (!perSecond.value)
            {
                go.transform.Translate(translate, space);
            }
            else
            {
                go.transform.Translate(translate * Time.deltaTime, space);
            }
        }
    }
}
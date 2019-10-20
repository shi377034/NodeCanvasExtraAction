using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("MatchTarget")]
    [Category("Animator")]
    public class AnimatorMatchTarget : ActionTask<Animator>
    {
        public BBParameter<AvatarTarget> bodyPart;
        public BBParameter<GameObject> target;
        public BBParameter<Vector3> targetPosition;
        public BBParameter<Quaternion> targetRotation;
        public BBParameter<Vector3> positionWeight;
        public BBParameter<float> rotationWeight;
        [Tooltip("Start time within the animation clip (0 - beginning of clip, 1 - end of clip)")]
        public BBParameter<float> startNormalizedTime;
        [Tooltip("End time within the animation clip (0 - beginning of clip, 1 - end of clip), values greater than 1 can be set to trigger a match after a certain number of loops. Ex: 2.3 means at 30% of 2nd loop")]
        public BBParameter<float> targetNormalizedTime;
        [Tooltip("Should always be true")]
        public BBParameter<bool> everyFrame;
        private Transform _transform;
        protected override void OnExecute()
        {
            if (target.value != null)
            {
                _transform = target.value.transform;
            }
            DoMatchTarget();
            if (!everyFrame.value)
            {
                EndAction();
            }
        }
        protected override void OnUpdate()
        {
            DoMatchTarget();
            if (!everyFrame.value)
            {
                EndAction();
            }
        }
        void DoMatchTarget()
        {
            Vector3 _pos = Vector3.zero;
            Quaternion _rot = Quaternion.identity;

            if (_transform != null)
            {
                _pos = _transform.position;
                _rot = _transform.rotation;
            }
            _pos += targetPosition.value;
            _rot *= targetRotation.value;

            MatchTargetWeightMask _weightMask = new MatchTargetWeightMask(positionWeight.value, rotationWeight.value);
            agent.MatchTarget(_pos, _rot, bodyPart.value, _weightMask, startNormalizedTime.value, targetNormalizedTime.value);
        }
    }
}
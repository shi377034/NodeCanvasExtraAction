using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("GetBoneTransform")]
    [Category("Animator")]
    public class GetAnimatorBoneGameObject : ActionTask<Animator>
    {
        public BBParameter<HumanBodyBones> bone;
        [BlackboardOnly]
        public BBParameter<GameObject> boneGameObject;
        protected override string info {
            get
            {
                return boneGameObject + " = " + bone;
            }
        }
        protected override void OnExecute()
        {
            boneGameObject.value = agent.GetBoneTransform(bone.value).gameObject;
            EndAction();
        }
    }
}
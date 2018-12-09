using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{
    [Name("GetLayerWeight")]
    [Category("Animator")]
    public class GetAnimatorLayerWeight : ActionTask<Animator>
    {
        public BBParameter<int> layerIndex;
        [BlackboardOnly]
        public BBParameter<float> layerWeight;
        protected override string info {
            get
            {
                return string.Format("{1} = GetLayerWeight({1})", layerWeight, layerIndex);
            }
        }
        protected override void OnExecute()
        {
            layerWeight.value = agent.GetLayerWeight(layerIndex.value);
            EndAction();
        }
    }
}
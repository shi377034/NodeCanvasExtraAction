using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
namespace NodeCanvas.Tasks.Actions{
    [Category("String")]
    [Description("Select a Random String from an array of Strings.")]
    public class SelectRandomString : ActionTask
    {
        public BBParameter<string[]> strings;
        [SliderField(0,1f)]
        public BBParameter<float[]> weights;
        [BlackboardOnly]
        public BBParameter<string> storeResult;
        private string result;
        protected override void OnExecute()
        {
            DoSelectRandomString();
            EndAction();
        }
        void DoSelectRandomString()
        {
            int randomIndex = weights.value.RandomWeightedIndex();

            if (randomIndex != -1)
            {
                storeResult.value = strings.value[randomIndex];
            }
        }
    }
}
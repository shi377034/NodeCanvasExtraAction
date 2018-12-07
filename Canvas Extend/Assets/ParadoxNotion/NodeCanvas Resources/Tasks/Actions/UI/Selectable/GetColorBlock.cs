using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get Colors")]
    [Category("UI/Selectable")]
    public class GetColorBlock : ActionTask<Selectable>
    {
        [BlackboardOnly]
        public BBParameter<float> fadeDuration;
        [BlackboardOnly]
        public BBParameter<float> colorMultiplier;
        [BlackboardOnly]
        public BBParameter<Color> normalColor;
        [BlackboardOnly]
        public BBParameter<Color> pressedColor;
        [BlackboardOnly]
        public BBParameter<Color> highlightedColor;
        [BlackboardOnly]
        public BBParameter<Color> disabledColor;

        private Selectable selectable;
        protected override void OnExecute()
        {
            selectable = agent;
            DoGetValue();
            EndAction();
        }
        private void DoGetValue()
        {
            colorMultiplier.value = selectable.colors.colorMultiplier;
            fadeDuration.value = selectable.colors.fadeDuration;
            normalColor.value = selectable.colors.normalColor;
            pressedColor.value = selectable.colors.pressedColor;
            highlightedColor.value = selectable.colors.highlightedColor;
            disabledColor.value = selectable.colors.disabledColor;
        }

    }
}
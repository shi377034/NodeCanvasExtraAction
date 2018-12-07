using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Colors")]
    [Category("UI/Selectable")]
    public class SetColorBlock : ActionTask<Selectable>
    {
        public BBParameter<float> fadeDuration;
        public BBParameter<float> colorMultiplier;
        public BBParameter<Color> normalColor;
        public BBParameter<Color> pressedColor;
        public BBParameter<Color> highlightedColor;
        public BBParameter<Color> disabledColor;

        protected override void OnExecute()
        {
            var colors = agent.colors;
            colors.colorMultiplier = colorMultiplier.value;
            colors.fadeDuration = fadeDuration.value;
            colors.normalColor = normalColor.value;
            colors.pressedColor = pressedColor.value;
            colors.highlightedColor = highlightedColor.value;
            colors.disabledColor = disabledColor.value;
            agent.colors = colors;
            EndAction();
        }
    }
}
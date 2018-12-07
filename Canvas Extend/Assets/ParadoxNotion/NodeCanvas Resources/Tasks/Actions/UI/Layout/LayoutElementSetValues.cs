using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Values")]
    [Category("UI/LayoutElement")]
    public class LayoutElementSetValues : ActionTask<UnityEngine.UI.LayoutElement>
    {
        public BBParameter<bool> ignoreLayout;
        public BBParameter<float> minWidth;
        public BBParameter<float> minHeight;
        public BBParameter<float> preferredWidth;
        public BBParameter<float> preferredHeight;
        public BBParameter<float> flexibleWidth;
        public BBParameter<float> flexibleHeight;
        private UnityEngine.UI.LayoutElement layoutElement;
        protected override void OnExecute()
        {
            layoutElement = agent;
            DoSetValues();
            EndAction();
        }
        private void DoSetValues()
        {
            layoutElement.ignoreLayout = ignoreLayout.value;
            layoutElement.minWidth = minWidth.value;
            layoutElement.minHeight = minHeight.value;
            layoutElement.preferredWidth = preferredWidth.value;
            layoutElement.preferredHeight = preferredHeight.value;
            layoutElement.flexibleWidth = flexibleWidth.value;
            layoutElement.flexibleHeight = flexibleHeight.value;
        }
    }
}
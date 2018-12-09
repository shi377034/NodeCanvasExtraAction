using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get Values")]
    [Category("UI/LayoutElement")]
    public class LayoutElementGetValues : ActionTask<UnityEngine.UI.LayoutElement>
    {
        [BlackboardOnly]
        public BBParameter<bool> ignoreLayout;
        [BlackboardOnly]
        public BBParameter<bool> minWidthEnabled;
        [BlackboardOnly]
        public BBParameter<float> minWidth;
        [BlackboardOnly]
        public BBParameter<bool> minHeightEnabled;
        [BlackboardOnly]
        public BBParameter<float> minHeight;
        [BlackboardOnly]
        public BBParameter<bool> preferredWidthEnabled;
        [BlackboardOnly]
        public BBParameter<float> preferredWidth;
        [BlackboardOnly]
        public BBParameter<bool> preferredHeightEnabled;
        [BlackboardOnly]
        public BBParameter<float> preferredHeight;
        [BlackboardOnly]
        public BBParameter<bool> flexibleWidthEnabled;
        [BlackboardOnly]
        public BBParameter<float> flexibleWidth;
        [BlackboardOnly]
        public BBParameter<bool> flexibleHeightEnabled;
        [BlackboardOnly]
        public BBParameter<float> flexibleHeight;
        private UnityEngine.UI.LayoutElement layoutElement;
        protected override void OnExecute()
        {
            layoutElement = agent;
            DoGetValues();
            EndAction();
        }
        private void DoGetValues()
        {
            ignoreLayout.value = layoutElement.ignoreLayout;
            minWidthEnabled.value = layoutElement.minWidth != 0;
            minWidth.value = layoutElement.minWidth;
            minHeightEnabled.value = layoutElement.minHeight != 0;
            minHeight.value = layoutElement.minHeight;
            preferredWidthEnabled.value = layoutElement.preferredWidth != 0;
            preferredWidth.value = layoutElement.preferredWidth;
            preferredHeightEnabled.value = layoutElement.preferredHeight != 0;
            preferredHeight.value = layoutElement.preferredHeight;
            flexibleWidthEnabled.value = layoutElement.flexibleWidth != 0;
            flexibleWidth.value = layoutElement.flexibleWidth;
            flexibleHeightEnabled.value = layoutElement.flexibleHeight != 0;
            flexibleHeight.value = layoutElement.flexibleHeight;
        }
    }
}
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get Navigation Mode")]
    [Category("UI/Selectable")]
    public class NavigationGetMode : ActionTask<Selectable>
    {
        [BlackboardOnly]
        public BBParameter<Navigation.Mode> navigationMode;
        protected override void OnExecute()
        {
            navigationMode.value = agent.navigation.mode;
            EndAction();
        }
    }
}
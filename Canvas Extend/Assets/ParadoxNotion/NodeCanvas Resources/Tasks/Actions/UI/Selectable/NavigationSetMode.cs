using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set Navigation Mode")]
    [Category("UI/Selectable")]
    public class NavigationSetMode : ActionTask<Selectable>
    {
        public BBParameter<Navigation.Mode> navigationMode;
        protected override void OnExecute()
        {
            var navigation = agent.navigation;
            navigation.mode = navigationMode.value;
            agent.navigation = navigation;
            EndAction();
        }
    }
}
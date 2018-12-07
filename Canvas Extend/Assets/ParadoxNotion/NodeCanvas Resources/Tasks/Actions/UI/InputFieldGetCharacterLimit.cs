using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Get CharacterLimit")]
    [Category("UI/InputField")]
    public class InputFieldGetCharacterLimit : ActionTask<InputField>
    {
        [BlackboardOnly]
        public BBParameter<int> characterLimit;
        protected override void OnExecute()
        {
            characterLimit.value = agent.characterLimit;
            EndAction();
        }
    }
}
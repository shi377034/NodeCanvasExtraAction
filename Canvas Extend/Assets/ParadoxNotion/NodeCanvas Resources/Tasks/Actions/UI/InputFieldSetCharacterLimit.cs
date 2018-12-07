using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set CharacterLimit")]
    [Category("UI/InputField")]
    public class InputFieldSetCharacterLimit : ActionTask<InputField>
    {
        public BBParameter<int> characterLimit;
        protected override void OnExecute()
        {
            agent.characterLimit = characterLimit.value;
            EndAction();
        }
    }
}
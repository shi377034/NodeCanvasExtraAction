using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Set AsterixChar")]
    [Category("UI/InputField")]
    public class InputFieldSetAsterixChar : ActionTask<InputField>
    {
        public BBParameter<string> asterixChar = "*";
        private static char __char__ = ' ';
        protected override void OnExecute()
        {
            var _char = __char__;

            if (asterixChar.value.Length > 0)
            {
                _char = asterixChar.value[0];
            }
            agent.asteriskChar = _char;
            EndAction();
        }
    }
}
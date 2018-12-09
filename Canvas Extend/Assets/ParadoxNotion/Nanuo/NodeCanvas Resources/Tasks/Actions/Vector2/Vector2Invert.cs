using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Invert")]
    [Category("Vector2")]
    public class Vector2Invert : ActionTask
    {
        public BBParameter<Vector2> vector;
        protected override void OnExecute()
        {
            vector.value *= -1;
            EndAction();
        }
    }
}
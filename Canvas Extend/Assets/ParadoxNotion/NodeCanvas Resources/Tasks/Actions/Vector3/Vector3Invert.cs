using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions
{
    [Name("Invert")]
    [Category("Vector3")]
    public class Vector3Invert : ActionTask
    {
        public BBParameter<Vector3> vector;
        protected override void OnExecute()
        {
            vector.value *= -1;
            EndAction();
        }
    }
}
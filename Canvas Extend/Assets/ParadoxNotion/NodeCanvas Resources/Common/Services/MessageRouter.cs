using UnityEngine;
using System.Collections;
namespace ParadoxNotion.Services
{

    public partial class MessageRouter:MonoBehaviour
    {
        private void Update()
        {
            Dispatch("OnUpdate");
        }
        private void LateUpdate()
        {
            Dispatch("OnLateUpdate");
        }
        private void FixedUpdate()
        {
            Dispatch("OnFixedUpdate");
        }        
    }
}

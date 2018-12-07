using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    [Category("Transform")]
    public class SmoothFollow : ActionTask<Transform>
    {
        [RequiredField]
        public BBParameter<GameObject> targetObject;
        public BBParameter<float> distance = 10f;
        public BBParameter<float> height = 5f;
        public BBParameter<float> heightDamping = 2f;
        public BBParameter<float> rotationDamping = 3f;

        private GameObject cachedObject;
        private Transform myTransform;

        private GameObject cachedTarget;
        private Transform targetTransform;
        protected override void OnExecute()
        {
            var go = agent.gameObject;

            if (cachedObject != go)
            {
                cachedObject = go;
                myTransform = go.transform;
            }

            if (cachedTarget != targetObject.value)
            {
                cachedTarget = targetObject.value;
                targetTransform = cachedTarget.transform;
            }


            // Calculate the current rotation angles
            var wantedRotationAngle = targetTransform.eulerAngles.y;
            var wantedHeight = targetTransform.position.y + height.value;

            var currentRotationAngle = myTransform.eulerAngles.y;
            var currentHeight = myTransform.position.y;

            // Damp the rotation around the y-axis
            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping.value * Time.deltaTime);

            // Damp the height
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping.value * Time.deltaTime);

            // Convert the angle into a rotation
            var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

            // Set the position of the camera on the x-z plane to:
            // distance meters behind the target
            myTransform.position = targetTransform.position;
            myTransform.position -= currentRotation * Vector3.forward * distance.value;

            // Set the height of the camera
            myTransform.position = new Vector3(myTransform.position.x, currentHeight, myTransform.position.z);

            // Always look at the target
            myTransform.LookAt(targetTransform);
            EndAction();
        }
    }
}
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Input")]
	public class TransformInputToWorldSpace : ActionTask {
        public enum AxisPlane
        {
            XZ,
            XY,
            YZ
        }
        public BBParameter<float> horizontalInput;
        public BBParameter<float> verticalInput;

        public BBParameter<float> multiplier = 1;
        public AxisPlane mapToPlane = AxisPlane.XZ;
        public BBParameter<Transform> relative;
        [BlackboardOnly]
		public BBParameter<Vector3> saveAs;
		[BlackboardOnly]
		public BBParameter<float> saveXAs;
		[BlackboardOnly]
		public BBParameter<float> saveYAs;
		[BlackboardOnly]
		public BBParameter<float> saveZAs;
        [BlackboardOnly]
        public BBParameter<float> storeMagnitude;

        public bool repeat;

		protected override void OnExecute(){ Do(); }
		protected override void OnUpdate(){ Do(); }

		void Do(){
            var forward = new Vector3();
            var right = new Vector3();

            if (relative.value != null)
            {
                switch (mapToPlane)
                {
                    case AxisPlane.XZ:
                        forward = Vector3.forward;
                        right = Vector3.right;
                        break;

                    case AxisPlane.XY:
                        forward = Vector3.up;
                        right = Vector3.right;
                        break;

                    case AxisPlane.YZ:
                        forward = Vector3.up;
                        right = Vector3.forward;
                        break;
                }
            }
            else
            {
                var transform = relative.value.transform;
                switch (mapToPlane)
                {
                    case AxisPlane.XZ:
                        forward = transform.TransformDirection(Vector3.forward);
                        forward.y = 0;
                        forward = forward.normalized;
                        right = new Vector3(forward.z, 0, -forward.x);
                        break;

                    case AxisPlane.XY:
                    case AxisPlane.YZ:
                        // NOTE: in relative mode XY ans YZ are the same!
                        forward = Vector3.up;
                        forward.z = 0;
                        forward = forward.normalized;
                        right = transform.TransformDirection(Vector3.right);
                        break;
                }
            }
            var h = horizontalInput.value;
            var v = verticalInput.value;

            // calculate resulting direction vector

            var direction = h * right + v * forward;
            direction *= multiplier.value;

            saveAs.value = direction;

            saveXAs.value = saveAs.value.x;
            saveYAs.value = saveAs.value.y;
            saveZAs.value = saveAs.value.z;
            storeMagnitude.value = saveAs.value.magnitude;

            if (!repeat)
				EndAction();
		}
	}
}
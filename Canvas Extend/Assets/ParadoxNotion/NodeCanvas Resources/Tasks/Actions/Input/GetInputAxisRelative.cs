using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions{

	[Category("Input")]
	public class GetInputAxisRelative : ActionTask {
        public BBParameter<Transform> relative;
        public BBParameter<string> xAxisName = "Horizontal" ;
		public BBParameter<string> yAxisName;
		public BBParameter<string> zAxisName = "Vertical";
		public BBParameter<float> multiplier = 1;
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
        private Quaternion rotation = Quaternion.identity;
		protected override void OnExecute(){ Do(); }
		protected override void OnUpdate(){ Do(); }

		void Do(){
            if(relative.value != null)
            {
                rotation = relative.value.rotation;
            }else
            {
                rotation = Quaternion.identity;
            }
			var x = string.IsNullOrEmpty(xAxisName.value)? 0 : Input.GetAxis(xAxisName.value);
			var y = string.IsNullOrEmpty(yAxisName.value)? 0 : Input.GetAxis(yAxisName.value);
			var z = string.IsNullOrEmpty(zAxisName.value)? 0 : Input.GetAxis(zAxisName.value);

            saveAs.value = rotation * new Vector3(x, y, z) *  multiplier.value;
            saveXAs.value = saveAs.value.x;
			saveYAs.value = saveAs.value.y;
            saveZAs.value = saveAs.value.z;
            storeMagnitude.value = saveAs.value.magnitude;
            if (!repeat)
				EndAction();
		}
	}
}
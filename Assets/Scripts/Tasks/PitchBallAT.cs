using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class PitchBallAT : ActionTask {

		public BBParameter<GameObject> baseballPrefab;
		public BBParameter<GameObject> batterGO;

		public float pitchSpeed;
		public enum destinations {forward, toBatter};
		public destinations destination;

		private Vector3 pitchDirection;

		protected override string OnInit() {
			if(destination == destinations.forward)
			{
				pitchDirection = Vector3.left;
			}
			else if (destination == destinations.toBatter)
			{
				pitchDirection = (batterGO.value.transform.position - agent.transform.position).normalized;
			}
			return null;
		}

		protected override void OnExecute() {
			GameObject baseballGO = GameObject.Instantiate(baseballPrefab.value, agent.transform.position, Quaternion.identity);
			baseballGO.GetComponent<Rigidbody2D>().velocity = pitchDirection * pitchSpeed;
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}
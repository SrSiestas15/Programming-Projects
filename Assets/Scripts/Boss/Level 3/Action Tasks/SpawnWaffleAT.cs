using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class SpawnWaffleAT : ActionTask {

        public BBParameter<float> attackLevel;
        
		public GameObject waffle;
		public Transform waffleSpawnLeft;
		public Transform waffleSpawnRight;
		public  Transform waffleSpawnMiddle;

		private SpiffyController spiffyScript;

		private float waffleSpeed;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			spiffyScript = agent.GetComponent<SpiffyController>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			if(attackLevel.value == 1 || attackLevel.value == 3)
			{
				spiffyScript.SpawnWaffles(waffle, attackLevel.value, waffleSpawnMiddle);
			}
			else if (attackLevel.value == 2)
			{
				spiffyScript.SpawnWaffles(waffle, attackLevel.value - 1, waffleSpawnLeft);
				spiffyScript.SpawnWaffles(waffle, attackLevel.value - 1, waffleSpawnRight);
			} 

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
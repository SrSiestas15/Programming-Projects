using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class TurnAroundAT : ActionTask {

		public enum possibleGoals { front, back }
		public possibleGoals goal;

		public static Vector3 newAngle;

		public BBParameter<float> turnSpeed;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			newAngle.y += Time.deltaTime * turnSpeed.value;
			agent.transform.eulerAngles = newAngle;

			if(goal == possibleGoals.front)
			{
				if(agent.transform.eulerAngles.y < 2) EndAction(true);
			}

            if (goal == possibleGoals.back)
            {
                if (agent.transform.eulerAngles.y > 179) EndAction(true);
            }

        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}
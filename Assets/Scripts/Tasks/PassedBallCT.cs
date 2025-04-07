using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class PassedBallCT : ConditionTask {

		BatterController batterScript;
		public BBParameter<GameObject> baseballGO;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			batterScript = agent.GetComponent<BatterController>();
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			if (batterScript.pitchedTo)
			{
				baseballGO.value = batterScript.baseballGO;
				batterScript.pitchedTo = false;
                return true;
			}
			else return false;
		}
	}
}
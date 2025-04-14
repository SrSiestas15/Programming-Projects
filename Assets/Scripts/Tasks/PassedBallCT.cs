using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class PassedBallCT : ConditionTask {

		BatterController batterScript;
		public BBParameter<GameObject> baseballGO;

		protected override string OnInit(){
			batterScript = agent.GetComponent<BatterController>();
			return null;
		}

		protected override bool OnCheck() {
			if (batterScript.pitchedTo)
			{
				baseballGO.value = batterScript.baseballGO; //sets the blackboard gameObject to be the same as the one in the BatterController.cs
				batterScript.pitchedTo = false;
                return true;
			}
			else return false;
		}
	}
}
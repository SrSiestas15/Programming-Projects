using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class WaitForBatterAT : ActionTask
	{
		//used to tell Batter to stop moving

		public BBParameter<GameObject> batterGO;
		private Blackboard batterBlackboard;

		protected override string OnInit()
		{
			batterBlackboard = batterGO.value.GetComponent<Blackboard>();
			return null;
		}

		protected override void OnExecute()
		{
			batterBlackboard.SetVariableValue("Blackboard Ready", true);
			EndAction(true);
		}
	}
}
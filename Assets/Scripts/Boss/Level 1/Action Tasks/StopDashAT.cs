using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Actions {

	public class StopDashAT : ActionTask {

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
            BossFish fishScript = agent.GetComponent<BossFish>();
			fishScript.dashEels = false;
            EndAction(true);
		}
	}
}
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class StunnedAT : ActionTask {

		BossFish fishScript;
		float stunTimer;
		public float stunTime;


		protected override string OnInit() {
			fishScript = agent.gameObject.GetComponent<BossFish>();
			return null;
		}

		protected override void OnExecute() {
			
		}

		protected override void OnUpdate() {
			if (fishScript.isStunned)
			{
				stunTimer += Time.deltaTime;
				if (stunTimer >= stunTime)
				{
					fishScript.isStunned = false;
					stunTimer = 0;
					EndAction(true);
				}
			}
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ShootEelAT : ActionTask {
		BossFish fishScript;

        protected override string OnInit() {
			
			fishScript = agent.GetComponent<BossFish>();
			return null;
		}

		protected override void OnExecute() {
			fishScript.dashEels = true;
			EndAction(true);
        }

		protected override void OnUpdate() {
		}
	}
}
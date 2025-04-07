using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class GettingShotAt : ConditionTask {

		TakeDamage bossTakeDamageScript;
		public float timeTillDash;
		float beforeDashTimer = 0f;

		protected override string OnInit(){
			bossTakeDamageScript = agent.GetComponent<TakeDamage>();
			return null;
		}

		protected override void OnEnable() {
            beforeDashTimer = 0f;
        }

		protected override bool OnCheck() {
			if (bossTakeDamageScript.isTakingDamage)
			{
				beforeDashTimer += Time.deltaTime;
				if (beforeDashTimer >= timeTillDash)
				{
					//DASH
					Debug.Log("DASH");
                    beforeDashTimer = 0f;
                    return true;
				} else
				{
					return false;
				}
			} else
			{
				return false;
			}

		}
	}
}
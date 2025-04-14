using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class MoveToPlayerAT : ActionTask {

		Vector3 startPos;
		Vector3 endPos;

		public AnimationCurve animationCurve;
		public float duration;
		float lerpTimer;

		public BBParameter<bool> blackboardReady;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
			if (PlayerMoveAndShoot.playerTransform != null) //as long as a player ship currently exists
			{
				//setting variables for the lerp curve
				startPos = agent.transform.position;
				endPos = PlayerMoveAndShoot.playerTransform.position;

				lerpTimer = 0;
			}
			else EndAction(false);

		}

		protected override void OnUpdate() {
			if(lerpTimer < duration)
			{
				lerpTimer += Time.deltaTime;
				float t = lerpTimer / duration;
				float curveValue = animationCurve.Evaluate(t);

				agent.transform.position = Vector3.Lerp(startPos, endPos, curveValue);
			} else EndAction(true); //once the batter rwaches its destination
		}
	}
}
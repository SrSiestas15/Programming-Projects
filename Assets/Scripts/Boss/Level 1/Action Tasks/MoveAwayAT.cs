using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class MoveAwayAT : ActionTask {
		BossFish fishScript;

        public AnimationCurve dashCurve;
        private float lerpTimer;

        public Transform dashTarget1;
        public Transform dashTarget2;

        Vector3 toEnd;

        Transform transformPosition;
        Transform endPosition;

        protected override string OnInit() {
            fishScript = agent.GetComponent<BossFish>();
            return null;
		}

		protected override void OnExecute() {
            transformPosition = agent.transform;
            lerpTimer = 0;
		}

		protected override void OnUpdate() {

            Debug.Log("toEnd: " + toEnd);
            Debug.Log("lerp timer: " + lerpTimer);
            Debug.Log("end position: " + endPosition);


            if (fishScript.shotDirection == "below")
			{
                endPosition = dashTarget1;

                //agent.gameObject.transform.position += Vector3.up * 3;
			}
            if (fishScript.shotDirection == "above")
            {
                endPosition = dashTarget2;

                //agent.gameObject.transform.position += Vector3.down * 3;
            }

            toEnd = endPosition.position - transformPosition.position;

            agent.gameObject.transform.position = Vector3.Lerp(transformPosition.position, endPosition.position, dashCurve.Evaluate(lerpTimer));
            lerpTimer += Time.deltaTime * 3;

            if (toEnd.magnitude < .5f)
            {
                EndAction(true);
            }
        }
	}
}
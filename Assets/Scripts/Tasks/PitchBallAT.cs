using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class PitchBallAT : ActionTask {

		//controls the pitcher's ball throw

		public BBParameter<GameObject> baseballPrefab;
		public BBParameter<GameObject> batterGO;
		public BBParameter<int> timesUntilAttack;

		public float pitchSpeed;
		public enum destinations {forward, toBatter}; //decide the kind of throw: set through the inspector
		public destinations destination;

		private Vector3 pitchDirection;

		protected override string OnInit() {
			if(destination == destinations.forward) 
			{
				pitchDirection = Vector3.left; //sets the pitch direction to the left
            }
			
			return null;
		}

		protected override void OnExecute() {
            if (destination == destinations.toBatter)
            {
                pitchDirection = (batterGO.value.transform.position - agent.transform.position).normalized; //sets the pitch direction towards the batter
            }

            GameObject baseballGO = GameObject.Instantiate(baseballPrefab.value, agent.transform.position, Quaternion.identity);
			baseballGO.GetComponent<Rigidbody2D>().velocity = pitchDirection * pitchSpeed;

            if (destination == destinations.forward)
            {
                timesUntilAttack.value --; //if it was a normal throw, reduce the number of normal throws left until the fastball
            }

            EndAction(true);
		}
	}
}
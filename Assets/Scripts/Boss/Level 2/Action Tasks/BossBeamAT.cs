using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class BossBeamAT : ActionTask {

        //after activation, the beam attack:
        //"aims" for a certain window of time (action depends on beamType)
        //then "fires" for a certain period of time (activating the collider)

        private float beamTimer;

        public enum action { Aiming, Waiting, Attacking, Leaving }
        public action currentAction = action.Aiming;

        //type of beam describes what it does during "aiming" period
        //static: does not move while aiming
        //rotate: rotates to look towards player
        //followHor: moves side to side to match player x-pos
        //followVer: moves up and down to match player y-pos
        [Space(5)]
        public float aimSpeed; //the speed at which the beam tries to aim towards the player

        public float aimTime; //how long the aiming lasts for
        public float waitTime; //how long the wait before shooting lasts for (should be short)
        public float attackTime; //how long the beam attack lasts for

        public BBParameter<GameObject> beamAttack;

        Vector3 originalPos;
        Vector3 toOriginalPos;

        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
            beamAttack.value.SetActive(false);
            originalPos = agent.transform.position;
            currentAction = action.Aiming;
            beamTimer = 0f;
        }

        protected override void OnUpdate()
        {
            beamTimer += Time.deltaTime;

            if (currentAction == action.Aiming) //aiming logic for each type of beam
            {
                if (beamTimer >= aimTime)
                {
                    currentAction = action.Waiting; //switches to next action when aimTime is over
                    beamTimer = 0;
                }

                int direction; //used to calculate what direction to aim towards

                if (PlayerMoveAndShoot.playerTransform.position.y < agent.transform.position.y) direction = -1; //checks if the player is below
                else direction = 1; //or above

                agent.transform.position += Vector3.up * aimSpeed * direction * Time.deltaTime; //moves up or down at aimSpeed

            }
            else if (currentAction == action.Waiting) //a little pause before shooting
            {
                if (beamTimer >= waitTime)
                {
                    currentAction = action.Attacking;
                    beamTimer = 0;
                }
            }
            else if (currentAction == action.Attacking) //shooting
            {
                if (beamTimer >= attackTime)
                {
                    currentAction = action.Leaving;
                    beamTimer = 0;
                    
                }

                beamAttack.value.SetActive(true); //turn on beam attack and collider
            }


            if (currentAction == action.Leaving)
            {
                beamAttack.value.SetActive(false);

                //set arm back to default pos
                toOriginalPos = originalPos - agent.transform.position;

                agent.transform.position += toOriginalPos.normalized * aimSpeed * Time.deltaTime;
                if (toOriginalPos.magnitude < 0.2)
                {
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
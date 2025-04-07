using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class FishChooseMoveAT : ActionTask {

		private List<string> possibleAttacks = new List<string>();

		public BBParameter<float> bossHealth;
		public BBParameter<string> chosenAttack;
		private string lastAttack;
		private string currentAttack;

        private TakeDamage fishHealthScript;
        private float percentageHealthLeft;
        private float initialSpiffyHealth;

        public BBParameter<int> attackLevel;
        public BBParameter<float> afterAttackTimer;

        protected override string OnInit() {
            possibleAttacks.Add("Shoot Fish");
            possibleAttacks.Add("Eel Dash");
            possibleAttacks.Add("Bubble Cluster Swirl");

            fishHealthScript = agent.GetComponent<TakeDamage>();
            initialSpiffyHealth = fishHealthScript.health;

            return null;
		}

		protected override void OnExecute() {

            //setting attack level
            //currentFishHealth = fishHealthScript.health;
            percentageHealthLeft = 100 * (fishHealthScript.health / initialSpiffyHealth);
            Debug.Log("fish script health: " + fishHealthScript.health);
            Debug.Log("initial health: " + initialSpiffyHealth);
            Debug.Log("percentage health: " + percentageHealthLeft);
            
            if (percentageHealthLeft < 15)
            {
                attackLevel.value = 3;
                afterAttackTimer.value = 1;
            }
            else if (percentageHealthLeft < 50)
            {
                attackLevel.value = 2;
                afterAttackTimer.value = 3;
            }
            else if (percentageHealthLeft < 100)
            {
                attackLevel.value = 1;
                afterAttackTimer.value = 5;
            }
            
            Debug.Log("attack level: " + attackLevel.value);

            while (currentAttack == lastAttack)
			{
				currentAttack = possibleAttacks[Random.Range(0, possibleAttacks.Count)];
			}

            if (lastAttack == "Eel Dash")
            {
                currentAttack = "Spawn Eel";
            }


            chosenAttack.value = currentAttack;

			lastAttack = currentAttack;

            EndAction(true);
		}

	}
}
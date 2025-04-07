using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class BanditChooseMoveAT : ActionTask {

		private List<string> possibleAttacks = new List<string>();

		public BBParameter<string> chosenAttack;
		private string lastAttack;
		private string currentAttack;

        private TakeDamage bossHealthScript;
        private float percentageHealthLeft;
        private float initialBossHealth;

        public BBParameter<int> attackLevel;
        public BBParameter<float> afterAttackTimer;

        protected override string OnInit() {
            possibleAttacks.Add("Beam");
            possibleAttacks.Add("Bullet Spray");
            possibleAttacks.Add("Parry");

            bossHealthScript = agent.GetComponentInParent<TakeDamage>();
            initialBossHealth = bossHealthScript.health;
            return null;
		}

		protected override void OnExecute() {
            //setting attack level
            percentageHealthLeft = 100 * (bossHealthScript.health / initialBossHealth);
            Debug.Log("boss script health: " + bossHealthScript.health);
            Debug.Log("initial health: " + initialBossHealth);
            Debug.Log("percentage health: " + percentageHealthLeft);
            
            //boss evolution stages
            //as time goes on the time between attacks decreases
            if (percentageHealthLeft < 15)
            {
                attackLevel.value = 3;
                afterAttackTimer.value = 2;
            }
            else if (percentageHealthLeft < 50)
            {
                attackLevel.value = 2;
                afterAttackTimer.value = 6;
            }
            else if (percentageHealthLeft < 100)
            {
                attackLevel.value = 1;
                afterAttackTimer.value = 9;
            }
            
            Debug.Log("attack level: " + attackLevel.value);

            while (currentAttack == lastAttack)
			{
				currentAttack = possibleAttacks[Random.Range(0, possibleAttacks.Count)];
			}


            chosenAttack.value = currentAttack;

			lastAttack = currentAttack;

            EndAction(true);
		}

	}
}
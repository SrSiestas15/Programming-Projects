using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class SpiffyChooseMoveAT : ActionTask {

        private List<string> possibleAttacks = new List<string>();

        public BBParameter<float> bossHealth;
        public BBParameter<string> chosenAttack;
        private string lastAttack;
        private string currentAttack;

        private TakeDamage spiffyHealthScript;
        private float percentageHealthLeft;
        private float initialSpiffyHealth;

        public BBParameter<int> attackLevel;
        public BBParameter<float> afterAttackTimer;

        protected override string OnInit()
        {

            possibleAttacks.Add("Spit Cereal");
            possibleAttacks.Add("Spawn Waffles");
            possibleAttacks.Add("Try Heal");

            spiffyHealthScript = agent.GetComponent<TakeDamage>();
            initialSpiffyHealth = spiffyHealthScript.health;
            bossHealth.value = initialSpiffyHealth; 

            return null;
        }

        protected override void OnExecute()
        {
            bossHealth.value = spiffyHealthScript.health;

            //setting attack level
            percentageHealthLeft = 100 * (spiffyHealthScript.health / initialSpiffyHealth);

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
            else if (percentageHealthLeft <= 100)
            {
                attackLevel.value = 1;
                afterAttackTimer.value = 5;
            }

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
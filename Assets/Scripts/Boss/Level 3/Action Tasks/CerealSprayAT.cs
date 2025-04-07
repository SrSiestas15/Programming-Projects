using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class CerealSprayAT : ActionTask {

		public BBParameter<float> attackLevel;

		public List<GameObject> cerealsToSpray; //the possible cereals to randomly choose from
		private List<GameObject> currentCereals; //keeps track of the cereals that are spawned in through SpiffyController.cs

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {
            StartCoroutine(ShootCereal());
		}

		protected override void OnUpdate() {
			
		}

        IEnumerator ShootCereal()
        {
            int extraCereal = 0; //keeps track of the current wave of cereals

            for (int i = 0; i < attackLevel.value + 2; i++) //how many waves of cereals will be shot: determined on current boss health
            {   
                currentCereals = new List<GameObject>(); //empties the list of cereals

                for (int e = extraCereal; e < (attackLevel.value + 3); e++) //how many cereals will be in this wave: determined with current boss health, amount decreases per wave
                {
                    GameObject newCereal = cerealsToSpray[Random.Range(0, cerealsToSpray.Count)]; //selects a random cereal (from the 4 prefabs)
                    currentCereals.Add(newCereal); //adds selected cereal to the lineup
                }
                agent.GetComponent<SpiffyController>().SpawnCereal(currentCereals, 60); //spawn in the cereals in current lineup

                extraCereal++; //the next wave of cereals has one less

                yield
                return new WaitForSeconds(.5f); //how long to wait until the next wave
            }
            EndAction(true);
        }

    }
}
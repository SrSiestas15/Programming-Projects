using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;

namespace NodeCanvas.Tasks.Actions {

	public class SpawnAttackAT : ActionTask {
        public BBParameter<int> attackLevel;

        public enum spawnObject { Fish, Bubble, Eels }
		public spawnObject chosenObject;



        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {

            return null;
		}


		protected override void OnExecute() {
			BossFish fishScript = agent.GetComponent<BossFish>();

			

            if (chosenObject == spawnObject.Fish)
			{
				for (int i = 0; i < attackLevel.value; i++)
				{
					float verticalOffset = Random.Range(-2, 2);
					float horizontalOffset = i * 4;
					fishScript.SpawnFish(horizontalOffset, verticalOffset);
				}
			}

			if (chosenObject == spawnObject.Bubble)
			{
                for (int i = 0; i < Mathf.Clamp(attackLevel.value, 0, 2); i++)
				{
					bool inverse;
					if (i % 2 == 0)
					{
						inverse = true;
					} else inverse = false;
					fishScript.SpawnBubble(inverse);
				}
			}

			if (chosenObject == spawnObject.Eels)
			{
				fishScript.SpawnEels(attackLevel.value);
			}


            EndAction(true);
		}
	}
}
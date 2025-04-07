using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class SpiffyMoveArmAT : ActionTask {

		private SpiffyController spiffyScript;

		public GameObject armGameObject;
		public GameObject leekObject;
		private TakeDamage leekHealth;
		private Transform mouthTransform;

		private MoveInRange bobScript;

		private bool isCarrying;
		private float speedUp = 1;
		private float speedDown = 2;

		private float startY;
		private float endY;
		private Vector3 newPos;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {

			spiffyScript = agent.GetComponent<SpiffyController>();
			bobScript = agent.GetComponent<MoveInRange>();

			newPos = armGameObject.transform.position;
			
			Transform[] tempTransforms2 = agent.GetComponentsInChildren<Transform>();
            foreach (Transform t in tempTransforms2)
            {
                if (t.gameObject.name == "SpiffyMouth") mouthTransform = t;
            }

            startY = armGameObject.transform.position.y;

			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			bobScript.enabled = false;
			endY = mouthTransform.position.y;
			leekHealth = leekObject.GetComponent<TakeDamage>();
			leekObject.SetActive(true);
			isCarrying = true;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (isCarrying)
			{
				if(armGameObject.transform.position.y <= endY)
				{
					newPos.y += Time.deltaTime * speedUp;
				}
				else
				{
                    leekObject.SetActive(false);
                    isCarrying = false;
                    //HEAL!!

                }
			}
			else if (!isCarrying)
			{
				bobScript.enabled = true;

				if(armGameObject.transform.position.y >= startY)
				{
                    newPos.y -= Time.deltaTime * speedDown;
                }
				else
				{
					EndAction(true);
				}
			}
			armGameObject.transform.position = newPos;

			if(leekHealth.health <= 0)
			{
                leekObject.SetActive(false);
                isCarrying = false;
			}

		}

		IEnumerator HealSpiffy()
		{
			spiffyScript.gameObject.GetComponent<TakeDamage>().health += 100;
			yield return new WaitForSeconds(2);
		}
	}
}
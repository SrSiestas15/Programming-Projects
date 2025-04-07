using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class BulletSprayAT : ActionTask {

        //later add so that the boss randomly chooses to shoot top to bottom or bottom to top
		//public bool topToBottom;
        
		public enum action { windup, shoot, end }
        public action currentAction = action.windup;

		public float sprayRange; //how far the gun moves up/down (does NOT change the gun spawn transforms, do those manually)
        public BBParameter<List<Transform>> spawnTransforms; //list of transforms where bullets will spawn
		public List<bool> beenShot = new List<bool>(); //if each bullet has been shot
		public BBParameter<Transform> gunTip;
		
		private Rigidbody2D rb;
		private BanditBossScript banditScript;

		

		protected override string OnInit() {
			rb = agent.GetComponent<Rigidbody2D>();
			banditScript = agent.GetComponentInParent<BanditBossScript>();
			return null;
		}


		protected override void OnExecute()
		{
			for (int i = 0; i < beenShot.Count; i++) //reset beenShot values
			{
				beenShot[i] = false;
			}
			currentAction = action.windup;
		}

		protected override void OnUpdate()
		{
			if (currentAction == action.windup) //move the arm up
			{
				rb.MoveRotation(rb.rotation + -200 * Time.deltaTime);
				if (rb.rotation <= -sprayRange) //if gun reaches the top, start shooting
				{
					currentAction = action.shoot;
				}
			} else if (currentAction == action.shoot) //move the arm down and shoot along the way
			{
                rb.MoveRotation(rb.rotation + 150 * Time.deltaTime);

				for (int i = 0; i < spawnTransforms.value.Count; i++) //for each transform value
				{
					Vector3 toSpawnLocation = spawnTransforms.value[i].position - gunTip.value.position;
					Debug.DrawLine(spawnTransforms.value[i].position, gunTip.value.position);

					if (toSpawnLocation.magnitude < 2) //if the tip of the gun is within range of the spawn position
					{

                        if (!beenShot[i]) //if the corrosponding bullet has not yet been shot
                        {
							banditScript.ShootBullet(spawnTransforms.value[i].position, gunTip.value.right); //shoot the bullet
							beenShot[i] = true;
                        
						}
					}

				}

				if (rb.rotation >= sprayRange) //if gun reaches the bottom, begin reset to default
				{
					currentAction = action.end;
				}

            } else if (currentAction == action.end) //move the arm back to default
			{
                rb.MoveRotation(rb.rotation + -200 * Time.deltaTime);
				if (rb.rotation <= 0)
				{
					rb.rotation = 0;
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
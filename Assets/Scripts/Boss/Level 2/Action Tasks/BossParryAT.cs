using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class BossParryAT : ActionTask
	{

		//activates the reflective property on the gun gameObject
		ReflectBullet reflectScript;
		Collider2D gunCollider;
        private Rigidbody2D armRB;
		GameObject gun;

		public float armRange;
		public float rotateSpeed;
		bool moveUp = true;

		public float parryTime;
		float timer = 0f;


        protected override string OnInit()
		{
			reflectScript = agent.GetComponentInChildren<ReflectBullet>(); //gets a reference to the reflect script on the gun
			gunCollider = agent.GetComponentInChildren<Collider2D>(); //gets a reference to the collider2D on the gun
            armRB = agent.GetComponent<Rigidbody2D>();
			gun = GameObject.Find("Gun");
            return null;
		}

		protected override void OnExecute()
		{
			//when these turn on, the bullets collide and bounce away from the gun!
			//make sure to turn these off when the 'parry' state ends
			gunCollider.enabled = true;
			reflectScript.reflecting = true;

			timer = 0f;

            armRB.rotation = 0;
            gun.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

		protected override void OnUpdate()
		{
			////rotate ARM up and down
			if (armRB.rotation > -armRange - 50 && moveUp) //move up
			{
				armRB.MoveRotation(armRB.rotation + -300 * Time.deltaTime);
			}
			else if (armRB.rotation <= -armRange - 50)
			{
				moveUp = false;
			}

			if (armRB.rotation < armRange - 30 && !moveUp) //move down
			{
				armRB.MoveRotation(armRB.rotation + 300 * Time.deltaTime);
			}
			else if (armRB.rotation >= armRange - 30)
			{
				moveUp = true;
			}

			//rotate gun
			gun.transform.Rotate(Vector3.forward * rotateSpeed, Space.Self);

			timer += Time.deltaTime;
			if (timer >= parryTime)
			{
                //reset to original pos/rotation
                armRB.MoveRotation(armRB.rotation + -200 * Time.deltaTime);
                if (armRB.rotation <= 0)
                {
                    armRB.rotation = 0;
					gun.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
					gunCollider.enabled = false;
					reflectScript.reflecting = false;
                    
                }

			}
			if (timer > parryTime + 1) EndAction(true);
        }


    }
}
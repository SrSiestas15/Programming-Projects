using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor;



namespace NodeCanvas.Tasks.Actions {

	public class FastballAT : ActionTask {

		public BBParameter<GameObject> baseballGO;
		public float ballSpeed;

		protected override string OnInit() {
			return null;
		}

		//changes the trajectory and speed of the ball to be launched at the player
		protected override void OnExecute() {
			Vector2 toPlayer = (PlayerMoveAndShoot.playerTransform.position - agent.transform.position).normalized * ballSpeed;
			if(baseballGO.value.GetComponent<Rigidbody2D>() != null)
			{
				baseballGO.value.GetComponent<Rigidbody2D>().velocity = toPlayer;
			}
			EndAction(true);
		}
	}
}
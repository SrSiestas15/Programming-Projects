using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ChangeSpriteAT : ActionTask {

		public BBParameter<GameObject> batterGO;

		SpriteRenderer pitcherRenderer;
		SpriteRenderer batterRenderer;

		public Sprite batterSprite;
		public Sprite pitcherSprite;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			pitcherRenderer = agent.GetComponentInChildren<SpriteRenderer>();
			batterRenderer = batterGO.value.GetComponentInChildren<SpriteRenderer>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			if(batterSprite != null)
			{
				batterRenderer.sprite = batterSprite;
			}
			if(pitcherRenderer != null)
			{
				pitcherRenderer.sprite = pitcherSprite;
			}
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}
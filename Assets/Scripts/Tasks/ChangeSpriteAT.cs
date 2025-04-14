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

		protected override string OnInit() {
			pitcherRenderer = agent.GetComponentInChildren<SpriteRenderer>();
			batterRenderer = batterGO.value.GetComponentInChildren<SpriteRenderer>();
			return null;
		}

		protected override void OnExecute() {
			//change sprites (new sprites selected through the inspector)
			//if a sprite wasn't selected for one of the gameObjects, ignore
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
	}
}
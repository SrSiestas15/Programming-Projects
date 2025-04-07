using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Actions {

	public class UpdateBossHealthAT : ActionTask {

        public BBParameter<float> bossHealth;
		private TakeDamage healthScript;

		public bool healthIsInParent;

        protected override string OnInit() {
			if (!healthIsInParent)
			{
				healthScript = agent.GetComponent<TakeDamage>();
			}
			else healthScript = agent.GetComponentInParent<TakeDamage>();

            return null;
		}

		protected override void OnUpdate() {
			bossHealth.value = healthScript.health;
		}
	}
}
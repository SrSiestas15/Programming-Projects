using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions {

	public class CheckStateCT : ConditionTask {

        public enum States
        {
            waiting,
            ready,
            busy,
        }
		public States desiredState;

		protected override bool OnCheck() {
			if (desiredState.ToString() == BatterController.currentState.ToString())
			{
				return true;
			}
			else return false;
		}
	}
}
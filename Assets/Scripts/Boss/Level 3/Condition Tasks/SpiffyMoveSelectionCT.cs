using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions {

	public class SpiffyMoveSelectionCT : ConditionTask {
        
        public BBParameter<string> chosenAttack;
        public enum possibleAttacks { spitCereal, spawnWaffles, tryHeal }
        public possibleAttacks requiredAttack;

        protected override string OnInit()
        {
            return null;
        }

        protected override bool OnCheck()
        {
            if ((requiredAttack == possibleAttacks.spitCereal) && chosenAttack.value == "Spit Cereal")
            {
                return true;
            } 
            else if ((requiredAttack == possibleAttacks.spawnWaffles) && chosenAttack.value == "Spawn Waffles")
            {
                return true;
            }
            else if ((requiredAttack == possibleAttacks.tryHeal) && chosenAttack.value == "Try Heal")
            {
                return true;
            }
            else return false;
        }
	}
}
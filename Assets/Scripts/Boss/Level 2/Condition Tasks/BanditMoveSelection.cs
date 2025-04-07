using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions
{

    public class BanditMoveSelection : ConditionTask
    {

        public BBParameter<string> chosenAttack;
        public enum possibleAttacks { beam, bulletSpray, parry}
        public possibleAttacks requiredAttack;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
        {
            return null;
        }

        //Called whenever the condition gets enabled.
        protected override void OnEnable()
        {

        }

        //Called whenever the condition gets disabled.
        protected override void OnDisable()
        {

        }

        //Called once per frame while the condition is active.
        //Return whether the condition is success or failure.
        protected override bool OnCheck()
        {
            if ((requiredAttack == possibleAttacks.beam) && chosenAttack.value == "Beam")
            {
                return true;
            }
            if ((requiredAttack == possibleAttacks.bulletSpray) && chosenAttack.value == "Bullet Spray")
            {
                return true;
            }
            if ((requiredAttack == possibleAttacks.parry) && chosenAttack.value == "Parry")
            {
                return true;
            }
            else return false;
        }
    }
}
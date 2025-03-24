using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions
{

    public class PlayerInputCT : ConditionTask
    {
        //Called once per frame while the condition is active.
        //Return whether the condition is success or failure.
        protected override bool OnCheck()
        {
            if (Input.GetKey(KeyCode.Space)) return true;
            else return false;
        }
    }
}
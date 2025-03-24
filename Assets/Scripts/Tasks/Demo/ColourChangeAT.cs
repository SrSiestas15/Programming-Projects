using NodeCanvas.Framework;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions
{

    public class ColourChangeAT : ActionTask
    {
        public Renderer renderer;
        public Color targetColor = Color.white;

        private Color startColor;

        protected override string OnInit()
        {
            startColor = renderer.material.color;
            return null;
        }

        protected override void OnUpdate()
        {
            float stepValue = Mathf.PingPong(Time.time, 1f);

            renderer.material.color = Color.Lerp(startColor, targetColor, stepValue);

            if (stepValue > 0.8f) EndAction(true);
            if (stepValue < 0) EndAction(false);
        }

        protected override void OnStop()
        {
            renderer.material.color = startColor;
        }
    }
}
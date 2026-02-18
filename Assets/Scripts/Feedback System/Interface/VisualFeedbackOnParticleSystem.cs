using System.Collections;

using UnityEngine;

namespace InterfaceImplementation
{
    [RequireComponent(typeof(ParticleSystem))]
    public class VisualFeedbackOnParticleSystem : MonoBehaviour, IVisualFeedback
    {
        /// <summary>
        /// https://docs.unity3d.com/6000.3/Documentation/ScriptReference/ParticleSystemRenderer.html
        /// </summary>
        private ParticleSystemRenderer particleSystemRenderer = null;

        private void Start()
        {
            particleSystemRenderer = GetComponent<ParticleSystemRenderer>();
        }

        public void ShowFeedback()
        {
            // Stop coroutine.
            StopCoroutine(nameof(UpdateFeedback));

            // (re) Start coroutine.
            StartCoroutine(nameof(UpdateFeedback));
        }

        private IEnumerator UpdateFeedback()
        {
            float duration = 2.0f;
            float timer = 0.0f;

            do
            {
                // Change particle renderer's material's color.
                particleSystemRenderer.material.color = Color.Lerp(Color.red, Color.white, timer / duration);

                // Update timer value.
                timer += Time.deltaTime;

                // Yield
                yield return 0;

            } while (timer < duration);
        }
    }
}

using System.Collections;

using UnityEngine;

namespace InterfaceImplementation
{
    [RequireComponent(typeof(MeshRenderer))]
    public class VisualFeedbackOnMeshRenderer : MonoBehaviour, IVisualFeedback
    {
        private MeshRenderer meshRenderer = null;

        private void Start()
        {
            meshRenderer = GetComponent<MeshRenderer>();
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
                // Change mesh renderer's material's color.
                meshRenderer.material.color = Color.Lerp(Color.red, Color.white, timer / duration);

                // Update timer value.
                timer += Time.deltaTime;

                // Yield
                yield return 0;

            } while (timer < duration);
        }
    }
}

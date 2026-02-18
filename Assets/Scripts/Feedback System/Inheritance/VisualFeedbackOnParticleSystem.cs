using System.Collections;

using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class VisualFeedbackOnParticleSystem : VisualFeedback
{
    private ParticleSystem pSystem = null;

    private void Start()
    {
        pSystem = GetComponent<ParticleSystem>();
    }

    public override void ShowFeedback()
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
            var mainModule = pSystem.main;
            var startColorGradient = mainModule.startColor;
            startColorGradient.color = Color.Lerp(Color.red, Color.white, timer / duration);
            mainModule.startColor = startColorGradient;

            // Update timer value.
            timer += Time.deltaTime;

            // Yield
            yield return 0;

        } while (timer < duration);
    }
}

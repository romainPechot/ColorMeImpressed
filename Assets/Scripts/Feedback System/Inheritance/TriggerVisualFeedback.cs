using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerVisualFeedback : MonoBehaviour
{
    [SerializeField]
    private VisualFeedback[] visualFeedbacks = new VisualFeedback[0];

    private void Update()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            foreach (VisualFeedback visualFeedback in visualFeedbacks)
            {
                visualFeedback.ShowFeedback();
            }
        }
    }
}

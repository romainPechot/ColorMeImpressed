using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

namespace InterfaceImplementation
{
    public class TriggerVisualFeedback : MonoBehaviour
    {
        private IVisualFeedback[] visualFeedbacks = new IVisualFeedback[0];

        private void Start()
        {
            List<IVisualFeedback> list = new List<IVisualFeedback>();

            // Get all MonoBehaviour in our children.
            MonoBehaviour[] monoBehaviours = GetComponentsInChildren<MonoBehaviour>();

            foreach (MonoBehaviour monoBehaviour in monoBehaviours)
            {
                // Does our MonoBehavior implement interface IVisualFeedback?
                if (monoBehaviour is IVisualFeedback visualFeedback)
                {
                    list.Add(visualFeedback);
                }
            }

            visualFeedbacks = list.ToArray();
        }

        private void Update()
        {
            if (Keyboard.current.spaceKey.isPressed)
            {
                foreach (IVisualFeedback visualFeedback in visualFeedbacks)
                {
                    visualFeedback.ShowFeedback();
                }
            }
        }
    }
}

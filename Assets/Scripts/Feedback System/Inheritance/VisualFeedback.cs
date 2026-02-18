using UnityEngine;

namespace InheritanceImplementation
{
    public abstract class VisualFeedback : MonoBehaviour
    {
        /// <summary>
        /// Should create a red pulse to white in 1 sec.
        /// </summary>
        public abstract void ShowFeedback();
    }
}

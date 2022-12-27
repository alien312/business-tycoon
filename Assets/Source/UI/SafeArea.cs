using UnityEngine;

namespace Source.UI
{
    public class SafeArea : MonoBehaviour
    {
        private void Start()
        {
            UpdateSafeArea();
        }
        
        private void UpdateSafeArea()
        {
            var safeArea = Screen.safeArea;
            var rect = GetComponent<RectTransform>();

            var anchorMin = safeArea.position;
            var anchorMax = safeArea.position + safeArea.size;

            anchorMin.x /= Screen.width;
            anchorMax.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.y /= Screen.height;

            rect.anchorMin = anchorMin;
            rect.anchorMax = anchorMax;
        }
    }
}
using UnityEngine;

public class SafeAreaHandler : MonoBehaviour
{
    private RectTransform panelSafeArea;
    private Rect lastSafeArea = new Rect(0, 0, 0, 0);

    void Awake()
    {
        panelSafeArea = GetComponent<RectTransform>();
        Refresh();
    }

    void Update()
    {
        Refresh();
    }

    private void Refresh()
    {
        Rect safeArea = Screen.safeArea;

        if (safeArea != lastSafeArea)
        {
            ApplySafeArea(safeArea);
        }
    }

    private void ApplySafeArea(Rect area)
    {
        lastSafeArea = area;

        // Convert safe area rectangle from absolute pixels to normalised anchor coordinates
        Vector2 anchorMin = area.position;
        Vector2 anchorMax = area.position + area.size;
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        panelSafeArea.anchorMin = anchorMin;
        panelSafeArea.anchorMax = anchorMax;
    }
}


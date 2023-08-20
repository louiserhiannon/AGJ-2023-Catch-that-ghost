using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    private bool isVisible = false;
    private Renderer ghostRenderer;     

    private void Start()
    {
        ghostRenderer = GetComponent<Renderer>();
        // Assuming ghosts start invisible
        SetVisibility(false);
    }

    public void MakeVisible()
    {
        SetVisibility(true);
    }

    public void ResetVisibility()
    {
        SetVisibility(false);
    }

    private void SetVisibility(bool visibility)
    {
        isVisible = visibility;
        ghostRenderer.enabled = isVisible;
    }

}

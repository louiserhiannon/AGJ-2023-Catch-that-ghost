using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostDetector : MonoBehaviour
{
    public float ghostDetectionRadius = 10f;
    public float ghostDetectionDuration = 5f;
    public LayerMask ghostLayer;

    private bool isGhostDetectionMode = false;
    private float ghostDetectionEndTime;
    public GhostController ghostController;

    void Update()
    {
        // Check for "I" key press to activate ghost detection mode
        if (Input.GetKeyDown(KeyCode.I))
        {
            ActivateGhostDetectionMode();
        }

        // Check if ghost detection mode is active and handle ghosts' visibility
        if (isGhostDetectionMode)
        {
            HandleGhostVisibility();
        }
    }

    void ActivateGhostDetectionMode()
    {
        isGhostDetectionMode = true;
        ghostDetectionEndTime = Time.time + ghostDetectionDuration;
    }

    void HandleGhostVisibility()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, ghostDetectionRadius, ghostLayer);

        foreach (Collider collider in hitColliders)
        {            
            GhostController ghostController = collider.GetComponent<GhostController>();
            if (ghostController != null)
            {
                Debug.Log("Found a ghost");
                ghostController.MakeVisible();
            }
            else return;
        }

        // Check if ghost detection mode time has passed
        if (Time.time >= ghostDetectionEndTime)
        {
            isGhostDetectionMode = false;           
            ghostController.ResetVisibility();           
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBallController : MonoBehaviour
{
    private SkinnedMeshRenderer skinnedMeshRenderer;
    public float blendSpeed;
    private float blendWeight;
    public bool openBall = false;
    private bool openBallStarted = false;
    public bool closeBall = false;
    private bool closeBallStarted = false;


    void Start()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        blendWeight = skinnedMeshRenderer.GetBlendShapeWeight(0);
        
    }


    void Update()
    {
        if (openBall && !closeBallStarted)
        {
            
            StartCoroutine(OpenBall());
            
        }
        
        if(closeBall && !openBallStarted)
        {
            
            StartCoroutine(CloseBall());
            
        }
        
    }

    private IEnumerator OpenBall()
    {
        if (!openBallStarted)
        {
            openBallStarted = true;
            
            while (skinnedMeshRenderer.GetBlendShapeWeight(0) < 100)
            {
                blendWeight += blendSpeed * Time.deltaTime;
                skinnedMeshRenderer.SetBlendShapeWeight(0, blendWeight);
                yield return null;
            }

            openBallStarted = false;
            openBall = false;

        }
        
        
    }

    private IEnumerator CloseBall()
    {
        if (!closeBallStarted)
        {
            closeBallStarted = true;
            
            while (skinnedMeshRenderer.GetBlendShapeWeight(0) > 0)
            {
                blendWeight -= blendSpeed * Time.deltaTime;
                skinnedMeshRenderer.SetBlendShapeWeight(0, blendWeight);
                yield return null;
            }

            closeBallStarted = false;
            closeBall = false;

        }

    }
}

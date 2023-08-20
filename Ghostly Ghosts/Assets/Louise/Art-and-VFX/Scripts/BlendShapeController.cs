using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendShapeController : MonoBehaviour
{
    private SkinnedMeshRenderer skinnedMeshRenderer;
    public float blendSpeed;
    private float blendWeight;
    private bool animate = true;


    void Start()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        blendWeight = skinnedMeshRenderer.GetBlendShapeWeight(0);
        StartCoroutine(ManageBlendShapes());
    }

    // Update is called once per frame
    private IEnumerator ManageBlendShapes()
    {
        while (animate)
        {
            while (skinnedMeshRenderer.GetBlendShapeWeight(0) < 100)
            {
                blendWeight += blendSpeed * Time.deltaTime;
                skinnedMeshRenderer.SetBlendShapeWeight(0, blendWeight);
                yield return null;
            }

            while (skinnedMeshRenderer.GetBlendShapeWeight(0) > 0)
            {
                blendWeight -= blendSpeed * Time.deltaTime;
                skinnedMeshRenderer.SetBlendShapeWeight(0, blendWeight);
                yield return null;
            }

            yield return null;
        }
        
    }
}

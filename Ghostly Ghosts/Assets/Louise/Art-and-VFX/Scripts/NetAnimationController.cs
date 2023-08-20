using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetAnimationController : MonoBehaviour
{
    private Animator netAnimator;
    public bool swingNet = false;
    private bool animationRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        netAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (swingNet && !animationRunning)
        {
            StartCoroutine(PlaySwingAnimation());
        }
    }

    private IEnumerator PlaySwingAnimation()
    {
        animationRunning = true;
        netAnimator.SetTrigger("Swing");
        yield return new WaitForSeconds(7);

        animationRunning = false;
        swingNet = false;
        
    }
}

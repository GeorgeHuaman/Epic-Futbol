using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public Transform ballTransform;
    public Transform initialTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ball"))
        {
            ResetBall();
        }
    }

    public void ResetBall()
    {
        ballTransform.position = initialTransform.position;
    }
}

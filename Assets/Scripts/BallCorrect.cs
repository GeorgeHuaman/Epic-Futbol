using SpatialSys.UnitySDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCorrect : MonoBehaviour
{
    public Rigidbody rb;
    public float kickForce = 10f;
    public float upwardForce = 2f;
    private bool once;
    public SpatialInteractable interactable;

    private float time;
    private float timeToDisable = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        interactable = GetComponent<SpatialInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = SpatialBridge.actorService.localActor.avatar.position;
        float distance = Vector3.Distance(transform.position, playerPosition);
        if (!once && distance <= 0.8f && Input.GetKeyDown(KeyCode.F))
        {
            Correct();
            once = true;
        }
        if (once)
        {
            time += Time.deltaTime;
            if (time>= timeToDisable)
            {
                interactable.enabled = false;
            }
        }
    }

    public void Incorrect()
    {
        rb.AddForce(transform.forward * kickForce, ForceMode.Impulse);
    }

    public void Correct()
    {
        Vector3 kickDirection = (transform.forward * kickForce) + (transform.up * upwardForce);
        rb.AddForce(-kickDirection, ForceMode.Impulse);
    }
}

using SpatialSys.UnitySDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float cooldown = 0.2f; // Tiempo de espera entre patadas en segundos
    private float time;
    public Rigidbody rb;
    public float kickForce;
    public Transform chest;
    public Transform initialPosition;
    private void Update()
    {
        Vector3 playerPosition = SpatialBridge.actorService.localActor.avatar.position;
        playerPosition.y -= 0.3f; // Ajusta el valor según lo necesario
        Vector3 direction = (transform.position - playerPosition).normalized;


        float distance = Vector3.Distance(transform.position, playerPosition);


        time += Time.deltaTime;

        if (distance <= 1.1f && time >= cooldown)
        {
            rb.AddForce(direction * kickForce, ForceMode.Impulse);
            time = 0f;
        }
    }
    //public void GiveControl()
    //{
    //    if (!hasControl) 
    //    {
    //        SpatialNetworkObject obj = GetComponent<SpatialNetworkObject>();
    //        obj.RequestOwnership();
    //    }
        
    //}

}

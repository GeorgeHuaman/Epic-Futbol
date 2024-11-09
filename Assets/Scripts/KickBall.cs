using SpatialSys.UnitySDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickBall : MonoBehaviour
{
    public float cooldown = 0.2f; // Tiempo de espera entre patadas en segundos
    private float time;
    public Transform ballTransform;
    public Rigidbody ballRb;
    public float kickForce;
    public Ball ball;

    void Update()
    {
        Vector3 playerPosition = SpatialBridge.actorService.localActor.avatar.position;
        playerPosition.y -= 0.3f; // Ajusta el valor según lo necesario
        Vector3 direction = (ballTransform.position - playerPosition).normalized;
        float distance = Vector3.Distance(ballTransform.position, playerPosition);

        time += Time.deltaTime;

        if (distance <= 1.1f && time >= cooldown)
        {
            ballRb.AddForce(direction * kickForce, ForceMode.Impulse);
            time = 0f;
        }



    }
}

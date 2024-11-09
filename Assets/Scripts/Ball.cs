using SpatialSys.UnitySDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : SpatialNetworkBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GiveControl();
        } 
    }
    public void GiveControl()
    {
        if (!hasControl) 
        {
            SpatialNetworkObject obj = GetComponent<SpatialNetworkObject>();
            obj.RequestOwnership();
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blinkScript : MonoBehaviour
{
    public float range = 1.5f;
    public float blinkDistance;
    public float safeDistance;
    public bool isSafe;

    LayerMask objects = LayerMask.GetMask("Default");
    LayerMask edges = LayerMask.GetMask("HardEdge");

    public Camera player;
    public CharacterController character;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if(range < 20)
            {
                range += .3f;
            }
            else
            {
                range = 20f;
            }
            ChargeBlink();
        }

        if (Input.GetButtonUp("Fire2"))
        {
            ReleaseBlink();
        }
    }

    public void ChargeBlink()
    {
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, range, objects))
        {
            blinkDistance = range;

            if (Physics.CheckSphere(hit.point,.7f,edges) == true)
            {
                isSafe = false;
            }
            else
            {
                isSafe = true;
                safeDistance = range;
            }
        }
    }

    public void ReleaseBlink()
    {
        
    }
}

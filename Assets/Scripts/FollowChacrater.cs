using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowChacrater : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 temp = transform.position;

        temp.x = player.position.x;

        transform.position = temp;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    bool isShaking = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isShaking)
        {
            Debug.Log("2");

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Hitbox")
        {
            isShaking = true;
            Invoke("StopShaking", .5f);
        }
    }
    void StopShaking()
    {
        isShaking = false;
    }
}

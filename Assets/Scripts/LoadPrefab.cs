using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPrefab : MonoBehaviour
{
    // Start is called before the first frame update

    public int length;
    public float time;
    public GameObject coin, star;
    void Start()
    {
        LoadRandomPositionPrefab();
    }



    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if ( time < 0)
        {
            LoadRandomPositionPrefab();
            time = 20;
        }
    }

    


    void LoadRandomPositionPrefab()
    {
        for (int i = 0; i < length; i++)
        {
            Instantiate(coin, new Vector3(Random.Range(-15.0f,10.0f), Random.Range(0f, 5.0f), 0), Quaternion.identity);
        }
        
    }
}

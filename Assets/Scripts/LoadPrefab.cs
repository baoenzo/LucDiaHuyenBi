using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPrefab : MonoBehaviour
{
    // Start is called before the first frame update

    public int coinQuanity, bombQuanity;
    public float time;
    public GameObject coin, bomb;
    void Start()
    {
        LoadRandomPositionPrefab();
        LoadBomb();
    }


    float bombTime = 5;
    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            LoadRandomPositionPrefab();
            time = 20;
        }

        bombTime -= Time.deltaTime;
        
        if(bombTime< 0)
        {
            LoadBomb();
            bombTime = 5;
        }
    }




    void LoadRandomPositionPrefab()
    {
        for (int i = 0; i < coinQuanity; i++)
        {
            Instantiate(coin, new Vector3(Random.Range(-30.0f, 10.0f), Random.Range(0f, 5.0f), 0), Quaternion.identity);
        }

    }
    void LoadBomb()
    {
        for (int i = 0; i < bombQuanity; i++)
        {
            Instantiate(bomb, new Vector3(Random.Range(-30.0f, 10.0f), 10, 0), Quaternion.identity);
        }
    }
}

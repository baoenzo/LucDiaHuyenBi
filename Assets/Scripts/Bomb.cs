using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update

   public GameObject bomb;
    public string ttag;
    public TextMeshProUGUI txtScore;
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ttag))
        {
            SceneManager.LoadScene("NgumCuToi");
            File.WriteAllText(Environment.CurrentDirectory + @"/Score.txt", txtScore.text);
        }
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

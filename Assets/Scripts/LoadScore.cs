using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class LoadScore : MonoBehaviour
{
    // Start is called before the first frame update
    private string path = Environment.CurrentDirectory + @"/Score.txt";
    public TextMeshProUGUI highScore;
    void Start()
    {
        if(File.Exists(path))
        {
            highScore.text = File.ReadAllText(path);
        }
        else
        {
            highScore.text = "0";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

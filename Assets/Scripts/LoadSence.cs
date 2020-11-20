using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSence : MonoBehaviour
{
    // Start is called before the first frame update
    public Button btnPlay;
    public string scenceName;
    void Start()
    {
        
        if (btnPlay == null && scenceName != "")
        {
            LoadSenceName(scenceName);
        }
        if(btnPlay != null)
        {
            btnPlay.onClick.AddListener(Playerclick);
        }
    }

    private void Playerclick()
    {
        SceneManager.LoadScene("BinhNguyenHiVong");
    }
    private void LoadSenceName(string scence)
    {
        SceneManager.LoadScene(scence);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

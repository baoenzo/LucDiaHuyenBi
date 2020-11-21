using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Common : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("BinhNguyenHiVong");
    }
    public void LoadLoading()
    {
        SceneManager.LoadScene("Loading");
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene("Start");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

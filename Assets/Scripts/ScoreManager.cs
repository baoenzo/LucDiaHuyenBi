using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static ScoreManager instance;
    public TextMeshProUGUI txtCoinQuantity, txtScore;
   // int score = 1;
    void Start()
    {
        if (instance == null)
            instance = this;
    }

   public void ChangeScore(int coinValue)
    {
        //score += coinValue;
        txtScore.text = (coinValue * 50).ToString();
        txtCoinQuantity.text = coinValue.ToString();
        
    }
}

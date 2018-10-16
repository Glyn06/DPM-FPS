using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour {
    public PlayerData data;

    public Text scoreText;

    private void Awake()
    {
        data.onScoreChangeCallBack += UpdateUI;
    }

    public void UpdateUI() {
        if(data != null && scoreText != null)
            scoreText.text = "Score: " + data.GetScore().ToString("0000");
    }
}

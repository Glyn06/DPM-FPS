using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour {
    public PlayerData data;

    public Text lBulletText;
    public Text rBulletText;
    public Text scoreText;

    private void Awake()
    {
        data.GetWeapon("Left").onClipChangeCallBack += UpdateUI;
        data.GetWeapon("Right").onClipChangeCallBack += UpdateUI;
        data.onScoreChangeCallBack += UpdateUI;
    }

    public void UpdateUI() {
        lBulletText.text = data.GetWeapon("Left").GetClip().ToString("00");
        rBulletText.text = data.GetWeapon("Right").GetClip().ToString("00");
        if(data != null)
        scoreText.text = "Score: " + data.GetScore().ToString("0000");
    }
}

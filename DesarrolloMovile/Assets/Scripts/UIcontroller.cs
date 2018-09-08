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
        data.getWeapon("Left").onClipChangeCallBack += UpdateUI;
        data.getWeapon("Right").onClipChangeCallBack += UpdateUI;
        data.onScoreChangeCallBack += UpdateUI;
    }

    public void UpdateUI() {
        lBulletText.text = data.getWeapon("Left").GetClip().ToString("00");
        rBulletText.text = data.getWeapon("Right").GetClip().ToString("00");
        scoreText.text = "Score: " + data.GetScore().ToString("0000");
    }
}

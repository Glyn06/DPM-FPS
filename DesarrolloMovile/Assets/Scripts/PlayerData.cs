using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    #region Singleton
    public static PlayerData instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnScoreChange();
    public OnScoreChange onScoreChangeCallBack;

    public Player_PC player;

    int score = 0;

    public Weapon GetWeapon(string side) {
        switch (side)
        {
            case "Left":
                return player.LeftWeapon;
            case "Right":
                return player.RightWeapon;
            default:
                Debug.LogWarning("No such weapon");
                return null;
        }
    }

    public int GetScore() {
        return score;
    }

    public void AddScore(int scoreToAdd) {
        score += scoreToAdd;

        if (onScoreChangeCallBack != null)
            onScoreChangeCallBack();
    }
}

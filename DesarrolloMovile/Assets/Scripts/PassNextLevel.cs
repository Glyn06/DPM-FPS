using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassNextLevel : MonoBehaviour {


    public string nextLevelName;
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nextLevelName);
        }
	}
}

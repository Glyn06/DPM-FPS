using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Material mat;
    float factor = 0.0f;
    float p = 1.0f;

	// Use this for initialization
	void Start () {
        mat = GetComponent<Renderer>().sharedMaterial;
	}
	
	// Update is called once per frame
	void Update ()
    {
        factor += Time.deltaTime * 1.0f * p;

        if (factor > 1.0f)
        {
            p *= -1;
            factor = 1.0f;
        }
        else if (factor < 0.0f)
        {
            p *= -1;
            factor = 0.0f;
        }

        //mat.SetFloat("_Factor", factor);

        Shader.SetGlobalFloat("_Factor", factor);
    }   
}

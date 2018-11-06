using UnityEngine;
using Valve.VR;

public class VRInputs : MonoBehaviour {
    private SteamVR_Behaviour_Pose trackedObj;

    public SteamVR_Action_Boolean triggerButton;
    public SteamVR_Action_Boolean grapButton;
    public GameObject sword;
    public float swordSize = 1;
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
        sword.transform.localScale = new Vector3(sword.transform.localScale.x, 0, sword.transform.localScale.z);
    }
       

    void FixedUpdate()
    {
        if (triggerButton.GetStateDown(trackedObj.inputSource)) 
        {
            Debug.Log("trigger " + gameObject.name);
        }

        if (grapButton.GetState(trackedObj.inputSource)) 
        {
            sword.SetActive(true);
            if (swordSize > sword.transform.localScale.y)
            {
                sword.transform.localScale = new Vector3(sword.transform.localScale.x, sword.transform.localScale.y + (Time.deltaTime ), sword.transform.localScale.z);

            }
        }
        else
        {
            sword.transform.localScale = new Vector3(sword.transform.localScale.x, 0, sword.transform.localScale.z);

            sword.SetActive(false);
        }
    }


}

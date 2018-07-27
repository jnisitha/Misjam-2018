using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balence_meter : MonoBehaviour {

    
    public float tick_value;
    public GameObject Player;
    public GameObject PivotPoint;
    playerBalance playerBalanceScript;
    private Image Balance_tick;

    private float currentZ; //degree to rotate player balence tick to

	void Start ()
    {
        playerBalance playerBalanceScript = Player.GetComponent<playerBalance>();
        tick_value = playerBalanceScript.currentBalance*0.02f;

        Balance_tick = this.GetComponent<Image>();
    }
	
	void FixedUpdate ()
    {
        tick_value = Player.GetComponent<playerBalance>().currentBalance * 0.02f;

        if (tick_value>=0)
        {
            currentZ = Mathf.Lerp(-90.0f, -180.0f, tick_value);
            Balance_tick.transform.eulerAngles = new Vector3(0.0f, 90.0f, currentZ);
            PivotPoint.GetComponent<Transform>().eulerAngles = new Vector3(currentZ + 90.0f, 0.0f, 0.0f);
        }
        if (tick_value < 0)
        {
            
            currentZ = Mathf.Lerp(-90.0f, 0.0f, Mathf.Abs(tick_value));
            Balance_tick.transform.eulerAngles = new Vector3(0.0f, 90.0f, currentZ);
            PivotPoint.GetComponent<Transform>().eulerAngles = new Vector3(currentZ + 90.0f, 0.0f, 0.0f);

        }
        //Debug.Log("readvalue " + tick_value);

    }
}

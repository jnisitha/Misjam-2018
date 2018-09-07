using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

    public float score = 1.0f;
    public float scoreMultiplier = 1;
    public GameObject beginObj;
    public GameObject endObj;

    private void Update()
    {
        //scoreMultiplier = BarHeight.getMultiplier(this.GetComponent<GameObject>);
        score += scoreMultiplier * Time.deltaTime;
    }
}

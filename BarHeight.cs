using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarHeight : MonoBehaviour {

    //public enum barHeight {one, two, three, four, five};
    public int barSpeed = 1;
    public float barHeight = 0.0f;
    public int scoreMultiplier = 1;
    private float bottomPosition = 0.0f;
    private float topPosition = 0.0f;

    public float heightScale; //will provide the percentatge the bar is currently between the bottom and top position

    private void Awake()
    {
        bottomPosition = this.transform.localPosition.z;
        topPosition = this.transform.localPosition.z + 1.5f;
        //Debug.Log("Bottom " + bottomPosition);
        //Debug.Log("Top " + topPosition);

    }

    private void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            if (this.transform.localPosition.z < topPosition)
            {
                this.transform.Translate(0, barSpeed * Time.deltaTime, 0, Space.Self);//doesnt work needs hieght adjustment
                //Debug.Log("W Pressed");
            }
            
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if(this.transform.localPosition.z > bottomPosition)
            {
                this.transform.Translate(0, -barSpeed * Time.deltaTime, 0, Space.Self);
                //Debug.Log("S Pressed");
            }
        }

        barHeight = this.transform.localPosition.z;
        heightScale = (barHeight - bottomPosition)/(topPosition-bottomPosition);
        //Debug.Log("Height Scale " + heightScale);

        ScoreMultiplier(heightScale);

    }

    private void ScoreMultiplier(float barHeight)
    {
        //Change to instead base multiplayer on the % scale, each additional 1/3 = +1 multiplier 
        if (barHeight < 0.33f)
        {
            scoreMultiplier = 1;
        }
        else if (barHeight >= 0.33f  && barHeight <= 0.66f)
        {
            scoreMultiplier = 2;
        }
        else if (barHeight > 0.66f)
        {
            scoreMultiplier = 3;
        }
        //else if (barHeight >= bottomPosition+0.3 && barHeight < bottomPosition+0.4)
        //{
        //    scoreMultiplier = 4;
        //}
        //else if (barHeight >= bottomPosition+0.4 && barHeight < bottomPosition+0.5)
        //{
        //    scoreMultiplier = 5;
        //}

        //Debug.Log("multiplier: " + scoreMultiplier);
    }

    public float getMultiplier()
    {
        return scoreMultiplier;
    }
}

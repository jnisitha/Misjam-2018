using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Safe_Zone : MonoBehaviour
{

    private float Fill;
    private float RotateDegree = 17.5f;
    private Image Zone_size;
    private float currentHeight;

    public float Bar_Height = 1.0f;
    public GameObject Player;

    void Start()
    {   
        Zone_size = this.GetComponent<Image>();
    }

    public void FixedUpdate()
    {

        Bar_Height = Player.GetComponent<playerBalance>().barHeight;
        Zone_size.fillAmount = Bar_Height*0.01f;
        Zone_size.transform.eulerAngles = new Vector3(0.0f, 90.0f, Bar_Height* 0.1f * RotateDegree);

        //Debug.Log("Bar height " + Bar_Height);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Follow : MonoBehaviour {

    public GameObject Player;
    private Vector3 player_position;
	
	void FixedUpdate ()
    {
        player_position.x = Player.GetComponent<Transform>().position.x - 1.5f;
        this.transform.position = player_position;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarField : MonoBehaviour {

    private ParticleSystem.Particle[] points;
    private ParticleSystem starParticleSystem;
    private Transform camTransform;
    public int starsMax = 100;
    public float starMinSize = 0.05f;
    public float starMaxSize = 0.06f;
    public float starDistance = 100f;
    public float starDistanceSqrt;


	// Use this for initialization
	void Start () {
        starDistanceSqrt = starDistance * starDistance;;
        camTransform = transform;
        starParticleSystem = gameObject.GetComponent<ParticleSystem>();
	}

    void createStars(){
        points = new ParticleSystem.Particle[starsMax];
        for (int i = 0; i < starsMax; i++){
            points[i].position = Random.insideUnitSphere * starDistance + camTransform.position; // A sphere around the camera
            points[i].startColor = new Color(1f, 1f, 1f, 1f);
            points[i].startSize = Random.Range(starMinSize, starMaxSize);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(points == null){
            createStars();
        }

        for (int i = 0; i < starsMax; i++)
        {
            // get distance of each star from the camera
            if( (points[i].position - camTransform.position).sqrMagnitude > starDistanceSqrt ){
                points[i].position = Random.insideUnitSphere * starDistance + camTransform.position;
            }
        }


        starParticleSystem.SetParticles(points, points.Length); //.particleSystem.setPart

        //particleSystem.setParticles();
	}
}

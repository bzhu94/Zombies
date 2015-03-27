using UnityEngine;
using System.Collections;

public class ZombieConstants : MonoBehaviour {

	
	public static float v = 7; //velocity
	public static int n = 0; //number of zombies
	public static float p = .5f; //probability of despawning when hits a despawning point
	public static float r = .3f; //probability of selecting a HARD zombie

	public static int modernHitCount = 0;
	public static int classicHitCount = 0;
	public static int shamblerHitCount = 0;
	
	// Use this for initialization
	void Start () {
		//InvokeRepeating("PrintBadHitCount", 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void PrintBadHitCount()
	{
		Debug.Log ("modern = " + modernHitCount + ", classic = " + classicHitCount + ", shambler = " + shamblerHitCount);
	}
}

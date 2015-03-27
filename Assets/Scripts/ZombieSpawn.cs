using UnityEngine;
using System.Collections;

public class ZombieSpawn : MonoBehaviour {

	public float hardRatio = (int)(ZombieConstants.r * 100); //this will be the a number between 0 and 100 for random generator

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	//this will spawn a zombie at the opposite corner. the lane will be random
	public static void TrySpawn(string corner)
	{			
		//first instantiate a zombie based on p

		

		float random = (float) Random.Range (0, 3); //the offset
		switch(corner)
		{
		case "tl": //instantiate in bottom right, facing west
			
			
			break;
			
		case "bl":
			
			break;
			
		case "br":
			
			break;
			
		case "tr":
			
			break;
		}
	}
	
}

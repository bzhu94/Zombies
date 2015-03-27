using UnityEngine;
using System.Collections;

public class ZombieDeSpawn : MonoBehaviour {

	private static int prob = (int)(ZombieConstants.p * 100); //this will be the a number between 0 and 100 for random generator
	private enum corner {topLeft, topRight, bottomRight, bottomLeft, none};

	// Use this for initialization
	void Start () {
		prob = (int)(ZombieConstants.p * 100);
		//Debug.Log ("prob start is "+ prob);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//I SHOULDN'T USE STATIC CLASSES IN UNITY... OOPS! WILL START TO GET UGLY
	public static void TryDespawn(GameObject zombie)
	{
		//Debug.Log("TryDespawnCalled");
		int rand = Random.Range (0, 100);
		
		//Debug.Log ("Rand is " + rand + " and prob is "+ prob);
		if(rand < prob) //should despawn!
		{
			string corner = "none"; //if this gets passed in, tryspawn will return error!

			float x = zombie.transform.position.x;
			float z = zombie.transform.position.z;

			if( x > 3.2 && x < 6.8 && z < 19.8 && z > 16.8)
			{
				corner = "tl";
			}
			else if ( x > 3.2 && x < 6.8 && z > 1.2 && z < 3.8)
			{
				corner = "bl";
			}
			else if ( x > 31.2 && x < 33.8 && z > 1.2 && z < 3.8)
			{
				corner = "br";
			}	
			else if ( x > 31.2 && x < 33.8 && z < 19.6 && z > 16.2)
			{
				corner = "tr";
			}
			
			Debug.Log (x + ", " + z + " and the corner was: " + corner);
			//Debug.Log ("Gone!");
			Destroy (zombie); //despawn the zombie...
			
			GameObject.Find("ZombieEngine").GetComponent<ZombieSpawn>().TrySpawn (corner);
			
		}
	}
}

using UnityEngine;
using System.Collections;

public class ZombieSpawnAndDeSpawn : MonoBehaviour {

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
	public static void TryDespawn(GameObject zombie)
	{
		//Debug.Log("TryDespawnCalled");
		int rand = Random.Range (0, 100);
		
		//Debug.Log ("Rand is " + rand + " and prob is "+ prob);
		if(rand < prob) //should despawn!
		{
			//Debug.Log ("Gone!");
			Destroy (zombie); //despawn the zombie...
			TrySpawn ();
		}

		
	}

	public static void TrySpawn()
	{
		
	}
}

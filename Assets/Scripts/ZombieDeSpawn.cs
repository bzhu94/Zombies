using UnityEngine;
using System.Collections;

public class ZombieDeSpawn : MonoBehaviour {

	private static int prob = (int)(ZombieConstants.p * 100); //this will be the a number between 0 and 100 for random generator
	private enum corner {topLeft, topRight, bottomRight, bottomLeft, none};


	public ModernZombie modernPrefab;
	public ClassicZombie classicPrefab;
	public PhoneZombie phonePrefab;
	public ShamblerZombie shamblerPrefab;

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
			string corner = "none"; //if this gets passed in, tryspawn will return error!

			float x = zombie.transform.position.x;
			float z = zombie.transform.position.z;

			if( x > 3.4 && x < 6.6 && z < 19.6 && z > 16.4)
			{
				corner = "tl";
			}
			else if ( x > 3.4 && x < 6.6 && z > 1.4 && z > 3.6)
			{
				corner = "bl";
			}
			else if ( x > 31.4 && x < 33.6 && z > 1.4 && z > 3.6)
			{
				corner = "br";
			}	
			else if ( x > 31.4 && x < 33.6 && z < 19.6 && z > 16.4)
			{
				corner = "tr";
			}
			
			//Debug.Log ("Gone!");
			Destroy (zombie); //despawn the zombie...
			ZombieSpawn.TrySpawn (corner);
			
		}
	}
}

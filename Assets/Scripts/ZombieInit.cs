using UnityEngine;
using System.Collections;

public class ZombieInit : MonoBehaviour {

	
	public ClassicZombie classicPrefab;
	public ShamblerZombie shamblerPrefab;

	// Use this for initialization
	void Start () {
		ZombieInitialize(ZombieConstants.n);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	/* this method will populate the map with n zombies of either shamblers or classics. The zombies will face clockwise*/
	void ZombieInitialize(int n) //don't make over 21!!
	{
		int isClassic; // this int will be randomly picked inside the loop. If 1, the zombie to init is a classic, other wise is a shambler.
		
		//init only on top and bottom. If i%3 = 2, outside, if = 1, mid, if 0, inside.
		//i/3 will correspond to the column. column will start at x = 6.5. Increment this by 3. 
		//top z = 19.5, mid = 18.5, inner = 17.5
	

		for(int i = 0; i < n; i++)
		{
			//determine x, z positions first
			bool outside = false, mid = false, inside = false;
			//find lane or z component
			float x; 
			float z;

			switch(i%3)
			{
				case 2:
					outside = true;
					z = 19.5f;
					break;
				case 1:
					mid = true;
					z = 18.5f;
					break;
				case 0:
					inside = true;
					z = 17.5f;
					break;

				default:
					z = -1000;
					Debug.Log ("you ducked up");
					break;
			}

			//find x component 

			x = 3 * (i/3) + 6.5f;
			
			isClassic = Random.Range (0, 2);
			if(isClassic == 0) //instatiate shambler
			{
				ShamblerZombie s = Instantiate (shamblerPrefab);
				s.dir = ShamblerZombie.direction.E; //face east;
				s.gameObject.transform.position = new Vector3(x, 0, z);
				s.transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way

				if(outside) s.aLane = ShamblerZombie.lane.outside;
				else if (mid) s.aLane = ShamblerZombie.lane.middle;
				else if (inside) s.aLane = ShamblerZombie.lane.inside;

				s.transform.parent = GameObject.Find ("GeneratedZombies").transform;
				
			
			}
			else //classic 
			{
				ClassicZombie classic = Instantiate (classicPrefab);
				classic.dir = ClassicZombie.direction.E; //face east;
				classic.gameObject.transform.position = new Vector3(x, 0, z);
				classic.transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
				
				if(outside) classic.aLane = ClassicZombie.lane.outside;
				else if (mid) classic.aLane = ClassicZombie.lane.middle;
				else if (inside) classic.aLane = ClassicZombie.lane.inside;

				classic.transform.parent = GameObject.Find ("GeneratedZombies").transform;
				
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class ZombieSpawn : MonoBehaviour {

	public  float hardRatio = (int)(ZombieConstants.r * 100); //this will be the a number between 0 and 100 for random generator

	public  GameObject modernPrefab;
	public  GameObject classicPrefab;
	public  GameObject phonePrefab;
	public  GameObject shamblerPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	//this will spawn a zombie at the opposite corner. the lane will be random
	public  void TrySpawn(string corner)
	{			
		//first instantiate a zombie based on p
		string zombieType = "none"; //a bullshit way of telling which zombie is instantiated, coz unity is dumb.
		string lane = "none";
		string dir = "none";

		GameObject zombieSpawn;
		
		int rand = Random.Range (0, 100);

		PhoneZombie phone = null;
		ModernZombie modern = null;
		ClassicZombie classic = null;
		ShamblerZombie shambler = null;
	
		if(rand < hardRatio) //instantiate a hard zombie (50 % a phone zombie)
		{
			int isPhone = Random.Range (0, 2);
			if(isPhone == 1) //create a phone zombie
			{
				zombieSpawn = Instantiate(phonePrefab) as GameObject ;
				zombieType = "phone";
				phone = zombieSpawn.GetComponent<PhoneZombie>();
			}
			else //create a modern zombie
			{
				zombieSpawn = Instantiate(modernPrefab) as GameObject;
				zombieType = "modern";
				modern = zombieSpawn.GetComponent<ModernZombie>();
				
			}
		}		
		else //create easy zombie (50% prob for each)
		{
			int isClassic = Random.Range (0, 2);
			if(isClassic == 1) //create a classic zombie
			{
				zombieSpawn = Instantiate(classicPrefab) as GameObject;
				zombieType = "classic";
				classic = zombieSpawn.GetComponent<ClassicZombie>();
					
			}
			else //create a shambler
			{
				zombieSpawn = Instantiate(shamblerPrefab) as GameObject;
				zombieType = "shambler";
				shambler = zombieSpawn.GetComponent<ShamblerZombie>();
			}
		}

		int off = Random.Range (0, 3); //the offset, always going IN TO OUT!!
		
		//this if chain will determine the lane that the zombie will be spawned in
		if(off == 0)
		{
			lane = "in";
		}
		else if (off == 1)
		{
			lane = "mid";
		}
		else if (off == 2)
		{
			lane = "out";
		}

		switch(corner)
		{
		case "tl": //instantiate in bottom right (since opposite of tl), facing west.
			dir = "W";
			zombieSpawn.transform.Rotate(new Vector3(0, 1, 0), -90); //rotate so zombie is looking right way
			
			switch(lane)
			{
			
				case "in":
				zombieSpawn.transform.position = new Vector3(31.5f, 0, 3.5f);
				break;

				case "mid":
				zombieSpawn.transform.position = new Vector3(32.5f, 0, 2.5f);
				break;

				case "out":
				zombieSpawn.transform.position = new Vector3(33.5f, 0, 1.5f);
				break;
			}

			break;
			
		case "bl": //so spawn top right, facing down

			dir = "S";
			zombieSpawn.transform.Rotate(new Vector3(0, 1, 0), 180); //rotate so zombie is looking right way
			
			switch(lane)
			{
					
				case "in":
					zombieSpawn.transform.position = new Vector3(31.5f, 0, 17.5f);
					break;
					
				case "mid":
					zombieSpawn.transform.position = new Vector3(32.5f, 0, 18.5f);
					break;
					
				case "out":
					zombieSpawn.transform.position = new Vector3(33.5f, 0, 19.5f);
					break;
			}
			
			break;
			
		case "br": //instantiate in top left (since opposite to br), facing east.
			Debug.Log ("br hit!");
			dir = "E";
			zombieSpawn.transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
			
			switch(lane)
			{
				case "in":
					zombieSpawn.transform.position = new Vector3(5.5f, 0, 17.5f);
					break;
					
				case "mid":
					zombieSpawn.transform.position = new Vector3(4.5f, 0, 18.5f);
					break;
					
				case "out":
					zombieSpawn.transform.position = new Vector3(3.5f, 0, 19.5f);
					break;
			}

			break;

		case "tr": //instantiate in bottom left facing up.
			
			dir = "N";
			//NO ROTATE YAY!!
			switch(lane)
			{
					
				case "in":
					zombieSpawn.transform.position = new Vector3(5.5f, 0, 3.5f);
					break;
					
				case "mid":
					zombieSpawn.transform.position = new Vector3(4.5f, 0, 2.5f);
					break;
					
				case "out":
					zombieSpawn.transform.position = new Vector3(3.5f, 0, 1.5f);
					break;
			}
			break;
		}

		//now set the lane of the zombie.

		switch(zombieType)
		{
			case "classic":
			switch(lane)
			{
				case "in":
				classic.aLane = ClassicZombie.lane.inside;
				break;
				
				case "mid":
				classic.aLane = ClassicZombie.lane.middle;
				break;
				
				case "out":
				classic.aLane = ClassicZombie.lane.outside;
				break;
			}		

			if(dir == "N") classic.dir = ClassicZombie.direction.N;
			else if (dir == "E") classic.dir = ClassicZombie.direction.E;
			else if (dir == "S") classic.dir = ClassicZombie.direction.S;
			else if (dir == "W") classic.dir = ClassicZombie.direction.W;
			
			break;
		
			case "shambler":
			switch(lane)
			{
				case "in":
				shambler.aLane = ShamblerZombie.lane.inside;	
				break;
					
				case "mid":
				shambler.aLane = ShamblerZombie.lane.middle;
					break;
					
				case "out":
				shambler.aLane  = ShamblerZombie.lane.outside;
					break;	
			}
	
			if(dir == "N") shambler.dir = ShamblerZombie.direction.N;
			else if (dir == "E") shambler.dir = ShamblerZombie.direction.E;
			else if (dir == "S") shambler.dir = ShamblerZombie.direction.S;
			else if (dir == "W") shambler.dir = ShamblerZombie.direction.W;

			break;
			

			case "modern":
			switch(lane)
			{
			case "in":
				modern.aLane = ModernZombie.lane.inside;	
				break;
				
			case "mid":
				modern.aLane = ModernZombie.lane.middle;
				break;
				
			case "out":
				modern.aLane = ModernZombie.lane.outside;
				break;	
			}

			if(dir == "N") modern.dir = ModernZombie.direction.N;
			else if (dir == "E") modern.dir = ModernZombie.direction.E;
			else if (dir == "S") modern.dir = ModernZombie.direction.S;
			else if (dir == "W") modern.dir = ModernZombie.direction.W;

			break;
	
			case "phone":
			switch(lane)
			{
				case "in":
					phone.aLane = PhoneZombie.lane.inside;
					break;
					
				case "mid":
					phone.aLane = PhoneZombie.lane.middle;
					break;
					
				case "out":
					phone.aLane = PhoneZombie.lane.outside;
					break;
			}

			if(dir == "N") phone.dir = PhoneZombie.direction.N;
			else if (dir == "E") phone.dir = PhoneZombie.direction.E;
			else if (dir == "S") phone.dir = PhoneZombie.direction.S;
			else if (dir == "W") phone.dir = PhoneZombie.direction.W;

			break;
		}

		zombieSpawn.transform.parent = GameObject.Find ("GeneratedZombies").transform; //put this in a gameobject so its neat
		
	}
	
}

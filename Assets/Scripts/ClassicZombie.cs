using UnityEngine;
using System.Collections;

public class ClassicZombie : MonoBehaviour{

	public enum direction {N, E, S, W};
	public enum lane {outside, middle, inside};

	public direction dir;
	public lane aLane;
	public float aSpeed;
	//public int yes;
	
	// Use this for initialization
	void Start () {
		aSpeed = ZombieConstants.v;
	}
	
	// Update is called once per frame
	void Update () {
		AvoidZombieCollision();
		Move ();		
	}

	//so the classic zombie will move in a clockwise fashion. If it hits one of the four corners, it will turn.
	void Move()
	{
		switch(dir)
		{
		case direction.N:
			transform.Translate(new Vector3(0, 0, aSpeed * Time.deltaTime), Space.World); //move up
			break;
		case direction.E:
			transform.Translate(new Vector3(aSpeed * Time.deltaTime, 0, 0), Space.World); //move up
			break;
		case direction.S:
			transform.Translate(new Vector3(0, 0, -aSpeed * Time.deltaTime), Space.World); //move up
			break;
		case direction.W:
			transform.Translate(new Vector3(-aSpeed * Time.deltaTime, 0, 0), Space.World); //move up
			break;
		}
		
	}	
	

	void OnTriggerEnter(Collider other) {
		switch(aLane)
		{
			case lane.outside:
			StayOutsideRing(other);
			break;
	
			case lane.middle:	
			StayMiddleRing(other);
			break;
	
			case lane.inside:
			StayInsideRing(other);
			break;
		}	

		if(other.tag == "Zombie") 
			ZombieConstants.classicHitCount++;
	}
	

	void StayInsideRing(Collider other) //this will make sure that if the zombie hits a collider, he turns and stays on the inside ring
	{
		if(other.gameObject.tag == "Inside") //execute only 
		{
			switch(other.gameObject.name)
			{
			case "InsideCubeBottomLeft": //force to turn north
				
				if(dir != direction.N) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
					ZombieDeSpawn.TryDespawn(gameObject);
					
				}
				
				transform.position = new Vector3(5.5f, 0, 3.5f); //position zombie so its in correct place
				dir = direction.N; //make zombie walk right way
				break;
				
			case "InsideCubeBottomRight": //force to turn west
				
				if(dir != direction.W) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
					ZombieDeSpawn.TryDespawn(gameObject);
					
				}
				transform.position = new Vector3(31.5f, 0, 3.5f);
				dir = direction.W;
				break;
				
			case "InsideCubeTopLeft": //forced to turn east
				
				
				if(dir != direction.E) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
					ZombieDeSpawn.TryDespawn(gameObject);
					
				}
				
				transform.position = new Vector3(5.5f, 0, 17.5f);
				
				dir = direction.E;
				break;
				
			case "InsideCubeTopRight": //forced to turn south
				
				
				if(dir != direction.S) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
					ZombieDeSpawn.TryDespawn(gameObject);
					
				}
				
				transform.position = new Vector3(31.5f, 0, 17.5f);
				
				dir = direction.S;
				break;
			}
		}
	}
	
	void StayMiddleRing(Collider other)//this will make sure that if the zombie hits a collider, he turns and stays on the middle ring
	{
		if(other.gameObject.tag == "Middle") //execute only 
		{
			switch(other.gameObject.name)
			{
			case "MiddleCubeBottomLeft": //force to turn north
				
				if(dir != direction.N) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
					ZombieDeSpawn.TryDespawn(gameObject);
					
				}
				
				transform.position = new Vector3(4.5f, 0, 2.5f); //position zombie so its in correct place
				dir = direction.N; //make zombie walk right way
				break;
				
			case "MiddleCubeBottomRight": //force to turn west
				
				if(dir != direction.W) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
					ZombieDeSpawn.TryDespawn(gameObject);
					
				}
				transform.position = new Vector3(32.5f, 0, 2.5f);
				dir = direction.W;
				break;
				
			case "MiddleCubeTopLeft": //forced to turn east
				
				
				if(dir != direction.E) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
					ZombieDeSpawn.TryDespawn(gameObject);
					
				}
				
				transform.position = new Vector3(4.5f, 0, 18.5f);
				
				dir = direction.E;
				break;
				
			case "MiddleCubeTopRight": //forced to turn south
				
				
				if(dir != direction.S) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
					ZombieDeSpawn.TryDespawn(gameObject);
					
				}
				
				transform.position = new Vector3(32.5f, 0, 18.5f);
				
				dir = direction.S;
				break;
			}
		}
	}
	
	void StayOutsideRing(Collider other) //this will make sure that if the zombie hits a collider, he turns and stays on the outside ring
	{
		if(other.gameObject.tag == "Outside") //execute only 
		{
			switch(other.gameObject.name)
			{
			case "OutsideCubeBottomLeft": //force to turn north
				
				if(dir != direction.N) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
					ZombieDeSpawn.TryDespawn(gameObject);
					
				}
				transform.position = new Vector3(3.5f, 0, 1.5f); //position zombie so its in correct place
				dir = direction.N; //make zombie walk right way
				break;
				
			case "OutsideCubeBottomRight": //force to turn west
				
				if(dir != direction.W) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
					ZombieDeSpawn.TryDespawn(gameObject);
					
				}
				transform.position = new Vector3(33.5f, 0, 1.5f);
				dir = direction.W;
				break;
				
			case "OutsideCubeTopLeft": //forced to turn east
				
				
				if(dir != direction.E) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
					ZombieDeSpawn.TryDespawn(gameObject);
					
				}
				
				transform.position = new Vector3(3.5f, 0, 19.5f);
				
				dir = direction.E;
				break;
				
			case "OutsideCubeTopRight": //forced to turn south
				
				
				if(dir != direction.S) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
					ZombieDeSpawn.TryDespawn(gameObject);
					
				}
				
				transform.position = new Vector3(33.5f, 0, 19.5f);
				
				dir = direction.S;
				break;
			}
		}
	}

	//we will only try to avoid colliding into 1 type of zombie: the shambler, because classic zombies can't change lanes.
	//However, since classic zombies have a max speed greater than that of the shambler's, if a raycast FORWARD hits a shambler, it will slow down to v/2 to match the shambler
	//only for the duration that the shambler hits the classic zombie's raycast.
	void AvoidZombieCollision() 
	{
		//if the raycast doesn't hit a shambler, let speed be v (the normal max speed)
		bool hitShambler = false;
		
		//these lines of code will shoot the raycast, and then will try to change lanes if raycast hits.
		RaycastHit front;
		Ray frontRay = new Ray(transform.position + transform.forward * .5f + transform.up * .5f , transform.forward);
		Debug.DrawRay(transform.position + transform.forward * .5f + transform.up * .5f , transform.forward, Color.green);
		
		if(Physics.Raycast(frontRay, out front, 1.5f))
		{
			if(front.collider.gameObject.tag == "Zombie")
			{
				//this code will check if the zombie is of type shambler. 
				ShamblerZombie script = front.collider.gameObject.GetComponent<ShamblerZombie>();
				if(script != null)
				{
					aSpeed = ZombieConstants.v / 2 ;
					hitShambler = true;
				}

				//this code will check if the zombie is of type shambler. 
				ClassicZombie classicScript = front.collider.gameObject.GetComponent<ClassicZombie>();
				if(classicScript != null)
				{
					aSpeed = classicScript.aSpeed;
					hitShambler = true;
				}
			}
		}

		//here the speed is returned to normal as soon as the raycast stops hitting a shambler
		if(hitShambler == false)
			aSpeed = ZombieConstants.v;
	} 
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhoneZombie : MonoBehaviour {
	
	public enum direction {N, E, S, W};
	public enum lane {outside, middle, inside};
	
	public lane aLane;
	public direction dir;

	public bool stopping;

	public float aSpeed; //this will always be positive. Only determines the magnitude of the speed, not the direction (direction enum takes care of that)

	public float epsilon;
	// Use this for initialization
	void Start () {	
		stopping = false;
		InvokeRepeating("ChangeSpeed", 1, 3);
		InvokeRepeating("ChangeDirection", 1, 10);
		InvokeRepeating("RandomlyChangeLanes", 1, 3); //zombie will randomly attempt to change lanes every given time interval
		InvokeRepeating("ToggleStopping", .5f, 4);
		aSpeed = ZombieConstants.v; //make start speed normal. 
		epsilon = .8f;
	}
	
	// Update is called once per frame
	void Update () {
		//checkTurn ();
		AvoidZombieCollision();
		Move ();
	}
	
	//the shambler zombie will move at half speed.
	
	void ToggleStopping()
	{
		stopping = !stopping;
	}

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
		
		StayOutsideRing(other);	
		
		if(other.tag == "Zombie") ZombieConstants.modernHitCount++;
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

			
			//now do reverse...
			case "ITL": 
				
				if(dir != direction.S) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), -90); //rotate so zombie is looking right way
					ZombieDeSpawn.TryDespawn(gameObject);
				}

				
				transform.position = new Vector3(5.5f, 0, 17.5f); //position zombie so its in correct place
				dir = direction.S; //make zombie walk right way
				break;
				
			case "ITR": //turn west
				
				if(dir != direction.W) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), -90); //rotate so zombie is looking right way
					ZombieDeSpawn.TryDespawn(gameObject);
				}
				
				transform.position = new Vector3(31.5f, 0, 17.5f);
				dir = direction.W;
				break;
				
			case "IBR": //forced to turn north
				
				if(dir != direction.N) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), -90); //rotate so zombie is looking right way
					ZombieDeSpawn.TryDespawn(gameObject);
				}
				
				transform.position = new Vector3(31.5f, 0, 3.5f);
				
				dir = direction.N;
				break;
				
			case "IBL": //forced to turn south
				
				if(dir != direction.E) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), -90); //rotate so zombie is looking right way
					ZombieDeSpawn.TryDespawn(gameObject);
				}
				
				transform.position = new Vector3(5.5f, 0, 3.5f);
				
				dir = direction.E;
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

				//now do reverse....
				case "MBL": //turn east
					
					if(dir != direction.E) //makes sure zombie isn't rotated multiple times in a turn
					{
						transform.Rotate(new Vector3(0, 1, 0), -90); //rotate so zombie is looking right way
						ZombieDeSpawn.TryDespawn(gameObject);
					}
					
					transform.position = new Vector3(4.5f, 0, 2.5f); //position zombie so its in correct place
					dir = direction.E; //make zombie walk right way
					break;
					
				case "MBR": //force to turn west
					
					if(dir != direction.N) //makes sure zombie isn't rotated multiple times in a turn
					{
						transform.Rotate(new Vector3(0, 1, 0), -90); //rotate so zombie is looking right way
						ZombieDeSpawn.TryDespawn(gameObject);
					}
					
					transform.position = new Vector3(32.5f, 0, 2.5f);
					dir = direction.N;
					break;
					
				case "MTL": //forced to turn east
					
					
					if(dir != direction.S) //makes sure zombie isn't rotated multiple times in a turn
					{
						transform.Rotate(new Vector3(0, 1, 0), -90); //rotate so zombie is looking right way
						ZombieDeSpawn.TryDespawn(gameObject);
					}
					
					transform.position = new Vector3(4.5f, 0, 18.5f);
					
					dir = direction.S;
					break;
					
				case "MTR": //forced to turn south
					
					
					if(dir != direction.W) //makes sure zombie isn't rotated multiple times in a turn
					{
						transform.Rotate(new Vector3(0, 1, 0), -90); //rotate so zombie is looking right way
						ZombieDeSpawn.TryDespawn(gameObject);
					}
					
					transform.position = new Vector3(32.5f, 0, 18.5f);
					
					dir = direction.W;
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

			//reverse
			case "OBL": //force to turn north
				
				if(dir != direction.E) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), -90); //rotate so zombie is looking right way
					ZombieDeSpawn.TryDespawn(gameObject);
				}				
				transform.position = new Vector3(3.5f, 0, 1.5f); //position zombie so its in correct place
				dir = direction.E; //make zombie walk right way
				break;
				
			case "OBR": //force to turn west
				
				if(dir != direction.N) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), -90); //rotate so zombie is looking right way
					ZombieDeSpawn.TryDespawn(gameObject);
				}	
				
				transform.position = new Vector3(33.5f, 0, 1.5f);
				dir = direction.N;
				break;
				
			case "OTL": //forced to turn east
				
				
				if(dir != direction.S) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), -90); //rotate so zombie is looking right way
					ZombieDeSpawn.TryDespawn(gameObject);
				}	
				
				transform.position = new Vector3(3.5f, 0, 19.5f);
				
				dir = direction.S;
				break;
				
			case "OTR": //forced to turn south
				
				
				if(dir != direction.W) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), -90); //rotate so zombie is looking right way
					ZombieDeSpawn.TryDespawn(gameObject);
				}				
				
				transform.position = new Vector3(33.5f, 0, 19.5f);
				
				dir = direction.W;
				break;
			}
		}
	}

	/*
	ChangeLanes will:
	1. Check to see if left and/or right lanes are open for changing (i.e. 
	2. 
	2. 
	*/
	void RandomlyChangeLanes()
	{
		if(stopping) return; //if the zombie has stopped, don't do anything

		List<bool> lanesClearList = lanesClear();
		bool leftClear = lanesClearList[0];
		bool rightClear = lanesClearList[1];
		
		//Debug.Log ("left: " + lanesClearList[0] + ", right: " + lanesClearList[1]);
		Vector3 pos = transform.position;
		
		switch(aLane)
		{
		case lane.inside: //lane before is inside, can only change to middle (this is allowed to happen ANYTIME, unlike middle and outside
			
			if(leftClear)
			{
				if(((pos.x == 5.5 || pos.x == 31.5) && pos.z > 3.5 && pos.z < 16.5) 
				   || ((pos.z == 3.5 || pos.z == 17.5) && pos.x > 6.5 && pos.x < 30.5))
				{
					
					aLane = lane.middle;

					
					transform.Translate(transform.right * -1, Space.World); //does actual shift
					//Debug.Log ("Inside works: before =  " + pos + ", after" + transform.position);
					
				}
				//else Debug.Log ("inside fail: " + pos.x + ", " + pos.z);
				
			}
			//Debug.Log("insidefail: " + pos.x + ", " + pos.z);
			break;
			
		case lane.middle: //lane before is middle
			if(((pos.x == 4.5 || pos.x == 32.5) && pos.z > 3.5 && pos.z < 16.5) 
			   || ((pos.z == 2.5 || pos.z == 18.5) && pos.x > 6.5 && pos.x < 30.5)) //this code checks to make sure
			{	
				
				if(leftClear && ! rightClear) //go to the left!
				{
					aLane = lane.outside;
					transform.Translate(-1 * transform.right, Space.World);
				}
				else if (!leftClear && rightClear) //go to the right!
				{
					aLane = lane.inside;
					transform.Translate(transform.right, Space.World);
				}
				else if (leftClear && rightClear) //randomly pick whether to go to the left or right
				{
					int rand = Random.Range(0, 2); //if rand is 0 go left, else go right
					
					if(rand == 0)
					{
						aLane = lane.outside;
						transform.Translate(-1 * transform.right, Space.World);
					}
					else 
					{
						aLane = lane.inside;
						transform.Translate(transform.right, Space.World);
					}
				}
				else if (!leftClear && !rightClear) //do nothing, can't change lanes because another zombie is blocking!
				{
					//Debug.Log ("Cant change lanes, target lane(s) occupied by zombies!");
				}
				
				//Debug.Log ("Mid works: before =  " + pos + ", after" + transform.position + " and lane is: " + aLane);
				
			}
			//else Debug.Log ("middle fail: " + pos.x + ", " + pos.z);
			break;
			
		case lane.outside: //lane before is outside, so can only go to the middle
			//Debug.Log ("test outside: pos.x = " + pos.x + ", pos.z = " + pos.z);
			
			if(((pos.x == 3.5 || pos.x == 33.5) && pos.z > 3.5 && pos.z < 16.5) 
			   || ((pos.z == 1.5 || pos.z == 19.5) && pos.x > 6.5 && pos.x < 30.5)) //this code checks to make sure
			{
				if(rightClear)
				{
					aLane = lane.middle;
					transform.Translate(transform.right, Space.World); //does actual shift
					//Debug.Log ("Outside works: before =  " + pos + ", after" + transform.position);
					
				}
				//else Debug.Log ("right clear is false");
			}
			//	else Debug.Log ("outside fail: pos.x is: " + pos.x + ", pos.z is: " + pos.z);
			break;
			
		}	
	}
	
	List<bool> lanesClear() //returns a list of 2 booleans. First bool will check whether left lane is clear. Second bool will check whether right lane is clear.
	{
		List<bool> result = new List<bool>();
		//these 2 booleans will be used later to determine whether it is safe to move to the left or right.
		bool leftClear = true;
		bool rightClear = true;
		
		//here, left refers to lefthand side of where zombie faces. So left will always point towards the boundary wall.
		//right will always point into the obstacle
		
		//these 4 blocks of code initialize the variables for raycasting to check the 
		RaycastHit tlOut;
		Ray tl = new Ray(transform.position + transform.forward * .5f - transform.right * .5f + transform.up * .5f , -transform.right);
		//Debug.DrawRay(transform.position + transform.forward * .5f - transform.right * .5f + transform.up * .5f , -transform.right, Color.black);
		
		RaycastHit blOut;
		Ray bl = new Ray(transform.position + transform.forward * -.5f - transform.right * .5f + transform.up * .5f , -transform.right);
		//Debug.DrawRay(transform.position + transform.forward * -.5f - transform.right * .5f + transform.up * .5f , -transform.right, Color.black);
		
		RaycastHit trOut;
		Ray tr = new Ray(transform.position + transform.forward * .5f + transform.right * .5f + transform.up * .5f , transform.right);
		//Debug.DrawRay(transform.position + transform.forward * .5f + transform.right * .5f + transform.up * .5f , transform.right, Color.black);
		
		RaycastHit brOut;
		Ray br = new Ray(transform.position + transform.forward * -.5f + transform.right * .5f + transform.up * .5f , transform.right);
		//Debug.DrawRay(transform.position + transform.forward * -.5f + transform.right * .5f + transform.up * .5f , transform.right, Color.black);
		
		//these 4 blocks of code will set the leftClear and rightClear booleans 
		if(Physics.Raycast(bl, out blOut, 1))
		{
			if(blOut.collider.gameObject.tag == "Zombie")
			{
				leftClear = false;
			}
		}
		
		if(Physics.Raycast(tl, out tlOut, 1))
		{
			if(tlOut.collider.gameObject.tag == "Zombie")
			{
				leftClear = false;
			}
		}
		
		if(Physics.Raycast(tr, out trOut, 1))
		{
			if(trOut.collider.gameObject.tag == "Zombie")
			{
				rightClear = false;
			}
		}
		
		if(Physics.Raycast(br, out brOut, 1))
		{
			if(brOut.collider.gameObject.tag == "Zombie")
			{
				rightClear = false;
			}
		}
		
		//result[0] = leftClear;
		//result[1] = rightClear;
		
		result.Add(leftClear);
		result.Add(rightClear);
		
		return result;
	}
	
	/*
	This method will raycast to the front and back of the zombie.
	If the either raycast hits a zombie, then attempt to change lanes.
	Since a shambler's max speed is v/2, shambler will never change speed. 
	However, other zombies will to avoid collisions
	*/
	

	void ChangeSpeed () //responsible for the direction (NESW) AND the magnitude of the speed. Magnitude is always positive
	{	
		if (stopping) aSpeed = 0;
		else aSpeed = ZombieConstants.v * Random.Range (.5f, 2); //magnitude of speed
	}

	void ChangeDirection()
	{
		switch(dir)
		{
			case direction.N:	
				dir = direction.S;
				break;
			case direction.E:
				dir = direction.W;
				break;
			case direction.S:
				dir = direction.N;
				break;
			case direction.W:
				dir = direction.E;
				break;			
		}

		//transform.Rotate(new Vector3(0, 1, 0), 180); //rotate so zombie is looking right way	
		
	}

	void AvoidZombieCollision() 
	{
		bool hitFrontZombie = false;
		
		//these lines of code will shoot the raycast, and then will try to change lanes if raycast hits.
		RaycastHit front;
		Ray frontRay = new Ray(transform.position + transform.forward * .5f + transform.up * .5f , transform.forward);
		Debug.DrawRay(transform.position + transform.forward * .5f + transform.up * .5f , transform.forward, Color.green);
		
		//change speeds and change lanes according to the zombie raycast hits.
		if(Physics.Raycast(frontRay, out front, 2))
		{
			if(front.collider.gameObject.tag == "Zombie")
			{
				//this code will check if the zombie is of type shambler. 
				ShamblerZombie shamblerScript= front.collider.gameObject.GetComponent<ShamblerZombie>();
				if(shamblerScript != null)
				{
					aSpeed = ZombieConstants.v / 2 ; //change speed to v/2, since shambler has only 1 speed
					hitFrontZombie = true;
					RandomlyChangeLanes();
				}
				
				ModernZombie modernScript = front.collider.gameObject.GetComponent<ModernZombie>();
				if(modernScript != null)
				{
					aSpeed = modernScript.aSpeed;
					hitFrontZombie = true;
					RandomlyChangeLanes();
				}
				
				
				ClassicZombie classicScript = front.collider.gameObject.GetComponent<ClassicZombie>();
				if(classicScript != null)
				{
					aSpeed = classicScript.aSpeed;
					hitFrontZombie = true;
					RandomlyChangeLanes();
				}
			}
		}

		//if back raycast hits, just try to change lanes (not speed)
		RaycastHit back;
		Ray backRay = new Ray(transform.position + -transform.forward * .5f + transform.up * .5f , -transform.forward);
		//Debug.DrawRay(transform.position + -transform.forward * .5f + transform.up * .5f , -transform.forward, Color.green);

		if(Physics.Raycast(backRay, out back, 3))
		{
			if(back.collider.gameObject.tag == "Zombie")
			{
				//this code will check if the zombie is of type shambler. 
				ShamblerZombie shamblerScript= back.collider.gameObject.GetComponent<ShamblerZombie>();
				if(shamblerScript != null)
				{
					aSpeed = ZombieConstants.v / 2 ; //change speed to v/2, since shambler has only 1 speed
					dir = (direction) System.Enum.Parse(typeof(direction), shamblerScript.dir.ToString());
					//transform.rotation = back.transform.rotation;
					
					hitFrontZombie = true;
					RandomlyChangeLanes();
				}
				
				ModernZombie modernScript = back.collider.gameObject.GetComponent<ModernZombie>();
				if(modernScript != null)
				{
					aSpeed = modernScript.aSpeed;
					dir = (direction) System.Enum.Parse(typeof(direction), modernScript.dir.ToString());
					//transform.rotation = back.transform.rotation;
					
					hitFrontZombie = true;
					RandomlyChangeLanes();
					//Debug.Log ("BADD");
				}
				
				
				ClassicZombie classicScript = back.collider.gameObject.GetComponent<ClassicZombie>();
				if(classicScript != null)
				{
					//Debug.Log ("hit by classic");
					aSpeed = classicScript.aSpeed;
					//dir = (direction) System.Enum.Parse(typeof(direction), classicScript.dir.ToString());
					//transform.rotation = front.transform.rotation;
					hitFrontZombie = true;
					RandomlyChangeLanes();
				}
				
				PhoneZombie phoneScript = back.collider.gameObject.GetComponent<PhoneZombie>();
				if(phoneScript != null)
				{
					//Debug.Log ("BOOM");
					aSpeed = phoneScript.aSpeed;
					//dir = (direction) System.Enum.Parse(typeof(direction), phoneScript.dir.ToString());
					//transform.rotation = back.transform.rotation;
					
					hitFrontZombie = true;
					RandomlyChangeLanes();
				}
			}
		}
	}

}
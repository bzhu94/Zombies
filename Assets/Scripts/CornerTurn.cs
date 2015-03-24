using UnityEngine;
using System.Collections;

public class CornerTurn : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/*
	public static void StayInsideRing(Collider other, string dir) //this will make sure that if the zombie hits a collider, he turns and stays on the inside ring
	{
		if(other.gameObject.tag == "Inside") //execute only 
		{
			switch(other.gameObject.name)
			{
			case "InsideCubeBottomLeft": //force to turn north
				
				if(dir != direction.N) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
				}
				
				transform.position = new Vector3(5.5f, 0, 3.5f); //position zombie so its in correct place
				dir = direction.N; //make zombie walk right way
				break;
				
			case "InsideCubeBottomRight": //force to turn west
				
				if(dir != direction.W) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
				}
				transform.position = new Vector3(31.5f, 0, 3.5f);
				dir = direction.W;
				break;
				
			case "InsideCubeTopLeft": //forced to turn east
				
				
				if(dir != direction.E) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
				}
				
				transform.position = new Vector3(5.5f, 0, 17.5f);
				
				dir = direction.E;
				break;
				
			case "InsideCubeTopRight": //forced to turn south
				
				
				if(dir != direction.S) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
				}
				
				transform.position = new Vector3(31.5f, 0, 17.5f);
				
				dir = direction.S;
				break;
			}
		}
	}
	
	void StayMiddleRing(Collider other, string dir)//this will make sure that if the zombie hits a collider, he turns and stays on the middle ring
	{
		if(other.gameObject.tag == "Middle") //execute only 
		{
			switch(other.gameObject.name)
			{
			case "MiddleCubeBottomLeft": //force to turn north
				
				if(dir != direction.N) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
				}
				
				transform.position = new Vector3(4.5f, 0, 2.5f); //position zombie so its in correct place
				dir = direction.N; //make zombie walk right way
				break;
				
			case "MiddleCubeBottomRight": //force to turn west
				
				if(dir != direction.W) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
				}
				transform.position = new Vector3(32.5f, 0, 2.5f);
				dir = direction.W;
				break;
				
			case "MiddleCubeTopLeft": //forced to turn east
				
				
				if(dir != direction.E) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
				}
				
				transform.position = new Vector3(4.5f, 0, 18.5f);
				
				dir = direction.E;
				break;
				
			case "MiddleCubeTopRight": //forced to turn south
				
				
				if(dir != direction.S) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
				}
				
				transform.position = new Vector3(32.5f, 0, 18.5f);
				
				dir = direction.S;
				break;
			}
		}
	}
	
	void StayOutsideRing(Collider other, string ) //this will make sure that if the zombie hits a collider, he turns and stays on the outside ring
	{
		if(other.gameObject.tag == "Outside") //execute only 
		{
			switch(other.gameObject.name)
			{
			case "OutsideCubeBottomLeft": //force to turn north
				
				if(dir != direction.N) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
				}
				//Debug.Log ("BOOM ");
				transform.position = new Vector3(3.5f, 0, 1.5f); //position zombie so its in correct place
				dir = direction.N; //make zombie walk right way
				break;
				
			case "OutsideCubeBottomRight": //force to turn west
				
				if(dir != direction.W) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
				}
				transform.position = new Vector3(33.5f, 0, 1.5f);
				dir = direction.W;
				break;
				
			case "OutsideCubeTopLeft": //forced to turn east
				
				
				if(dir != direction.E) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
				}
				
				transform.position = new Vector3(3.5f, 0, 19.5f);
				
				dir = direction.E;
				break;
				
			case "OutsideCubeTopRight": //forced to turn south
				
				
				if(dir != direction.S) //makes sure zombie isn't rotated multiple times in a turn
				{
					transform.Rotate(new Vector3(0, 1, 0), 90); //rotate so zombie is looking right way
				}
				
				transform.position = new Vector3(33.5f, 0, 19.5f);
				
				dir = direction.S;
				break;
			}
		}
	}
	*/
}

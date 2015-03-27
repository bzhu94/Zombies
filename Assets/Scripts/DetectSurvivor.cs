using UnityEngine;
using System.Collections;

public class DetectSurvivor : MonoBehaviour {

	public Transform zombieTransform; //every update it will set the transform and rotation to that of the zombie.
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(zombieTransform != null)
		{
			transform.position = zombieTransform.position;
			transform.rotation = zombieTransform.rotation;
		}
		else 
		{
			Destroy(gameObject);	
		}
	}

	void OnTriggerEnter(Collider other)
	{	
		if(other.gameObject.tag == "Survivor")
		{
			Debug.Log ("Survivor has been detected. GG MOFO");
			other.gameObject.SetActive(false);
		}
	}
}

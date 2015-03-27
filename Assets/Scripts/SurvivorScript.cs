using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SurvivorScript : MonoBehaviour {

	public int coinCount = 0;
	public Transform target;
	NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if(coinCount == 14)
		{
			agent.SetDestination(target.position);
		}
		goTowardsNearestCoin();
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Coin")
		{
			coinCount++;
			other.gameObject.SetActive(false);
			Debug.Log ("Coin destroyed");
			
		}
	}

	void goTowardsNearestCoin()
	{
		GameObject[] coinsTemp = GameObject.FindGameObjectsWithTag("Coin");
		List<GameObject> coinsRemaining = new List<GameObject>();

		foreach (GameObject g in coinsTemp)
		{
			if (g.activeInHierarchy == true) coinsRemaining.Add (g);
		}

		coinsRemaining.Sort(ByDistance); //sort from least to greatest

		if(coinsRemaining.Count > 0)
		agent.SetDestination(coinsRemaining[0].transform.position); //go to the nearest coin
	}

	int ByDistance(GameObject a, GameObject b)
	{
		float distToA =  Vector3.Distance(transform.position, a.transform.position);
		float distToB =  Vector3.Distance(transform.position, b.transform.position);
		return distToA.CompareTo(distToB);
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
	public GameObject asteroidPrefab;

	private GameObject[] lanes = new GameObject[3];

	private List<GameObject> asteroidPool = new List<GameObject>();
	private int initialPoolSize = 10;
 
	void Awake () 
	{
		lanes = GameObject.FindGameObjectsWithTag("Lane");

		for(int i=0; i<initialPoolSize; i++)
		{
			CreateNewAsteroid();
		}

		StartCoroutine(SpawnAsteroids());
	}

	IEnumerator SpawnAsteroids()
	{	
		//Determine what lane won't spawn an asteroid	
		int safeLane = Random.Range(0, 3);
		bool[] activeLanes = new bool[3];
		activeLanes[safeLane] = true;

		//1 or 2 asteroids spawn each time
		int numAsteroids = Random.Range(1,3);

		while(numAsteroids>0)
		{
			for(int i=0; i<activeLanes.Length; i++)
			{
				if(!activeLanes[i])
				{
					GameObject asteroid = GetAsteroidFromPool();
					if(asteroid != null)
					{
						activeLanes[i] = true;
						asteroid.SetActive(true);
						asteroid.SendMessage("Initialize", lanes[i].transform);
					}
					break;
				}
			}
			numAsteroids--;
		}

		yield return new WaitForSeconds(3);
		StartCoroutine(SpawnAsteroids());
	}

	GameObject GetAsteroidFromPool()
	{
		foreach(GameObject asteroid in asteroidPool)
		{
			if(!asteroid.activeSelf)
			{
				return asteroid;
			}
		}

		//If there's no asteroid in pool, create a new one.
		return CreateNewAsteroid();
	}

	GameObject CreateNewAsteroid()
	{
		GameObject newAsteroid = Instantiate(asteroidPrefab, transform.position, Quaternion.identity);
		newAsteroid.SetActive(false);
		asteroidPool.Add(newAsteroid);

		return newAsteroid;
	}
}

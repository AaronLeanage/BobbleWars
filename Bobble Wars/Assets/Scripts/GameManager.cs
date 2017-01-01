using UnityEngine;
using System.Collections;
using System.Collections.Generic; //Allows use of generic arrays

public class GameManager : MonoBehaviour {
	public GameObject Player;
	public GameObject[] spawnPoints;
	public GameObject Alien;

	public int maxAliensOnScreen; 
	public int totalAliens; //Number of Aliens defeated to win
	public float minSpawnTime; //Values for rate at which Aliens spawn
	public float maxSpawnTime;
	public int aliensPerSpawn; //How many to appear during a spawn event

	private int aliensOnScreen = 0; //Track number on screen
	private float generatedSpawnTime = 0; //Track time between spawn events (randomise it later)
	private float currentSpawnTime = 0; //Will track time since last spawn

	void Start () {
	
	}

	void Update () {
		currentSpawnTime += Time.deltaTime; 
		if (currentSpawnTime > generatedSpawnTime) {//When the amount of time since last spawn is greater than a random amount of time
			currentSpawnTime = 0; //Reset interval to 0
			generatedSpawnTime = Random.Range(minSpawnTime, maxSpawnTime); //Set it to a random value within the range of the max and min values

			if (aliensPerSpawn > 0 && aliensOnScreen < totalAliens) {//Self explanatory really
				List<int> previousSpawnLocations = new List<int>(); // Keeps track of which spawn points were used and in which order

				if (aliensPerSpawn > spawnPoints.Length) {
					aliensPerSpawn = spawnPoints.Length - 1; //Prevents more aliens being spawned than spawn points
				}
				aliensPerSpawn = (aliensPerSpawn > totalAliens) ? aliensPerSpawn - totalAliens : aliensPerSpawn; //Prevents more aliens spawning than allowed in max

				//Actual spawn code below:
				for (int i = 0; i < aliensPerSpawn; i++) {//Loop iterates once for each alien to be spawned
					if (aliensOnScreen < maxAliensOnScreen) {//Checks if current number on screen is less than allowed
						aliensOnScreen += 1; //Adds one to being on screen
						//Because array indexes start at 0, -1 is technically 0 and 0 is the first spawn point
						int spawnPoint = -1;
						//Keep looping around until a spawn point is found
						while (spawnPoint == -1) {
							//Produce a random number that says which spawn to use
							int randomNumber = Random.Range(0, spawnPoints.Length - 1);
							//Check if theat spawn point has previously been used, if not, add it to the list and set the spawn point to this one
							if (!previousSpawnLocations.Contains(randomNumber)) {
								previousSpawnLocations.Add(randomNumber);
								spawnPoint = randomNumber;
							}
						}
						//Create the alien and set the position to the position of the spawn point
						GameObject spawnLocation = spawnPoints[spawnPoint];
						GameObject newAlien = Instantiate(Alien) as GameObject;
						newAlien.transform.position = spawnLocation.transform.position;

					}				
				}
			}

		}
	}
}

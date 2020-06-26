using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
	private GameObject deathFloor;
	public GameObject SpawnPoint;
	public GameObject Particle;
	public bool thisIsHUB;
	private bool alreadyActive;
	private AudioManager audioManager;
	private void Awake()
	{
		deathFloor = GameObject.Find("DeathFloor");
		audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		if(thisIsHUB)
		if(PlayerPrefs.HasKey("PlayedTutorial"))
		{
			if(PlayerPrefs.GetInt("PlayedTutorial") == 1)
			{
				deathFloor.GetComponent<DeathHandler>().actualSpawnPoint = SpawnPoint;
				Particle.SetActive(true);
			}

	
		}
	
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerStay(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			if(Input.GetKeyDown(KeyCode.E))
			{
				if (!alreadyActive)
				{
					deathFloor.GetComponent<DeathHandler>().actualSpawnPoint = SpawnPoint;
					audioManager.PlaySound("Checkpoint");
					Particle.SetActive(true);
					if (thisIsHUB)
					{
						PlayerPrefs.SetInt("PlayedTutorial", 1);
					}
				}
				alreadyActive = true;
			}
		}
	}
}

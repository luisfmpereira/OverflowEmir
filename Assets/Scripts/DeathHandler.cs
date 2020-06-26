using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
	public GameObject actualSpawnPoint;
	private GameObject player;
    private Camera cam;
	private AudioManager audioManager;

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;
		audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			other.transform.position = actualSpawnPoint.transform.position;
			audioManager.PlaySound("Died");
		}
	}

	public void PlayerDied()
	{
		player.transform.position = actualSpawnPoint.transform.position;
        cam.transform.position = actualSpawnPoint.transform.position;
		audioManager.PlaySound("Died");

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SaveHUB : MonoBehaviour
{
	private GameObject player;
	public GameObject[] spawnHub;
	public GameObject options;
	private AudioManager audioManager;
	[SerializeField]
	private GameObject[] dialogo;



	private void Awake()
	{
		audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		player = GameObject.Find("Player");

		if (PlayerPrefs.HasKey("SetSpawnHub"))
		{
				switch (PlayerPrefs.GetInt("SetSpawnHub"))
				{
					default:
						break;
					case 1:
						player.transform.position = spawnHub[1].transform.position;
						break;
					case 2:
						player.transform.position = spawnHub[2].transform.position;
						break;
					case 3:
						player.transform.position = spawnHub[3].transform.position;
						break;
				}
		}
		else if (PlayerPrefs.HasKey("PlayedTutorial"))
		{
			if (PlayerPrefs.GetInt("PlayedTutorial") == 1)
			{
				player.transform.position = spawnHub[0].transform.position;
			}
		}
		for (int i = 0; i < dialogo.Length; i++)
		{
			if (PlayerPrefs.HasKey("Dialogo" + i))
			{
				dialogo[i].SetActive(false);
			}
		}
		if(!PlayerPrefs.HasKey("PlayedTutorial"))
		{
			dialogo[1].SetActive(true);
			dialogo[2].SetActive(true);
			dialogo[3].SetActive(true);
		}


		if (Global.actualLevel == 1 || PlayerPrefs.GetInt("SetSpawnHub") == 1)
		{
			dialogo[4].SetActive(true);
			dialogo[5].SetActive(true);
			dialogo[6].SetActive(true);
			dialogo[7].SetActive(true);
		}
		if (Global.actualLevel == 2 || PlayerPrefs.GetInt("SetSpawnHub") == 2)
		{
			dialogo[8].SetActive(true);
			dialogo[9].SetActive(true);
		}

		if (Global.actualLevel == 3 || PlayerPrefs.GetInt("SetSpawnHub") == 3)
		{
			dialogo[12].SetActive(true);
			dialogo[13].SetActive(true);
			dialogo[14].SetActive(true);
		}

	}

	private void Start()
	{

	}

	public void continueButton()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		Time.timeScale = 1;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			options.SetActive(true);
			Time.timeScale = 0;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}

	public void MainMenuButton()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(0);
		audioManager.StopSound("WindDesert");
	}
}

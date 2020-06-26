using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogoManager : MonoBehaviour
{
	public bool onAwake;
	public bool canBlockMovement;
	public GameObject player;
	public MitraMovement mitraMovement;
	public WaterMovement water;
	private GameObject deathFloor;
	public int numberToSetPlayerPrefs;
	public string[] dialogo;
	public Text textDialogo;
	public GameObject image;
	public GameObject creditos;

	public bool activated;
	public int[] numeroDialogo;
	public int[] timeTexts;
	public bool useOnlyOneTime;
	public MitraMovement callMethods;
	public GameObject[] spawnAfterLevel;

	[SerializeField]
	private bool canCallLevel1;
	[SerializeField]
	private bool canOpenPortal1;
	[SerializeField]
	private bool canGoAfterLevel1;
	[SerializeField]
	private bool canGoMiddle;
	[SerializeField]
	private bool canGoToLevel2;
	[SerializeField]
	private bool canGoToLevel3;
	[SerializeField]
	private bool endGame;
	private AudioManager audioManager;


	private void Awake()
	{
		deathFloor = GameObject.Find("DeathFloor");
		if(!onAwake)
		{
		audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
		mitraMovement = GameObject.Find("Mitra").GetComponent<MitraMovement>();
		}

	}
	// Start is called before the first frame update
	void Start()
    {
        if(onAwake)
		{
			StartCoroutine(DialogoChange());
		}
    }

    // Update is called once per frame
    void Update()
    {
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player") && !activated)
		{
			activated = true;
			StartCoroutine(DialogoChange());
		}
	}

	public IEnumerator DialogoChange()
	{
		for (int i = 0; i < numeroDialogo.Length; i++)
		{
			if (canBlockMovement)
			{
				player.GetComponent<CharacterMovement>().cannotMove = true;
				audioManager.StopSound("Steps");
			}			
			textDialogo.text = dialogo[numeroDialogo[i]];
			if (!onAwake)
				textDialogo.gameObject.SetActive(true);
			image.SetActive(true);
			if (useOnlyOneTime)
			yield return new WaitForSeconds(timeTexts[0]);
			else
			{
				yield return new WaitForSeconds(timeTexts[i]);		
			}
			if (!onAwake)
				textDialogo.gameObject.SetActive(false);
			image.SetActive(false);
		}
		if (canBlockMovement)
			player.GetComponent<CharacterMovement>().cannotMove = false;
		if (canCallLevel1)
		{
			callMethods.canGoToLevel1 =  true;
			PlayerPrefs.SetInt("PlayedTutorial", 1);
			deathFloor.GetComponent<DeathHandler>().actualSpawnPoint = spawnAfterLevel[0];
			mitraMovement.doorNumber = 1;
		}
		if(canOpenPortal1)
		{
			callMethods.canOpenPortal1 = true;
		}
		if(canGoAfterLevel1)
		{
			callMethods.canGoAfterLevel1 = true;
		}
		if(canGoMiddle)
		{
			callMethods.goMiddle = true;
			StartCoroutine(MoveWater());

		}

		if(canGoToLevel2)
		{
			callMethods.canGoToLevel2 = true;
			mitraMovement.doorNumber = 2;
			deathFloor.GetComponent<DeathHandler>().actualSpawnPoint = spawnAfterLevel[1];
		}

		if(canGoToLevel3)
		{
			callMethods.canGoToLevel3 = true;
			mitraMovement.doorNumber = 3;
			deathFloor.GetComponent<DeathHandler>().actualSpawnPoint = spawnAfterLevel[2];
		}

		if(endGame)
		{
			creditos.SetActive(true);
		}
		PlayerPrefs.SetInt("Dialogo" + numberToSetPlayerPrefs, 1);

		if(onAwake)
		{
			SceneManager.LoadScene(1);
		}
	}

	IEnumerator MoveWater()
	{
		yield return new WaitForSeconds(2);
		water.canMoveUp = true;
		yield return new WaitForSeconds(12);
		water.canMoveUp = false;
	}
}

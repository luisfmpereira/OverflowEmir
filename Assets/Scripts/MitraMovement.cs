using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MitraMovement : MonoBehaviour
{
	private GameObject player;
	public float speed;
	public float maxDistToMove;
	public bool isFollowing;
	private GameObject follow;
	public bool canFollowThePlayer;
	public WaterMovement water;
	public GameObject firstDestination;
	public GameObject secondDestination;
	public GameObject thirdDestination;
	public GameObject portal1Destination;
	public GameObject portal2Destination;
	public GameObject portal3Destination;
	public GameObject afterOpenPortal1;
	public GameObject afterOpenPortal2;
	public GameObject afterOpenPortal3;
	public GameObject afterOpenPortal2Hub;
	public GameObject afterOpenPortal3Hub;
	public GameObject midPos;
	public GameObject[] midAnim;
	public int doorNumber;
	public bool canGoToLevel1;
	public bool canGoToLevel2;
	public bool canGoToLevel3;
	public bool canOpenPortal1;
	public bool canOpenPortal2;
	public bool canOpenPortal3;
	public bool canGoAfterLevel1;
	public bool canGoAfterLevel2;
	public bool canGoAfterLevel3;
	public bool goMiddle;
	private bool callOneTime1;
	private bool callOneTime2;
	private bool callOneTime3;
	public GameObject door1;
	public GameObject door2;
	public GameObject door3;
	public bool returnToPos1;
	public bool returnToPos2;
	public bool returnToPos3;
	public DialogoManager dialogoPortal1;
	public DialogoManager dialogoPortal2;
	public DialogoManager dialogoPortal3;
	public DialogoManager dialogo7;
	public DialogoManager dialogo10;
	public DialogoManager dialogo14;
	int x;


	private void Awake()
	{
		player = GameObject.Find("Player");
		follow = player.transform.GetChild(0).gameObject;
	}

	// Start is called before the first frame update
	void Start()
	{
		//this.transform.position = follow.transform.position;

		if (Global.actualLevel == 1 || PlayerPrefs.GetInt("SetSpawnHub") == 1)
		{
			this.transform.position = afterOpenPortal1.transform.position;
		}

		if(Global.actualLevel == 2 || PlayerPrefs.GetInt("SetSpawnHub") == 2)
		{
			this.transform.position = afterOpenPortal2Hub.transform.position;
		}

		if(Global.actualLevel == 3 || PlayerPrefs.GetInt("SetSpawnHub") == 3)
		{
			this.transform.position = afterOpenPortal3Hub.transform.position;
		}

	}

	// Update is called once per frame
	void Update()
	{
		if (canFollowThePlayer)
		{
			if ((Mathf.Abs((this.transform.position.x + this.transform.position.z) - (follow.transform.position.x + follow.transform.position.z)) > maxDistToMove))
			{
				isFollowing = true;
			}

			if (isFollowing)
			{
				FollowPlayer();
			}

			if ((this.transform.position.x - (follow.transform.position.x)) < 0.1f && (this.transform.position.z - (follow.transform.position.z)) < 0.1f)
			{
				isFollowing = false;
			}
		}

		if (canGoToLevel1)
		{
			GoToLevel1();
		}

		if (canGoToLevel2)
		{
			GoToLevel2();
		}

		if(canGoToLevel3)
		{
			GoToLevel3();
		}

		if (canOpenPortal1)
		{
			if (!callOneTime1)
			{
				door1.GetComponent<DoorHandler>().UnlockyDoor();	
				StartCoroutine(ReturnAndText(dialogoPortal1,1));
				callOneTime1 = true;
			}
			OpenPortal(portal1Destination);
		}
		if (canOpenPortal2)
		{
			if (!callOneTime2)
			{
				door2.GetComponent<DoorHandler>().UnlockyDoor();
				StartCoroutine(ReturnAndText(dialogoPortal2,2));
				callOneTime2 = true;
			}
			OpenPortal(portal2Destination);
		}

		if(canOpenPortal3)
		{
			if (!callOneTime3)
			{
				door3.GetComponent<DoorHandler>().UnlockyDoor();
				StartCoroutine(ReturnAndText(dialogoPortal3, 2));
				callOneTime3 = true;
			}
			OpenPortal(portal3Destination);
		}

		if (returnToPos1)
		{
			ReturnToPos(afterOpenPortal1);
		}


		if (returnToPos2)
		{
			ReturnToPos(afterOpenPortal2);
		}

		if (returnToPos3)
		{
			ReturnToPos(afterOpenPortal3);
		}

		if (canGoAfterLevel1)
		{
			CanGoAfterLevel1();
		}

		if(canGoAfterLevel2)
		{
			CanGoAfterLevel2();
		}

		if (goMiddle)
		{
			GoMiddle();
		}
	}

	void FollowPlayer()
	{
		transform.position = Vector3.MoveTowards(transform.position, follow.transform.position, speed * Time.deltaTime);
	}

	void GoToLevel1()
	{
		transform.position = Vector3.MoveTowards(transform.position, firstDestination.transform.position, speed * Time.deltaTime);
		if ((this.transform.position - firstDestination.transform.position).magnitude < 0.1f)
			canGoToLevel1 = false;
	}

	void OpenPortal(GameObject destination)
	{
		transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, speed * Time.deltaTime);
		if ((this.transform.position - destination.transform.position).magnitude < 0.2f)
		{
			canOpenPortal1 = false;
			canOpenPortal2 = false;
			canOpenPortal3 = false;
		}
	}

	void ReturnToPos(GameObject after)
	{
		transform.position = Vector3.MoveTowards(transform.position, after.transform.position, speed * Time.deltaTime);
		if ((this.transform.position - after.transform.position).magnitude < 0.1f)
		{
			returnToPos1 = false;
			returnToPos2 = false;
			returnToPos3 = false;
		}
	}

	void CanGoAfterLevel1()
	{
		transform.position = Vector3.MoveTowards(transform.position, midPos.transform.position, speed * Time.deltaTime);
		if ((this.transform.position - midPos.transform.position).magnitude < 0.1f)
		{
			canGoAfterLevel1 = false;
		}
	}


	void CanGoAfterLevel2()
	{
		transform.position = Vector3.MoveTowards(transform.position, midPos.transform.position, speed * Time.deltaTime);
		if ((this.transform.position - midPos.transform.position).magnitude < 0.1f)
		{
			canGoAfterLevel2 = false;
		}
	}

	void GoMiddle()
	{
		
		water.level = Global.actualLevel;
		if ((this.transform.position - midAnim[x].transform.position).magnitude < 0.1f)
		{
			if (x < 3)
				x++;
			else
			{
				speed = 9;
				if (Global.actualLevel == 1 || PlayerPrefs.GetInt("SetSpawnHub") == 1)
				{
					canGoAfterLevel1 = true;
					StartCoroutine(dialogo7.DialogoChange());
				}
				if (Global.actualLevel == 2 || PlayerPrefs.GetInt("SetSpawnHub") == 2)
				{
					canGoAfterLevel2 = true;
					StartCoroutine(dialogo10.DialogoChange());
				}

				if(Global.actualLevel == 3 || PlayerPrefs.GetInt("SetSpawnHub") == 3)
				{
					canGoAfterLevel2 = true;
					StartCoroutine(dialogo14.DialogoChange());
				}
				
				goMiddle = false;
			}

		}
		else
		{
			speed = 10;
			transform.position = Vector3.MoveTowards(transform.position, midAnim[x].transform.position, speed * Time.deltaTime);
		}
	}

	void GoToLevel2()
	{
		transform.position = Vector3.MoveTowards(transform.position, secondDestination.transform.position, speed * Time.deltaTime);
		if ((this.transform.position - secondDestination.transform.position).magnitude < 0.1f)
		{
			canOpenPortal2 = true;
			canGoToLevel2 = false;
		}
	}

	void GoToLevel3()
	{
		transform.position = Vector3.MoveTowards(transform.position, thirdDestination.transform.position, speed * Time.deltaTime);
		if ((this.transform.position - thirdDestination.transform.position).magnitude < 0.1f)
		{
			canOpenPortal3 = true;
			canGoToLevel3 = false;
		}
	}

	IEnumerator ReturnAndText(DialogoManager diag, int level)
	{
		yield return new WaitForSeconds(4);
		if (doorNumber == 1)
			returnToPos1 = true;
		else if (doorNumber == 2)
			returnToPos2 = true;
		else if (doorNumber == 3)
			returnToPos3 = true;
		yield return new WaitForSeconds(3);
		StartCoroutine(diag.DialogoChange());
	}

}

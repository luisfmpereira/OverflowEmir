using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	[SerializeField] private Transform playerBody;
	public float CameraMoveSpeed = 120.0f;
	public GameObject CameraFollowObj;
	Vector3 FollowPOS;
	public float clampAngle = 80.0f;
	public float inputSensitivity = 150.0f;
	public GameObject CameraObj;
	public GameObject PlayerObj;
	public float camDistanceXToPlayer;
	public float camDistanceYToPlayer;
	public float camDistanceZToPlayer;
	public float mouseX;
	public float mouseY;
	public float smoothX;
	public float smoothY;
	private float rotY = 0.0f;
	private float rotX = 0.0f;

	private void Awake()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	// Use this for initialization
	void Start () {
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
	
	}
	
	// Update is called once per frame
	void Update () {

		// We setup the rotation of the sticks here
		mouseX = Input.GetAxis ("Mouse X") * inputSensitivity * Time.deltaTime;
		mouseY = Input.GetAxis ("Mouse Y") * -1 * inputSensitivity * Time.deltaTime;

		rotY += mouseY ;
		rotX += mouseX ; 

		 rotY = Mathf.Clamp (rotY, -clampAngle, clampAngle);

		Quaternion localRotation = Quaternion.Euler (rotY, rotX, 0.0f);
		transform.rotation = localRotation;
		//playerBody.Rotate(Vector3.up * mouseX);

	}

	void LateUpdate () {
		CameraUpdater ();
	}

	void CameraUpdater() {
		// set the target object to follow
		Transform target = CameraFollowObj.transform;

		//move towards the game object that is the target
		float step = CameraMoveSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.position, step);
	}
}

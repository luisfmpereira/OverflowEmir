using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
	public float[] posY;
	public float speed;
	public bool canMoveUp;
	public int level;
	[SerializeField]
	private Gradient gradient;
	[SerializeField]
	private Gradient gradient2;
	[SerializeField]
	float duration;
	float t = 0f;
	public bool changeMat;
	public Material mat;
	public Color oldColor;
	public Color oldColor1;


	private void Awake()
	{
		mat.SetColor("_DepthGradientShallow", oldColor);
		mat.SetColor("_DepthGradientDeep", oldColor1);
		if (level == 3 || PlayerPrefs.GetInt("SetSpawnHub") == 3)
		{
			this.transform.position = new Vector3(transform.position.x, posY[2], transform.position.z);
		}
		else if (level == 2 || PlayerPrefs.GetInt("SetSpawnHub") == 2)
		{
			this.transform.position = new Vector3(transform.position.x, posY[1], transform.position.z);
		}
		else if (level == 1 || PlayerPrefs.GetInt("SetSpawnHub") == 1)
		{
			this.transform.position = new Vector3(transform.position.x, posY[0], transform.position.z);
		}

	}
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (canMoveUp)
		{
			MoveUp();
		}


		if (changeMat)
		{
			float value = Mathf.Lerp(0f, 1f, t);
			t += Time.deltaTime / duration;
			Color color = gradient.Evaluate(value);
			Color color1 = gradient2.Evaluate(value);
			mat.SetColor("_DepthGradientShallow", color);
			mat.SetColor("_DepthGradientDeep", color1);
		}
	}

	void MoveUp()
	{
		if (level == 1 || PlayerPrefs.GetInt("SetSpawnHub") == 1)
		{
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, posY[1], transform.position.z), speed * Time.deltaTime);
		}

		if (level == 2 || PlayerPrefs.GetInt("SetSpawnHub") == 2)
		{
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, posY[2], transform.position.z), speed * Time.deltaTime);
		}

		if (level == 3 || PlayerPrefs.GetInt("SetSpawnHub") == 3)
		{
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, posY[3], transform.position.z), speed * Time.deltaTime);
			changeMat = true;
		}
	}

}

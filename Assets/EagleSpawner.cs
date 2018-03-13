using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawner : MonoBehaviour {
	public float gap = 20;
	public float followers = 2;
	public GameObject prefab;
	// Use this for initialization

	void Awake()
	{
		StartCoroutine(MaintainFormation());
	}

	System.Collections.IEnumerator MaintainFormation()
	{
		yield return new WaitForSeconds(3);
		while (true)
		{
			GameObject[] eagle = GameObject.FindGameObjectsWithTag("eagle");
			if (eagle.Length < 5)
			{
				GameObject newFollower = GameObject.Instantiate<GameObject>(prefab);
				newFollower.GetComponent<Rigidbody>().isKinematic = false;
				newFollower.GetComponent<Rigidbody>().useGravity = true;
				Vector3 newPos = transform.position;
				newPos.x = newPos.x + Random.Range(-5, 5);
				newPos.y = 5;
				newPos.z = newPos.z + Random.Range(-5, 5);
				newFollower.transform.position = newPos;
			}
			yield return new WaitForSeconds(2);
		}
	}
	public int targetCount = 5;
	public float radius = 10;

	System.Collections.IEnumerator SpawnFollowers()
	{
		yield return new WaitForSeconds(3);
		while (true)
		{
			GameObject[] follower = GameObject.FindGameObjectsWithTag("Follower");
			if (follower.Length < targetCount)
			{
				GameObject enemy = GameObject.Instantiate(prefab);
				Vector2 c = Random.insideUnitCircle * radius;
				enemy.transform.position = new Vector3
					(c.x
						, 5
						, c.y
					);
			}
			yield return new WaitForSeconds(2);
		}
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnFollowers());

	}

	
	// Update is called once per frame
	void Update () {
		
	}
}

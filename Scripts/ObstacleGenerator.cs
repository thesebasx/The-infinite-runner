using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
	[SerializeField] private float _timeForSpawn;
    //[SerializeField] private List<GameObject> _obstacles = new List<GameObject>();
	private float _timer = 0f;

	private void Start()
	{
		SpawnObstacle();
	}
	private void Update()
	{
		if (_timer <= _timeForSpawn)
			_timer += Time.deltaTime;
		else
		{
			SpawnObstacle();
			_timer = 0f;
		}
	}

	void SpawnObstacle()
	{
		int i = Random.Range(0, 2);
		switch (i)
		{
			case 0:
				GameObject cactus = PoolManager.Instance.RequestCactus();
				cactus.transform.position = new Vector3(11f, cactus.transform.position.y);
				cactus.SetActive(true);
				break;
			case 1:
				GameObject threectus = PoolManager.Instance.RequestThreectus();
				threectus.transform.position = new Vector3(11f, threectus.transform.position.y);
				threectus.SetActive(true);
				break;
		}
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
	private static PoolManager _instance;
	public static PoolManager Instance
	{
		get
		{
			if (_instance == null)
				Debug.LogError("Pool Manager is null");

			return _instance;
		}
	}
	[SerializeField] private GameObject _cactusPrefab;
	[SerializeField] private GameObject _threectusPrefab;
	private int amount = 3;

	[SerializeField] private List<GameObject> _cactusList = new List<GameObject>();
	[SerializeField] private List<GameObject> _threectuarList = new List<GameObject>();
	[SerializeField] private Transform _holder;

	private void Awake()
	{
		_instance = this;
	}

	private void Start()
	{
		GenerateObjects(_cactusPrefab, _cactusList);
		GenerateObjects(_threectusPrefab, _threectuarList);
	}

	public GameObject RequestCactus()
	{
		foreach(var cactus in _cactusList)
		{
			if (cactus.activeSelf == false)
				return cactus;
		}

		GameObject obj = Instantiate(_cactusPrefab);
		obj.SetActive(false);
		obj.transform.parent = _holder;
		_cactusList.Add(obj);
		return obj;
	}

	public GameObject RequestThreectus()
	{
		foreach(var threectus in _threectuarList)
		{
			if (threectus.activeSelf == false)
				return threectus;
		}

		GameObject obj = Instantiate(_threectusPrefab);
		obj.SetActive(false);
		obj.transform.parent = _holder;
		_threectuarList.Add(obj);
		return obj;
	}

	private void GenerateObjects(GameObject prefab, List<GameObject> list)
	{
		for (int i = 0; i < amount; i++)
		{
			GameObject obj = Instantiate(prefab);
			obj.SetActive(false);
			obj.transform.parent = _holder;
			list.Add(obj);
		}
	}

	
}

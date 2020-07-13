using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float _factor;
    [SerializeField] private float _speed;
    [SerializeField] private float _parallaxEft;

    //private float time = 0;

    // Update is called once per frame
    void Update()
    {
        //time += Time.deltaTime;
        _speed = _speed + Mathf.Pow((1 / _speed),_factor);
        //_speed = _speed + Mathf.Log10(Mathf.RoundToInt(time) + 1);
        //_speed = 1 / (Mathf.Log(10) * _speed);
        Vector2 position = transform.position;
        position += Vector2.left * _speed * _parallaxEft * Time.deltaTime;
        transform.position = position;

        if (transform.position.x <= -10)
		{
            transform.position = new Vector3(29.9f, transform.position.y);
            //gameObject.SetActive(false);
		}
    }
}

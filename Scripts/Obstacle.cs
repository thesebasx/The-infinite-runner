using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _factor;
    // Update is called once per frame
    void Update()
    {
        _speed = _speed + Mathf.Pow((1 / _speed), _factor);
        Vector2 position = transform.position;
        position += Vector2.left * _speed * Time.deltaTime;
        transform.position = position;

        if (transform.position.x <= -10)
        {
            gameObject.SetActive(false);
        }
    }
}

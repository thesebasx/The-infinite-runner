using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightCycle : MonoBehaviour
{
    [SerializeField] private float _cycleDuration;
    private float _alpha;
    private bool _isDay;
    private float timer;
    SpriteRenderer SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _cycleDuration = 0f;
        SpriteRenderer = GetComponent<SpriteRenderer>();
        timer = _cycleDuration;
        _isDay = false;
    }

    // Update is called once per frame
    void Update()
    {
        _alpha = SpriteRenderer.color.a;
        if (_isDay && _alpha < 1)
            _alpha += 0.01f;
        else if(!_isDay && _alpha > 0)
            _alpha -= 0.01f;
        SpriteRenderer.color = new Color(SpriteRenderer.color.r, SpriteRenderer.color.g, SpriteRenderer.color.b, _alpha);

        

        if (_alpha >= 1)
		{
            if (timer > 0)
                timer -= Time.deltaTime;
            else
            {
                _isDay = false;
                timer = _cycleDuration;
            }
        }   
        else if (_alpha <= 0)
		{
            if (timer > 0)
                timer -= Time.deltaTime;
            else
            {
                _isDay = true;
                timer = _cycleDuration;
            }
        }
            
            


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGloves : MonoBehaviour
{
    public GameObject headPosition;
    private Vector3 startingPosition;
    float speed = 0.1f;
    public GameObject RightGlove;
    public GameObject leftGlove;
    private float timer = 3;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        float step = speed * Time.deltaTime;

        
        transform.position = Vector3.MoveTowards(transform.position, headPosition.transform.position, step);
    }
}

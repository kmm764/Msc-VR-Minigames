using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOneController : MonoBehaviour
{
    public GameObject ball;
    private float countdownTime = 4.0f;
    private float spawnCountDown;
    public static float scoreTotal;
    public static float reactionTimeS;
    //private bool isSpawn = false;
    public Text scoreText;
    public Text reactionTimeBoard;
    private float incremental = 40;
    float ang;
    private float radius = 0.8f;

    void Start()
    {
        spawnCountDown = countdownTime;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCountDown -= Time.deltaTime;

        if (spawnCountDown < 0)
        {
            ang = Random.value *80;
            
            ang -= incremental;
            Vector3 positionS = new Vector3(transform.position.x + radius * Mathf.Sin(((ang) * Mathf.Deg2Rad)), transform.position.y + Random.Range(0f, 0.8f), transform.position.z + radius * Mathf.Cos((ang) * Mathf.Deg2Rad));
            Instantiate(ball, positionS, transform.rotation);
            //add ball countdown

            spawnCountDown = Random.Range(2.5f, countdownTime);
        }
        //+ Random.Range(-0.8f, 0.8f)+ Random.Range(0f, 0.8f)

        scoreText.text = scoreTotal.ToString();
        reactionTimeBoard.text = reactionTimeS.ToString();
    }
    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
}

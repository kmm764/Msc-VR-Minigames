using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float spawnCountDown;
    private float reactionTime = 0;
    private bool hitGlove;
    private float scoreS;

    // Start is called before the first frame update
    void Start()
    {
        hitGlove = false;
    
    }

    

    // Update is called once per frame
    void Update()
    {
        if(hitGlove == false)
        {
            reactionTime += Time.deltaTime;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            Debug.Log("destroy self");
            Destroy(gameObject);
            
        }
        if (collision.gameObject.tag == "Glove")
        {
            hitGlove = true;
            scoreS = Mathf.Max((2-reactionTime)*50,0);
            Debug.Log(scoreS);
            GameOneController.scoreTotal += scoreS;
            GameOneController.reactionTimeS = reactionTime;
        }
    }
   
    void Max(float v1, float v2)
    {

    }
}

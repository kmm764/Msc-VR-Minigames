using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public Text scoreText;
    
    
    private static float scoreX;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // timer += Time.deltaTime;
        scoreX = PunchingBag.HitScore;
        
        scoreText.text = scoreX.ToString();

        
    }

    
}

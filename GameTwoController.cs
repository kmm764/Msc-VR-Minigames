using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTwoController : MonoBehaviour
{
    public Text scoreText;
    
    public static float score2X;
    //indicator
    float counter = 3;
    public Text indiText;
    public Text reactionBoard;
    public static bool counterOn = false;
    private string colorName;
    public Text impact;
    public static float impactStrength = 0; 

    // Start is called before the first frame update
    void Start()
    {
        counterOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        // timer += Time.deltaTime;
        //scoreX = PunchingBag.HitScore;
        
        scoreText.text = score2X.ToString();
        //indicator
        if (counter > 0 && counterOn == true)
        {
            counter -= Time.deltaTime;

        }
        else if (counter < 0)
        {
            PunchingBag.startHitIndicator = UnityEngine.Random.Range(1, 5);
            counter = 3;
            counterOn = false;

        }
        //counter = Mathf.Round(counter * 100f) / 100f;
        indiText.text = counter.ToString();
        
        switch (PunchingBag.startHitIndicator)
        {
            case 1:
                colorName = "Red";
                break;
            case 2:
                colorName = "Blue";
                break;
            case 3:
                colorName = "Green";
                break;
            case 4:
                colorName = "Yellow";
                break;
            case 0:
                colorName = "none";
                break;
        }

        reactionBoard.text = colorName;
        impact.text = impactStrength.ToString();
    }

}

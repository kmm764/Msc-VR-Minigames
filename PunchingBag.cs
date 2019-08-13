using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchingBag : MonoBehaviour
{
    // Start is called before the first frame update
    public static float HitScore;
    public int colorOfTheBoard; //0 is nothing, 1 is red, 2 is blue, 3 is green, 4 is yellow
    public static int startHitIndicator;
    private static int whichColorNow;
    private bool canHit = false;
    private float startTimer = 0;
    public static float reactionTime;
    private float velocityOfGloveNow;
    // Update is called once per frame

    void Update()
    {
       if (colorOfTheBoard == startHitIndicator)
        {
            canHit = true;
        }
        else
        {
            canHit = false;
        }

        if (canHit == true)
        {
            startTimer += Time.deltaTime;

        }
        

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Glove")
        {
            if (canHit == true)
            {
                Glove gloveS = other.gameObject.GetComponent<Glove>();
                velocityOfGloveNow = gloveS.velocityMagnitude;

                Debug.Log("Hit");
                startHitIndicator = 0; //change back to none
                GameTwoController.counterOn = true;

                reactionTime = startTimer;
                startTimer = 0;//reset timer
                               //HitScore = reactionTime;



                Debug.Log("VelocityNow = " + velocityOfGloveNow);
                GameTwoController.impactStrength = velocityOfGloveNow;
                GameTwoController.score2X += Mathf.Max(0, (1.5f - reactionTime) * 100);
                canHit = false;
            }
            else if (canHit == false && startHitIndicator > 0)
            {
                GameTwoController.score2X -= 100;
                startHitIndicator = 0;
                GameTwoController.counterOn = true;

            }
        }
    }
            

}

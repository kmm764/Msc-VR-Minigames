using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameThreeController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject headPosition;
    public GameObject RightGlove;
    public GameObject LeftGlove;
    private Vector3 startingPositionR;
    private Vector3 startingPositionL;
    private Quaternion StartingRotationR;
    private Quaternion StartingRotationL;
    private float speed = 2.0f;
    private float timer = 3;
    float distanceTravelledR = 0;
    float distanceTravelledL = 0;
    public GameObject opponentHead;

    float AIpunchingDistance = 35;

    int indicator =0;
    bool punchingRC;
    bool punchingLJ;
    bool moveGloveBackR =false;
    bool moveGloveBackL = false;
    bool canPunch = false;

    public static bool adjustheightBool = false;
    Vector3 headPositionWhenStart ;
        //new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {

        startingPositionR = RightGlove.transform.position;
        startingPositionL = LeftGlove.transform.position;
        StartingRotationR = RightGlove.transform.rotation;
        StartingRotationL = RightGlove.transform.rotation;
        punchingRC = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(startingPositionR);
        if (canPunch == false)
        {
            timer -= Time.deltaTime;
        }
        
        //Debug.Log(headPositionWhenStart);

        //Right hand
        distanceTravelledR += Vector3.Distance(RightGlove.transform.position, startingPositionR);
        distanceTravelledL += Vector3.Distance(LeftGlove.transform.position, startingPositionL);
        if (punchingRC == false && punchingLJ == false)
        {
            headPositionWhenStart = headPosition.transform.position;
        }
        

        if (timer < 0)
        {
            //making sure indicator wont trigger twice in a row
            canPunch = true;
            timer = 5;
            //generate random number to choose between animations
            indicator = Random.Range(3, 4);
            
        }

        switch (indicator)
        {
            case 1:

                punchingRC = true;
                RightCross(0);
                
                break;
            case 2:
                punchingLJ = true;
                LeftJab();
                break;
            case 3:
                punchingRC = true;
                
                RightCross(1);
                
                
                    
                
                                
                break;
            case 4:
                
                break;
            case 0:
                
                break;
        }
        //right hand cross
        

        //head
        if (punchingRC == false && punchingLJ ==false)
        {
            startingPositionR = RightGlove.transform.position;
            startingPositionL = LeftGlove.transform.position;
            StartingRotationR = RightGlove.transform.rotation;
            StartingRotationL = RightGlove.transform.rotation;
            opponentHead.transform.LookAt(2 * opponentHead.transform.position - headPosition.transform.position);
        }
        

        if (adjustheightBool == true)
        {
            opponentHead.transform.position = new Vector3(0, headPosition.transform.position.y, 1.0f);
            adjustheightBool = false;
        }
        Debug.Log(timer);
    }
    void RightCross(int moves) //0 = basic cross, 1 = jab/cross 
    {
        
        float step = speed * (Time.deltaTime);
        
        if (punchingRC == true && moveGloveBackR == false)
        {
            
            RightGlove.transform.rotation = Quaternion.Euler(-90, -90, 90);
            RightGlove.transform.position = Vector3.MoveTowards(RightGlove.transform.position, headPositionWhenStart, step);
        }
        else if(punchingRC == true && moveGloveBackR == true)
        {
            
            RightGlove.transform.position = Vector3.MoveTowards(RightGlove.transform.position, startingPositionR, step);
            
        }

        if (distanceTravelledR > (AIpunchingDistance-1) && punchingRC ==true)
        {
            moveGloveBackR = true;
        }

        if (RightGlove.transform.position == startingPositionR && moveGloveBackR == true)
        {
            RightGlove.transform.rotation = StartingRotationR;
            timer = 2;
            if (moves == 0)
            {
                indicator = 0;
            }
            else if(moves ==1){
                indicator = 2;
            }
            punchingRC = false;
            moveGloveBackR = false;
            distanceTravelledR = 0;
            canPunch = false;
        }
        Debug.Log(distanceTravelledR);
    }
    void LeftJab()
    {
        float step = speed * Time.deltaTime;
        
        if (punchingLJ == true && moveGloveBackL == false)
        {

            LeftGlove.transform.rotation = Quaternion.Euler(90, -90, 90);
            LeftGlove.transform.position = Vector3.MoveTowards(LeftGlove.transform.position, headPositionWhenStart, step);
        }
        else if (punchingLJ == true && moveGloveBackL == true)
        {

            LeftGlove.transform.position = Vector3.MoveTowards(LeftGlove.transform.position, startingPositionL, step);

        }

        if (distanceTravelledL > AIpunchingDistance && punchingLJ == true)
        {
            moveGloveBackL = true;
        }

        if (LeftGlove.transform.position == startingPositionL && moveGloveBackL == true)
        {
            LeftGlove.transform.rotation = StartingRotationL;
            timer = 2;
            indicator = 0;
            punchingLJ = false;
            moveGloveBackL = false;
            distanceTravelledL = 0;
            canPunch = false;
        }
    }
}

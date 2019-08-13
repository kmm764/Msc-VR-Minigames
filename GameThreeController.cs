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
    //private Transform startingRTransform;
    //private Transform startingLTransform;
    private Quaternion StartingRotationR;
    private Quaternion StartingRotationL;
    private float speed = 2.0f;
    private float timer = 3;
    float distanceTravelledR = 0;
    float distanceTravelledL = 0;
    public GameObject opponentHead;
    public Light IT;
    public static bool changeLightToRed = false;

    Vector3 controlPoint;
    float AIpunchingDistance = 25;

    int indicator = 0;
    bool punchingRC;
    bool punchingLJ;
    bool punchingRH;
    bool punchingLH;
    bool punchingJC;
    bool moveGloveBackR = false;
    bool moveGloveBackL = false;
    bool canPunch = false;
    float timerR = 1;
    int moves;
    bool reachEndR;
    bool reachEndL;
    float counterR;
    float counterL;
    public static bool adjustheightBool = false;
    Vector3 headPositionWhenStart;
    float speedH = 1f;
    //new Vector3(0, 0, 0);

    Vector3 centerPoint;
    Vector3 startRelcenter;
    Vector3 endRelcenter;

    // Start is called before the first frame update
    void Start()
    {

        startingPositionR = RightGlove.transform.position;
        startingPositionL = LeftGlove.transform.position;
        StartingRotationR = RightGlove.transform.rotation;
        StartingRotationL = LeftGlove.transform.rotation;
        punchingRC = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (changeLightToRed && timerR > 0)
        {

            timerR -= Time.deltaTime;
            IT.color = Color.red;
        }


        //Debug.Log(startingPositionR);
        if (canPunch == false)
        {
            timer -= Time.deltaTime;
        }

        //Debug.Log(headPositionWhenStart);

        //Right hand
        distanceTravelledR += Vector3.Distance(RightGlove.transform.position, startingPositionR);
        distanceTravelledL += Vector3.Distance(LeftGlove.transform.position, startingPositionL);
        if (punchingRC == false && punchingLJ == false && punchingJC == false && punchingRH == false && punchingLH == false)
        {
            headPositionWhenStart = headPosition.transform.position;
        }


        if (timer < 0)
        {
            //making sure indicator wont trigger twice in a row
            canPunch = true;
            timer = 5;
            //generate random number to choose between animations
            indicator = Random.Range(5, 7);

        }

        switch (indicator)
        {
            case 1:


                RightCross(moves);

                break;
            case 2:
                RightHook(moves);
                
                break;
            case 3:
                LeftJab(moves);
                break;
            case 4:
                LeftHook(moves);
                break;

            case 5:
                if (punchingJC == false)
                {
                    moves = 1;
                    punchingJC = true;
                }


                RightCross(moves);

                break;
            case 6:
                if (punchingJC == false)
                {
                    moves = 3;
                    punchingJC = true;
                }


                LeftJab(moves);
                break;
            case 0:

                break;
        }
        //right hand cross


        //head
        if (punchingRC == false && punchingLJ == false && punchingJC == false && punchingRH == false && punchingLH == false)
        {
            startingPositionR = RightGlove.transform.position;
            startingPositionL = LeftGlove.transform.position;
            StartingRotationR = RightGlove.transform.rotation;
            StartingRotationL = LeftGlove.transform.rotation;
            opponentHead.transform.LookAt(2 * opponentHead.transform.position - headPosition.transform.position);
        }


        if (adjustheightBool == true)
        {
            opponentHead.transform.position = new Vector3(0, headPosition.transform.position.y, 1.0f);
            adjustheightBool = false;
        }
        Debug.Log(timer);
    }
    void RightCross(int m) //number of moves remaining
    {
        punchingRC = true;
        float step = speed * (Time.deltaTime);

        if (punchingRC == true && moveGloveBackR == false)
        {

            RightGlove.transform.rotation = Quaternion.Euler(-90, -90, 90);
            RightGlove.transform.position = Vector3.MoveTowards(RightGlove.transform.position, headPositionWhenStart, step);
        }
        else if (punchingRC == true && moveGloveBackR == true)
        {

            RightGlove.transform.position = Vector3.MoveTowards(RightGlove.transform.position, startingPositionR, step);

        }

        if (distanceTravelledR > (AIpunchingDistance - 1) && punchingRC == true)
        {
            moveGloveBackR = true;
        }

        if (RightGlove.transform.position == startingPositionR && moveGloveBackR == true)
        {
            RightGlove.transform.rotation = StartingRotationR;
            timer = 2;
            if (m == 0)
            {
                indicator = 0;
                punchingJC = false;
            }
            else if (m > 0)
            {
                moves -= 1;
                indicator = Random.Range(3, 5);
                //;

            }
            punchingRC = false;
            moveGloveBackR = false;
            distanceTravelledR = 0;
            canPunch = false;
        }

        Debug.Log(distanceTravelledR);
    }
    void LeftJab(int m)
    {
        punchingLJ = true;
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
            if (m == 0)
            {
                indicator = 0;
                punchingJC = false;
            }
            else if (m > 0)
            {
                moves -= 1;
                indicator = Random.Range(1, 3);


            }
            punchingLJ = false;

            moveGloveBackL = false;
            distanceTravelledL = 0;
            canPunch = false;
        }
    }
    void RightHook(int m)
    {
        punchingRH = true;

        float step = speed * (Time.deltaTime);
        Vector3 startHead = new Vector3(headPositionWhenStart.x + 0.5f, headPositionWhenStart.y, headPositionWhenStart.z);

        //move forward
        if (punchingRH == true && moveGloveBackR == false)
        {
            //Bezier Curves

            controlPoint = startingPositionR + (headPositionWhenStart - startingPositionR) + Vector3.left * 1.0f;
            if (counterR < 1.0f)
            {
                counterR += 1.0f * Time.deltaTime;
                Vector3 m1 = Vector3.Lerp(startingPositionR, controlPoint, counterR);
                Vector3 m2 = Vector3.Lerp(controlPoint, startHead, counterR);
                RightGlove.transform.position = Vector3.Lerp(m1, m2, counterR);
            }



            //RightGlove.transform.rotation = Quaternion.Euler(0, -90, 130);
            //RightGlove.transform.position = Vector3.MoveTowards(RightGlove.transform.position, , step);
        }
        //move back
        else if (punchingRH == true && moveGloveBackR == true)
        {

            RightGlove.transform.position = Vector3.MoveTowards(RightGlove.transform.position, startingPositionR, step);

        }
        //move back indicator
        if (startHead == RightGlove.transform.position && punchingRH == true)
        {
            moveGloveBackR = true;
        }

        if (RightGlove.transform.position == startingPositionR && moveGloveBackR == true)
        {
            RightGlove.transform.rotation = StartingRotationR;
            timer = 2;
            if (m == 0)
            {
                indicator = 0;
                punchingJC = false;
            }
            else if (m > 0)
            {
                moves -= 1;
                indicator = Random.Range(3, 5);
                //;

            }
            punchingRH = false;
            moveGloveBackR = false;
            distanceTravelledR = 0;
            canPunch = false;
            counterR = 0;
        }
    }
    void LeftHook(int m)
    {
        punchingLH = true;

        float step = speed * (Time.deltaTime);
        Vector3 startHeadL = new Vector3(headPositionWhenStart.x - 0.5f, headPositionWhenStart.y, headPositionWhenStart.z);

        //move forward
        if (punchingLH == true && moveGloveBackL == false)
        {
            //Bezier Curves

            controlPoint = startingPositionL + (headPositionWhenStart - startingPositionL) + Vector3.right * 1.0f;
            if (counterL < 1.0f)
            {
                counterL += 1.0f * Time.deltaTime;
                Vector3 m1 = Vector3.Lerp(startingPositionL, controlPoint, counterL);
                Vector3 m2 = Vector3.Lerp(controlPoint, startHeadL, counterL);
                LeftGlove.transform.position = Vector3.Lerp(m1, m2, counterL);
            }



            //RightGlove.transform.rotation = Quaternion.Euler(0, -90, 130);
            //RightGlove.transform.position = Vector3.MoveTowards(RightGlove.transform.position, , step);
        }
        //move back
        else if (punchingLH == true && moveGloveBackL == true)
        {

            LeftGlove.transform.position = Vector3.MoveTowards(LeftGlove.transform.position, startingPositionL, step);

        }
        //move back indicator
        if (startHeadL == LeftGlove.transform.position && punchingLH == true)
        {
            moveGloveBackL = true;
        }

        if (LeftGlove.transform.position == startingPositionL && moveGloveBackL == true)
        {
            LeftGlove.transform.rotation = StartingRotationL;
            timer = 2;
            if (m == 0)
            {
                indicator = 0;
                punchingJC = false;
            }
            else if (m > 0)
            {
                moves -= 1;
                indicator = Random.Range(1, 3);
                //;

            }
            punchingLH = false;
            moveGloveBackL = false;
            canPunch = false;
            counterL = 0;
        }

    }
}


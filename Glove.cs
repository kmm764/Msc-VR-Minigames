using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Glove : MonoBehaviour
{
    Vector3 PrevPosition;
    Vector3 NewPosition;
    Vector3 velocityNow;
    private Rigidbody rb;
    public float velocityMagnitude;
    void Start()
    {
        PrevPosition = transform.position;
        NewPosition = transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        NewPosition = transform.position;
        velocityNow = (NewPosition - PrevPosition) / Time.fixedDeltaTime;
        //Debug.Log("velocity is"+velocityNow.magnitude);
        PrevPosition = NewPosition;
        velocityMagnitude = velocityNow.magnitude;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            Debug.Log("HitBall");
            rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;

            Physics.IgnoreCollision(collision.gameObject.GetComponent<SphereCollider>(), gameObject.GetComponent<CapsuleCollider>());


            Vector3 direction = (collision.gameObject.transform.position - collision.contacts[0].point).normalized;
            rb.AddForce(direction * (velocityNow.magnitude * 2f), ForceMode.Impulse);


        }
        if (collision.gameObject.name == "Minigame1")
        {
            SceneManager.LoadScene(sceneName: "minigame1");
        }

        if (collision.gameObject.name == "Minigame2")
        {
            SceneManager.LoadScene(sceneName: "minigame2");
        }
        if (collision.gameObject.name == "Minigame3")
        {
            SceneManager.LoadScene(sceneName: "minigame3");
        }

        if (collision.gameObject.name == "adjustHeight")
        {
            GameThreeController.adjustheightBool = true;
        }

    }

}


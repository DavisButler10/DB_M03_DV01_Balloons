using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    public GameObject balloonPrefab;
    private GameObject balloon;
    public float floatStrength = 20f;
    public float growRate = 1.5f;
    private Rigidbody rb;

    void Update()
    {
        if (balloon != null)
        {
            GrowBalloon();
        }
    }

    public void CreateBalloon(GameObject parentHand)
    {
        balloon = Instantiate(balloonPrefab, parentHand.transform);
        balloon.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        rb = balloon.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }


    void ReleaseBalloon()
    {
        rb.isKinematic = false;
        balloon.transform.parent = null;
        rb.AddForce(Vector3.up * floatStrength);
        GameObject.Destroy(balloon, 10f);
        balloon = null;
    }

    public void GrowBalloon()
    {
        balloon.transform.localScale += balloon.transform.localScale * growRate * Time.deltaTime;
    }

}

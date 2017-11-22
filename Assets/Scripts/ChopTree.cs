using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopTree : MonoBehaviour {

    private float countdown = 2.0f;
    private bool startcountdown = false;
    private Transform collecter = null;

    private void OnMouseDown()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;
        //startcountdown = true;
    }

    void Update()
    {
        if (startcountdown)
        {
            countdown -= Time.deltaTime;
            if (countdown < 0)
            {
                Destroy(gameObject);
            }
        }
        
    }

    public void SetStartCountdown(bool b)
    {
        this.startcountdown = b;
    }

    public bool HasCollecter()
    {
        return this.collecter != null;
    }

    public void SetCollecter (Transform collecter)
    {
        this.collecter = collecter;
    }

}

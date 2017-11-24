using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ChopTree : MonoBehaviour {

    private float countdown = 2.0f;
    private bool startcountdown = false;
    private Transform collecter = null;

    public float quantity;

    public void Start()
    {
        quantity = 3.0f;
    }

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

    public float GetQuantity()
    {
        return quantity;
    }

    public float Collect(float quantity)
    {
        float returnValue = 0.0f;
        if (quantity >= this.quantity)
        {
            returnValue = this.quantity;
            this.SetStartCountdown(true);
            this.quantity = 0.0f;   
        } else
        {
            returnValue = Mathf.Max(0.0f, quantity);
            this.quantity -= quantity;
            collecter.transform.GetComponent<AICharacterControl>().SetTarget(null);
        }
        collecter = null;
        return returnValue;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialContainer : MonoBehaviour {

    public float quantity;
    public float maxQuantity;

	// Use this for initialization
	void Start () {
        quantity = 0.0f;
        maxQuantity = 10000.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float AddQuantity(float quantity)
    {
        float returnValue = 0.0f;

        if (this.quantity + quantity <= this.maxQuantity)
        {
            returnValue = 0.0f;
            this.quantity += quantity;
        }
        else
        {
            returnValue = Mathf.Max(0.0f, this.quantity + quantity - maxQuantity);
            this.quantity = maxQuantity;
        }
        return returnValue;
    }
}

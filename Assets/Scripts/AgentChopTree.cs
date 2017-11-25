using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class AgentChopTree : MonoBehaviour {

    public float quantity = 0.0f;
    public float maxQuantity = 5.0f;
    public float reachDistance = 1.0f;

	// Use this for initialization
	void Start () {
        quantity = 0.0f;
        maxQuantity = 5.0f;
        reachDistance = 1.0f;
    }
	
	// Update is called once per frame
	void Update () {
        Transform target = gameObject.GetComponent<AICharacterControl>().target;
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.position) <= gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().stoppingDistance + reachDistance)
            {
                //Debug.Log("Collect Distance reached");
                HandleInteraction(target);
            }
        }


    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision detected");
        if (gameObject.GetComponent<AICharacterControl>().target != null)
        {
            if (gameObject.GetComponent<AICharacterControl>().target.transform == other.GetComponentInParent<Transform>())
            {
                //Debug.Log("Correct Collision");
                HandleInteraction(other.transform);
            }
        }
    }

    public bool HasSpace()
    {
        return (quantity < maxQuantity);
    }

    public void HandleInteraction(Transform target )
    {
        if (target.CompareTag("Tree"))
        {
            //Debug.Log("Tree");
            quantity += target.GetComponent<ChopTree>().Collect(maxQuantity - quantity);
            gameObject.GetComponent<AICharacterControl>().target = null;
        }
        else if (target.CompareTag("Container"))
        {
            //Debug.Log("Container");
            float returnQuantity = transform.parent.GetComponent<AgentManager>().container.GetComponent<MaterialContainer>().AddQuantity(quantity);
            quantity = returnQuantity;
            gameObject.GetComponent<AICharacterControl>().target = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class AgentChopTree : MonoBehaviour {

    public float quantity;
    public float maxQuantity;

	// Use this for initialization
	void Start () {
        quantity = 0.0f;
        maxQuantity = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
        Transform target = gameObject.GetComponent<AICharacterControl>().target;
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.position) <= gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().stoppingDistance+1.0f)
            {
                //Debug.Log("Collect Distance reached");
                HandleInteraction(target);
            }
        }


    }

    /*void OnTriggerEnter(Collider other)
    {
        if (gameObject.GetComponent<AICharacterControl>().target.CompareTag(other.transform.tag))
        {
            Debug.Log("Correct Collision");
            HandleInteraction(other.transform);
        }

    }*/

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

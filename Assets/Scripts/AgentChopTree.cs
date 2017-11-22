using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class AgentChopTree : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Transform target = gameObject.GetComponent<AICharacterControl>().target;
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.position) <= gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().stoppingDistance)
            {
                target.GetComponent<ChopTree>().SetStartCountdown(true);
            }
        }
    }
}

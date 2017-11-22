using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class TreeManager : MonoBehaviour {

    public Transform agentManager;


    void Start()
    {
             
    }

    void Update()
    {
        foreach(Transform agent in agentManager.transform)
        {
            if (!agent.GetComponent<AICharacterControl>().HasTarget())
            {
                foreach (Transform tree in transform)
                {
                    if (!tree.GetComponent<ChopTree>().HasCollecter() && tree.GetComponent<Rigidbody>().useGravity== true)
                    {
                        agent.GetComponent<AICharacterControl>().SetTarget(tree);
                        tree.GetComponent<ChopTree>().SetCollecter(agent);
                        return;
                    }
                }
                
            }
        }
    }

}

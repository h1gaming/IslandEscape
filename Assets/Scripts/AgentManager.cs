using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.Characters.ThirdPerson;

public class AgentManager : MonoBehaviour
{
    public Transform treeManager;
    public Transform container;


    public void Update()
    {
        foreach (Transform agent in transform)
        {
            if (!agent.GetComponent<AICharacterControl>().HasTarget())
            {
                /** Collect Wood if possible */
                if (agent.GetComponent<AgentChopTree>().HasSpace())
                {
                    foreach (Transform tree in treeManager.transform)
                    {
                        if (!tree.GetComponent<ChopTree>().HasCollecter() && tree.GetComponent<Rigidbody>().useGravity == true)
                        {
                            agent.GetComponent<AICharacterControl>().SetTarget(tree);
                            tree.GetComponent<ChopTree>().SetCollecter(agent);
                            break;
                        }
                    }
                    /** if there are no more trees, just bring the inventory to the container */
                    if (agent.GetComponent<AICharacterControl>().target == null && agent.GetComponent<AgentChopTree>().quantity > 0.0f)
                    {
                        agent.GetComponent<AICharacterControl>().SetTarget(container);
                    }
                }
                /** else the space is full -> bring it to the container */
                else
                {
                    agent.GetComponent<AICharacterControl>().SetTarget(container);
                }

            }
        }
    }
}

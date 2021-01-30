// MoveTo.cs
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
  public Transform goal;
  public NavMeshAgent agent;

  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    agent.destination = goal.position;
  }

  void Update()
  {
    var diff = (agent.destination - goal.position).magnitude;
    // Debug.Log(diff);

    if (diff > 0.1)
    {
      Debug.Log("called!");
      agent.destination = goal.position;
    }
  }
}
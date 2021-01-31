using UnityEngine;
using UnityEngine.AI;

public class LurkUtils : MonoBehaviour
{
  public void chooseCloseNavMeshDestination(GameObject agent, float walkRadius)
  {
    var offset = Vector3.ProjectOnPlane(Random.insideUnitSphere * walkRadius, Vector3.forward);

    var desired = agent.transform.position + offset;

    NavMeshHit hit;
    NavMesh.SamplePosition(desired, out hit, 1.0f, 1 << NavMesh.GetAreaFromName("Walkable"));

    var target = hit.position;

    var component = agent.GetComponent<NavMeshAgent>();
    component.SetDestination(target);
  }

  public bool isCloseToDestination(GameObject agent)
  {
    return agent.GetComponent<NavMeshAgent>().remainingDistance < 0.2;
  }
}

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

  public void updateAnimation(NavMeshAgent agent, CharacterBehaviour character)
  {
    var vector = Vector3.ProjectOnPlane(agent.velocity, Vector3.back);
    if (vector.Equals(Vector3.zero)) return;

    var isHorizontal = Mathf.Abs(vector.x) >= Mathf.Abs(vector.y);

    character.speed = 1f;
    if (isHorizontal)
    {
      character.dirX = vector.x >= 0 ? 1 : -1;
      character.dirY = 0;
    }
    else
    {
      character.dirX = 0;
      character.dirY = vector.y >= 0 ? 1 : -1;
    }
  }

  public void stopAnimation(CharacterBehaviour character)
  {
    character.speed = 0f;

    // If this is not done, the character stays looking where it moved to
    // which is better obviously
    // character.dirX = 0;
    // character.dirY = 0;
  }
}

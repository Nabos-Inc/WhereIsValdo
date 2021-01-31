using UnityEngine;
using UnityEngine.AI;

public class FixNavRotation : MonoBehaviour
{
  // Start is called before the first frame update

  void Awake()
  {
    var agent = GetComponent<NavMeshAgent>();
    agent.updateRotation = false;
    agent.updateUpAxis = false;
  }
}

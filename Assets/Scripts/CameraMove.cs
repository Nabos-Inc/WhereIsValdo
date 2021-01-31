using UnityEngine;

public class CameraMove : MonoBehaviour
{
  public float factor;

  void Update()
  {
    var horizontal = Input.GetAxisRaw("Horizontal");
    var vertical = Input.GetAxisRaw("Vertical");

    var vector = new Vector3(horizontal, vertical, 0);

    gameObject.transform.Translate(vector * factor * Time.deltaTime);
  }
}

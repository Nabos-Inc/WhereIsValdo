using UnityEngine;

public class CameraMove : MonoBehaviour {
    public float factor;
    public Camera targetCamera;
    public float maxHorizontal = 6;
    public float maxVertical = 3.5f;
    public float deadzoneX = 0.3f;
    public float deadzoneY = 2f;

    [HideInInspector]
    public PolygonCollider2D polCollider;
    [HideInInspector]
    public bool moveEnabled = false;

    void Update() {
        if (moveEnabled) {
            var mousePos = targetCamera.ScreenToWorldPoint(Input.mousePosition);
            var cameraPos = targetCamera.transform.position;

            var camHeight = targetCamera.orthographicSize * 2f;
            var camWidth = camHeight * targetCamera.aspect;

            var difX = Mathf.Clamp(mousePos.x - cameraPos.x, -maxHorizontal, maxHorizontal);
            var xScale = Mathf.Abs(difX) > deadzoneX ? difX / maxHorizontal : 0;

            var difY = Mathf.Clamp(mousePos.y - cameraPos.y, -maxVertical, maxVertical);
            var yScale = Mathf.Abs(difX) > deadzoneY ? difY / maxVertical : 0;

            var vector = new Vector3(factor * xScale, factor * yScale, 0);
            gameObject.transform.Translate(vector * Time.deltaTime);

            if (gameObject.transform.position.x > (polCollider.bounds.max.x - camWidth / 2)) {
                gameObject.transform.position = new Vector3(polCollider.bounds.max.x - camWidth / 2, gameObject.transform.position.y, 0f);
            } else if (gameObject.transform.position.x < (polCollider.bounds.min.x + camWidth / 2)) {
                gameObject.transform.position = new Vector3(polCollider.bounds.min.x + camWidth / 2, gameObject.transform.position.y, 0f);
            }

            if (gameObject.transform.position.y > (polCollider.bounds.max.y - camHeight / 2)) {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, polCollider.bounds.max.y - camHeight / 2, 0f);
            } else if (gameObject.transform.position.y < (polCollider.bounds.min.y + camHeight / 2)) {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, polCollider.bounds.min.y + camHeight / 2, 0f);
            }
        }
    }
}

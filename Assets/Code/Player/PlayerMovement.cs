using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject playerObject;
    private Camera cam;


    private void Start()
    {
        playerObject = GetComponent<GameObject>();
        cam = Camera.main;
    }

    public void FrameUpdate()
    {
        Vector3 mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        float angleRad = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
        float angleDef = (180 / Mathf.PI) * angleRad;

        transform.rotation = Quaternion.Euler(0f, 0f, angleDef);
    }
}

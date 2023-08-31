using UnityEngine;

[ExecuteInEditMode]
public class LookAtForSprites : MonoBehaviour
{
    void Start()
    {
        Camera camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        transform.LookAt(new Vector3(transform.position.x, camera.transform.position.y, camera.transform.position.z));
    }
}

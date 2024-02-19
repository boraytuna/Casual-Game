using UnityEngine;

public class BulletHole : MonoBehaviour
{
    public GameObject bulletHole;
    public float distance = 10f;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance))
            {
                GameObject bH = Instantiate(bulletHole, hit.point + new Vector3(0f, 0f, -0.2f), Quaternion.LookRotation(-hit.normal));
            }
        }
    }
}

using UnityEngine;

public class viewuse : MonoBehaviour
{
    public float range = 3f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, range))
            {
                slot_lever lever = hit.collider.GetComponent<slot_lever>();
                if (lever != null)
                {
                    lever.ActivateLever();
                }
            }
        }
    }
}

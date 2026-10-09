using UnityEngine;

public class ProximityScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject compass;

    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

}

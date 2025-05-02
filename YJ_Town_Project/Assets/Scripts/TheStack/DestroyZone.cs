using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Rubble"))
        {
            Destroy(collision.gameObject);
        }
    }
}
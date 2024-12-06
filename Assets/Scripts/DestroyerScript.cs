using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject parent = other.transform.parent.gameObject;
        if (parent != null)
        {
            Destroy(parent.gameObject);
        } else
        {
            Destroy(other.gameObject);
        }
    }
}

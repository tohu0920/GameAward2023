using UnityEngine;

public class Wind : MonoBehaviour
{
    public Transform target;
    public float attractionStrength = 3f;
    public float maxDistance = 10f;
    public float exaggerationFactor = 1.0f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 forceDirection = (target.position - other.transform.position).normalized;
            float distance = Vector3.Distance(target.position, other.transform.position);
            float normalizedDistance = Mathf.Clamp01(distance / maxDistance);
            float exaggeratedForce = Mathf.Pow(normalizedDistance, exaggerationFactor);
            float force = attractionStrength * exaggeratedForce;
            other.GetComponent<Rigidbody>().AddForce(forceDirection * force);
            Debug.Log("force: " + force);
        }
    }
}

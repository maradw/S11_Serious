using UnityEngine;

public class TargetObject : MonoBehaviour
{
    public Collider spawnArea;
    public float minTime = 2f;
    public float maxTime = 5f;

    void Start()
    {
        ScheduleNextAppearance();
    }

    void ScheduleNextAppearance()
    {
        float delay = Random.Range(1f, 3f);
        Invoke("ActivateTarget", delay);
    }

    void ActivateTarget()
    {
        transform.position = GetRandomPositionInMesh(spawnArea);
        gameObject.SetActive(true);

        float activeDuration = Random.Range(minTime, maxTime);
        Invoke(nameof(DeactivateTarget), activeDuration);
    }

    void DeactivateTarget()
    {
        gameObject.SetActive(false);
        ScheduleNextAppearance();
    }

    public void OnHit()
    {
        CancelInvoke(); // detener desactivación si fue golpeado
        transform.position = GetRandomPositionInMesh(spawnArea);
        ScheduleNextAppearance(); // reprogramar aparición
    }

    Vector3 GetRandomPositionInMesh(Collider collider)
    {
        Bounds bounds = collider.bounds;
        Vector3 pos;
        int attempts = 0;
        do
        {
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);
            float z = Random.Range(bounds.min.z, bounds.max.z);
            pos = new Vector3(x, y, z);
            attempts++;
        } while (!collider.bounds.Contains(pos) && attempts < 10);

        return pos;
    }
}

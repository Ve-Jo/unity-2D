using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject TubePrefab;
    [SerializeField]
    private float TubeSpawnShift = 2.0f;
    [SerializeField]
    private float timeout = 4.0f;

    private float leftTime;

    void Start()
    {
        //leftTime = timeout;
        leftTime = 0f;
    }
    void Update()
    {
        leftTime -= Time.deltaTime;
        if (leftTime <= 0) {
            SpawnTube();
            leftTime = timeout;
        }
    }

    private void SpawnTube()
    {
        var tube = GameObject.Instantiate(TubePrefab);
        tube.transform.position = this.transform.position;
        tube.transform.position += Vector3.up * Random.Range(-TubeSpawnShift, TubeSpawnShift);
    }
}

using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private readonly Vector3 _spawnPos = new (25, 0, 0);
    private const float StartDelay = 2.0f;
    private const float RepeatDelay = 2.0f;
    
    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), StartDelay, RepeatDelay);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, _spawnPos, obstaclePrefab.transform.rotation);
    }
}

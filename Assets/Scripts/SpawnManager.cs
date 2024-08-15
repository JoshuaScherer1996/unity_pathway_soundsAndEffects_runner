using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Declaring and initializing the variables and constants.
    public GameObject obstaclePrefab;
    private readonly Vector3 _spawnPos = new(25, 0, 0);
    private const float StartDelay = 2.0f;
    private const float RepeatDelay = 2.0f;
    private PlayerController _playerControllerScript;

    // Start is called before the first frame update.
    private void Start()
    {
        // Saves the PlayerController script and repeatedly invokes the SpawnObstacle method.
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating(nameof(SpawnObstacle), StartDelay, RepeatDelay);
    }

    // Instantiates the obstacle objects as long as the game isn't over.
    private void SpawnObstacle()
    {
        if (_playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, _spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
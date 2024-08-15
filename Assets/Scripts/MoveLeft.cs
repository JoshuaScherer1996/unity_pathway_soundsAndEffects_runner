using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private const float Speed = 30.0f;
    private PlayerController _playerControllerScript;
    private const float LeftBounds = -15.0f;
    
    // Start is called before the first frame update.
    private void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame.
    private void Update()
    {
        if (_playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * (Time.deltaTime * Speed));
        }

        if (transform.position.x < LeftBounds && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private const float Speed = 30.0f;
    private PlayerController _playerControllerScript;
    
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
    }
}

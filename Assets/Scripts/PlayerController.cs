using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Declaring and initializing the variables and constants.
    private Rigidbody _playerRb;
    private const float JumpForce = 10.0f;
    private const float GravityModifier = 2.0f;
    private bool _isOnGround = true;
    
    
    // Start is called before the first frame update.
    private void Start()
    {
        // Saves the Rigidbody of the player.
        _playerRb = GetComponent<Rigidbody>();
        
        // Applying the GravityModifier.
        Physics.gravity *= GravityModifier;

    }

    // Update is called once per frame.
    private void Update()
    {
        // Makes the player jump if space bar is pressed.
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            _playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            _isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isOnGround = true;
    }
}

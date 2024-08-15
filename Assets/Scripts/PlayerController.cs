using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Declaring and initializing the variables and constants.
    private Rigidbody _playerRb;
    private Animator _playerAnim;
    private const float JumpForce = 700.0f;
    private const float GravityModifier = 2.0f;
    private bool _isOnGround = true;
    public bool gameOver;
    private static readonly int JumpTrig = Animator.StringToHash("Jump_trig"); // More efficient than using the name.


    // Start is called before the first frame update.
    private void Start()
    {
        // Saves the Rigidbody of the player.
        _playerRb = GetComponent<Rigidbody>();

        // Applying the GravityModifier.
        Physics.gravity *= GravityModifier;
        
        // Saves the Animator of the player.
        _playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame.
    private void Update()
    {
        // Makes the player jump and handles the jump animation logic.
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            _playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            _isOnGround = false;
            _playerAnim.SetTrigger(JumpTrig);
        }
    }

    // Invoked when the player collides with another object.
    private void OnCollisionEnter(Collision collision)
    {
        // Executes the collision logic based on the tag of the collided object. 
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
        }
    }
}
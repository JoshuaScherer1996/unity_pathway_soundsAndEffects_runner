using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Declaring and initializing the variables and constants.
    private Rigidbody _playerRb;
    private Animator _playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    private AudioSource _playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private const float JumpForce = 700.0f;
    private const float GravityModifier = 2.0f;
    private bool _isOnGround = true;
    public bool gameOver;
    private static readonly int JumpTrig = Animator.StringToHash("Jump_trig"); // More efficient than using the name.
    private static readonly int DeathB = Animator.StringToHash("Death_b");
    private static readonly int DeathTypeINT = Animator.StringToHash("DeathType_int");


    // Start is called before the first frame update.
    private void Start()
    {
        // Saves the Rigidbody of the player.
        _playerRb = GetComponent<Rigidbody>();

        // Applying the GravityModifier.
        Physics.gravity *= GravityModifier;
        
        // Saves the Animator of the player.
        _playerAnim = GetComponent<Animator>();
        
        // Saves the AudioSource of the player.
        _playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame.
    private void Update()
    {
        // Makes the player jump and handles the jump animation logic.
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround && !gameOver)
        {
            _playerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            _isOnGround = false;
            _playerAnim.SetTrigger(JumpTrig);
            dirtParticle.Stop();
            _playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    // Invoked when the player collides with another object.
    private void OnCollisionEnter(Collision collision)
    {
        // Executes the collision logic based on the tag of the collided object. 
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            _playerAnim.SetBool(DeathB, true);
            _playerAnim.SetInteger(DeathTypeINT, 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            _playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
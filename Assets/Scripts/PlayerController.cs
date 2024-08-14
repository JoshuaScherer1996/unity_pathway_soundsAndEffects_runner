using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _playerRb;
    
    // Start is called before the first frame update.
    void Start()
    {
        // Saves the Rigidbody of the player.
        _playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame.
    void Update()
    {
        // Makes the player jump if space bar is pressed.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }
    }
}

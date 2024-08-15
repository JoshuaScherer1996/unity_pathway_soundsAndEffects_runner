using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Declaring the variables.
    private Vector3 _startPos;
    private float _repeatWidth;
    
    // Start is called before the first frame update.
    private void Start()
    {
        // Saves the starting position of the object.
        _startPos = transform.position;
        
        // Saves the width at which the repetition will start.
        _repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame.
    private void Update()
    {
        // Resets the position to the start so that the background seems to run endlessly.
        if (transform.position.x < _startPos.x - _repeatWidth)
        {
            transform.position = _startPos;
        }
    }
}

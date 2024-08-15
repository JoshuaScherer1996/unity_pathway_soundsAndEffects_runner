using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 _startPos;
    
    // Start is called before the first frame update
    private void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.x < _startPos.x - 50)
        {
            transform.position = _startPos;
        }
    }
}

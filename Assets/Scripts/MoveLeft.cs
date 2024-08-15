using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private const float Speed = 30.0f;
    
    // Start is called before the first frame update.
    private void Start()
    {
        
    }

    // Update is called once per frame.
    private void Update()
    {
        transform.Translate(Vector3.left * (Time.deltaTime * Speed));
    }
}

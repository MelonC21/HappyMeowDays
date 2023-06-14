using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{

    [SerializeField]
    private Transform playerLocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerLocation != null)
        {
            transform.LookAt(playerLocation);
        }
    }
}

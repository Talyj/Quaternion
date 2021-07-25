using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleBehaviour : MonoBehaviour
{
    /*ICI AJOUTER LA FONCTIONNALITE DE ROTATION QUATERNION*/
    private float speed;
    //0 = left 1 = right
    public int direction;
    void Start()
    {
        speed = Random.Range(10, 30);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (direction == 0)
        {
            transform.position += transform.right * Time.deltaTime * speed;   
        }
        else
        {
            transform.position += transform.right * Time.deltaTime * -speed;   
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);   
        }
    }
}

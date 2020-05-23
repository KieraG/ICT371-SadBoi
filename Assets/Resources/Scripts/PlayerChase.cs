using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerChase : MonoBehaviour
{

    public Transform player;
    public int viewDistance = 100000;
    public float speed = 0.01f;
    public float multiplier = 0.0001f;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void Update()
    {
        
        if (Vector3.Distance(player.position, this.transform.position) < viewDistance) //if player comes within a distance less than 10, Apex activates
        {
            Vector3 direction = player.position - this.transform.position;

            direction.y = 0.0f;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                            Quaternion.LookRotation(direction), 0.1f); //same as above note. not sure what went wrong

            this.GetComponent<Rigidbody>().AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.Impulse);
        }

    }

}


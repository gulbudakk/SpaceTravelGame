using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 250f;

    public GameObject rotator;
    public bool notBounded = false;
    public float time = 0.3f;

    public GameObject collidedPlanet;
    public Text score;
    private int num;
    public Text highScore;
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    void OnBecameInvisible()
    {
        SceneManager.LoadScene(1);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        

        if (collider.tag == "Rotator" && collider.gameObject != collidedPlanet) //if player hits a planet, orbit it
        {
            notBounded = false;
            rotator = collider.gameObject;
            transform.parent = rotator.transform;
            rb.velocity = Vector2.zero; rb.angularVelocity = 0f;
            num++;
            score.text = num.ToString();
            if (num > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", num);
                highScore.text = num.ToString();
            }
        }
    }

    void Unbind()
    {
        transform.parent = null; //unbind from parent which is rotator
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && notBounded == false)
        {
            notBounded = true;
            Invoke("Unbind", time);
        }

        if (notBounded)
        {
            //add force to player in the direction it is rotating
            rb.AddForce(transform.up * speed * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AngryBall : MonoBehaviour
{
    [SerializeField] public TMP_Text ScoreText;
    [HideInInspector] public int Points = 0;
    [HideInInspector] public bool ballIsActive;
    private Vector3 ballPosition;
    private Vector2 ballInitialForce;
    private Rigidbody2D _rb;
    [SerializeField] private GameObject playerObject;
    private float lowBorderPosition = -5.12f;
    private float respawnPosition = -3.51f;

    private void Start ()
    {
      ballInitialForce = new Vector2(100, 200);
      ballIsActive = false;
      ballPosition = transform.position;
     _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") == true)
        {
            if (!ballIsActive)
            {
                _rb.AddForce(ballInitialForce);
                ballIsActive = !ballIsActive; 
            }
        }
        if (!ballIsActive && playerObject != null) 
        {
            ballPosition.x = playerObject.transform.position.x;
            transform.position = ballPosition; 
        }
        else if (ballIsActive && transform.position.y <lowBorderPosition)
        {
          ballIsActive = !ballIsActive;
          ballPosition.x = playerObject.transform.position.x;
          ballPosition.y= respawnPosition;
          transform.position = ballPosition;
          _rb.AddForce(ballInitialForce);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            Debug.Log("boom");
            Points++;
           
            ScoreText.text ="Score: " + Points.ToString();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;
using UnityEditor.DeviceSimulation;

public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private int ScoreValue = 1;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] float ms = 6f;
    [SerializeField] float hs = 5f;
    public delegate void MessageEvent();
    public static event MessageEvent ObjetToucher;

    [SerializeField] Transform groundCheck;

    private void Start()
    {
        _rigidbody= GetComponent<Rigidbody>();
        _scoreText.text = "Score : " + ScoreValue;
    }
    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        _rigidbody.velocity = new Vector3(horizontalInput * ms, _rigidbody.velocity.y, verticalInput * ms);

        if (Input.GetButtonDown("Jump"))
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, hs, _rigidbody.velocity.z);
        }


    }
    
    private void OnTriggerEnter(Collider other)
    {   

        if (other.gameObject.CompareTag("Target_Trigger"))
        {
            
            Destroy(other.gameObject);
            ScoreValue++;
            _scoreText.text = "Score : " + ScoreValue;
            ObjetToucher();
        }
    }
    // 
    /*public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target_T"))
        {
            Destroy(collision.gameObject);
            ScoreValue++;
            _scoreText.text = "Score : " + ScoreValue;
            
        }
    }*/
    
}


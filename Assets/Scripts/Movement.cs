using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 180f;
    public Joystick joystick;
    private Rigidbody rb;
    public TextMeshProUGUI text;
    int score = 0;
    public Slider slider;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        float verticalInput = joystick.Vertical;
        float horizontalInput = joystick.Horizontal;

     
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

  
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.3f);
        }
    }
    public void jump()
    {

        rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("coin"))
        {
            score = score + 1;
            text.SetText(score.ToString());
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag.Equals("spike"))
        {


            slider.value -= 10;
            Destroy(other.gameObject);

        }
    }

}


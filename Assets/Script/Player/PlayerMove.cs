using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rig;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
/*        if (Joystick.isInput)
        {
            transform.position = (rig.position + Joystick.inputDirection * Time.deltaTime * speed);
        }*/
    }

    private void FixedUpdate()
    {
        if (Joystick.isInput)
        {
            rig.MovePosition(rig.position + Joystick.inputDirection * Time.deltaTime * speed);
        }
    }
}

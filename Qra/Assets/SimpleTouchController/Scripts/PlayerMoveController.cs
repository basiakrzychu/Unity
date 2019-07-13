using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMoveController : MonoBehaviour {

	
	public SimpleTouchController leftController;
	
	public float speedV = 25f;

    public float speedH = 25f;

    Animator anim;

    private Rigidbody2D _rigidbody;

    public float acc = 0.025f;


    void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        speedV += acc;

        anim.SetFloat("input_x", leftController.GetTouchPosition.x);
        anim.SetFloat("input_y", leftController.GetTouchPosition.y);

        if (leftController.GetTouchPosition.y!=0 || leftController.GetTouchPosition.x!=0)
        {
            anim.SetBool("isrunning", true);
            anim.SetBool("isidle", false);

           

            _rigidbody.MovePosition(transform.position + (transform.up * leftController.GetTouchPosition.y * Time.deltaTime * speedV) +
            (transform.right * leftController.GetTouchPosition.x * Time.deltaTime * speedH));
        }
        else
        {
            anim.SetBool("isrunning", false);
            anim.SetBool("isidle", true);
        }
    }

	

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpSTR;
    [SerializeField] float turnSmoothTime;

    float turnSmoothVelocity;
    [SerializeField] float gravity = 9.8f;

    Animator animator;
    CharacterController controller;

    [SerializeField] GameObject attackPrefab;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Gravity();

        Attack();
    }

    void Move()
    {
        if (controller.isGrounded == false)
        {
            return;
        }

        // Movment script credited to Brackeys' video: https://www.youtube.com/watch?v=4HpC--2iowE and Unity3D School's video: https://www.youtube.com/watch?v=ExEJtw2mhR4
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction.y = jumpSTR;
        }

        controller.Move(direction * (speed * Time.deltaTime));
    }

    void Gravity()
    {
        if (controller.isGrounded == false)
        {
            controller.Move(Vector3.down * (gravity * Time.deltaTime));
        }
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

        }
    }
}

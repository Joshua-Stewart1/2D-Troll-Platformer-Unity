using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;

    public GameObject projectile;

    public float maxSpeed = 8;
    public float jumpForce = 5;
    public float walkForce = 20;
    public float runForce = 40;
    public float projectileSpeed = 1;
    public int projectileLimit = 3;

    private bool canJump = true;
    private int direction = -1;
    private int projectileCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //Detect collisions for landing
    void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D[] contacts = collision.contacts;
        for (int i = 0; i < contacts.Length; i++)
        {
            if (contacts[i].point.y < transform.position.y - 0.40f)
            {
                canJump = true;
            }
        }
    }

    //Process player dying in the scene
    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Set direction for projectile code
    private void SetDirection()
    {
        if (body.velocity.x > 0.01 && canJump)
        {
            direction = 1;
        }
        else if (body.velocity.x < -0.01 && canJump)
        {
            direction = -1;
        }
    }

    //Calculate the player's movement options
    private void HandleMovement()
    {
        //Handle running
        body.AddForce(new Vector2(Input.GetAxis("Horizontal") *
            (Input.GetButton("Run") ? runForce : walkForce) * Time.deltaTime, 0.0f));

        //Handle jumping
        if (body.velocity.y < -0.01f)
            canJump = false;
        if (body.velocity.y > -0.01f && body.velocity.y < 0.01f && body.GetContacts(new ContactPoint2D[1]) > 0)
            canJump = true;
        if (Input.GetButtonDown("Hop") && canJump)
        {
            body.AddForce(new Vector2(0.0f, jumpForce * Mathf.Sqrt(1 + Mathf.Abs(body.velocity.x) / (maxSpeed * 3))),
                ForceMode2D.Impulse);
            canJump = false;
        }
    }

    //Handle projectile firing
    private void ShootProjectile()
    {
        if (Input.GetButtonDown("Jump") && projectileCount < projectileLimit)
        {
            GameObject p = Instantiate(projectile, transform.position + new Vector3(0.5f * direction, -0.09f, transform.position.z), transform.rotation);
            p.GetComponent<Rigidbody2D>().AddForce(new Vector2(projectileSpeed * direction, 0f), ForceMode2D.Impulse);
            p.GetComponent<ProjectileMovement>().SetPlayer(this);
            projectileCount++;
        }
    }

    public void ProjectileDeath()
    {
        projectileCount--;
    }

    // Update is called once per frame
    void Update()
    {

        SetDirection();
        HandleMovement();
        ShootProjectile();

        //Set values for animations
        animator.SetFloat("VelocityX", body.velocity.x);
        animator.SetBool("Grounded", canJump);
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(Mathf.Clamp(body.velocity.x, -maxSpeed, maxSpeed), body.velocity.y);
    }
}

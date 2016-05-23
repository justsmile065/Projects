using UnityEngine;
using System.Collections;

public class CharacterController2D : MonoBehaviour
{

    public float Maxspeed = 10f; // максимальная скорость движения персонажа
    private bool isFacingRight = true; // Определение направления вправо/влево
    private Animator anim; // Ссылка на компонент анимаций
    private bool isGrounded = true;
    public Transform groundcheck;
    private float groundRadius = 0.2f;
    public LayerMask whatisground;

	private void Start ()
    {
        anim = GetComponent<Animator>();
	}

    public Rigidbody2D RB;
	private void FixedUpdate ()
    {

        isGrounded = Physics2D.OverlapCircle(groundcheck.position, groundRadius, whatisground);

        anim.SetBool("Ground", isGrounded);

        anim.SetFloat("Vspeed", RB.velocity.y);

        if (!isGrounded)
            return;


        float Move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(Move));
        RB.velocity = new Vector2(Move * Maxspeed, RB.velocity.y);

        if (Move > 0 && !isFacingRight)
            Flip();
        else if (Move < 0 && isFacingRight)
            Flip();
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;

        transform.localScale = theScale;
    }

    private void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);

            RB.AddForce(new Vector2(0, 600));
        }
    }
}

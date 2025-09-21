using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private float speedSide = 20f;
    [SerializeField] private float jumpForce = 250f;
    private float moveInput;
    private Rigidbody rb;
    private Animator animator;
    private bool isGrounded;
    private bool isDie = false;
    private AudioManager audioManager;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = false;
        animator = GetComponent<Animator>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }


    void Update()
    {
        if (isDie) return;
        float accelerate = 10 + Mathf.Floor(RoadSpawner.instance.roadCount / 10f);
        if (speed < accelerate) speed = accelerate;
        moveInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            animator.SetBool("isJump", true);
            audioManager.PlayJumpSound();
        }
        if (transform.position.y < -5f)
        {
            Die();
        }
    }
    void FixedUpdate()
    {
        if (isDie) return;
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * Vector3.forward
        + moveInput * speedSide * Time.fixedDeltaTime * Vector3.right);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJump", false);
        }

    }

    public void Die()
    {
        isDie = true;
        animator.SetBool("isDie", true);
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        GameOver();
    }

    private void GameOver()
    {
        GameManager.Instance.gameUI.StartGameOverUI();
    }
}

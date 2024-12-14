using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Bandit : MonoBehaviour
{
    [SerializeField] float m_speed = 4.5f;
    [SerializeField] float m_jumpForce = 7.5f;
    public BoxCollider2D standingCollider; 

    private Animator m_animator;
    private Rigidbody2D m_body2d;
    private Sensor_Bandit m_groundSensor;
    private bool isCrouching = false;

    private bool m_grounded = false;
    private bool m_combatIdle = false;
    private bool m_isDead = false;
    private Vector3 m_originalScale; 
    private Player_Combat playerCombat;

    // Use this for initialization
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();

        // Store the original scale
        m_originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if character just landed on the ground
        if (!m_grounded && m_groundSensor.State())
        {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
        }

        // Check if character just started falling
        if (m_grounded && !m_groundSensor.State())
        {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        // -- Handle input and movement --
        float inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
            transform.localScale = new Vector3(-Mathf.Abs(m_originalScale.x), m_originalScale.y, m_originalScale.z);
        else if (inputX < 0)
            transform.localScale = new Vector3(Mathf.Abs(m_originalScale.x), m_originalScale.y, m_originalScale.z);

        // Move
        m_body2d.linearVelocity = new Vector2(inputX * m_speed, m_body2d.linearVelocity.y);

        // Set AirSpeed in animator
        m_animator.SetFloat("AirSpeed", m_body2d.linearVelocity.y);

        // -- Handle Animations --
        // Death
        if (Input.GetKeyDown("e"))
        {
            if (!m_isDead)
                m_animator.SetTrigger("Death");
            else
                m_animator.SetTrigger("Recover");

            m_isDead = !m_isDead;
            SceneManager.LoadScene("Boss_Scene");
        }
        
        // Hurt
        else if (Input.GetKeyDown("q"))
            m_animator.SetTrigger("Hurt");

        // Attack
        // else if (Input.GetMouseButtonDown(0))
        // {
        //     m_animator.SetTrigger("Attack");
        // }
        
        // Change between idle and combat idle
        else if (Input.GetKeyDown("f"))
            m_combatIdle = !m_combatIdle;

        // Jump
        else if (Input.GetKeyDown("space") && m_grounded)
        {
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.linearVelocity = new Vector2(m_body2d.linearVelocity.x, m_jumpForce);
            m_groundSensor.Disable(0.2f);
        }

        // Run
        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
            m_animator.SetInteger("AnimState", 2);

        // Combat Idle
        else if (m_combatIdle)
            m_animator.SetInteger("AnimState", 1);

        // Idle
        else
            m_animator.SetInteger("AnimState", 0);
            

        if(Input.GetKeyDown("c")&&!isCrouching){
                Crouch();
        }   
        else if (Input.GetKeyUp("c") && isCrouching)
        {
            StandUp();
        }
        
    }
     void StandUp()
    {
        isCrouching = false;
        if (standingCollider != null)
        {
            standingCollider.enabled = true;
        }

    }
     void Crouch()
    {
        isCrouching = true;
        if (standingCollider != null)
        {
            standingCollider.enabled = false;
        }

    }
    // void OnCollisionEnter2D(Collision2D collision) 
    // {
    //     // print("Collision");
    //     if (collision.gameObject.name.StartsWith("Black"))
    //     {
    //         // print("Going into the function");
    //         playerCombat.registerDamage(10); 
    //     }
    // }
}

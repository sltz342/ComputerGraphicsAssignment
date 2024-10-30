using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Vars for speeds
    [SerializeField] private float speed;

    //Vars for jumping
    [SerializeField] private float jumpForce;
    private Boolean isGrounded;
    private Rigidbody rb;
    private float depth;

    [SerializeField] private LayerMask groundLayers;


    //Vars for movement and cubePrefab
    private Vector3 _moveDir;
    public GameObject cubePrefab;

    //Vars for Mouse Camera Control
    [SerializeField, Range(1, 20)] private float mouseSensX;
    [SerializeField, Range(1, 20)] private float mouseSensY;

    private Vector2 currentRotation;
    [SerializeField] private Transform followTarget;

    [SerializeField, Range(-90, 0)] private float minViewAngle;
    [SerializeField, Range(0, 90)] private float maxViewAngle;

    //For Coin Collection
    private int coinsCollected = 0;
    
    
    //For UI and Health Shown
    [Header("Player UI")]
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI healthShown;


    [SerializeField] private float maxHealth;
    private float _health;

    
    private float Health
    {
        get => _health;
        set { 
            _health = value;
            healthBar.fillAmount = _health / maxHealth;
        }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        InputManager.Init(this);

        healthShown.text = "Health";
        rb = GetComponent<Rigidbody>();
        depth = GetComponent<Collider>().bounds.size.y;

        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.rotation * (speed * Time.deltaTime * _moveDir);
        CheckGround();
    }
    public void setMovementDirection(Vector3 newDirection)
    {
        _moveDir = newDirection;


    }
    
    public void jump() {
        Debug.Log("Jump called");
        if(isGrounded )
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    
    }
    
    public void setLookDirection(Vector2 readValue)
    {
        //Controls rotation angles
        currentRotation.x += readValue.x * Time.deltaTime * mouseSensX;
        currentRotation.y += readValue.y * Time.deltaTime * mouseSensY;

        //Controls looking left and right
        transform.rotation = Quaternion.AngleAxis(currentRotation.x, Vector3.up);
        followTarget.localRotation = Quaternion.AngleAxis(currentRotation.y, Vector3.right);

        //Clamps 
        currentRotation.y = Mathf.Clamp(currentRotation.y, minViewAngle, maxViewAngle);

        //
        followTarget.localRotation = Quaternion.AngleAxis(currentRotation.y, Vector2.right);
    }
    
    private void CheckGround()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, depth, groundLayers);

        Debug.DrawRay(transform.position, Vector3.down * depth, Color.red, 0, false);
    }
    
    public void GotCoin(int i)
    {
        coinsCollected = coinsCollected + i;
        Debug.Log("You have collected " + coinsCollected + " coins so far!");
    }
}

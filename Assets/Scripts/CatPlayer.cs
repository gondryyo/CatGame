using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPlayer : MonoBehaviour
{
    [SerializeField] private float speed;

    public static CatPlayer Instance;
    private PlayerInputActions playerInputActions;
    private Rigidbody2D rb;

    public List<Transform> catList = new List<Transform>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        playerInputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        playerInputActions.Enable();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = new Vector3(playerInputActions.Standard.Movement.ReadValue<Vector2>().x, playerInputActions.Standard.Movement.ReadValue<Vector2>().y, 0).normalized;
        rb.AddForce(direction * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Cat"))
        {
            if (collision.transform.GetComponent<CatScript>().catCollected == false)
            {
                Transform currentCat = collision.transform;

                if (catList.Count == 0)
                {
                    collision.transform.GetComponent<CatScript>().currentTarget = transform;
                }
                else
                {
                    collision.transform.GetComponent<CatScript>().currentTarget = catList[catList.Count - 1];
                }

                collision.transform.GetComponent<CatScript>().catCollected = true;
                catList.Add(currentCat);
            }
            
        }
        
    }
}

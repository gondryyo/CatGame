using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    public bool catCollected;
    public Transform currentTarget;

    [SerializeField] private float speed;
    [SerializeField] private float spacing;

    private void Start()
    {
        catCollected = false;
    }

    private void Update()
    {
        if (catCollected)
        {
            if (currentTarget != null)
            {
                Move(currentTarget);
            }
        }
    }

    private void Move(Transform followTarget)
    {
        Vector3 dir = followTarget.position - transform.position;
        dir = dir.normalized;

        if ((followTarget.position - transform.position).magnitude > spacing)
        {
            transform.Translate(dir * speed * Time.deltaTime);

        }
    }
}

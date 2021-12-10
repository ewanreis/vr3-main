using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public CharacterController target;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0.2f,0);
        
    }
    void FixedUpdate()
    {
        Vector2 toTarget = target.transform.position - transform.position;
        float speed = 1.5f;

        transform.Translate(toTarget * speed * Time.deltaTime);
    }
}

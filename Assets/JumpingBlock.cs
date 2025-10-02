using System;
using UnityEngine;

public class JumpingBlock : MonoBehaviour
{
    [SerializeField] private Transform block;
    [SerializeField] private Vector3 accelerationBegin;
    [SerializeField] private Vector3 velocityBegin;

    private Vector3 velocity;
    private Vector3 acceleration;
    private float t = 0;

    private float yMin;

    enum  State
    {
        onGround, airBorne
    }

    private State myState = State.onGround;

    private void Start()
    {
        yMin = block.position.y;
    }

    private void Update()
    {
        if (myState == State.onGround)
        {
            t = 0;
            velocity = Vector3.zero;
            acceleration = Vector3.zero;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity = velocityBegin;
                acceleration = accelerationBegin;
                myState = State.airBorne;   
            }
        }

        if (myState == State.airBorne)
        {
            t += Time.deltaTime;
            if (block.position.y < yMin)
            {
                Debug.Log(t);
                myState = State.onGround;
                velocity = Vector3.zero;
                acceleration = Vector3.zero;
                block.position = new Vector3(block.position.x, yMin, block.position.z); 
            }
        }
        
        velocity += acceleration * Time.deltaTime;
        block.position += velocity * Time.deltaTime;
        
    }
}

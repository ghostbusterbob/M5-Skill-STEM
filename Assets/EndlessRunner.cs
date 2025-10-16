using UnityEngine;

public class EndlessRunner : MonoBehaviour
{
    [SerializeField] float vBegin = 5;

    [SerializeField] float gravity = -10;



    Animator animator;
    Vector3 velocity = Vector3.zero;
    Vector3 acceleration = Vector3.zero;

    float tmax = 0.867f;
    float t = 0;



    enum State { running, jumping};
    State myState = State.running;

    void Start()
    {
        animator = GetComponent<Animator>();
       
    }

    void Update()
    {
        if (myState == State.running) {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                t = 0;
                myState = State.jumping;
                animator.Play("jump");
                velocity = new Vector3(0, vBegin, 0);

                gravity = -2 * vBegin / (tmax);
                acceleration = new Vector3(0, gravity, 0);

            }
        }
        ;
        if (myState == State.jumping)
        {
            t += Time.deltaTime;
            if(t > tmax)
            {
                velocity = Vector3.zero;
                acceleration = Vector3.zero;
                myState = State.running;

            }
        };



        velocity += acceleration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
       
    }
}
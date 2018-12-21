using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMovement : MonoBehaviour
{
    private GameObject pawn;
    private Vector3 destination;
    public float speed = 100;

    void IncrementPosition()
    {
        float delta = speed * Time.deltaTime;
        Vector3 currentPosition = gameObject.transform.position;
        Vector3 nextPosition = Vector3.MoveTowards(currentPosition, destination, delta);

        gameObject.transform.position = nextPosition;
    }


    // Start is called before the first frame update
    void Start()
    {
        destination = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       if (destination != gameObject.transform.position)
        {
            IncrementPosition();
        }

    }


    public void SetDestination(Vector3 location)
    {
        destination = location;
    }
}

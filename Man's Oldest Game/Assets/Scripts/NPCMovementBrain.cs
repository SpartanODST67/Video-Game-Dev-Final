using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovementBrain : MonoBehaviour
{
    [SerializeField] List<Transform> movementPoints = new List<Transform>();
    [SerializeField] int movementPointIndex = 0;
    [SerializeField] float arrivalThreshold = 0.001f;
    [SerializeField] float positionDifferenceThreshold = 0.001f;
    [SerializeField] ControllableCharacter character;
    [SerializeField] GameObject battleSystem;

    private void Update()
    {
        if(battleSystem.activeSelf)
        {
            return;
        }
        float pointDistance = StraightDistance(movementPoints[movementPointIndex].position);
        if(pointDistance <= arrivalThreshold)
        {
            movementPointIndex++;
            movementPointIndex %= movementPoints.Count;
        }
        Vector3 movementVector = MovementVector(movementPoints[movementPointIndex].position);
        character.move(movementVector);
    }

    private float StraightDistance(Vector3 destinationPoint)
    {
        return Mathf.Sqrt(Mathf.Pow(transform.position.x - destinationPoint.x, 2) + Mathf.Pow(transform.position.y - destinationPoint.y, 2));
    }

    private Vector3 MovementVector(Vector3 destinationPoint)
    {
        Vector3 movementVector = new Vector3();
        
        if(Mathf.Abs(destinationPoint.x - transform.position.x) < positionDifferenceThreshold)
        {
            movementVector.x = 0;
        }
        else if(destinationPoint.x > transform.position.x)
        {
            movementVector.x = 1;
        }
        else if(destinationPoint.x < transform.position.x)
        {
            movementVector.x = -1;
        }
        else
        {
            movementVector.x = 0;
        }

        if (Mathf.Abs(destinationPoint.y - transform.position.y) < positionDifferenceThreshold)
        {
            movementVector.y = 0;
        }
        else if (destinationPoint.y > transform.position.y)
        {
            movementVector.y = 1;
        }
        else if(destinationPoint.y < transform.position.y)
        {
            movementVector.y = -1;
        }
        else
        {
            movementVector.y = 0;
        }

        return movementVector;
    }
}

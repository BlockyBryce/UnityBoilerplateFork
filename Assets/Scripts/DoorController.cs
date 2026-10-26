using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public bool doorOpen = true;
    public GameObject door;
    public float closeSpeed = 200f;
    public GameObject openPos;
    public GameObject closePos;

    private Transform target;
    private bool doorMoving = false;

    void Start()
    {
        target = openPos.transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            var audioPlayer = FindAnyObjectByType<AudioController>();
            if (doorMoving == false)
            {
                audioPlayer.DoorButtonPress(true);
                if (doorOpen == true)
                {
                    doorOpen = false;
                    target = closePos.transform;
                }
                else
                {
                    doorOpen = true;
                    target = openPos.transform;
                }
                doorMoving = true;
            }
            else
            {
                audioPlayer.DoorButtonPress(false);
            }
        }

        if (doorMoving == true)
        {
            float step = closeSpeed * Time.deltaTime;
            if (doorOpen == true)
            {
                door.transform.position = Vector3.MoveTowards(door.transform.position, target.position, step);
            }
            else if (doorOpen == false)
            {
                door.transform.position = Vector3.MoveTowards(door.transform.position, target.position, step);
            }
        }
        if (door.transform.position == target.position)
        {
            doorMoving = false;
        }
    }
}
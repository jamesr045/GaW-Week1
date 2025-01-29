using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Rendering;

public class DrawLine : MonoBehaviour
{
    LineRenderer line;
    Vector3 previousPosition;

    [SerializeField]
    private float minDistance = 0.01f;
    [SerializeField,Range(0,1)]
    public float width;

    private bool lineComplete;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 1;
        previousPosition = transform.position;
        line.startWidth = line.endWidth = width;

        lineComplete = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (lineComplete == false)
            {
                Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentPosition.z = 0f;

                if (Vector3.Distance(currentPosition, previousPosition) > minDistance)
                {
                    if (previousPosition == transform.position)
                    {
                        line.SetPosition(0, currentPosition);
                    }
                    else
                    {
                        line.positionCount++;
                        line.SetPosition(line.positionCount - 1, currentPosition);
                    }

                    previousPosition = currentPosition;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            lineComplete = true;
        }
    }
}

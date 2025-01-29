using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    public GameObject line;

    Color currentColour;
    public float lineWidth;

    private void Start()
    {
        currentColour = Color.black;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject drawnLine = Instantiate(line);


            drawnLine.GetComponent<LineRenderer>().startColor = currentColour;
            drawnLine.GetComponent <LineRenderer>().endColor = currentColour;
            drawnLine.GetComponent<DrawLine>().width = lineWidth;
        }

        if (Input.GetMouseButton(1))
        {
            //While holding right click, delete any lines underneath the cursor
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Line"))
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }



        if (Input.GetKey(KeyCode.Alpha1))
        {
            currentColour = Color.black;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            currentColour = new Color(255,0,106);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            currentColour = Color.yellow;
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            currentColour = Color.blue;
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            currentColour = Color.green;
        }
    }
}

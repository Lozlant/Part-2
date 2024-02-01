using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    Vector2 lastPosition;
    public float pointThreshold = 0.2f;
    LineRenderer lineRenderer;
    Rigidbody2D rigidbody;
    Vector2 currentPosition;
    float speed;
    public AnimationCurve landing;
    public float timerValue;
    public Sprite[] planeSprites= new Sprite[4];
    
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();

        lineRenderer.positionCount = 1;

        lineRenderer.SetPosition(0, transform.position + new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0));
        GetComponent<Transform>().rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        speed = Random.Range(1f, 3f);
        GetComponent<SpriteRenderer>().sprite = planeSprites[(int)Random.Range(0, 4)];
        


    }
    private void FixedUpdate()
    {
        currentPosition = transform.position;
        if(points.Count > 0 )
        {
            Vector2 direction = points[0] - currentPosition;
            float angle= Mathf.Atan2(direction.x,direction.y)*Mathf.Rad2Deg;
            rigidbody.rotation = -angle;
        }
        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up * speed * Time.deltaTime);

    }
    private void Update()
    {
        Vector3 posIncamera=Camera.main.WorldToViewportPoint(transform.position);
        if (posIncamera.x < 0 || posIncamera.y < 0 || posIncamera.x > 1 || posIncamera.y > 1)
        {
            Destroy(gameObject);
        }
        if (!GetComponent<SpriteRenderer>().isVisible)
        {
            Destroy(gameObject);
        }
            if (Input.GetKey(KeyCode.Space))
        {
            timerValue += 0.5f * Time.deltaTime;
            float interpolation = landing.Evaluate(timerValue);
            if(transform.localScale.z < 0.1f) 
            {
                Destroy(gameObject);
            }

            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        }
        lineRenderer.SetPosition(0, transform.position);
        if (points.Count > 0 )
        {
            if (Vector2.Distance(currentPosition, points[0]) < pointThreshold)
            {
                points.RemoveAt(0);

                for(int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }
        }
    }
    private void OnMouseDown()
    {
        points = new List<Vector2>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }
    private void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Vector2.Distance(newPosition, lastPosition) > pointThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
            lastPosition = newPosition;
        }        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Vector3.Distance(GetComponent<Transform>().position, collision.gameObject.transform.position) <= 1f)
        {
            Destroy(collision.gameObject);
        }
    }
}

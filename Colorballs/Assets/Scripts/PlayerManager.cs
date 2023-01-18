using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Transform ball;
    private Vector3 startMousePos, startBallPos; 
    private bool moveTheBall;
    private float maxSpeed, velocity;

    
    void Start()
    {
        ball = transform;
        maxSpeed = 0.5f;

    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            moveTheBall = true;

            Plane newPlan = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(newPlan.Raycast(ray, out var distance))
            {
                startMousePos = ray.GetPoint(distance);
                startBallPos = ball.position;
            }

            else if(Input.GetMouseButtonUp(0))
            {
                moveTheBall = false;
            }

            if(moveTheBall)
            {
                Plane newPlan = new Plane(Vector3.up, 0f);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if(newPlan.Raycast(ray, out var distance))
                {
                    Vector3 mouseNewPos = ray.GetPoint(distance);
                    Vector3 MouseNewPos = mouseNewPos - startMousePos;
                    Vector3 DesireBallPos = mouseNewPos + startBallPos;

                    ball.position = new Vector3(Mathf.SmoothDamp(ball.position.x, DesireBallPos.x, ref velocity, maxSpeed), ball.position.y, 
                        ball.position.z);
                    
                }
            }

        }
    }
}

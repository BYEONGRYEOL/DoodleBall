using UnityEngine;
using System.Collections.Generic;
using LevelManagement;
namespace LineGame
{
    public class LineWithAccel : MonoBehaviour
    {
        public SurfaceEffector2D surfaceEffector2D;
        public LineRenderer lineRenderer;
        public EdgeCollider2D edgeCollider;
        public Rigidbody2D rigidBody;
        private DrawLineWithAccel drawLineWithAccel;


        [HideInInspector] public List<Vector2> points = new List<Vector2>();
        [HideInInspector] public int pointsCount = 0;

        //The minimum distance between line's points.
        float pointsMinDistance = 0.1f;

        //Circle collider added to each line's point
        float circleColliderRadius;
        private void Awake()
        {
            drawLineWithAccel = FindObjectOfType<DrawLineWithAccel>();
        }
        public void AddPoint(Vector2 newPoint)
        {
            //If distance between last point and new point is less than pointsMinDistance do nothing (return)
            if (pointsCount >= 1 && Vector2.Distance(newPoint, GetLastPoint()) < pointsMinDistance)
                return;

            points.Add(newPoint);
            pointsCount++;

            //Add Circle Collider to the Point
            CircleCollider2D circleCollider = this.gameObject.AddComponent<CircleCollider2D>();
            circleCollider.offset = newPoint;
            circleCollider.radius = circleColliderRadius;

            //Line Renderer
            if (points.Count >= 2)
            {
                drawLineWithAccel.nowInk_line += Vector2.Distance(points[pointsCount - 1], points[points.Count - 2]);

                UI_Ingame_R.Instance.SliderUpdate();


            }
            lineRenderer.positionCount = pointsCount;
            lineRenderer.SetPosition(pointsCount - 1, newPoint);


            //Edge Collider
            //Edge colliders accept only 2 points or more (we can't create an edge with one point :D )
            if (pointsCount > 1)
                edgeCollider.points = points.ToArray();
        }

        public Vector2 GetLastPoint()
        {
            return (Vector2)lineRenderer.GetPosition(pointsCount - 1);
        }
        
        
        public void UsePhysics(bool usePhysics)
        {
            // isKinematic = true  means that this rigidbody is not affected by Unity's physics engine
            rigidBody.isKinematic = !usePhysics;
        }

        public void SetLineColor(Gradient colorGradient)
        {
            lineRenderer.colorGradient = colorGradient;
        }

        public void SetPointsMinDistance(float distance)
        {
            pointsMinDistance = distance;
        }

        public void SetLineWidth(float width)
        {
            lineRenderer.startWidth = width;
            lineRenderer.endWidth = width;

            circleColliderRadius = width / 2f;

            edgeCollider.edgeRadius = circleColliderRadius;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            
            if (collision.gameObject.CompareTag("Player"))
            {
                if (Player.Instance.IsFastAlready())
                    surfaceEffector2D.enabled = false;
                else
                {
                    surfaceEffector2D.enabled = true;
                }
                Debug.Log("CollisionEnter 실행");
                if (Player.Instance.IsGoingRight())
                {
                    Debug.Log("오른쪽 가속");
                    surfaceEffector2D.speed = 5;
                }
                else
                {
                    Debug.Log("왼쪽 가속");
                    surfaceEffector2D.speed = -5;
                }
            }
        }
        private void OnCollisionStay2D(Collision2D collision)
        {
            
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("CollisionStay 실행");

                if (Player.Instance.IsFastAlready())
                {
                    Debug.Log("IsFastAlready");
                    surfaceEffector2D.enabled = false;
                }
                else
                {
                    surfaceEffector2D.enabled = true;
                }
                if (surfaceEffector2D.speed != 0)
                {
                    Debug.Log("IsFastAlready");
                    return;
                }
                if (Player.Instance.IsGoingRight())
                {
                    Debug.Log("오른쪽 가속");
                    surfaceEffector2D.speed = 5;
                }
                else
                {
                    Debug.Log("왼쪽 가속");
                    surfaceEffector2D.speed = -5;
                }
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            Debug.Log("가속선 초기화");
            if (collision.gameObject.CompareTag("Player"))
            {
                surfaceEffector2D.speed = 0;
            }
        }
    }
}
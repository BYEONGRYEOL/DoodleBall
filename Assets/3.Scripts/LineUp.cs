using UnityEngine;
using System.Collections.Generic;
using LevelManagement;
namespace LineGame
{
    public class LineUp : MonoBehaviour
    {
        [SerializeField] private int triggerCount = 0;
        
        public LineRenderer lineRenderer;
        public EdgeCollider2D edgeCollider;
        
        private DrawLineUp drawLineUp;


        [HideInInspector] public List<Vector2> points = new List<Vector2>();
        [HideInInspector] public int pointsCount = 0;

        //The minimum distance between line's points.
        float pointsMinDistance = 0.1f;

        //Circle collider added to each line's point
        float circleColliderRadius;
        private void Awake()
        {
            drawLineUp = FindObjectOfType<DrawLineUp>();
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
            circleCollider.isTrigger = true;
            circleCollider.offset = newPoint;
            circleCollider.radius = circleColliderRadius;

            //Line Renderer
            if (points.Count >= 2)
            {
                drawLineUp.nowInk_line += Vector2.Distance(points[pointsCount - 1], points[points.Count - 2]);

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
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && triggerCount < 16)
            {
                Player.Instance.UpTrigger();
                triggerCount += 1;
            }
        }
    }
}
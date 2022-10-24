using UnityEngine;
using System.Collections.Generic;
using LevelManagement;
namespace LineGame
{
    public class Line : MonoBehaviour
    {
        public LineRenderer lineRenderer;
        public EdgeCollider2D edgeCollider;
        public Rigidbody2D rigidBody;
        private DrawLine drawLine;
        [HideInInspector] public List<Vector2> points = new List<Vector2>();
        [HideInInspector] public int pointsCount = 0;
        //The minimum distance between line's points.
        float pointsMinDistance = 0.1f;
        //Circle collider added to each line's point
        float circleColliderRadius;
        private void Awake()
        {
            drawLine = FindObjectOfType<DrawLine>();
        }
        public void AddPoint(Vector2 newPoint)
        {
            //그냥 화면을 꾹 누르고 있는경우 계속해서 새로운 edge로 인식하는 것을 막기위해 고안한 코드
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
                drawLine.nowInk_line += Vector2.Distance(points[pointsCount - 1], points[points.Count - 2]);
                UI_Ingame_R.Instance.SliderUpdate();
            }
            lineRenderer.positionCount = pointsCount;
            lineRenderer.SetPosition(pointsCount - 1, newPoint);
            //엣지 콜라이더는 점이 2개 이상이 이어져야 유니티 엔진에서 콜라이더역할을 수행할수있다.
            if (pointsCount > 1)
                edgeCollider.points = points.ToArray();
        }

        public Vector2 GetLastPoint()
        {
            return (Vector2)lineRenderer.GetPosition(pointsCount - 1);
        }

        public void UsePhysics(bool usePhysics)
        {
            // isKinematic = true  중력 안받겠다는거
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

    }
}
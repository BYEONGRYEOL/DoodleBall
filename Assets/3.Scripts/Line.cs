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
            //�׳� ȭ���� �� ������ �ִ°�� ����ؼ� ���ο� edge�� �ν��ϴ� ���� �������� ����� �ڵ�
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
            //���� �ݶ��̴��� ���� 2�� �̻��� �̾����� ����Ƽ �������� �ݶ��̴������� �����Ҽ��ִ�.
            if (pointsCount > 1)
                edgeCollider.points = points.ToArray();
        }

        public Vector2 GetLastPoint()
        {
            return (Vector2)lineRenderer.GetPosition(pointsCount - 1);
        }

        public void UsePhysics(bool usePhysics)
        {
            // isKinematic = true  �߷� �ȹްڴٴ°�
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
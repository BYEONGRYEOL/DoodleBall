using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace LineGame
{
    public class DummyDrawLine : MonoBehaviour
    {
        /*[SerializeField] private GameObject line;
        private GameObject[] lines;
        public Toggle activeToggle;
        [SerializeField] private float ink;
        
        #region VARIABLE FOR MOBILE
        private Touch touch;
        private Vector2 touchPosition;
        #endregion
        Vector3 mP;
        public float delay = 0.3f;
        private float circleColliderRadius = 0.1f;
        private int pointsCount = 0;
        private float minDistance = 0.1f;

        float usedInk = 0;
        
        LineRenderer lineRenderer;
        EdgeCollider2D collider2D;
        CircleCollider2D circleCollider;
        List<Vector2> points = new List<Vector2>();

        private void Start()
        {
            
            activeToggle = UI_Ingame_R.Instance.lineWithGravityToggle;
            
        }
        

        
        void Update()
        {
            // on Mobile
            if (Input.touchCount == 1)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    GameObject myLine = Instantiate(line);
                    lineRenderer = myLine.GetComponent<LineRenderer>();
                    collider2D = myLine.GetComponent<EdgeCollider2D>();
                    points.Add(Camera.main.ScreenToWorldPoint(touch.position));
                    lineRenderer.positionCount = 1;
                    lineRenderer.SetPosition(0, points[0]);
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 position = Camera.main.ScreenToWorldPoint(touch.position);
                    if (Vector2.Distance(points[points.Count - 1], position) > 0.05f)
                    {
                        points.Add(position);
                        lineRenderer.positionCount++;
                        lineRenderer.SetPosition(lineRenderer.positionCount - 1, position);
                        collider2D.points = points.ToArray();
                    }
                }
                else if (touch.phase == TouchPhase.Ended)
                {

                    points.Clear();
                }
                else if (touch.phase == TouchPhase.Canceled)
                {
                    points.Clear();
                }


            }

            //on PC
            // 잉크 제한을 넘지 않았을 때 시작
            if (usedInk <= ink)
            {
                //마우스 클릭 시작시
                if (Input.GetMouseButtonDown(0))
                {
                    //UI와 게임필드 클릭 구분을 위해
                    if (EventSystem.current.IsPointerOverGameObject() == false)
                    {
                        
                        mP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        Debug.Log(mP);
                        RaycastHit2D hit = Physics2D.Raycast(mP, transform.forward, 15f);
                        Debug.Log(hit);
                        if (hit)
                        {
                            if (hit.transform.CompareTag("DefaultTile"))
                            {
                                return;
                            }
                        }
                        
                        Debug.Log("Down 실행 " + Input.mousePosition);
                        GameObject myLine = Instantiate(line);
                        Debug.Log("생성했나?");
                        lineRenderer = myLine.GetComponent<LineRenderer>();
                        collider2D = myLine.GetComponent<EdgeCollider2D>();
                        

                        points.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                        circleCollider = myLine.GetComponent<CircleCollider2D>();
                        circleCollider.offset = points[0];
                        circleCollider.radius = circleColliderRadius;
                        Debug.Log(points[0]);
                        lineRenderer.positionCount = 1;
                        lineRenderer.SetPosition(0, points[0]); 
                    }

                }
                //클릭되고있는 중간
                else if (Input.GetMouseButton(0))
                {
                    //UI클릭과 구분
                    if (EventSystem.current.IsPointerOverGameObject() == false)
                    {
                        mP = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        Debug.Log(mP);
                        RaycastHit2D hit = Physics2D.Raycast(mP, transform.forward, 15f);
                        Debug.Log(hit);
                        if (hit)
                        {
                            if (hit.transform.CompareTag("DefaultTile"))
                            {
                                points.Clear();
                                Debug.Log("충돌감지");
                                return;
                            }
                        }
                        if(points.Count != 0)
                        {
                            Debug.Log("충돌 없을 때");
                            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                            if (Vector2.Distance(points[points.Count - 1], position) > 0.05f)
                            {

                                Debug.Log("button 실행" + Input.mousePosition);
                                points.Add(position);

                                *//*circleCollider = myLine.GetComponent<CircleCollider2D>();\*//*
                                circleCollider.offset = points[0];
                                circleCollider.radius = circleColliderRadius;
                                usedInk += Vector2.Distance(points[points.Count - 1], points[points.Count - 2]);
                                Debug.Log("시작점 : " + points[points.Count - 2] + "끝점 : " + points[points.Count - 1]);
                                
                                lineRenderer.positionCount++;
                                lineRenderer.SetPosition(lineRenderer.positionCount - 1, position);

                                collider2D.points = points.ToArray();
                            }
                        }
                     
                    }
                }
                //클릭 해제 시
                else if (Input.GetMouseButtonUp(0))
                {
                    points.Clear();
                }
            }
        }
        public void ToggleEnable()
        {
            if (activeToggle.isOn)
            {
                gameObject.SetActive(true);
            }
            else if (activeToggle.isOn == false)
            {
                gameObject.SetActive(false);
            }
        }

        public void EraseLine()
        {
            usedInk = 0;
            points.Clear();
        }
    */


    }


}

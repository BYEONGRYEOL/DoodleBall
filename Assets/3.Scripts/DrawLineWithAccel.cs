using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using LevelManagement;
using Utility;
using LevelManagement.Levels;
namespace LineGame
{
    public class DrawLineWithAccel : SingletonMonoBehaviour<DrawLineWithAccel>
    {
        //잉크 총량
        public float maxInk_line;
        public float nowInk_line;
        public GameObject linePrefab;
        public LayerMask cantDrawOverLayer;
        int cantDrawOverLayerIndex;

        private bool enableDraw = false;
        public Toggle activeToggle;
        [Space(30f)]
        public Gradient lineColor;
        public float linePointsMinDistance;
        public float lineWidth;

        LineWithAccel currentLine;

        Camera cam;


        void Start()
        {
            SceneInitialized();
        }


        void Update()
        {

            //아직 잉크를 다 쓰지 않았다면
            if (nowInk_line < maxInk_line)
            {
                //마우스 버튼 클릭 되었을 때
                if (Input.GetMouseButtonDown(0) && enableDraw)
                {
                    if (EventSystem.current.IsPointerOverGameObject() == false)
                    {
                        BeginDraw();

                    }
                }
            }
            //아직 그려지는 중이라면 매 프레임 동안 Draw함수 실행
            if (currentLine != null)
                Draw();
            //마우스 떼면 EndDraw 함수 실행
            if (Input.GetMouseButtonUp(0))
                EndDraw();
        }

        // Begin Draw ----------------------------------------------
        void BeginDraw()
        {
            //currentLine에 프리팹에 저장된 Line 가져오기
            currentLine = Instantiate(linePrefab, this.transform).GetComponent<LineWithAccel>();

            //Set line properties
            //currentLine.UsePhysics(false);
            currentLine.SetLineColor(lineColor);
            currentLine.SetPointsMinDistance(linePointsMinDistance);
            currentLine.SetLineWidth(lineWidth);
            //처음 터치가 시작된 위치 mousePosition으로 받기
            Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            //mousePosition근처에 그릴 수 없게 지정한 레이어가 있다면 Hit에 그걸 받아온다.
            RaycastHit2D hit = Physics2D.CircleCast(mousePosition, lineWidth / 3f, Vector2.zero, 1f, cantDrawOverLayer);

            if (hit)
            {
                //그리기 함수 종료
                Debug.Log("레이어 충돌");
                EndDraw();
            }
            else
            {
                //그릴 수 없는 레이어 충돌하지 않은 경우 AddPoint함수로 점찍기
                currentLine.AddPoint(mousePosition);
            }


        }
        // Draw ----------------------------------------------------
        void Draw()
        {
            SFX.Instance.PlaySFX("Drawing");
            //현재 프레임에 마우스가 위치한 곳을 mousePosition으로 받기
            Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

            //Check if mousePos hits any collider with layer "CantDrawOver", if true cut the line by calling EndDraw( )
            RaycastHit2D hit = Physics2D.CircleCast(mousePosition, lineWidth / 3f, Vector2.zero, 1f, cantDrawOverLayer);

            if (hit)
            {
                Debug.Log("레이어 충돌");
                EndDraw();
            }
            //그리는 도중에라도 잉크 총량 넘어가면 그리기 종료

            if (nowInk_line >= maxInk_line - 3)
            {
                EndDraw();
            }
            //모든 제약조건을 어기지 않았다면 다음 점찍기 
            else
            {
                currentLine.AddPoint(mousePosition);
            }

        }
        // End Draw ------------------------------------------------
        void EndDraw()
        {
            //효과음
            //현재 그리고있는 currentLine이 있고,
            if (currentLine != null)
            {
                //currentLine에서 꼭짓점이 만약 2개 미만이라면 ---> 선이 아니라 점이라면
                if (currentLine.pointsCount < 2)
                {
                    //If line has one point, destroy it
                    Destroy(currentLine.gameObject);
                }
                else
                {
                    //Add the line to "CantDrawOver" layer 그릴 수 없는 레이어로 추가해서 다른 선이 못지나가도록 한다.
                    //--------------------------------------------------------------------------------------
                    /*currentLine.gameObject.layer = cantDrawOverLayerIndex;*/
                    //--------------------------------------------------------------------------------------
                    currentLine = null;
                }
            }
        }
        public void UsePhysics()
        {

        }
        public void EraseLine()
        {
            //현재 사용 잉크 초기화
            nowInk_line = 0f;
        }
        public void ToggleEnable()
        {
            //Line 토글이 On인 상태에서만 선이 그려지도록
            if (activeToggle.isOn)
            {
                UI_Ingame_R.Instance.lineWithAccelToggleCheck.gameObject.SetActive(true);
                enableDraw = true;
            }
            else if (activeToggle.isOn == false)
            {
                UI_Ingame_R.Instance.lineWithAccelToggleCheck.gameObject.SetActive(false);
                enableDraw = false;
            }
        }
        public void SceneInitialized()
        {
            maxInk_line = MissionObjectList.Instance.objectList.BuildIndexToLevelIndex().Ink_LineWithAccel;
            cam = null;
            activeToggle = null;

            cam = Camera.main;
            //토글 버튼 클릭으로 펜 그리기 말기
            activeToggle = UI_Ingame_R.Instance.lineWithAccelToggle;
            //그릴 수 없는 레이어 지정
            //----------------------------------------------------------------
            /*cantDrawOverLayerIndex = LayerMask.NameToLayer("CantDrawOver");*/
            //----------------------------------------------------------------
            ToggleEnable();
        }
    }
}
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
        //��ũ �ѷ�
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

            //���� ��ũ�� �� ���� �ʾҴٸ�
            if (nowInk_line < maxInk_line)
            {
                //���콺 ��ư Ŭ�� �Ǿ��� ��
                if (Input.GetMouseButtonDown(0) && enableDraw)
                {
                    if (EventSystem.current.IsPointerOverGameObject() == false)
                    {
                        BeginDraw();

                    }
                }
            }
            //���� �׷����� ���̶�� �� ������ ���� Draw�Լ� ����
            if (currentLine != null)
                Draw();
            //���콺 ���� EndDraw �Լ� ����
            if (Input.GetMouseButtonUp(0))
                EndDraw();
        }

        // Begin Draw ----------------------------------------------
        void BeginDraw()
        {
            //currentLine�� �����տ� ����� Line ��������
            currentLine = Instantiate(linePrefab, this.transform).GetComponent<LineWithAccel>();

            //Set line properties
            //currentLine.UsePhysics(false);
            currentLine.SetLineColor(lineColor);
            currentLine.SetPointsMinDistance(linePointsMinDistance);
            currentLine.SetLineWidth(lineWidth);
            //ó�� ��ġ�� ���۵� ��ġ mousePosition���� �ޱ�
            Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            //mousePosition��ó�� �׸� �� ���� ������ ���̾ �ִٸ� Hit�� �װ� �޾ƿ´�.
            RaycastHit2D hit = Physics2D.CircleCast(mousePosition, lineWidth / 3f, Vector2.zero, 1f, cantDrawOverLayer);

            if (hit)
            {
                //�׸��� �Լ� ����
                Debug.Log("���̾� �浹");
                EndDraw();
            }
            else
            {
                //�׸� �� ���� ���̾� �浹���� ���� ��� AddPoint�Լ��� �����
                currentLine.AddPoint(mousePosition);
            }


        }
        // Draw ----------------------------------------------------
        void Draw()
        {
            SFX.Instance.PlaySFX("Drawing");
            //���� �����ӿ� ���콺�� ��ġ�� ���� mousePosition���� �ޱ�
            Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

            //Check if mousePos hits any collider with layer "CantDrawOver", if true cut the line by calling EndDraw( )
            RaycastHit2D hit = Physics2D.CircleCast(mousePosition, lineWidth / 3f, Vector2.zero, 1f, cantDrawOverLayer);

            if (hit)
            {
                Debug.Log("���̾� �浹");
                EndDraw();
            }
            //�׸��� ���߿��� ��ũ �ѷ� �Ѿ�� �׸��� ����

            if (nowInk_line >= maxInk_line - 3)
            {
                EndDraw();
            }
            //��� ���������� ����� �ʾҴٸ� ���� ����� 
            else
            {
                currentLine.AddPoint(mousePosition);
            }

        }
        // End Draw ------------------------------------------------
        void EndDraw()
        {
            //ȿ����
            //���� �׸����ִ� currentLine�� �ְ�,
            if (currentLine != null)
            {
                //currentLine���� �������� ���� 2�� �̸��̶�� ---> ���� �ƴ϶� ���̶��
                if (currentLine.pointsCount < 2)
                {
                    //If line has one point, destroy it
                    Destroy(currentLine.gameObject);
                }
                else
                {
                    //Add the line to "CantDrawOver" layer �׸� �� ���� ���̾�� �߰��ؼ� �ٸ� ���� ������������ �Ѵ�.
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
            //���� ��� ��ũ �ʱ�ȭ
            nowInk_line = 0f;
        }
        public void ToggleEnable()
        {
            //Line ����� On�� ���¿����� ���� �׷�������
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
            //��� ��ư Ŭ������ �� �׸��� ����
            activeToggle = UI_Ingame_R.Instance.lineWithAccelToggle;
            //�׸� �� ���� ���̾� ����
            //----------------------------------------------------------------
            /*cantDrawOverLayerIndex = LayerMask.NameToLayer("CantDrawOver");*/
            //----------------------------------------------------------------
            ToggleEnable();
        }
    }
}
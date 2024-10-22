using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
//using static UnityEditor.FilePathAttribute;
//using static UnityEditor.PlayerSettings;

public class ClickEventScript : MonoBehaviour
{
    //���콺 Ŭ���� ���õ� �ൿ �� ����
    
    public GameObject tile_cover; // Ŭ���� ��ġ ������ Ŀ��
    public GameObject click_Obj; //���콺�� Ŭ���� ������Ʈ;
    public GameObject save_Obj_Foruibutton; //uibutton�� ���� ������Ʈ;
    public GameObject tile_cover_copy; //������ Ŀ���� ��������

    public GameObject building_selection_summoning_area; //���� Ŭ���� ��ȯ ���� ����ǥ��
    private GameObject building_selection_summoning_area_copy; //���� Ŭ���� ��ȯ ���� ����ǥ�� ����

    Vector3 MousePoint; // ���콺 ����Ʈ ��ǥ ��������
    Camera Camera;

    public bool Location_prohibited = true; //ui buttonŬ���� ��ġ�� ���� �Ұ����ϰ� ����� ����

    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Camera").GetComponent<Camera>(); //ī�޶� �ҷ���
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camera_bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 camera_top = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, Camera.main.nearClipPlane));
        Vector3 camera_quarter_view = camera_bottom + (camera_top - camera_bottom) * 1 / 5;
        //ī�޶��� 1/5�κ��� Ŭ���� �Ұ��ϰ� ����� ���ؼ� ������ ����

        //���� ���콺�� Ŭ���� ������Ʈ ��������
        if (Input.GetMouseButtonDown(0) && GameObject.Find("Resourse").GetComponent<Resourse>().the_world == 0) //���콺 ���� ��ư : ���콺 ����Ʈ�� �ִ� ������Ʈ ��������
        {
            Destroy(building_selection_summoning_area_copy); //���� Ÿ�ϼ��� ��ȯ���� ����
            Destroy(tile_cover_copy); //���� �׵θ� ����
            // ���콺 Ŭ���� ��ǥ ��������
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (pos.y > camera_quarter_view.y)
            {
                //�ش� ��ǥ�� �ִ� ������Ʈ ã��
                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
                if (hit.collider != null)
                {
                    click_Obj = hit.transform.gameObject;
                }

                Vector2 click_Obj_position = click_Obj.transform.position;  //���� ��ȯ�� ��ġ(���콺 Ŭ�� ��ġ)
                if (GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)click_Obj_position.x, (int)click_Obj_position.y] == 0//�ش� ��ǥ�� �Ʊ� �ǹ��Ǵ� ������ �������� ���� �� 
                        && GameObject.Find("Resourse").GetComponent<Resourse>().visible_Tile[(int)click_Obj_position.x, (int)click_Obj_position.y] != 0)
                {
                    GameObject.Find("Ui").GetComponent<SpawnPerson>().unitSummon_ClickOnFloor(click_Obj_position); //Ŭ���� ��ġ�� ���ּ�ȯ
                    GameObject.Find("Ui").GetComponent<SpawnPerson>().spawn_possible = false; //spawnPerson��ũ��Ʈ���� ��ȯ������ x���� false�� ����
                }

                //Ŭ���� ������Ʈ�� �±� ���� ����(uiscript���� uiǥ���ϴ� �Լ� ����)
                GameObject.Find("Ui").GetComponent<UiScript>().ui_Open_Down(click_Obj);

                //ui�� update�� �ƴ� Ŭ���ؼ� ���� ����ǰ� ����
                //GameObject.Find("Ui").GetComponent<UiScript>().Uistart();
            }

            if (click_Obj.tag == "Unit" || click_Obj.tag == "Building")
            {
                //�����޽��̶� ���� ��ũ��Ʈ���� ���
                save_Obj_Foruibutton = click_Obj; //��ưui�� ������ �� Ÿ����ġ���� �������� �Ǿ ���� Ŭ���Ǿ� �ִ� save_Obj_Foruibutton�� ������
                tile_cover_copy = Instantiate(tile_cover, new Vector3(click_Obj.transform.position.x, click_Obj.transform.position.y, -3), Quaternion.identity); //���콺 ��ġ�� �׵θ� ����

            }
            if (click_Obj.tag == "Building") //������ Ŭ���ϰų� ��ȯ���ɻ����϶�
            {
                building_selection_summoning_area_copy = Instantiate(building_selection_summoning_area, new Vector3(save_Obj_Foruibutton.transform.position.x, save_Obj_Foruibutton.transform.position.y, -2), Quaternion.identity);
            }//�ǹ� ���ý� �ֺ��� ���� ��ȯ ���� 

        }
        //���콺 ������ ��ư : ���õ� ������Ʈ�� ���� �ൿ
        if (Input.GetMouseButtonDown(1) && click_Obj != null)
        {
            if (click_Obj.tag == "Unit") //�±װ� �����̶�� �̵� �غ� 
            {
                //blue_Unit_Tile�� �ش� ��ǥ�� ���õ� ����( Click_object) �� ��ȣ
                int unit_type = GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile
                    [(int)click_Obj.transform.position.x, (int)click_Obj.transform.position.y];

                //���� ���õ� click_object�� ���� ��ǥ 
                Vector2 unit_pos = new Vector2(click_Obj.transform.position.x, click_Obj.transform.position.y);

                MousePoint = Input.mousePosition;
                MousePoint = Camera.ScreenToWorldPoint(MousePoint);
                if (GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)MousePoint.x, (int)MousePoint.y] == 0//�ش� ��ǥ�� �Ʊ� �ǹ��Ǵ� ������ �������� ���� �� 
                    && GameObject.Find("Resourse").GetComponent<Resourse>().visible_Tile[(int)MousePoint.x, (int)MousePoint.y] != 0)//�ش� ��ǥ�� �þ߰� ���� ��
                {
 
                    // ���� �ķ� ������ Ȯ���ϱ�
                    int blue_food = GameObject.Find("Resourse").GetComponent<Resourse>().food;
                    //�ķ� Ȯ��
                    float Cal = Mathf.Abs(unit_pos.x - (int)MousePoint.x -0.5f ) + Mathf.Abs(unit_pos.y - (int)MousePoint.y - 0.5f);

                    if (blue_food >= Cal)
                    {
                        GameObject.Find("Resourse").GetComponent<Resourse>().food -= (int)Cal; //�ķ� ����
                        click_Obj.transform.position = new Vector3((int)MousePoint.x + 0.5f, (int)MousePoint.y + 0.5f, -1);

                        GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)MousePoint.x, (int)MousePoint.y] = unit_type;
                        GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)unit_pos.x, (int)unit_pos.y] = 0;
                        tile_cover_copy.transform.position = new Vector3((int)MousePoint.x + 0.5f, (int)MousePoint.y + 0.5f, -3);
                    }
                }
            }
        }

        //// �����̽��� ������ �� && �ӽ÷� �������� ��� ���� ui�� ��ư���� �ű� �����Դϴ�.
        if (Input.GetKeyDown(KeyCode.Space) && click_Obj != null)
        {
            if (click_Obj.tag == "MapTile") //�� Ÿ���̶�� �⺻ ���� ��ȯ�ϱ�
            {
                if (GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)click_Obj.transform.position.x, (int)click_Obj.transform.position.y] == 0)
                {
                    Vector2 unit_pos = new Vector2(click_Obj.transform.position.x, click_Obj.transform.position.y);
                    if (GameObject.Find("Resourse").GetComponent<Resourse>().visible_Tile[(int)unit_pos.x, (int)unit_pos.y] != 0)
                    {
                        GameObject.Find("SpawnObj").GetComponent<SpawnObj>().SpawnBasicUnit(unit_pos);
                    }
                }
            }
        }
        // A  ��ư �� �Ʊ� ��ȯ
        if (Input.GetKeyDown(KeyCode.A) && click_Obj != null)
        {
            if (click_Obj.tag == "MapTile") //�� Ÿ���̶�� �� ��� ��ȯ�ϱ�
            {
                if (GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)click_Obj.transform.position.x, (int)click_Obj.transform.position.y] == 0)
                {
                    Vector2 unit_pos = new Vector2(click_Obj.transform.position.x, click_Obj.transform.position.y);
                    //if (GameObject.Find("Resourse").GetComponent<Resourse>().visible_Tile[(int)unit_pos.x, (int)unit_pos.y] != 0) ��� ����
                    {
                        GameObject.Find("SpawnObj").GetComponent<SpawnObj>().Spawn_knife_Blue_Unit(unit_pos);
                    }
                }
            }
        }
        // S ��ư ���� �Ʊ� ��ȯ
        if (Input.GetKeyDown(KeyCode.S) && click_Obj != null)
        {
            if (click_Obj.tag == "MapTile") //�� Ÿ���̶�� ���� ��� ��ȯ�ϱ�
            {
                if (GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)click_Obj.transform.position.x, (int)click_Obj.transform.position.y] == 0)
                {
                    Vector2 unit_pos = new Vector2(click_Obj.transform.position.x, click_Obj.transform.position.y);
                    //if (GameObject.Find("Resourse").GetComponent<Resourse>().visible_Tile[(int)unit_pos.x, (int)unit_pos.y] != 0) ��񲨵�
                    {
                        GameObject.Find("SpawnObj").GetComponent<SpawnObj>().Spawn_axe_Blue_Unit(unit_pos);
                    }
                }
            }
        }
        // D ��ư ���� �Ʊ� ��ȯ
        if (Input.GetKeyDown(KeyCode.D) && click_Obj != null)
        {
            if (click_Obj.tag == "MapTile") //�� Ÿ���̶�� ���� ��� ��ȯ�ϱ�
            {
                if (GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)click_Obj.transform.position.x, (int)click_Obj.transform.position.y] == 0)
                {
                    Vector2 unit_pos = new Vector2(click_Obj.transform.position.x, click_Obj.transform.position.y);
                    //if (GameObject.Find("Resourse").GetComponent<Resourse>().visible_Tile[(int)unit_pos.x, (int)unit_pos.y] != 0) ��񲨵�
                    {
                        GameObject.Find("SpawnObj").GetComponent<SpawnObj>().Spawn_shield_Blue_Unit(unit_pos);
                    }
                }
            }
        }

        // Z ��ư ���� �� ��ȯ
        if (Input.GetKeyDown(KeyCode.Z) && click_Obj != null)
        {
            if (click_Obj.tag == "MapTile") //�� Ÿ���̶�� �� Red ��ȯ�ϱ�
            {
                if (GameObject.Find("Resourse").GetComponent<Resourse>().red_Unit_Tile[(int)click_Obj.transform.position.x, (int)click_Obj.transform.position.y] == 0)
                {
                    Vector2 unit_pos = new Vector2(click_Obj.transform.position.x, click_Obj.transform.position.y);
                    GameObject.Find("SpawnObj").GetComponent<SpawnObj>().Spawn_knife_Red_Unit(unit_pos);
                }
            }
        }
        // X ��ư ���� �� ��ȯ
        if (Input.GetKeyDown(KeyCode.X) && click_Obj != null)
        {
            if (click_Obj.tag == "MapTile") //�� Ÿ���̶�� ���� ���� ��ȯ�ϱ�
            {
                if (GameObject.Find("Resourse").GetComponent<Resourse>().red_Unit_Tile[(int)click_Obj.transform.position.x, (int)click_Obj.transform.position.y] == 0)
                {
                    Vector2 unit_pos = new Vector2(click_Obj.transform.position.x, click_Obj.transform.position.y);
                    GameObject.Find("SpawnObj").GetComponent<SpawnObj>().Spawn_axe_Red_Unit(unit_pos);
                }
            }
        }
        // c ��ư ���� �� ��ȯ
        if (Input.GetKeyDown(KeyCode.C) && click_Obj != null)
        {
            if (click_Obj.tag == "MapTile") //�� Ÿ���̶�� ���� �� ��ȯ�ϱ�
            {
                if (GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)click_Obj.transform.position.x, (int)click_Obj.transform.position.y] == 0)
                {
                    Vector2 unit_pos = new Vector2(click_Obj.transform.position.x, click_Obj.transform.position.y);
                    GameObject.Find("SpawnObj").GetComponent<SpawnObj>().Spawn_shield_Red_Unit(unit_pos);
                }
            }
        }
        //V ��ư �� Ÿ�� ��ȯ
        if (Input.GetKeyDown(KeyCode.V) && click_Obj != null)
        {
            if (click_Obj.tag == "MapTile") //�� Ÿ���̶�� ���� �� ��ȯ�ϱ�
            {
                if (GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)click_Obj.transform.position.x, (int)click_Obj.transform.position.y] == 0)
                {
                    Vector2 unit_pos = new Vector2(click_Obj.transform.position.x, click_Obj.transform.position.y);
                    GameObject.Find("SpawnObj").GetComponent<SpawnObj>().Spawn_Tower_R(unit_pos);
                }
            }
        }
    }
}
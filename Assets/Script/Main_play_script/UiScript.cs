using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


//���ҽ����� -> uidocument ��� ���ϸ鼭 �ۼ�

public class UiScript : MonoBehaviour
{
    //���� Ÿ�� ���� ����
    public int unitType_DecisionVariable = 0; //0�⺻, 1��, 2����, 3����

    //ui���� �Ұ�(ui�� �����ִ��� �����ִ��� Ȯ��)
    bool building_ShowOn = false;
    bool base_person_ShowOn = false, sword_person_ShowOn = false, ax_person_ShowOn = false, shield_person_ShowOn = false;

    //����(�ǹ���ȯ) ����� ui
    private VisualElement unitUnderbar;
    //�ǹ�(���ּ�ȯ) ����� ui
    private VisualElement base_buildingUnderbar_B;
    private VisualElement sword_buildingUnderbar_B;
    private VisualElement ax_buildingUnderbar_B;
    private VisualElement shield_buildingUnderbar_B;
    //�¸�, �й� ui
    private VisualElement game_win;
    private VisualElement game_lose;

    //�ǹ�
    private Button spawn_base_building_B_button; //����� �ǹ�
    private Button spawn_sword_building_B_button;
    private Button spawn_ax_building_B_button;
    private Button spawn_shield_building_B_button;

    //unit
    private Button spawn_base_blueUnit_button;  //�⺻����
    private Button spawn_knife_blueUnit_button; //�� �Ʊ�
    private Button spawn_shield_blueUnit_button; //���� �Ʊ�
    private Button spawn_axe_blueUnit_button; //���� �Ʊ�

    //return button
    private Button return_button1, return_button2; 

    //turnend button
    private Button turn_end;

    //�ڿ� �ؽ�Ʈ
    private Label food_text_lable;
    private Label wood_text_lable;
    //�� ������
    private Label turn_value_lable;

    //�Ͽ��� Ŭ���� ������ ��߸�� ǥ���� �� ��
    private VisualElement turn_visual;
    private Label turn_visual_lable;

    //lodingǥ��
    //public ParticleSystem loding;
    //Camera Camera;


    void Start()
    {
        //ui�� �����ϴ� uidocument�� �����´�
        var root = GetComponent<UIDocument>().rootVisualElement;

        unitUnderbar = root.Q<VisualElement>("unit_Underbar"); //unit_Underbar = �ش� visualwelement�� �̸�

        base_buildingUnderbar_B = root.Q<VisualElement>("basic_building_Underbar_B"); //��������� ui ����
        sword_buildingUnderbar_B = root.Q<VisualElement>("sword_building_Underbar_B");
        ax_buildingUnderbar_B = root.Q<VisualElement>("ax_building_Underbar_B");
        shield_buildingUnderbar_B = root.Q<VisualElement>("shield_building_Underbar_B");

        game_win = root.Q<VisualElement>("gameEndVisualElement_win");//�¸� ui
        game_lose = root.Q<VisualElement>("gameEndVisualElement_lose");//�й� ui

        turn_end = root.Q<Button>("turnend_button"); //�� ���� ��ư
        
        //����� �ǹ�
        spawn_base_building_B_button = root.Q<Button>("Summon_spawn_base_building_B");
        spawn_sword_building_B_button = root.Q<Button>("Summon_spawn_sword_building_B");
        spawn_ax_building_B_button = root.Q<Button>("Summon_spawn_ax_building_B");
        spawn_shield_building_B_button = root.Q<Button>("Summon_spawn_shield_building_B");

       

        //��� ����
        spawn_base_blueUnit_button = root.Q<Button>("Summon_spawn_base_unit_blue"); //�⺻���� ��ư ����
        spawn_knife_blueUnit_button = root.Q<Button>("Summon_spawn_knife_unit_blue"); 
        spawn_shield_blueUnit_button = root.Q<Button>("Summon_spawn_shield_unit_blue"); 
        spawn_axe_blueUnit_button = root.Q<Button>("Summon_spawn_axe_unit_blue");

        //�������� ���� ��ư
        return_button1 = root.Q<Button>("return_Button_win");
        return_button2 = root.Q<Button>("return_Button_lose");

        //�ڿ� �ؽ�Ʈ
        food_text_lable = root.Q<Label>("food_text");
        wood_text_lable = root.Q<Label>("wood_text");

        //�� �� �ؽ�Ʈ
        turn_value_lable = root.Q<Label>("turn_value");

        //�Ͽ��� Ŭ���� ������ ��߸�� ǥ����
        turn_visual = root.Q<VisualElement>("turn_visual");
        turn_visual_lable = root.Q<Label>("turn_visual_label");

    }

    void Update() //ui�� �ִ� ��ư Ŭ���̶� click�̺�Ʈ�� ���콺Ŭ���̶� ���ÿ� ����Ǽ� ���� ����
    {
        if (GameObject.Find("Resourse").GetComponent<Resourse>().the_world == 0)
        {
            //turn_end��ư Ŭ��
            turn_end.RegisterCallback<ClickEvent>(OnTurnEndButtonClicked);
        }


        //������ư Ŭ��
        spawn_base_building_B_button.RegisterCallback<ClickEvent>((e) => OnSpawnBuildingButtonClicked(e, 1));
        spawn_sword_building_B_button.RegisterCallback<ClickEvent>((e) => OnSpawnBuildingButtonClicked(e, 2));
        spawn_ax_building_B_button.RegisterCallback<ClickEvent>((e) => OnSpawnBuildingButtonClicked(e, 3));
        spawn_shield_building_B_button.RegisterCallback<ClickEvent>((e) => OnSpawnBuildingButtonClicked(e, 4));

        //���� ��ư Ŭ��
        spawn_base_blueUnit_button.RegisterCallback<ClickEvent>((e) => OnSpawn_UnitButtonClicked(e, 0)); //�⺻����
        spawn_knife_blueUnit_button.RegisterCallback<ClickEvent>((e) => OnSpawn_UnitButtonClicked(e, 1)); //�� 
        spawn_axe_blueUnit_button.RegisterCallback<ClickEvent>((e) => OnSpawn_UnitButtonClicked(e, 2));//����
        spawn_shield_blueUnit_button.RegisterCallback<ClickEvent>((e) => OnSpawn_UnitButtonClicked(e, 3)); //����

        //���� ��ư Ŭ����
        return_button1.RegisterCallback<ClickEvent>(OnReturnButtonClicked);
        return_button2.RegisterCallback<ClickEvent>(OnReturnButtonClicked);

        food_text_lable.text = GameObject.Find("Resourse").GetComponent<Resourse>().food.ToString(); //���� ���� ǥ��
        wood_text_lable.text = GameObject.Find("Resourse").GetComponent<Resourse>().wood.ToString(); //���� ���� ǥ��
        turn_value_lable.text = GameObject.Find("Resourse").GetComponent<Resourse>().turn_value.ToString(); //�� ǥ��

        //�Ͽ����ư Ŭ���� �̹��� ǥ��
        if (GameObject.Find("Resourse").GetComponent<Resourse>().the_world == 1)
        {
            turn_visual.RemoveFromClassList("turn_visual_out");
            //turn_visual_label�� ����
            turn_visual_lable.text = GameObject.Find("Resourse").GetComponent<Resourse>().turn_value.ToString() + "��";
        }
        else
        {
            turn_visual.AddToClassList("turn_visual_out");
            //turn_visual_label�� ����
            turn_visual_lable.text = " ";
        }
        
        
    }


    //������ �̺�Ʈ ����
    public void OnTurnEndButtonClicked(ClickEvent evt)
    {
        GameObject.Find("Ui").GetComponent<TurnEnd>().turn_End();
    }

    //spawn�ǹ� ��ư Ŭ��
    public void OnSpawnBuildingButtonClicked(ClickEvent evt,int type_value)
    {
        //�ǹ��� Ÿ���� ������ type_value�� ���� ������
        GameObject.Find("Ui").GetComponent<Build>().build_Button_Click(type_value); 
        unitUnderbar.RemoveFromClassList("ui_button_up");
        if (building_ShowOn == true)
        {
            building_ShowOn = false;
        }
       
    }

    //���� ��ȯ
    //���� Ÿ���� ��ȣ���� ��ȯ�ǰ� �ϴ°� spawnperson��ũ��Ʈ���� �����Ұ���
    public void OnSpawn_UnitButtonClicked(ClickEvent evt, int unit_number)
    {

        unitType_DecisionVariable = unit_number; //�⺻ ���� Ÿ�� ��ȣ 0
        spawnUnitFunction();    //��ȯ

        base_buildingUnderbar_B.RemoveFromClassList("ui_button_up"); //uiâ �ݱ�
        sword_buildingUnderbar_B.RemoveFromClassList("ui_button_up"); //uiâ �ݱ�
        ax_buildingUnderbar_B.RemoveFromClassList("ui_button_up"); //uiâ �ݱ�
        shield_buildingUnderbar_B.RemoveFromClassList("ui_button_up"); //uiâ �ݱ�

    }


    //���ּ�ȯ
    public void spawnUnitFunction()
    {
        GameObject.Find("Ui").GetComponent<SpawnPerson>().person_button_click();
        if (base_person_ShowOn == true || sword_person_ShowOn == true || ax_person_ShowOn == true || shield_person_ShowOn == true )
        {
            base_person_ShowOn = false; //Ȥ�� ���� showon�� false�� ����
            sword_person_ShowOn = false;
            ax_person_ShowOn = false;
            shield_person_ShowOn = false;
        }
    }

    //���� ui ����
    public void ui_Open_Down(GameObject click_obj)
    {
        if (click_obj != null)
        {
            //unitŬ���� ������ ���� ui �ִϸ��̼�
            if (click_obj.tag == "Unit" && 
                GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)click_obj.transform.position.x, (int)click_obj.transform.position.y] == 1)  //�⺻�����϶���
            {
                //��Ÿ�Ͻ�Ʈ ��������(�ִϸ��̼� ȿ�� ����)
                unitUnderbar.AddToClassList("ui_button_up");
                building_ShowOn = true;
            }
            else
            {
                if (building_ShowOn == true)
                {
                    //��Ÿ�Ͻ�Ʈ �����ϱ�(�ִϸ��̼� ȿ�� ����)
                    unitUnderbar.RemoveFromClassList("ui_button_up");
                    building_ShowOn = false;
                }
            }

            //person ui �ִϸ��̼�
            //base_buildingUnderbar_B uiâ
            if (click_obj.tag == "Building" &&
                GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)click_obj.transform.position.x, (int)click_obj.transform.position.y] == 10)
            {
                base_person_ShowOn = true;
                //��Ÿ�Ͻ�Ʈ ��������(�ִϸ��̼� ȿ�� ����)
                base_buildingUnderbar_B.AddToClassList("ui_button_up");
            }
            else
            {
                if (base_person_ShowOn == true)
                {
                    //��Ÿ�Ͻ�Ʈ �����ϱ�(�ִϸ��̼� ȿ�� ����)
                    base_buildingUnderbar_B.RemoveFromClassList("ui_button_up");
                    base_person_ShowOn = false;
                }
            }
            //sword_buildingUnderbar_B uiâ
            if (click_obj.tag == "Building" &&
                GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)click_obj.transform.position.x, (int)click_obj.transform.position.y] == 11)
            {
                sword_person_ShowOn = true;
                //��Ÿ�Ͻ�Ʈ ��������(�ִϸ��̼� ȿ�� ����)
                sword_buildingUnderbar_B.AddToClassList("ui_button_up");
            }
            else
            {
                if (sword_person_ShowOn == true)
                {
                    //��Ÿ�Ͻ�Ʈ �����ϱ�(�ִϸ��̼� ȿ�� ����)
                    sword_buildingUnderbar_B.RemoveFromClassList("ui_button_up");
                    sword_person_ShowOn = false;
                }
            }
            //ax_buildingUnderbar_B uiâ
            if (click_obj.tag == "Building" &&
                GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)click_obj.transform.position.x, (int)click_obj.transform.position.y] == 12)
            {
                ax_person_ShowOn = true;
                //��Ÿ�Ͻ�Ʈ ��������(�ִϸ��̼� ȿ�� ����)
                ax_buildingUnderbar_B.AddToClassList("ui_button_up");
            }
            else
            {
                if (ax_person_ShowOn == true)
                {
                    //��Ÿ�Ͻ�Ʈ �����ϱ�(�ִϸ��̼� ȿ�� ����)
                    ax_buildingUnderbar_B.RemoveFromClassList("ui_button_up");
                    ax_person_ShowOn = false;
                }
            }
            //shield_buildingUnderbar_B uiâ
            if (click_obj.tag == "Building" &&
                GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)click_obj.transform.position.x, (int)click_obj.transform.position.y] == 13)
            {
                shield_person_ShowOn = true;
                //��Ÿ�Ͻ�Ʈ ��������(�ִϸ��̼� ȿ�� ����)
                shield_buildingUnderbar_B.AddToClassList("ui_button_up");
            }
            else
            {
                if (shield_person_ShowOn == true)
                {
                    //��Ÿ�Ͻ�Ʈ �����ϱ�(�ִϸ��̼� ȿ�� ����)
                    shield_buildingUnderbar_B.RemoveFromClassList("ui_button_up");
                    shield_person_ShowOn = false;
                }
            }


        }
    }

    //���Ϲ�ư Ŭ��
    public void OnReturnButtonClicked(ClickEvent evt)
    {
        SceneManager.LoadScene("Start_screen_scene"); //Start_play_scene ���� �ҷ����ڴ�.
    }

    //�¸� or �й�� �ߴ� ui
    //GamePlay ��ũ��Ʈ���� ���
    public void game_Win_Ui()
    {
        game_win.style.display = DisplayStyle.Flex;
    }
    public void game_Lose_Ui()
    {
        game_lose.style.display = DisplayStyle.Flex;
    }
}

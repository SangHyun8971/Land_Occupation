using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

//ui Ȯ��


public class SpawnPerson : MonoBehaviour
{
    public bool spawn_possible = false;
    //unit��ȯ�� �ڵ�
    public void person_button_click()
    {
        spawn_possible = true;

        //Ŭ���̺�Ʈ ��ũ��Ʈ���� click_Obj�� ��ġ���� �����´�.
        Vector3 clickObjPosition = GameObject.Find("ClickManager").GetComponent<ClickEventScript>().save_Obj_Foruibutton.transform.position;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (i != 1 || j != 1)
                {

                     // spawn �� �ִ� Ȯ�ο��� ����� �̵���.
                     if (GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)clickObjPosition.x + i - 1, (int)clickObjPosition.y + j - 1] == 0)
                     {
                         //���ҽ� ��ũ��Ʈ�� �����ϴ� spawn_value���� Ŭ���� ������Ʈ ������ ��ġ���� ����
                         Vector2 unit_spawn_possible = new Vector2(clickObjPosition.x + i - 1, clickObjPosition.y + j - 1);
                         GameObject.Find("Resourse").GetComponent<Resourse>().spawn_value[i, j] = unit_spawn_possible;
                     }

                }
            }
        }
    }

    //person(unit)��ư Ŭ���� �ٴڿ� Ŭ���� unit���� 
    public void unitSummon_ClickOnFloor(Vector2 click_Obj_position)
    {
        int unitTypeNumber = GameObject.Find("Ui").GetComponent<UiScript>().unitType_DecisionVariable; //���� Ÿ�Թ�ȣ�� ���� ��ȯ (0�̸� �⺻,1�̸� �Ʊ� ��, 2����, 3����)
        int blue_food = GameObject.Find("Resourse").GetComponent<Resourse>().food;
        if (spawn_possible == true) //spawnPerson ��ũ��Ʈ���� person_button�� Ŭ���ϰ� ���� ���� ������ if ��
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    //�ǹ� ������ Ÿ�� ��ġ����� ������ Ÿ���� ��ġ���� ���ؼ� �´� ��ġ�� ���� ��ȯ
                    if (click_Obj_position == GameObject.Find("Resourse").GetComponent<Resourse>().spawn_value[i, j]
                       && GameObject.Find("Resourse").GetComponent<Resourse>().visible_Tile[(int)click_Obj_position.x, (int)click_Obj_position.y] != 0)
                    {
                        if (unitTypeNumber == 0) //0�� Ÿ���� ���� ��ȯ(�⺻����)
                        {
                            if (blue_food >= 40)
                            {
                                GameObject.Find("SpawnObj").GetComponent<SpawnObj>().SpawnBasicUnit(click_Obj_position); //�⺻ ���� ��ȯ
                                GameObject.Find("Resourse").GetComponent<Resourse>().food -= 40;
                            }                                                             //�߰��� �ķ� �ڿ� ���� �ڵ尰���� ������ �� ��!!!
                        }
                        else if (unitTypeNumber == 1) //1�� Ÿ���� ���� ��ȯ(�Ʊ� ��)
                        {
                            if (blue_food >= 70)
                            {
                                GameObject.Find("SpawnObj").GetComponent<SpawnObj>().Spawn_knife_Blue_Unit(click_Obj_position);
                                GameObject.Find("Resourse").GetComponent<Resourse>().food -= 70;
                            }
                        }
                        else if (unitTypeNumber == 2) //2�� Ÿ���� ���� ��ȯ(�Ʊ� ����)
                        {
                            if (blue_food >= 70)
                            {
                              
                                GameObject.Find("SpawnObj").GetComponent<SpawnObj>().Spawn_axe_Blue_Unit(click_Obj_position);
                                GameObject.Find("Resourse").GetComponent<Resourse>().food -= 70;
                            }
                        }
                        else if (unitTypeNumber == 3) //3�� Ÿ���� ���� ��ȯ(�Ʊ� ����)
                        {
                            if (blue_food >= 70)
                            {
                                GameObject.Find("SpawnObj").GetComponent<SpawnObj>().Spawn_shield_Blue_Unit(click_Obj_position);
                                GameObject.Find("Resourse").GetComponent<Resourse>().food -= 70;
                            }
                        }

                    }
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
//using static UnityEditor.PlayerSettings;

//ui->canvas->build_button���� ���

public class Build : MonoBehaviour
{
    //Ŭ���� ��ġ�� object�ı� �� ���ο� �ǹ� ������ ���� �ڵ�
    GameObject objectToRemove = null;

    public GameObject base_building_B;
    public GameObject sword_building_B;
    public GameObject ax_building_B;
    public GameObject shield_building_B;

    public void build_Button_Click(int type_value)
    {
        //Ŭ���̺�Ʈ ��ũ��Ʈ���� click_Obj�� ��ġ���� �����´�.
        Vector3 clickObjPosition = GameObject.Find("ClickManager").GetComponent<ClickEventScript>().save_Obj_Foruibutton.transform.position;

        List<GameObject> blueUnitList = GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit;
        //Resourse ��ũ��Ʈ�� blue_Unit ����Ʈ ��������

        //�׵θ�Ÿ�� �ǹ����� �Ұ���(���ֻ����� �����߻��ؼ�)
        if ((int)clickObjPosition.x != 0 && (int)clickObjPosition.y != 0 && (int)clickObjPosition.x != 101 && (int)clickObjPosition.y != 101)
        {
            foreach (GameObject obj in blueUnitList)
            {
                if (obj.transform.position == clickObjPosition)
                {
                    objectToRemove = obj;
                    break;
                }
                //Ŭ���� ���� ������Ʈ�� ��ġ�� ����Ʈ�� ��ġ���� ������ objectToRemove�� obj�� ���� ��
            }

            //�ǹ���ȣ(blue_Unit_Tile) �� object���� ,10(type_value = 1):��� �⺻, 11(type_value = 2):��� ��, 12(type_value = 3):��� ����, 13(type_value = 4):��� ����
            if (objectToRemove != null)
            {
                int blue_wood = GameObject.Find("Resourse").GetComponent<Resourse>().wood;  //�ڿ��Һ�
                if(blue_wood >= 50 && type_value == 1) {

                    GameObject.Find("Resourse").GetComponent<Resourse>().wood -= 50;
                    //���� obj�� ��ġ�� �ִ� Ÿ���� �� �ǹ������� ����
                    blueUnitList.Remove(objectToRemove); // List���� �ش� ������Ʈ ����
                    Destroy(objectToRemove); // �ش� ������Ʈ �ı�

                    GameObject.Find("SpawnObj").GetComponent<SpawnObj>().Spawn_Tower_B(clickObjPosition);

                }

                if (blue_wood >= 70 && type_value == 2)
                {

                    GameObject.Find("Resourse").GetComponent<Resourse>().wood -= 70;
                    //���� obj�� ��ġ�� �ִ� Ÿ���� �� �ǹ������� ����
                    blueUnitList.Remove(objectToRemove); // List���� �ش� ������Ʈ ����
                    Destroy(objectToRemove); // �ش� ������Ʈ �ı�

                    GameObject.Find("SpawnObj").GetComponent<SpawnObj>().Spawn_Sword_Tower_B(clickObjPosition);

                }

                if (blue_wood >= 70 && type_value == 3)
                {

                    GameObject.Find("Resourse").GetComponent<Resourse>().wood -= 70;
                    //���� obj�� ��ġ�� �ִ� Ÿ���� �� �ǹ������� ����
                    blueUnitList.Remove(objectToRemove); // List���� �ش� ������Ʈ ����
                    Destroy(objectToRemove); // �ش� ������Ʈ �ı�

                    GameObject.Find("SpawnObj").GetComponent<SpawnObj>().Spawn_Ax_Tower_B(clickObjPosition);

                }

                if (blue_wood >= 70 && type_value == 4)
                {

                    GameObject.Find("Resourse").GetComponent<Resourse>().wood -= 70;
                    //���� obj�� ��ġ�� �ִ� Ÿ���� �� �ǹ������� ����
                    blueUnitList.Remove(objectToRemove); // List���� �ش� ������Ʈ ����
                    Destroy(objectToRemove); // �ش� ������Ʈ �ı�

                    GameObject.Find("SpawnObj").GetComponent<SpawnObj>().Spawn_Shield_Tower_B(clickObjPosition);

                }
            }




        }
    }
}
    

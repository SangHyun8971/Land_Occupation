using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    // ���ְ� �ǹ��� ��ȯ�ϴ� �Լ����� ������ ���Դϴ�.

    public GameObject basic_Blue;
    public GameObject basic_Red;

    public GameObject knife_Blue;
    public GameObject knife_Red;
    public GameObject axe_Blue;
    public GameObject axe_Red;
    public GameObject shield_Blue;
    public GameObject shield_Red;

    public GameObject base_building_B;
    public GameObject sword_building_B;
    public GameObject ax_building_B;
    public GameObject shield_building_B;

    public GameObject base_building_R;
    public GameObject sword_building_R;
    public GameObject ax_building_R;
    public GameObject shield_building_R;


    private int[,] Unit_Tile;
    //�⺻ ���� ��ȯ // ���� �ڵ� 1
    public void SpawnBasicUnit(Vector2 pos)
    {
        GameObject Basic_Unit = Instantiate(basic_Blue, new Vector3(pos.x, pos.y, -2), Quaternion.identity);

        GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit.Add(Basic_Unit); // Resouse�� �ִ� blue_unit�� �߰�
        GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)pos.x, (int)pos.y] = 1; //blue �� Ÿ�Ͽ� ���� �Ӽ� ����

    }

    // ���� �ڵ� 1 ���� �⺻ ���� ������ ������ �ʹ�.
    public void SpawnBasicUnit_R(Vector2 pos)
    {

        GameObject Basic_Unit = Instantiate(basic_Red, new Vector3(pos.x, pos.y, -2), Quaternion.identity);

        GameObject.Find("Resourse").GetComponent<Resourse>().red_Unit.Add(Basic_Unit); // Resouse�� �ִ� red_unit�� �߰�
        GameObject.Find("Resourse").GetComponent<Resourse>().red_Unit_Tile[(int)pos.x, (int)pos.y] = 1; //red �� Ÿ�Ͽ� ���� �Ӽ� ����

    }

    // ���� �ڵ� 2  �Ķ� ��(�Ʊ�) �˺� ��ȯ
    public void Spawn_knife_Blue_Unit(Vector2 pos)
    {
        GameObject knife_Unit = Instantiate(knife_Blue, new Vector3(pos.x, pos.y, -2), Quaternion.identity);

        GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit.Add(knife_Unit); // Resouse�� �ִ� blue_unit�� �߰�
        GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)pos.x, (int)pos.y] = 2; //blue �� Ÿ�Ͽ� ���� �Ӽ� ����

    }

    //���� �ڵ� 2  ���� ��(����) �˺� ��ȯ
    public void Spawn_knife_Red_Unit(Vector2 pos)
    {

        GameObject knife_Unit = Instantiate(knife_Red, new Vector3(pos.x, pos.y, -2), Quaternion.identity);

        GameObject.Find("Resourse").GetComponent<Resourse>().red_Unit.Add(knife_Unit); // Resouse�� �ִ� red_unit�� �߰�
        GameObject.Find("Resourse").GetComponent<Resourse>().red_Unit_Tile[(int)pos.x, (int)pos.y] = 2; //red �� Ÿ�Ͽ� ���� �Ӽ� ����

    }
    //���� �ڵ� 3 �Ķ� ��(�Ʊ�) ������ ��ȯ
    public void Spawn_axe_Blue_Unit(Vector2 pos)
    {

        GameObject axe_Unit = Instantiate(axe_Blue, new Vector3(pos.x, pos.y, -2), Quaternion.identity);

        GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit.Add(axe_Unit); // Resouse�� �ִ� blue_unit�� �߰�
        GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)pos.x, (int)pos.y] = 3; //blue �� Ÿ�Ͽ� ���� �Ӽ� ����

    }
    //���� �ڵ�3 ���� ��(����) ������ ��ȯ
    public void Spawn_axe_Red_Unit(Vector2 pos)
    {

        GameObject axe_Unit = Instantiate(axe_Red, new Vector3(pos.x, pos.y, -2), Quaternion.identity);

        GameObject.Find("Resourse").GetComponent<Resourse>().red_Unit.Add(axe_Unit); // Resouse�� �ִ� red_unit�� �߰�
        GameObject.Find("Resourse").GetComponent<Resourse>().red_Unit_Tile[(int)pos.x, (int)pos.y] = 3; //red �� Ÿ�Ͽ� ���� �Ӽ� ����

    }

    //���� �ڵ� 4 �Ʊ� ���� �� ��ȯ
    public void Spawn_shield_Blue_Unit(Vector2 pos)
    {

        GameObject shield_Unit = Instantiate(shield_Blue, new Vector3(pos.x, pos.y, -2), Quaternion.identity);

        GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit.Add(shield_Unit); // Resouse�� �ִ� blue_unit�� �߰�
        GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)pos.x, (int)pos.y] = 4; //blue �� Ÿ�Ͽ� ���� �Ӽ� ����

    }
    //���� �ڵ�4 ���� ���к� ��ȯ
    public void Spawn_shield_Red_Unit(Vector2 pos)
    {
        GameObject shield_Unit = Instantiate(shield_Red, new Vector3(pos.x, pos.y, -2), Quaternion.identity);
        GameObject.Find("Resourse").GetComponent<Resourse>().red_Unit.Add(shield_Unit); // Resouse�� �ִ� red_unit�� �߰�
        GameObject.Find("Resourse").GetComponent<Resourse>().red_Unit_Tile[(int)pos.x, (int)pos.y] = 4; //red �� Ÿ�Ͽ� ���� �Ӽ� ����

    }
    //Ÿ�� ��ȯ
    public void Spawn_Tower_B(Vector2 pos) { 
        GameObject castle_B = Instantiate(base_building_B, new Vector3(pos.x, pos.y, -2), Quaternion.identity);
        GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit.Add(castle_B);
        GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)pos.x, (int)pos.y] = 10;
    }
    public void Spawn_Sword_Tower_B(Vector2 pos)
    {
        GameObject swordcastle_B = Instantiate(sword_building_B, new Vector3(pos.x, pos.y, -2), Quaternion.identity);
        GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit.Add(swordcastle_B);
        GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)pos.x, (int)pos.y] = 11;
    }
    public void Spawn_Ax_Tower_B(Vector2 pos)
    {
        GameObject axcastle_B = Instantiate(ax_building_B, new Vector3(pos.x, pos.y, -2), Quaternion.identity);
        GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit.Add(axcastle_B);
        GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)pos.x, (int)pos.y] = 12;
    }
    public void Spawn_Shield_Tower_B(Vector2 pos)
    {
        GameObject shieldcastle_B = Instantiate(shield_building_B, new Vector3(pos.x, pos.y, -2), Quaternion.identity);
        GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit.Add(shieldcastle_B);
        GameObject.Find("Resourse").GetComponent<Resourse>().blue_Unit_Tile[(int)pos.x, (int)pos.y] = 13;
    }

    //�� Ÿ�� ��ȯ
    public void Spawn_Tower_R(Vector2 pos)
    {
        GameObject castle_R = Instantiate(base_building_R, new Vector3(pos.x, pos.y, -2), Quaternion.identity);
        GameObject.Find("Resourse").GetComponent<Resourse>().red_Unit.Add(castle_R);
        GameObject.Find("Resourse").GetComponent<Resourse>().red_Unit_Tile[(int)pos.x, (int)pos.y] = 10;
    }
    public void Spawn_Sword_Tower_R(Vector2 pos)
    {
        GameObject swordcastle_R = Instantiate(sword_building_R, new Vector3(pos.x, pos.y, -2), Quaternion.identity);
        GameObject.Find("Resourse").GetComponent<Resourse>().red_Unit.Add(swordcastle_R);
        GameObject.Find("Resourse").GetComponent<Resourse>().red_Unit_Tile[(int)pos.x, (int)pos.y] = 11;
    }
    public void Spawn_Ax_Tower_R(Vector2 pos)
    {
        GameObject axcastle_R = Instantiate(ax_building_R, new Vector3(pos.x, pos.y, -2), Quaternion.identity);
        GameObject.Find("Resourse").GetComponent<Resourse>().red_Unit.Add(axcastle_R);
        GameObject.Find("Resourse").GetComponent<Resourse>().red_Unit_Tile[(int)pos.x, (int)pos.y] = 12;
    }
    public void Spawn_Shield_Tower_R(Vector2 pos)
    {
        GameObject shieldcastle_R = Instantiate(shield_building_R, new Vector3(pos.x, pos.y, -2), Quaternion.identity);
        GameObject.Find("Resourse").GetComponent<Resourse>().red_Unit.Add(shieldcastle_R);
        GameObject.Find("Resourse").GetComponent<Resourse>().red_Unit_Tile[(int)pos.x, (int)pos.y] = 13;
    }

    public void update_Unit_Draw(int[,] bData, int[,] rData, int x, int y)
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                int btype = bData[i, j];
                int rtype = rData[i, j];


                if (btype == 1) SpawnBasicUnit(new Vector2(i + 0.5f, j + 0.5f));
                else if (btype == 2) Spawn_knife_Blue_Unit(new Vector2(i + 0.5f, j + 0.5f));
                else if (btype == 3) Spawn_axe_Blue_Unit(new Vector2(i + 0.5f, j + 0.5f));
                else if (btype == 4) Spawn_shield_Blue_Unit(new Vector2(i + 0.5f, j + 0.5f));
                else if (btype == 10) Spawn_Tower_B(new Vector2(i + 0.5f, j + 0.5f));
                else if (btype == 11) Spawn_Sword_Tower_B(new Vector2(i + 0.5f, j + 0.5f));
                else if (btype == 12) Spawn_Ax_Tower_B(new Vector2(i + 0.5f, j + 0.5f));
                else if (btype == 13) Spawn_Shield_Tower_B(new Vector2(i + 0.5f, j + 0.5f));

                if (rtype == 1) SpawnBasicUnit_R(new Vector2(i + 0.5f, j + 0.5f));
                else if (rtype == 2) Spawn_knife_Red_Unit(new Vector2(i + 0.5f, j + 0.5f));
                else if (rtype == 3) Spawn_axe_Red_Unit(new Vector2(i + 0.5f, j + 0.5f));
                else if (rtype == 4) Spawn_shield_Red_Unit(new Vector2(i + 0.5f, j + 0.5f));
                else if (rtype == 10) Spawn_Tower_R(new Vector2(i + 0.5f, j + 0.5f));
                else if (rtype == 11) Spawn_Sword_Tower_R(new Vector2(i + 0.5f, j + 0.5f));
                else if (rtype == 12) Spawn_Ax_Tower_R(new Vector2(i + 0.5f, j + 0.5f));
                else if (rtype == 13) Spawn_Shield_Tower_R(new Vector2(i + 0.5f, j + 0.5f));
            }
        }


    }
}

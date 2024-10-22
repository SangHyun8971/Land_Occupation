using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurnEnd : MonoBehaviour
{
    //ui -> canvas -> turn_end���� �����

    public void turn_End() //�� ���� ��ư
    {
        GameObject.Find("Resourse").GetComponent<Resourse>().the_world = 1;//Ŭ�� ���ϰ� ����
        Befor_Fight();
        Invoke("after_Fight", 1);
    }

    private void Befor_Fight()
    {
        GameObject.Find("Resourse").GetComponent<Resourse>().turn_value += 1; //�� ����
        GameObject.Find("Resourse").GetComponent<Resourse>().draw_Unit();
        GameObject.Find("Resourse").GetComponent<Resourse>().update_Visible();
        //�þ� �׸��� ( ����� ���� ����
        GameObject.Find("DrawField").GetComponent<Draw_Field>().draw_Dark(
            GameObject.Find("Resourse").GetComponent<Resourse>().visible_Tile,
            GameObject.Find("Resourse").GetComponent<Resourse>().blue_Influence_Tile,
            GameObject.Find("Resourse").GetComponent<Resourse>().red_Influence_Tile,
            GameObject.Find("Resourse").GetComponent<Resourse>().width, //����
            GameObject.Find("Resourse").GetComponent<Resourse>().height//����
            );
    }
    private void after_Fight()
    {
        //���� ���� ����
        GameObject.Find("Resourse").GetComponent<Resourse>().update_Fight_Unit();
        /*GameObject.Find("SpawnObj").GetComponent<SpawnObj>().update_Unit_Draw();*/ // ���� updat_Fight_Unit () ������ �۵���
        GameObject.Find("Resourse").GetComponent<Resourse>().draw_Unit();
        //�þ� �� ����
        GameObject.Find("Resourse").GetComponent<Resourse>().update_Visible();
        //����� ���
        GameObject.Find("Resourse").GetComponent<Resourse>().update_Influence();
        //���� �ķ� �߰�
        GameObject.Find("Resourse").GetComponent<Resourse>().update_Resourse();
        //�þ� �׸��� ( ����� ���� ����
        GameObject.Find("DrawField").GetComponent<Draw_Field>().draw_Dark(
            GameObject.Find("Resourse").GetComponent<Resourse>().visible_Tile,
            GameObject.Find("Resourse").GetComponent<Resourse>().blue_Influence_Tile,
            GameObject.Find("Resourse").GetComponent<Resourse>().red_Influence_Tile,
            GameObject.Find("Resourse").GetComponent<Resourse>().width, //����
            GameObject.Find("Resourse").GetComponent<Resourse>().height//����
            );
        // �̵�

        GameObject.Find("Resourse").GetComponent<Resourse>().activeEnemy(); // �̵� ���� ���� ����

        // ����

        GameObject.Find("Resourse").GetComponent<Resourse>().the_world = 0; // �ٽ� Ŭ���� �� �ֽ��ϴ�.
    }

}

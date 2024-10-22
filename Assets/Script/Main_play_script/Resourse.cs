using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resourse : MonoBehaviour
{
    //���� [101, 101] ���� �����ϰ� �Ǹ� build �����κе� ���� �������ֱ�
    //������ �����ϴ� ��
    public int[,] map_Tile = new int[101, 101]; //�� Ÿ�� #1 : �� #2 : �ķ� �� #3 : �ڿ���
    public int[,] visible_Tile = new int[101, 101]; //�þ� Ÿ��
    public int[,] blue_Unit_Tile = new int[101, 101]; //���� ��ġ Ÿ�� ���ְ� �ǹ��� ���� �� #0 �� #1 ~ 9 ���� ���� #10~ �ǹ� ����
    public int[,] red_Unit_Tile = new int[101, 101]; //���� ����

    public int[,] blue_Influence_Tile = new int[101, 101]; // �Ķ��� �ǹ� ����� (���� ���� 2ĭ : ���⼭  �ڿ��� ���� �� ����)
    public int[,] red_Influence_Tile = new int[101, 101]; // ������ �ǹ� �����  (���� ���� 2ĭ)
    /* ���� ������ ���� �ڵ� ��ȣ
        0 : ���� ����
        1: �⺻ ����
        2: �� ����
        3: ���� ����
        4: ���� ����
        10 : ���� ( �⺻ ���� ��ȯ ���� ) 
        11 : �˰ǹ�
        12 : �����ǹ�
        13 : ���аǹ�
*/
    public Vector2[,] spawn_value = new Vector2[3, 3];  //�ǹ� ��ó ���� ���� �����ϵ��� ������ �ǹ��� ��ó ��ġ���� ���� ����

    public int width, height;// ���� ���� ũ��

    public List<GameObject> visible = new List<GameObject>(); //�þ� Ÿ�� ���� ��ġ ( ���ó : �� ���� �� �ٲ� visible_Tile�� ���� �ٽ� �׸��� ���� ��������)
    public List<GameObject> blue_Unit = new List<GameObject>(); // �Ʊ� ������ ������ �� (���ó : �� ���� �� for ���� ���� �þ� �۾� �� �ڿ� ó��)
    public List<GameObject> red_Unit = new List<GameObject>(); //���� ������ ������ ��

    public int wood = 0; //����
    public int food = 0; //�ķ�
    public int turn_food_up = 0;��//�ķ�up
    public int turn_wood_up = 0;��//����up


    public int turn_value = 0; //����°����

    public int the_world = 0; // Ŭ�� ���� # 0 Ŭ���� �� ���� 1 : Ŭ�� ����

    //�ӽ÷� ���⿡ �� �� ���� ��� �ִٸ� �Űܼ� ����
    public void placeRedUnit()
    {
       
        red_Unit_Tile[15, 15] = Random.Range(11, 14);
        red_Unit_Tile[15, 18] = Random.Range(11, 14);
        red_Unit_Tile[18, 15] = Random.Range(11, 14);
        red_Unit_Tile[11, 11] = Random.Range(11, 14);
        red_Unit_Tile[11, 14] = Random.Range(11, 14);
        red_Unit_Tile[11, 18] = Random.Range(11, 14);
        red_Unit_Tile[14, 11] = Random.Range(11, 14);
        red_Unit_Tile[18, 11] = Random.Range(11, 14);
        red_Unit_Tile[8, 8] = Random.Range(11, 14); 
        red_Unit_Tile[8,12] = Random.Range(11, 14);
        red_Unit_Tile[8, 15] = Random.Range(11, 14);
        red_Unit_Tile[8, 19] = Random.Range(11, 14);
        red_Unit_Tile[12, 8] = Random.Range(11, 14);
        red_Unit_Tile[15, 8] = Random.Range(11, 14);
        red_Unit_Tile[19, 8] = Random.Range(11, 14);
        red_Unit_Tile[13, 4] = Random.Range(11, 14);
        red_Unit_Tile[4, 13] = Random.Range(11, 14);
        red_Unit_Tile[17, 4] = Random.Range(11, 14);
        red_Unit_Tile[4,17] = Random.Range(11, 14);
   
    }



    // �� Ÿ�� ���� �Է�
    public void make_Map_Tile()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                map_Tile[i, j] = Random.Range(1, 4);
                
            }
        }
        //red�� ai �ǹ� ��ġ (�迭)
        placeRedUnit();
    }
    //�þ� ������Ʈ
    public void update_Visible()
    {
        visible_Tile = new int[101, 101]; // �þ��ʵ� �ʱ�ȭ
        for(int i = visible.Count - 1; i >= 0; i--)
        {
            Destroy(visible[i]);
            visible.Remove(visible[i]);
        }
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {

                int type = blue_Unit_Tile[i, j]; // ���� Ÿ�� �������� Ÿ�� ���� �þ� ������ �ٸ�
                //����
                if (type > 0 && type < 10) //������ 1~9
                {
                    for (int w = i - 1; w <= i + 1; w++)
                    {
                        for (int h = j - 1; h <= j + 1; h++)
                        {
                            if (w >= 0 && w < width && h >= 0 && h < height) //�ش� ��ǥ�� �� ���� �ȿ� �ִٸ�?
                            {
                                visible_Tile[w, h] = 1;
                            }
                        }
                    }
                }
                //���� 10
                else if (type >= 10 && type < 99) //10 ����
                {
                    for (int w = i - 3; w <= i + 3; w++)
                    {
                        for (int h = j - 3; h <= j + 3; h++)
                        {
                            if (w >= 0 && w < width && h >= 0 && h < height) //�ش� ��ǥ�� �� ���� �ȿ� �ִٸ�?
                            {
                                visible_Tile[w, h] = 1;
                            }
                        }
                    }
                }
            }
        }
    }
    //����� ������Ʈ
    public void update_Influence()
    {
        blue_Influence_Tile = new int[101, 101];
        red_Influence_Tile = new int[101, 101];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                //�Ʊ� ���� ���� ���� Ž��
                if (blue_Unit_Tile[i, j] == 10) // �ش� ��ǥ�� �����϶�
                {
                    for (int w = i - 2; w <= i + 2; w++) // 2Ÿ�� ����
                    {
                        for (int h = j - 2; h <= j + 2; h++)
                        {
                            if (w >= 0 && w < width && h >= 0 && h < height) //���� ��
                            {
                                blue_Influence_Tile[w, h] = 1; //�ش� Ÿ���� �� ����
                            }
                        }
                    }
                }
                //���� ���� ���� ���� Ž��
                if  (red_Unit_Tile[i, j] == 10) // �ش� ��ǥ�� �����϶�
                {
                    for (int w = i - 2; w <= i + 2; w++) // 2Ÿ�� ����
                    {
                        for (int h = j - 2; h <= j + 2; h++)
                        {
                            if (w >= 0 && w < width && h >= 0 && h < height) //���� ��
                            {
                                red_Influence_Tile[w, h] = 1; //�ش� Ÿ���� �� ����
                            }
                        }
                    }
                }


            }
        }
    }
    // �ڿ� ������Ʈ (����� ���� �ǹ����� �ķ�,���� ����
    public void update_Resourse()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                //������ �� ���� ������� ��
                if (blue_Influence_Tile[i, j] == 1 && red_Influence_Tile [i,j] !=1)
                {
                    //�ش� �ʵ尡 �������
                    if (map_Tile[i, j] == 2) food += turn_food_up; //�ķ� +3
                    else if (map_Tile[i, j] == 3) wood+= turn_wood_up;//���� +1
                }
                if (blue_Unit_Tile[i, j] == 1)//�ش� Ÿ�Ͽ� �� �⺻ ������ ������?
                {
                    if (map_Tile[i, j] == 2) food += 5; //�ķ� +5 
                    else if (map_Tile[i, j] == 3) wood += 3;//���� +3
                }
            }
        }
    }


    int[,] check_Unit = new int[9, 2] { { 0,0}, { -1, -1 }, { -1, 0 }, { -1, 1 }, { 0, -1 }, { 0, 1 }, { 1, -1 }, { 1, 0 }, { 1, 1 } };
    // ���� ������Ʈ ( ������ ���� ���� ������Ʈ)
    // ����� ���忡�� �� ���� 2,3,4 > 1 = 10, 2>3>4>2 (��� ���� �ص� ������ ,, ���� ������ ��ȣ�ۿ��̶�... ��� ���忡�� ��� ���� Ȯ�� ����)
    // ���� �ڵ��� ��� (�ٸ� ��ǥ�� ���� = �� �� ����  , ���� ��ǥ�� ���� = �� �� ���)
    // Ȯ�� ���� ��� �ڱ� ��ġ -> ���� ������ ������� Ȯ�� 
    // 2,3,4 ���� ������ ��� �ٸ� ��� ���ڿ� �� , �� �ܿ��� �ֺ��� ���� ������ �ִ����� Ȯ��
    public void update_Fight_Unit()
    {
        //��� Ÿ�� Ȯ�� �� ����
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                //Ÿ�� ��������
                int type = blue_Unit_Tile[i, j];
                //���� Ÿ���̶��
                if (type != 0)
                {
                    //�ǹ� �Ǵ� �⺻ �����϶�
                    if (type >= 10 || type == 1)
                    {
                        //�ֺ� Ȯ��
                        for (int w = i - 1; w <= i + 1; w++)
                        {
                            for (int h = j - 1; h <= j + 1; h++)
                            {
                                if (w >= 0 && w < width && h >= 0 && h < height) //�� �� ��ǥ�� �ȿ� ���� ��
                                {
                                    // ���� ��ǥ�� �ִ� ���� ������ ���� �����̶��
                                    if (red_Unit_Tile[w, h] > 1 && red_Unit_Tile[w, h] < 10)
                                    {
                                        //�ش� ����� �� �� ����
                                        blue_Unit_Tile[i, j] = 0;
                                    }
                                }
                            }
                        }
                    }
                    //�� �����̶��
                    else if (type == 2)
                    {
                        if (red_Unit_Tile[i, j] == 2)
                        {
                            red_Unit_Tile[i, j] = 0;
                            blue_Unit_Tile[i, j] = 0;
                        }
                        else
                            for (int z = 0; z < 9; z++)
                            {
                                int w = i + check_Unit[z, 0];
                                int h = j + check_Unit[z, 1];
                                if (w >= 0 && w < width && h >= 0 && h < height) //�� �� ��ǥ�� �ȿ� ���� ��
                                {
                                    //�ش� ��ġ�� �������̶��? 
                                    if (red_Unit_Tile[w, h] == 3) red_Unit_Tile[w, h] = 0;
                                    //�ݴ�� ���к��̶��?
                                    else if (red_Unit_Tile[w, h] == 4)
                                    {
                                        blue_Unit_Tile[i, j] = 0;
                                        break;
                                    }
                                    //���� ���� �Ǵ� �ǹ��̶��?
                                    else if (red_Unit_Tile[w, h] == 1 || red_Unit_Tile[w, h] >= 10) red_Unit_Tile[w, h] = 0;
                                }
                            }
                    }
                    //�������� ��
                    else if (type == 3)
                    {
                        if (red_Unit_Tile[i, j] == 3)
                        {
                            red_Unit_Tile[i, j] = 0;
                            blue_Unit_Tile[i, j] = 0;
                        }
                        else
                            for (int z = 0; z < 9; z++)
                            {
                                int w = i + check_Unit[z, 0];
                                int h = j + check_Unit[z, 1];
                                if (w >= 0 && w < width && h >= 0 && h < height) //�� �� ��ǥ�� �ȿ� ���� ��
                                {
                                    //�ش� ��ġ�� ���к��̶��? 
                                    if (red_Unit_Tile[w, h] == 4) red_Unit_Tile[w, h] = 0;
                                    //�ݴ�� �˺��̶��?
                                    else if (red_Unit_Tile[w, h] == 2)
                                    {
                                        blue_Unit_Tile[i, j] = 0;
                                        break;
                                    }
                                    //���� ���� �Ǵ� �ǹ��̶��?
                                    else if (red_Unit_Tile[w, h] == 1 || red_Unit_Tile[w, h] >= 10) red_Unit_Tile[w, h] = 0;
                                }
                            }
                    }
                    //���к��� ��
                    else if (type == 4)
                    {
                        if (red_Unit_Tile[i, j] == 4)
                        {
                            red_Unit_Tile[i, j] = 0;
                            blue_Unit_Tile[i, j] = 0;
                        }
                        else
                            for (int z = 0; z < 9; z++)
                            {
                                int w = i + check_Unit[z, 0];
                                int h = j + check_Unit[z, 1];
                                if (w >= 0 && w < width && h >= 0 && h < height) //�� �� ��ǥ�� �ȿ� ���� ��
                                {
                                    //�ش� ��ġ�� �˺��̶��? 
                                    if (red_Unit_Tile[w, h] == 2) red_Unit_Tile[w, h] = 0;
                                    //�ݴ�� �������̶��?
                                    else if (red_Unit_Tile[w, h] == 3)
                                    {
                                        blue_Unit_Tile[i, j] = 0;
                                        break;
                                    }
                                    //���� ���� �Ǵ� �ǹ��̶��?
                                    else if (red_Unit_Tile[w, h] == 1 || red_Unit_Tile[w, h] >= 10) red_Unit_Tile[w, h] = 0;
                                }
                            }
                    }
                }
            }
        }
        
    }
    public void draw_Unit()
    {
        // �ʵ� �� ���� �ٽ� �׸��� ���� �۾� ( ���ֵ� ���� �����)
        for (int i = blue_Unit.Count - 1; i >= 0; i--)
        {
            //�Ʊ����� ����
            Destroy(blue_Unit[i]);
            blue_Unit.Remove(blue_Unit[i]);
        }
        for (int i = red_Unit.Count - 1; i >= 0; i--)
        {
            //���� ���� ����
            Destroy(red_Unit[i]);
            red_Unit.Remove(red_Unit[i]);
        }
        //���� �ٽ� �׸���
        GameObject.Find("SpawnObj").GetComponent<SpawnObj>().update_Unit_Draw(blue_Unit_Tile, red_Unit_Tile, width, height);
    }
    
    public void activeEnemy() // �� ���� �����̱�
    {
        for (int i = 0; i < red_Unit.Count; i++)
        {
            if (red_Unit[i].CompareTag("Enemy")) // tag ���� tag�� "Enemy"�� �ش� ��ü�� MoveEnemy�Լ� ȣ��
            {
                red_Unit[i].GetComponent<EnemyMove>().MoveEnemy();
            }
            else if (red_Unit[i].CompareTag("Building")) // tag ���� tag�� "Building"�� �ش� ��ü�� SpawnEnemy�Լ� ȣ��
            {
                red_Unit[i].GetComponent<EnemySpawn>().SpawnEnemy();
            }
        }
    }
}

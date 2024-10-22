using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Build.Content;
using UnityEngine;

public class EnemySpawn : MonoBehaviour // �ǹ��� ���¿� �°� ������ ��ȯ�ϴ� ��ũ��Ʈ
{
    bool unitSwitch = true;
    int[,] check_Unit = new int[8, 2] { { -1, -1 }, { -1, 0 }, { -1, 1 }, { 0, -1 }, { 0, 1 }, { 1, -1 }, { 1, 0 }, { 1, 1 } };

    public void SpawnEnemy()
    {
        Vector3 towerPos;
        towerPos = this.gameObject.transform.position; // �ǹ��� ��ġ���� �޾ƿ�
        int enemyValue = 0;
        int spawnCount = 0;
        if (GameObject.Find("Resourse").GetComponent<Resourse>().turn_value % 2 == 0) // 2�Ͽ� �ѹ��� ����
        {
            unitSwitch = true;
            
            spawnCount = 0;

            enemyValue  = GameObject.Find("Resourse").GetComponent<Resourse>().red_Unit_Tile[(int)towerPos.x, (int)towerPos.y]; // �迭�� ��ġ�� �ǹ��� ��ȣ�� �޾ƿ� �ǹ� ���� �ĺ�

            while(unitSwitch)
            {
                int pickCase = Random.Range(0, 8);
                if (GameObject.Find("Resourse").GetComponent<Resourse>().red_Unit_Tile[(int)towerPos.x + check_Unit[pickCase, 0], (int)towerPos.y + check_Unit[pickCase, 1]] == 0)
                {
                    if(enemyValue == 11) 
                    {
                        GameObject.Find("SpawnObj").GetComponent<SpawnObj>().Spawn_knife_Red_Unit(towerPos);
                    }
                    else if (enemyValue == 12)
                    {
                        GameObject.Find("SpawnObj").GetComponent<SpawnObj>().Spawn_axe_Red_Unit(towerPos);
                    }
                    else if (enemyValue == 13)
                    {
                        GameObject.Find("SpawnObj").GetComponent<SpawnObj>().Spawn_shield_Red_Unit(towerPos);
                    }
                    else
                    {
                        enemyValue = 0;
                    }

                    unitSwitch = false;
                }
                else
                {
                    spawnCount++;
                }
                if(spawnCount > 20)
                {
                    unitSwitch = false;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public float temp_value;
    public float Wheelspeed; //ī�޶� ���� �ӵ�
    public float MoveSpeed; //ī�޶� �̵� �ӵ�
    public float dragSpeed; //ī�޶� �巡�� �̵��ӵ�
    float clickPointX, clickPointY;
    Camera Camera;
    int max_x;
    int max_y;
    // Start is called before the first frame update
    void Start()
    {
        max_x = GameObject.Find("Resourse").GetComponent<Resourse>().width;
        max_y = GameObject.Find("Resourse").GetComponent<Resourse>().height;
        Camera = GameObject.Find("Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // ī�޶� ���� �ܾƿ�
        float scroll = Input.GetAxis("Mouse ScrollWheel") * Wheelspeed;
        //ī�޶� �� �� ������ ��Ÿ�� # Ȯ�� �ִ�ġ : 4  ��� �ִ�ġ : 10
        temp_value = Camera.orthographicSize;
        // scroll < 0 : scroll down�ϸ� ����
        if (Camera.orthographicSize <= 4f && scroll > 0)
        {
            
            Camera.orthographicSize = temp_value; // maximize zoom in

            // �ִ�� Zoom in ���� �� Ư�� ���� �������� ��

            // �ִ� �� �� ������ ��� �� ���� ���߷��� �ѹ� �� �ƿ� �Ǵ� ������ ����
        }

        // scroll > 0 : scroll up�ϸ� �ܾƿ�
        else if (Camera.orthographicSize >= 10f && scroll < 0)
        {
            Camera.orthographicSize = temp_value; // maximize zoom out
        }
        else
            Camera.orthographicSize -= scroll * 0.5f;

        dragMove();
        //ī�޶� ��ȭ �¿�  �̵�

        if(Input.GetKey(KeyCode.RightArrow)) {
            transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * MoveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * MoveSpeed * Time.deltaTime;
        }
        //���� �ʰ� �Ұ����ϰ� �����
        if(transform.position.x < temp_value)
        {
            transform.position = new Vector3(temp_value, transform.position.y,-10);
        }
        if (transform.position.x > max_x-temp_value)
        {
            transform.position = new Vector3(max_x - temp_value, transform.position.y, -10);
        }
        if (transform.position.y < temp_value/2)
        {
            transform.position = new Vector3(transform.position.x, temp_value / 2, -10);
        }
        if (transform.position.y > max_x - (temp_value/2))
        {
            transform.position = new Vector3(transform.position.x, max_y - (temp_value / 2), -10);
        }
    }
   void dragMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPointX = Input.mousePosition.x;
            clickPointY = Input.mousePosition.y;
        }
        if (Input.GetMouseButton(0))
        {
            // (���� ���콺 ��ġ - ���� ��ġ)�� ���� �������� ī�޶� �̵�
            Vector2 position = Camera.main.ScreenToViewportPoint(-new Vector3(Input.mousePosition.x - clickPointX, Input.mousePosition.y - clickPointY, 0));
            Vector2 move = position * dragSpeed * Time.deltaTime;

            Camera.main.transform.Translate(move);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Start_screen_ui : MonoBehaviour
{
    private Button start_Button;    //���� ���۹�ư
    private Button exit_Button;     //���� ��ư

    private Button tuto_On_Button;     //��� ���� ��ư
    private Button tuto_Next_Button;//�ѱ��
    private Button tuto_Exit_Button;//����

    private int tuto_number = 1;

    //���� ��� ����
    private VisualElement tuto;
    private VisualElement tuto1;
    private VisualElement tuto2;
    private VisualElement tuto3;
    private VisualElement tuto4;
    private VisualElement tuto5;
    private VisualElement tuto6;
    private VisualElement tuto7;
    private VisualElement tuto8;
    private VisualElement tuto9;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        start_Button = root.Q<Button>("start_button"); //���� ��ư
        exit_Button = root.Q<Button>("exit_button"); //���� ��ư
        tuto_On_Button = root.Q<Button>("tuto_button"); //Ʃ�� ��ư

        tuto_Next_Button = root.Q<Button>("next");  //Ʃ�� ����
        tuto_Exit_Button = root.Q<Button>("x");     //Ʃ�� ȭ�� ����

        //Ʃ�� ȭ�� ǥ��
        tuto = root.Q<VisualElement>("tuto");
        tuto1 = root.Q<VisualElement>("tuto_1");
        tuto2 = root.Q<VisualElement>("tuto_2");
        tuto3 = root.Q<VisualElement>("tuto_3");
        tuto4 = root.Q<VisualElement>("tuto_4");
        tuto5 = root.Q<VisualElement>("tuto_5");
        tuto6 = root.Q<VisualElement>("tuto_6");
        tuto7 = root.Q<VisualElement>("tuto_7");
        tuto8 = root.Q<VisualElement>("tuto_8");
        tuto9 = root.Q<VisualElement>("tuto_9");

    }

    // Update is called once per frame
    void Update()
    {
        start_Button.RegisterCallback<ClickEvent>(OnStartButtonClicked); //���� ��ư Ŭ��
        exit_Button.RegisterCallback<ClickEvent>(OnExitButtonClicked); //���� ��ư Ŭ��
        tuto_On_Button.RegisterCallback<ClickEvent>(OnTutoOnButtonClicked);



        tuto_Next_Button.RegisterCallback<ClickEvent>(OnTutoNextButtonClicked); //Ʃ�� �ѱ�� ��ư
        tuto_Exit_Button.RegisterCallback<ClickEvent>(OnTutoExitButtonClicked); //Ʃ�� �����ư

        Tuto();
    }

    public void OnStartButtonClicked(ClickEvent evt)
    {
        SceneManager.LoadScene("Main_play_scene"); //Main_play_scene ���� �ҷ����ڴ�.
    }


    public void OnExitButtonClicked(ClickEvent evt)
    {
            //UnityEditor.EditorApplication.isPlaying = false;
            //Application.Quit(); //���� ����

    }

    public void OnTutoOnButtonClicked(ClickEvent evt) //Ʃ�� ����
    {
        tuto.RemoveFromClassList("tuto_hide");
    }

        public void OnTutoNextButtonClicked(ClickEvent evt) //Ʃ�� number����(Tuto()���� ���)
    {
        if(tuto_number < 9)
        {
            tuto_number += 1;
        }
    }

    public void OnTutoExitButtonClicked(ClickEvent evt) //Ʃ�� ���� ��ư
    {
        tuto.AddToClassList("tuto_hide");
        tuto_number = 1;

        tuto1.style.display = DisplayStyle.None;
        tuto2.style.display = DisplayStyle.None;
        tuto3.style.display = DisplayStyle.None;
        tuto4.style.display = DisplayStyle.None;
        tuto5.style.display = DisplayStyle.None;
        tuto6.style.display = DisplayStyle.None;
        tuto7.style.display = DisplayStyle.None;
        tuto8.style.display = DisplayStyle.None;
        tuto9.style.display = DisplayStyle.None;
    }

    public void Tuto()//Ʃ�丮�� ��ȣ�� ���� ȭ��
    {
        if (tuto_number == 1)
        {
            tuto1.style.display = DisplayStyle.Flex;;
        }else if (tuto_number == 2)
        {
            tuto2.style.display = DisplayStyle.Flex;
        }
        else if (tuto_number == 3)
        {
            tuto3.style.display = DisplayStyle.Flex;
        }
        else if (tuto_number == 4)
        {
            tuto4.style.display = DisplayStyle.Flex;
        }
        else if (tuto_number == 5)
        {
            tuto5.style.display = DisplayStyle.Flex;
        }
        else if (tuto_number == 6)
        {
            tuto6.style.display = DisplayStyle.Flex;
        }
        else if (tuto_number == 7)
        {
            tuto7.style.display = DisplayStyle.Flex;
        }
        else if (tuto_number == 8)
        {
            tuto8.style.display = DisplayStyle.Flex;
        }
        else if (tuto_number == 9)
        {
            tuto9.style.display = DisplayStyle.Flex;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class player_holder : MonoBehaviour
{
    Vector3 startPos; //�ʱ���ġ
    Quaternion StartRot; //�ʱ�ȸ��
    GameObject Player; //�÷��̾�
    GameObject Finish; //��������
    GameObject FailButton;
    Animator animator;
    #region �ܺ� �Լ� ����
    GameObject Blocks;

    #endregion
    public Image StartButton = null;
    public bool FinishCheck;
    private void Start()
    {
        FinishCheck = true;
        Player = GameObject.FindGameObjectWithTag("Player");
        Finish = GameObject.FindGameObjectWithTag("Finish");
        animator = Player.GetComponent<Animator>();
        startPos = Player.transform.position;
        StartRot = Player.transform.rotation;
        FailButton = GameObject.FindGameObjectWithTag("FailButton");
    }
    //Panel Main Loop �ȿ� �ڽĵ� ������ ����
    public IEnumerator Go() //��ŸƮW��ư�� �������� ����Ǵ� �ڷ�ƾ�Լ�
    {
        yield return new WaitForSeconds(1f); //1�� ������
        //Fail fail = FailButton.GetComponent<Fail>();
        //�����гο� ����
        Blocks = GameObject.FindGameObjectWithTag("MainDrop").gameObject;//Panel Main Loop�� ����
        Debug.Log(Blocks.name);
        int nSize = Blocks.transform.childCount; //Panel Main Loop�� �ڽĵ� ����
        for (int i = 0; i < nSize; i++)
        {

            Debug.Log("i : " + i);
            Debug.Log("nSize :" + nSize);
            GameObject Child = Blocks.transform.GetChild(i).gameObject; // Panel Main Loop�� �ڽĿ�����Ʈ ����
            ///����� �Լ��� �� �ҷ�����
            FunctionMove FunctionMove = Child.GetComponent<FunctionMove>();  //�ڽĿ�����Ʈ�� FunctionMove �Լ� �ҷ�����
            FunctionJump FunctionJump = Child.GetComponent<FunctionJump>();
            FunctionRotate FunctionRotate = Child.GetComponent<FunctionRotate>();  //�ڽĿ�����Ʈ�� FunctionRotate �Լ� �ҷ�����
            FunctionFor FunctionFor = Child.GetComponent<FunctionFor> (); //�ڽĿ�����Ʈ�� FunctionFor �Լ� �ҷ�����
            FunctionClass FunctionClass = Child.GetComponent<FunctionClass>();
            
            ///���ʷ� �Լ����� �ִ��� üũ�ϱ�
            if (FunctionMove)   //FunctionMove ��, �̵� ����϶� ����
            {
                yield return StartCoroutine(FunctionMove.MoveZ()); //z�� 1 �̵�
            }
            else if (!FunctionMove && FunctionJump) // ȸ�� ��� �϶� ����
            {
                if (Child.tag == "Jump") //����
                    yield return StartCoroutine(FunctionJump.Jump());
            }
            else if (!FunctionMove && !FunctionJump &&  FunctionRotate) // ȸ�� ��� �϶� ����
            {
                if (Child.tag == "Rotate_R") //������ ȸ��
                    yield return StartCoroutine(FunctionRotate.RightRotate());
                else if (Child.tag == "Rotate_L") //���� ȸ��
                    yield return StartCoroutine(FunctionRotate.LeftRotate());
                else if (Child.tag == "Rotate_B") //������ ȸ��
                    yield return StartCoroutine(FunctionRotate.BackRotate());
            }
            else if (!FunctionMove && !FunctionJump &&  !FunctionRotate && FunctionFor)
            {
                yield return StartCoroutine(FunctionFor.For()); 
            }
            else if (!FunctionMove && !FunctionJump &&  !FunctionRotate && !FunctionFor && FunctionClass)
            {
                yield return StartCoroutine(FunctionClass.Function()); 
            }

        //    if (i == (nSize - 1)) //������ ��ϱ��� ��� ���������
        //    {
        //        if (Mathf.Abs(transform.position.x - Finish.transform.position.x) <= 1F && Mathf.Abs(Player.transform.position.z - Finish.transform.position.z) <= 1F) //���������� �����ϸ� 
        //        {
        //            animator.SetTrigger("Jump"); //����
        //        }
        //        else // ���������� �������� ���ϸ�
        //            fail.FailCheck = true; //����
        //    }
        }
    }
   

    
    public void OnClickButton() //��ŸƮ ��ư �������� ����
    {
        StartCoroutine(Go());
    }
}
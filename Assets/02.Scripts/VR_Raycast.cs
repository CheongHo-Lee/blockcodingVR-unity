using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;
using UnityEngine.EventSystems;

namespace Codezero
{
    public class VR_Raycast : MonoBehaviour
    {
        public AudioClip EffectSound;
        public AudioSource audioSource;

        private SteamVR_LaserPointer laserPointer;

        Vector3 startPosition;
        Vector3 diffPosition;
        GameObject canvas_;
        Transform ParentPos;
        Vector3 StartPos;
        FunctionMove FunctionMove;
        FunctionRotate functionRotate;
        int Mnum, Rnum;
        GameObject CloneBlock;

        private void OnEnable()
        {
            laserPointer = gameObject.GetComponent<SteamVR_LaserPointer>();

            // �̺�Ʈ �Ҵ�
            laserPointer.PointerIn += OnPointerEnter;
            laserPointer.PointerOut += OnPointerExit;
            laserPointer.PointerClick += OnPointerClick;
            laserPointer.PointerDown += OnPointerDown;
            laserPointer.Drag += OnDrag;
            laserPointer.EndDrag += OnEndDrag;
            laserPointer.Drop += OnDrop;
        }

        private void OnDisable()
        {
            // �̺�Ʈ ���� ����
            laserPointer.PointerIn -= OnPointerEnter;
            laserPointer.PointerOut -= OnPointerExit;
            laserPointer.PointerClick -= OnPointerClick;
            laserPointer.PointerDown -= OnPointerDown;
            laserPointer.Drag -= OnDrag;
            laserPointer.EndDrag -= OnEndDrag;
            laserPointer.Drop -= OnDrop;
        }

        //������ �����Ͱ� ���� ���
        void OnPointerEnter(object sender, PointerEventArgs e)
        {
            IPointerEnterHandler enterHandler = e.target.GetComponent<IPointerEnterHandler>();
            if (enterHandler == null) return;

            enterHandler.OnPointerEnter(new PointerEventData(EventSystem.current));

            // UI ���ͷ��� ����
            if (GameObject.FindWithTag("UI")) {
                audioSource.PlayOneShot(EffectSound);
            }
        }

        // ������ �����Ͱ� ���������
        void OnPointerExit(object sender, PointerEventArgs e)
        {
            IPointerExitHandler exitHandler = e.target.GetComponent<IPointerExitHandler>();
            if (exitHandler == null) return;

            exitHandler.OnPointerExit(new PointerEventData(EventSystem.current));
        }

        //Ʈ��Ŀ ��ư�� Ŭ���������
        void OnPointerClick(object sender, PointerEventArgs e)
        {
            IPointerClickHandler clickHandler = e.target.GetComponent<IPointerClickHandler>();
            if (clickHandler == null) return;

            clickHandler.OnPointerClick(new PointerEventData(EventSystem.current));
        }

        // ������ �ٿ����� ���
        void OnPointerDown(object sender, PointerEventArgs e)
        {
            IPointerDownHandler downHandler = e.target.GetComponent<IPointerDownHandler>();
            if (downHandler == null) return;

            downHandler.OnPointerDown(new PointerEventData(EventSystem.current));
        }

        // �巡������ ���
        void OnDrag(object sender, PointerEventArgs e)
        {
            IDragHandler dragHandler = e.target.GetComponent<IDragHandler>();
            if (dragHandler == null) return;

            dragHandler.OnDrag(new PointerEventData(EventSystem.current));
        }

        // �巡�װ� ������ ���
        void OnEndDrag(object sender, PointerEventArgs e)
        {
            IEndDragHandler endHandler = e.target.GetComponent<IEndDragHandler>();
            if (endHandler == null) return;

            endHandler.OnEndDrag(new PointerEventData(EventSystem.current));
        }

        // ������� ���
        void OnDrop(object sender, PointerEventArgs e)
        {
            IDropHandler dropHandler = e.target.GetComponent<IDropHandler>();
            if (dropHandler == null) return;

            dropHandler.OnDrop(new PointerEventData(EventSystem.current));
        }
    }
}
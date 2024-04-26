using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RectangleTrainer.ChromaTower.View
{
    public class DragRotator : MonoBehaviour
    {
        [SerializeField] float dampening = 0.8f;
        [SerializeField] float rotationSpeedMultiplier = 5.0f; // ��������� �������� ��� ����� �������� ��������

        private float delta;
        private ChromaTowerRenderer tower;
        private Vector2 lastInputPos;

        public void AttachTower(ChromaTowerRenderer tower)
        {
            this.tower = tower;
        }

        private Vector2 InputPosition
        {
            get
            {
#if UNITY_EDITOR || UNITY_STANDALONE
                return new Vector2(Input.mousePosition.x, Input.mousePosition.y);
#else
                if (Input.touchCount > 0)
                {
                    return Input.GetTouch(0).position;
                }
                else
                {
                    return lastInputPos;
                }
#endif
            }
        }

        private void Update()
        {
            // �������� ������� ������� �����
            Vector2 inputPos = InputPosition;

            if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                lastInputPos = inputPos;
            }

            if (Input.GetMouseButton(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved))
            {
                // ������������ ��������� ������� ��� ��������
                delta = (inputPos.x - lastInputPos.x) * Time.deltaTime;
                lastInputPos = inputPos;

                // ��������� �����������
                delta = delta * (1 - dampening) + delta * dampening;

                // �������� �� ����������� ��� ����� �������� ��������
                delta *= rotationSpeedMultiplier;

                // ������� �����
                tower.transform.Rotate(Vector3.up, delta);
            }
        }
    }
}

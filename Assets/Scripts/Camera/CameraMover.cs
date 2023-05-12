using System;
using UnityEngine;

namespace Camera
{
    public class CameraMover : MonoBehaviour
    {
        public float mouseSensitivity = 170.0f; // чувствительность мыши
        public float clampAngle = 80.0f; // ограничение угла поворота по вертикали
     
        private float rotY = 0.0f; // угол поворота по вертикали
        private float rotX = 0.0f; // угол поворота по вертикали

        void Start()
        {
            Vector3 rot = transform.localRotation.eulerAngles;
            rotX = rot.x;
            rotY = rot.y;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                MoveToDirection(Vector3.left);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                MoveToDirection(Vector3.forward);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                MoveToDirection(Vector3.right);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                MoveToDirection(Vector3.back);
            }

            if (Input.GetMouseButton(0))
            {
                RotateCamera();
            }
            
        }


        private void RotateCamera()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            rotX += mouseY;
            rotY += mouseX;

            rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

            transform.localRotation = Quaternion.Euler(-rotX, rotY, 0.0f);
        }

        private void MoveToDirection(Vector3 direction)
        {
            Vector3 globalMovement = transform.TransformDirection(direction);
            transform.position += globalMovement*0.3f;
        }
    }
}
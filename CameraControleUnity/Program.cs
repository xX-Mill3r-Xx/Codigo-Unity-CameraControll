using System;
using Unity;
using UnityEngine;


namespace CameraControleUnity
{
    /*Antes de implementar este codigo, lembre-se de criar um objeto
     plano para servir de chão e um objeto capsula para servir como player;
    
     Renomeie o obj capsula para Player e arraste o objeto camera para dentro do mesmo.
    Posicione a camera de forma que fique no local da cabeça do player;*/

    class CameraControl : MonoBehaviour
    {
        public Transform _playerTransform; // Controla o transform do player;
        public Transform _cameraTransform; // Controla o transform da camera;

        Vector2 rotationMouse; // Rotação X Y do Mouse;
        public int Sensibility; // Sensibilidade do Mouse;

        private void Start()
        {
            //Descomentar este codigo para travar o cursor do mouse;
            //Cursor.visible = false;
            //Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            Vector2 MouseCtrl; // Variavel que controla o Mouse;
            MouseCtrl = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            rotationMouse = new Vector2(rotationMouse.x + MouseCtrl.x * Sensibility * Time.deltaTime,
                rotationMouse.y + MouseCtrl.y * Sensibility * Time.deltaTime); // rotação do mouse;

            _playerTransform.eulerAngles = new Vector3(_playerTransform.eulerAngles.x, rotationMouse.x, _playerTransform.eulerAngles.z); //Transform do player;

            rotationMouse.y = Math.Clamp(rotationMouse.y, -90,90);

            _cameraTransform.localEulerAngles = new Vector3(-rotationMouse.y, _cameraTransform.localEulerAngles.y, _cameraTransform.localEulerAngles.z); ;
        }
    }
}

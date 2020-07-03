using UnityEngine;

namespace RatboyStudios.PlayerInput
{
    public class PlayerInput : MonoBehaviour
    {
        
        //DETECTAR LA TECLA IZQUIERDA
        //DETECTAR LA TECLA DERECHA
        [SerializeField] private float _horizontal;
        public float Horizontal
        {
            get { return _horizontal; }
        }

        //DETECTAR LA TECLA ARRIBA
        //DETECTAR LA TECLA ABAJO
        [SerializeField] private float _vertical;
        public float Vertical
        {
            get { return _vertical; }
        }

        //DETECTAR LA TECLA DE P PARA PAUSAR
        [SerializeField] private bool _pause;
        public bool Pause
        {
            get { return _pause; }
        }

        //DETECTAR LA TECLA DE E PARA ATACAR

        [SerializeField] private bool _attack;
        
        public bool Attack
        {
            get { return _attack; }
        }
        
        //DETECTAR LA TECLA C PARA AGACHARSE

        [SerializeField] private bool _crouch;
        
        public bool Crouch
        {
            get { return _crouch; }
        }
        //CHECAR SI ESTÁ ACTIVADO O DESACTIVADO MI INPUT

        [SerializeField] private bool _inputEnabled = false;
        
        public bool InputEnabled
        {
            get
            {
                return _inputEnabled; 
                
            }
            set { _inputEnabled = value; }
        }


        private void Update()
        {
            if (_inputEnabled)
            {
                _horizontal = Input.GetAxisRaw("Horizontal");
                _vertical = Input.GetAxisRaw("Vertical");
                _pause = Input.GetKeyDown(KeyCode.P);
                _attack = Input.GetKeyUp(KeyCode.E);
                _crouch = Input.GetKey(KeyCode.C);
            }
            else
            {
                _horizontal = 0f;
                _vertical = 0f;
                _pause = false;
                _attack = false;
                _crouch = false;
            }
        }
    }
}
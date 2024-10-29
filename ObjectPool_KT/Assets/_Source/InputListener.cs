using UnityEngine;

namespace _Source
{
    public class InputListener : MonoBehaviour
    {
        private PlayerShooter _playerShooter;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I)) _playerShooter.Shoot();
        }

        public void Construct(PlayerShooter playerShooter)
        {
            _playerShooter = playerShooter;
        }
    }
}
using UnityEngine;

namespace LudumDare55
{
    public class CursorWatcher : MonoBehaviour
    {
        private Vector2 _initialPosition;
        private void Start()
        {
            _initialPosition = transform.position;
        }

        private void Update()
        {
            Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition = Vector2.Lerp(_initialPosition, newPosition, .05f);
            newPosition.x = Mathf.Clamp(newPosition.x, _initialPosition.x - .3f, _initialPosition.x + .3f);
            newPosition.y = Mathf.Clamp(newPosition.y, _initialPosition.y - .2f, _initialPosition.y + .2f);
            
            transform.position = newPosition;
        }
    }
}

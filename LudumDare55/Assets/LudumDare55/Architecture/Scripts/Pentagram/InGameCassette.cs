using UnityEngine;

namespace LudumDare55
{
    public class InGameCassette : MonoBehaviour
    {
        private Cassette _cassette;

        private void OnMouseDrag()
        {
            var newPosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            transform.position = newPosition;
        }

        public void Construct(Cassette cassette)
        {
            _cassette = cassette;
        }
    }
}
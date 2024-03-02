using UnityEngine;

namespace CodeBase {
    public class MissScript : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D col) {
            if (col.gameObject.name == "Ball") {
                FindObjectOfType<GameManager>().Miss();
            }
        }
    }
}

using UnityEngine;

public class PlayerControl : MonoBehaviour {
    private float edge = 440f;

    void Update() {
//        float horizontal = Input.GetAxis("Horizontal");
//        if (horizontal != 0) {
//            horizontal = horizontal > 0 ? 1 : -1;
//            transform.Translate(Vector2.right * 6 * Time.deltaTime * horizontal);
//            //判断边界
//            if (transform.position.x > edge || transform.position.x < -edge) {
//                transform.Translate(Vector2.right * -6 * Time.deltaTime * horizontal);
//            }
//        }

        float x = Input.mousePosition.x - 540;
//        Debug.Log("MousePosition.x:" + Input.mousePosition.x);
        if (x > -edge && x < edge) {
            Vector3 position = transform.position;
//        Debug.Log("positionbefore:" + position);
            position.x = x / 100;
//        Debug.Log("positionafter:" + position);
            transform.localPosition = position;
        }

        if (Input.GetMouseButtonDown(0)) {
            if (transform.childCount > 0) {
                GetComponentInChildren<BallControl>().StartMove();
                transform.GetChild(0).parent = null;
            }
        }
    }
}
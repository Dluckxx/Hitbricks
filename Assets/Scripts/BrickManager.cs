using UnityEngine;

public class BrickManager : MonoBehaviour {
    public GameObject brick_white;
    public GameObject brick_black;

    private float width = 0.7f;
    private float height = 0.2f;

    public int x;
    public int y;

    void Start() {
        for (int i = 0; i > y; i--) {
            for (int j = 0; j < x; j++) {
                GameObject go;
                if ((j - i) % 2 == 0) {
                    go = Instantiate(brick_white, transform);
                } else {
                    go = Instantiate(brick_black, transform);
                }

                go.transform.localPosition = new Vector2(width * j, height * i);
            }
        }
    }
}
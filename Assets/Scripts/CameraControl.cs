using UnityEngine;

public class CameraControl : MonoBehaviour {
    public Camera mainCamera;

    private void Awake() {
        Application.targetFrameRate = 60;
        float designWidth = 1080f;
        float designHeight = 1920f;
        float designOrthographicSize = 9.6f;
        float designScale = designWidth / designHeight;
        float scaleRate = (float) Screen.width / (float) Screen.height;
        Debug.Log("监测到分辨率：" + Screen.width + 'x' + Screen.height);
        if (scaleRate < designScale) {
            float scale = scaleRate / designScale;
            Debug.Log("正交摄像机换算比例为：" + scale);
            mainCamera.orthographicSize = designOrthographicSize / scale;
            Debug.Log("摄像机大小调整为：9.6 --> " + mainCamera.orthographicSize);
            //调整砖块位置
            GameObject brickManager = GameObject.Find("BrickManager");
            Vector2 brickManagerPosition = brickManager.transform.position;
            brickManagerPosition.y += mainCamera.orthographicSize - designOrthographicSize;
            brickManager.transform.localPosition = brickManagerPosition;
            //调整操作区域位置和墙的位置
            GameObject bottom = GameObject.Find("Bottom");
            Vector2 bottomPosition = bottom.transform.position;
            bottomPosition.y -= mainCamera.orthographicSize - designOrthographicSize;
            bottom.transform.localPosition = bottomPosition;
            bottom.transform.GetChild(0).localPosition += new Vector3(0, 2.4f, 0);
            //调整玩家位置
            GameObject player = GameObject.Find("Player");
            Vector2 playerPosition = player.transform.position;
            playerPosition.y -= mainCamera.orthographicSize - designOrthographicSize;
            player.transform.localPosition = playerPosition;
        } else {
            mainCamera.orthographicSize = designOrthographicSize;
        }
    }
}
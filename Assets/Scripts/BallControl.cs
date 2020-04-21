using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallControl : MonoBehaviour {
    private bool isStart;
    private Vector3 point;
    private float ballspeed = 8;
    private int lastCollisionID;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (isStart == false) {
            return;
        }

        if (transform.position == point) {
            return;
        }

        if (collision.gameObject.GetInstanceID() == lastCollisionID) {
            return;
        }

        if (collision.collider.CompareTag("Die")) {
            isStart = false;
            gameObject.transform.parent = GameObject.Find("Player").transform;
            transform.localPosition = new Vector2(0, 0.3F);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0).normalized * 0;
            return;
        }

        if (collision.collider.CompareTag("Brick")) {
            Destroy(collision.collider.gameObject);
        }

        Vector2 inVec = transform.position - point;
        Vector2 outVec = Vector2.Reflect(inVec, collision.contacts[0].normal);
        point = transform.position;
        GetComponent<Rigidbody2D>().velocity = outVec.normalized * ballspeed;

        lastCollisionID = collision.gameObject.GetInstanceID();
//        Debug.Log("in-->out:" + inVec.normalized + "-->" + outVec.normalized + "开始碰撞:" + collision.gameObject.name);
    }

    //开局
    public void StartMove() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1F, 1F), 1).normalized * ballspeed;
        isStart = true;
        point = transform.position;
    }
}
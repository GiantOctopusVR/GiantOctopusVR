using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointClick : MonoBehaviour {
    public Transform parent;
    public GameObject Node;
    public GameObject Turret;

    public float snapValue = 2;
    //public float depth = 0;

    private GameController gameController;

    // Use this for initialization
    void Start () {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (gameController.currentPlatform == GameController.GamePlatform.Vive)
        {
            var mouse = Input.mousePosition;
            var temp = Camera.main.ScreenToWorldPoint(mouse);
            temp.y = 0.5f;
            transform.position = SnapPos(temp);

            if (Input.GetKey(KeyCode.Mouse0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag.Equals("Ground"))
                    {

                        var pos = hit.point;
                        pos.y = 0.5f;
                        Instantiate(Node, SnapPos(pos), Quaternion.identity, parent);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag.Equals("Node"))
                    {
                        var pos = hit.point;
                        pos.y = 1.5f;
                        Instantiate(Turret, SnapPos(pos), Quaternion.identity, parent);
                        //Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
    }

    Vector3 SnapPos(Vector3 clickPos)
    {
        var pos = clickPos;
        float snapInverse = 1 / (snapValue + 0.5f);

        float x, y, z;

        // if snapValue = .5, x = 1.45 -> snapInverse = 2 -> x*2 => 2.90 -> round 2.90 => 3 -> 3/2 => 1.5
        // so 1.45 to nearest .5 is 1.5
        x = Mathf.Round(pos.x * snapInverse) / snapInverse;
        z = Mathf.Round(pos.z * snapInverse) / snapInverse;
        y = pos.y;

        var newPos = new Vector3(x, y, z);

        return newPos;
    }

}

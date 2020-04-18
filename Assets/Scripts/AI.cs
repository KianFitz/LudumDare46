using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private List<GameObject> points;

    private GameObject target;
    private int pointer;
    private Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        target = points[0];
        pointer = 0;

        transform.position = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        bool canSeePlayer = CheckForPlayer();

        if (!canSeePlayer)
            Move();
        else
            Shoot();
    }

    private bool CheckForPlayer() {
        return false;
    }

    private void Shoot() {

    }

    private void Move() {
        var curPos = new Vector2Int((int)transform.position.x, (int)transform.position.y);
        var targetPos = new Vector2Int((int)target.transform.position.x, (int)target.transform.position.y);


        if (curPos == targetPos) {
            pointer++;
            if (pointer > points.Count - 1) pointer = 0;

            target = points[pointer];
            dir = (target.transform.position - transform.position).normalized;
        }

        transform.position += dir * moveSpeed * Time.deltaTime;
    }
}

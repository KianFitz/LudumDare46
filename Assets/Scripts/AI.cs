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
    private Vector3 oldDir;

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
        Debug.DrawRay(transform.position, new Vector3(dir.x, 0, 0), Color.red);

        if (CanSeePlayer())
            Shoot();
        else
            Move();
    }

    private bool CanSeePlayer() {
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

            oldDir = dir;
            dir = (target.transform.position - transform.position).normalized;

            if (oldDir == null) oldDir = dir;

            if (!SameSign(oldDir.x, dir.x)) {
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }

        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    private bool SameSign(float x1, float x2) {
        return (x1 <= 0 && x2 <= 0) || (x1 >= 0 && x2 >= 0);
    }
}

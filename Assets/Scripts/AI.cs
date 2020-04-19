using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private List<GameObject> points;
    [SerializeField]
    private AIScriptableObject data;

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

        gameObject.name = data.Name;

        GetComponent<Health>().MaxCharge = data.MaxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CanSeePlayer())
            Shoot();
        else
            Move();
    }

    private bool CanSeePlayer() {
        int layerMask = ~(1 << 9);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, data.AttackRange, layerMask);

        for (int i = 0; i < colliders.Length; i++) {

            var collider = colliders[i];

            if (collider != null && collider.gameObject.tag == "Player") {

                Vector2 dir = (collider.transform.position - transform.position).normalized;

                Debug.DrawRay(transform.position, dir * data.AttackRange, Color.red);

                RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, data.AttackRange, layerMask);

                if (hit.collider != null && hit.collider.gameObject.tag == "Player") return true;
            }       
        }

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
        //rigidbody.MovePosition(transform.position + dir * moveSpeed * Time.fixedDeltaTime);
    }

    private bool SameSign(float x1, float x2) {
        return (x1 <= 0 && x2 <= 0) || (x1 >= 0 && x2 >= 0);
    }
}

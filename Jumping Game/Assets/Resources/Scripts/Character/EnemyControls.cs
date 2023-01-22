using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyControls : MonoBehaviour
{
    private Transform target;
    private float activateDistance = 50f;
    private float pathUpdateSeconds = 0.1f;
    private float speed = 2.5f;
    private float nextWaypointDistance = 0.1f;
    private float jumpNodeHeightRequirement = 0.9f;
    private float jumpModifier = 8;
    private float jumpCheckOffset = 0.1f;
    private bool followEnabled = true;
    private bool jumpEnabled = true;
    private bool directionLookEnabled = true;
    private int currentTargetPlatform;

    private Path path;
    private int currentWaypoint = 0;
    RaycastHit2D isGrounded;
    Seeker seeker;
    public static Rigidbody2D enemyRB;

    public void Start()
    {
        seeker = GetComponent<Seeker>();
        enemyRB = GetComponent<Rigidbody2D>();
        currentTargetPlatform = 0;

        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);
    }

    private void FixedUpdate()
    {
        target = Level.listOfPlatforms[currentTargetPlatform];
        // target = Level.selectedCharacterCollider.gameObject.transform;
        if (TargetInDistance() && followEnabled)
        {
            PathFollow();
        }
        cameraBorders();
    } 
    private void UpdatePath()
    {
        if (followEnabled && TargetInDistance() && seeker.IsDone())
        {
            seeker.StartPath(enemyRB.position, target.position + new Vector3(0, .6f, 0), OnPathComplete);
        }
    }

    private void PathFollow()
    {
        if (path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (Level.selectedCharacterCollider.gameObject.transform.position.y > transform.position.y)
            {
                currentTargetPlatform++;
            }
            else if (Level.selectedCharacterCollider.gameObject.transform.position.y < transform.position.y && currentTargetPlatform != 0) 
            {
                currentTargetPlatform--;
            }
            return;
        }

        Vector3 startOffset = transform.position - new Vector3(0f, GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset);
        isGrounded = Physics2D.Raycast(startOffset, -Vector3.up, 0.05f);

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - enemyRB.position).normalized;

        if (jumpEnabled && isGrounded.collider != null)
        {
            if (direction.y > jumpNodeHeightRequirement && direction.y < 0.9f)
            {
                enemyRB.velocity = new Vector2(enemyRB.velocity.x, direction.y * (jumpModifier+8));
            }
            else if (direction.y > 0.9f)
            {
                enemyRB.velocity = new Vector2(enemyRB.velocity.x, direction.y * jumpModifier);
            }
        }

        enemyRB.velocity = new Vector2(direction.x * speed, enemyRB.velocity.y);

        float distance = Vector2.Distance(enemyRB.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (directionLookEnabled)
        {
            if (enemyRB.velocity.x > 0.05f)
            {
                transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (enemyRB.velocity.x < -0.05f)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
    }

    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.transform.position) < activateDistance;
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    void cameraBorders()
    {
        float xMin;
        float xMax;
        xMin = Camera.main.ViewportToWorldPoint(new Vector2(0,0)).x + enemyRB.gameObject.GetComponent<BoxCollider2D>().bounds.size.x/2;
        xMax = Camera.main.ViewportToWorldPoint(new Vector2(1,0)).x - enemyRB.gameObject.GetComponent<BoxCollider2D>().bounds.size.x/2;
        enemyRB.position = new Vector2(Mathf.Clamp(enemyRB.position.x, xMin, xMax), enemyRB.position.y);
    }
}

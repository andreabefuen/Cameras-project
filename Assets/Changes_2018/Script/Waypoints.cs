using UnityEngine;
using System.Collections;

public class Waypoints : MonoBehaviour {

    public bool gizmosActivate;
    public Transform pathHolder;

    public float speed;
    public float waitTime;

    private int indexway = 0;


	// Use this for initialization
	void Start () {

        Vector3[] waypoints = new Vector3[pathHolder.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = pathHolder.GetChild(i).position;
            
        }

        StartCoroutine(FollowPath(waypoints));
    }
	
    IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints[indexway];

        int targetWaypointIndex = indexway + 1;

        Vector3 targetWaypoint = waypoints[targetWaypointIndex];

        while(true)
        {
            transform.LookAt(targetWaypoint);
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
            if (transform.position == targetWaypoint)
            {
                targetWaypointIndex++;
                targetWaypoint = waypoints[targetWaypointIndex];
                yield return new WaitForSeconds(waitTime);
            }
            if(targetWaypointIndex > waypoints.Length)
            {
                yield return null;
            }
            yield return null;
        }
       
        
    }

    private void OnDrawGizmos()
    {
        if (gizmosActivate)
        {
            Vector3 startPosition = pathHolder.GetChild(0).position;
            Vector3 previousPosition = startPosition;
            foreach (Transform waypoint in pathHolder)
            {
                Gizmos.DrawSphere(waypoint.position, 1f);
                Gizmos.DrawLine(previousPosition, waypoint.position);
                previousPosition = waypoint.position;
            }
            //Gizmos.DrawLine(previousPosition, startPosition);
        }

    }

    // Update is called once per frame
    void Update () {
	
	}
}

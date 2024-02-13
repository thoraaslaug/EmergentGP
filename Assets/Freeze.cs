using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{  TrailRenderer myTrail;
    EdgeCollider2D myCollider;
 
    static List<EdgeCollider2D> unusedColliders = new List<EdgeCollider2D>();
 
    void Awake()
    {
        myTrail = this.GetComponent<TrailRenderer>();   
        myCollider = GetValidCollider();
    }   
 
    void Update()
    {
        SetColliderPointsFromTrail(myTrail, myCollider);
    }
    
    EdgeCollider2D GetValidCollider()
    {
        EdgeCollider2D validCollider;
        if(unusedColliders.Count>0)
        {
            validCollider = unusedColliders[0];
            validCollider.enabled = true;
            unusedColliders.RemoveAt(0);
        }
        else
        {
            validCollider = new GameObject("TrailCollider",typeof(EdgeCollider2D)).GetComponent<EdgeCollider2D>();
        }
        return validCollider;
    }
 
    void SetColliderPointsFromTrail(TrailRenderer trail, EdgeCollider2D collider)
    {
        List<Vector2> points = new List<Vector2>();
        if(trail.positionCount == 0)
        {
            points.Add(transform.position);
            points.Add(transform.position);
        }
        else for(int position = 0; position<trail.positionCount; position++)
        {
            points.Add(trail.GetPosition(position));
        }
        collider.SetPoints(points);
    }
 
    void OnDestroy()
    {
        if(myCollider!=null)
        {
            myCollider.enabled = false;
            unusedColliders.Add(myCollider);
        }
    }
}
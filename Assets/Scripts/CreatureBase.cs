using UnityEngine;
using System.Collections;

public class CreatureBase : MonoBehaviour
{
    public float time;
    public bool canFly;
    public bool canSwim;
    public float movementSpeed;
    public bool isHostile;
    public bool isAggressive;
    private LifeSource lifesource;
    public int awarenessLevel;
    private BoxCollider awarenessBox;
    private float previousAwarenessLevel;
    public float HungerRate;
    public float CreatureHunger;
    public float FindFoodHunger;
    private Vector3 moveVelocity;
    void Start()
    {
        // set creature hunger here
        awarenessBox = GetComponent<BoxCollider>();
        awarenessBox.center = transform.position;
        awarenessBox.size = new Vector3(awarenessLevel, awarenessLevel,awarenessLevel);
    }
    void Update()
    {
        CreatureHunger -= HungerRate * Time.deltaTime * time;
    }
    void ModifyAwareness(float NewAwarenessLevel)
    {
        awarenessBox.size = new Vector3(NewAwarenessLevel, NewAwarenessLevel, NewAwarenessLevel);
    }
    void OnTriggerStay(Collider other)
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, awarenessBox.size);
 
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "Player"){
            }
            if (colliders[i].gameObject.tag == "Food" && CreatureHunger < FindFoodHunger)
            {
                Vector3 targetPosition = colliders[i].transform.position;
                Vector3.SmoothDamp(transform.position, targetPosition, ref moveVelocity, 3);
            }
        }
    }
  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ICharacter
{
    private string LOG_TAG = typeof(Enemy).Name;
    [SerializeField] private float moveSpeed = 1.2f;
    private Health health;

    private int currentLocIndex = 0;
    
    // This movePaths is assigned to Enemy after they are spawned in Wave
    public List<Transform> movePaths;
    public CharacterType GetCharacterType()
    {
        return CharacterType.ENEMY;
    }

    private Transform nextDestination;
    // Start is called before the first frame update
    void Awake()
    {
        health = GetComponent<Health>();
        health.OnDead += Die;
    }

    void Start(){
        Debug.Log(LOG_TAG + " Has been created with " + this.movePaths.Count + " destination point(s)");
        foreach(var transform in this.movePaths){
                print("Location index " +
                transform.position.ToString());
        }

        // Assign first location to move:
        nextDestination = this.movePaths[0];
    }


    // Update is called once per frame
    void Update()
    {
        // If not move path is assigned, skip
        if (movePaths.Count == 0) return;
        
        // Create new Destination
        Transform nextDest = this.movePaths[this.currentLocIndex];
        // Move to next destination
        transform.position = Vector2.MoveTowards(transform.position,nextDest.position, moveSpeed*Time.deltaTime);

        // Arrived Success
        if (Vector2.Distance(transform.position, nextDest.position) <= 0.2){
            Debug.Log("Arrived to Position " + currentLocIndex);
            this.currentLocIndex ++;

            if (currentLocIndex == (this.movePaths.Count)){
                currentLocIndex = 0;
            }
        }


        
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}

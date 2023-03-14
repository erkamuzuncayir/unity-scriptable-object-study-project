using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
#region Fields
    public GameObjectRuntimeSet     all_spawned_collectables;
    [ Header( "Collectable Types" ) ]
    public List< CollectableType >  collectable_type_list = new();
    [ Space( 10f ) ]
    public IntVariableSO            collectable_total_count;
    
    [ Header( "Spawn Limitations" ) ]
    [ Range( 0, -9 ) ]
    public int obj_x_pos_min;
    [ Range( 0, 9 ) ]
    public int obj_x_pos_max;
    const float obj_y_pos_min = 0.5f;
    const float obj_y_pos_max = 0.5f;
    [ Range( 0, -9 ) ]
    public int obj_z_pos_min;
    [ Range( 0, 9 ) ]
    public int obj_z_pos_max;
#endregion

#region Unity API
    /*
     * Hack: I call awake instead of start, sometimes the **InstantiatePickUps** method doesn't work fast enough.
     * Therefore **Start** method in **CollectableCounter** can't get the correct total_collectable_count. */
    void Awake() 
    {
        all_spawned_collectables.Initalize(); // Why: Clear spawned collectables for each session
        collectable_total_count.value = 0; // Why: Sets collectable count 0 for each session
        InstantiatePickUps();
    }
#endregion

#region Implementation
    void InstantiatePickUps()
    {
        foreach( var eachCollectableType in collectable_type_list )
        {
            for( int i = 0; i < eachCollectableType.collectable_count_SO.Value; i++ )
            {
                // Why : Checks collectable if it is foe or not
                if ( !eachCollectableType.collectable_prefab.
                        GetComponent< CollectableSettings >().isCollectableFoe.Value )
                    collectable_total_count.value++;

                Instantiate( eachCollectableType.collectable_prefab, 
                                GenerateRandomVector3(), Random.rotation );
            }
        }
    }

    Vector3 GenerateRandomVector3()
    {
        var randomVector3 = new Vector3( Random.Range( obj_x_pos_min, obj_x_pos_max ),
                                            Random.Range( obj_y_pos_min, obj_y_pos_max ),
                                            Random.Range( obj_z_pos_min, obj_z_pos_max ) );
        foreach ( var spawnedCollectable in all_spawned_collectables.items )
        {
            // Why : Checks to avoid spawning the same position twice.
            if ( randomVector3.x == spawnedCollectable.transform.position.x &&
                randomVector3.z == spawnedCollectable.transform.position.z )
                return GenerateRandomVector3();
        }
        return randomVector3;
    }
}
#endregion

// Why : This class provides us a good inspector experience with editing and debugging.
[System.Serializable]
public class CollectableType
{
#region Fields
    public GameObject collectable_prefab;
    public IntReference collectable_count_SO;
#endregion
}


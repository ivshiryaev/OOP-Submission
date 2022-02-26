using UnityEngine;

public class Collision_DestroyOnCollision : MonoBehaviour
{
    [SerializeField] bool destroyCollisionObject_b, destroySelf_b, onLayerCollision_b, onTagCollision_b;

    [SerializeField] string layerToDestroy;
    [SerializeField] string tagToDestroy;


    private void OnCollisionEnter(Collision collision)
    {
        //Check LayerName
        if (onLayerCollision_b && collision.gameObject.layer == LayerMask.NameToLayer(layerToDestroy))
        {
            if (!destroySelf_b)
                Destroy(collision.gameObject);
            else
                Destroy(gameObject);
        }

        //Check Tag
        if (onTagCollision_b && collision.gameObject.CompareTag(tagToDestroy))
        {
            if (!destroySelf_b)
                Destroy(collision.gameObject);
            else
                Destroy(gameObject);
        }

        //Destroying this.gameObject if destroySelf == true
        if (destroySelf_b)
            Destroy(gameObject);

        //Destroying  gameObject on collision
        if (destroyCollisionObject_b)
            Destroy(collision.gameObject);
    }
}

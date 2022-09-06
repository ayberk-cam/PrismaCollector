using UnityEngine;

public class StackManager : MonoBehaviour
{

    [SerializeField] private float distance = 0.25f;
    public Transform prevPickable;
    [SerializeField] private Transform stackArea;
    public int stacked;
    
    private void Pick(GameObject collectableObject,string newTag)
    {
        collectableObject.tag = newTag;
        collectableObject.transform.parent = stackArea.transform;
        var desiredPosition = prevPickable.localPosition;
        desiredPosition.y += distance;

        collectableObject.transform.localPosition = desiredPosition;
        prevPickable = collectableObject.transform;
        collectableObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickable"))
        {
            Pick(other.gameObject,"Stacked");
            stacked += 1;
        }
    }
}

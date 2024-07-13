using UnityEngine;
namespace Content.Scripts
{
    public class MiningResource : MonoBehaviour
    {
        public EResourceType ResourceType => resourceType;
        [SerializeField] private EResourceType resourceType;
    }

    public enum EResourceType
    {
        Bush,
        Stone,
        Tree
    }
}

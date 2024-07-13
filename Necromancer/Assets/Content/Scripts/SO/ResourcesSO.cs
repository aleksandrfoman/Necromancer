using UnityEngine;
namespace Content.Scripts.SO
{
    [CreateAssetMenu(fileName = "ResourcesSO", menuName = "GameData/ResourcesSO", order = 0)]
    public class ResourcesSO : ScriptableObject
    {
        [field: SerializeField] public MiningResource ResourcePrefab { get; private set; }
    }
}

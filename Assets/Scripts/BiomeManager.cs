using UnityEngine;

namespace SpencerHaney
{
    [ExecuteInEditMode]
    class BiomeManager : MonoBehaviour
    {
        public static BiomeManager Instance;

        [SerializeField]
        public Biome[] Biomes;

        private void Awake()
        {
            Instance = this;
        }
    }
}

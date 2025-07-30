using UnityEngine;

namespace YekGames.CoroutineSystem.Mono
{
    public class CoroutinesHolder : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
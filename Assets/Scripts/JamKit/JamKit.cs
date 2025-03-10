using UnityEngine;

namespace JamKit
{
    public partial class JamKit : MonoBehaviour
    {
        public readonly string SameScene = null;

        [SerializeField] private Globals _globals;
        public Globals Globals => _globals;

        private void Start()
        {
            StartSfx();
            StartLeaderboard();
        }

        private void Update()
        {
            UpdateSfx();
        }
    }
}
using UnityEngine;

namespace JamKit
{
    public partial class JamKit : MonoBehaviour
    {
        [SerializeField] private Globals _globals;
        public Globals Globals => _globals;

        private void Start()
        {
            StartSfx();
        }

        private void Update()
        {
            UpdateSfx();
        }
    }
}
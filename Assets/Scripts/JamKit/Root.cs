using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JamKit
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private JamKit _jamKit;
        [SerializeField] private Camera _camera;

        private IScene _currentScene;
        private bool _isSceneLoading;
        [SerializeField] private string _currentSceneName = "Game";

        private void Start()
        {
            ChangeScene("", _currentSceneName);
        }

        private void Update()
        {
            if (_isSceneLoading)
            {
                return;
            }

            string nextSceneName = _currentScene.Tick();
            if (nextSceneName != _jamKit.SameScene)
            {
                ChangeScene(_currentSceneName, nextSceneName);
            }
        }

        private void ChangeScene(string oldSceneName, string newSceneName)
        {
            _isSceneLoading = true;

            if (oldSceneName != "")
            {
                _currentScene.Exit();
                SceneManager.UnloadSceneAsync(oldSceneName);
            }

            _currentSceneName = newSceneName;
            SceneManager.LoadScene(newSceneName, new LoadSceneParameters(LoadSceneMode.Additive));
            _currentScene = FindFirstObjectByType<SceneRoot>();
            _currentScene.Init(_jamKit, _camera);
            _isSceneLoading = false;
        }

    }
}
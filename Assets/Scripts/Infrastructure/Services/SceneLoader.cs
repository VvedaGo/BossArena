using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services
{
    public class SceneLoader : ISceneLoader
    {
        private Action _callbackSceneLoad;
       
        public void LoadSceneAsync(string nameScene, Action callback)
        {
            _callbackSceneLoad = callback;
            AsyncOperation operation = SceneManager.LoadSceneAsync(nameScene);
            operation.completed += SceneLoaderCallback;
        }

        public void SceneLoaderCallback(AsyncOperation obj)
        {
            _callbackSceneLoad?.Invoke();
        }
    }
}
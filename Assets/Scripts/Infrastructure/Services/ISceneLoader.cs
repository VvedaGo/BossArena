using System;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface ISceneLoader : IService
    {
        void LoadSceneAsync(string nameScene, Action callback);
        void SceneLoaderCallback(AsyncOperation obj);
    }
}
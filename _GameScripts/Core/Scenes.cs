// Copyright (C) by Khoruz Studio

using UnityEngine;
using UnityEngine.SceneManagement;

namespace _GameScripts.Core
{
    enum GameScenes
    {
        MainMenu,
        Hub,
        Battle
    }
    
    [CreateAssetMenu(fileName = "Scenes", menuName = "Game/System/Scenes")]
    public class Scenes: ScriptableObject
    {
        public void LoadMainMenu()
        {
            LoadScene(GameScenes.MainMenu);
        }
        
        public void LoadHub()
        {
            LoadScene(GameScenes.Hub);
        }
        
        public void LoadBattle()
        {
            LoadScene(GameScenes.Battle);
        }

        private void LoadScene(GameScenes scene)
        {
            SceneManager.LoadSceneAsync((int) scene);
        }
    }
}
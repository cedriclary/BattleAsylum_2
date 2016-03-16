﻿using UnityEngine;
using System.Collections;

namespace s3
{
    public class GameManager_GoToMenuScene : MonoBehaviour
    {
        private GameManager_Master gameManagerMaster;

        void OnEnable()
        {
            SetInitialReferences();
            gameManagerMaster.GoToMenuSceneEvent += GoToMenuScene;
        }

        void OnDisable()
        {
            gameManagerMaster.GoToMenuSceneEvent -= GoToMenuScene;
        }
      
        void SetInitialReferences()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }

        void GoToMenuScene()
        {
            Application.LoadLevel(0);
        }
    }
}

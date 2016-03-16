using UnityEngine;
using System.Collections;

namespace s3
{
    public class GameManager_ToggleMenu : MonoBehaviour
    {
        private GameManager_Master gameManagerMaster;
        public GameObject menu;

        void Start()
        {
        }

        void Update()
        {
            CheckForMenuToggleRequest();

        }

        void OnEnable()
        {
            setInitialReferences();
            gameManagerMaster.GameOverEvent += ToggleMenu;

        }

        void OnDisable()
        {
            gameManagerMaster.GameOverEvent -= ToggleMenu;
        }

        void setInitialReferences()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }

        void CheckForMenuToggleRequest()
        {
            if(Input.GetKeyUp(KeyCode.Escape) && !gameManagerMaster.isGameOver )
           {
                ToggleMenu();
            }
        }

        void ToggleMenu()
        {
            if(menu!=null)
            {
                menu.SetActive(!menu.activeSelf);
                gameManagerMaster.isMenuOn = !gameManagerMaster.isMenuOn;
                gameManagerMaster.CallEventMenuToggle();
               
            }
            else
            {
                Debug.LogWarning("Attache un canvas au gameManager ");
            }
        }

    }
}
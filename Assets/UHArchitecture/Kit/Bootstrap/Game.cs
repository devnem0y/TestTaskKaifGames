using System;
using UnityEngine;
using UralHedgehog.UI;

namespace UralHedgehog
{
    public class Game : EntryPoint
    {
        public static Game Instance { get; private set; }

        [SerializeField] private StorePurchases _storePurchases;
        
        private Shop _shop;
        private MainScreenController _mainScreenController;

        private void Awake()
        {
            Instance = this;
        }

        protected void Start()
        {
            Run();
        }

        protected override void Initialization()
        {
            base.Initialization();

            _shop = new Shop(_storePurchases, _player);
            _mainScreenController = new MainScreenController(_shop);
            UIManager = new UIManager(UIHandler, _settings, _mainScreenController);
        }

        public override void ChangeState(GameState state)
        {
            base.ChangeState(state);
            
            switch (GameState)
            {
                case GameState.LOADING:
                    Debug.Log("<color=yellow>Loading</color>");
                    ScreenTransition.Perform(null, TransitionMode.STATIC);
                    break;
                case GameState.MAIN:
                    Debug.Log("<color=yellow>Main</color>");
                    //UIManager.OpenViewSettings();
                    UIManager.OpenViewMain();
                    ScreenTransition.Show();
                    break;
                case GameState.PLAY:
                    Debug.Log("<color=yellow>Play</color>");
                    break;
                case GameState.VICTORY:
                    Debug.Log("<color=yellow>Victory</color>");
                    break;
                case GameState.DEFEAT:
                    Debug.Log("<color=yellow>Defeat</color>");
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
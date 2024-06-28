namespace UralHedgehog
{
    namespace UI
    {
        public class UIManager
        {
            private readonly UIHandler _uiHandler;
            
            private readonly ISettings _settings;
            private readonly MainScreenController _mainScreenController;
            private readonly ClickerController _clickerController;
            
            public UIManager(UIHandler uiHandler, ISettings settings, 
                MainScreenController mainScreenController, ClickerController clickerController)
            {
                _uiHandler = uiHandler;
                
                _settings = settings;
                _mainScreenController = mainScreenController;
                _clickerController = clickerController;
            }

            #region Open

            /// <summary>
            /// Поднимает виджет настроек
            /// </summary>
            public void OpenViewSettings()
            {
                _uiHandler.Create(nameof(WSettings), _settings);
            }
            
            public void OpenViewTransactions(Transactions transactions)
            {
                _uiHandler.Create(nameof(WTransactions), transactions);
            }
            
            public void OpenViewMain()
            {
                _uiHandler.Create(nameof(PMain), _mainScreenController);
            }
            
            public void OpenViewTop()
            {
                _uiHandler.Create(nameof(PTop), _clickerController);
            }

            #endregion

            //TODO: Методы Close могут понадобиться для принудительного закрытия виджета, либо если виджет не имеет кнопки закрыть.
            //TODO: Его можно закрыть и уничтожить из любого места.
            #region Close

            /// <summary>
            /// Уничтожает виджет настроек
            /// </summary>
            public void CloseViewSettings()
            {
                _uiHandler.Kill(nameof(WSettings));
            }
            
            public void CloseViewTransactions()
            {
                _uiHandler.Kill(nameof(WTransactions));
            }

            #endregion
        }
    }
}
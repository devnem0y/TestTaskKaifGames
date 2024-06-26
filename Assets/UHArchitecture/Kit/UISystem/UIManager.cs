namespace UralHedgehog
{
    namespace UI
    {
        public class UIManager
        {
            private readonly UIHandler _uiHandler;
            
            private readonly ISettings _settings;
            private readonly Shop _shop;
            
            public UIManager(UIHandler uiHandler, ISettings settings, Shop shop)
            {
                _uiHandler = uiHandler;
                
                _settings = settings;
                _shop = shop;
            }

            #region Open

            /// <summary>
            /// Поднимает виджет настроек
            /// </summary>
            public void OpenViewSettings()
            {
                _uiHandler.Create(nameof(WSettings), _settings);
            }
            
            public void OpenViewShop()
            {
                _uiHandler.Create(nameof(WShop), _shop);
            }
            
            public void OpenViewTransactions(Transactions transactions)
            {
                _uiHandler.Create(nameof(WTransactions), transactions);
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
            
            public void CloseViewShop()
            {
                _uiHandler.Kill(nameof(WShop));
            }
            
            public void CloseViewTransactions()
            {
                _uiHandler.Kill(nameof(WTransactions));
            }

            #endregion
        }
    }
}
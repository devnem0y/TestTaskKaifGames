using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UralHedgehog.UI;

public class PTop : Widget<ClickerController>
{
    [SerializeField] private TMP_Text _lblLevel;
    [SerializeField] private TMP_Text _lblClickCount;
    [SerializeField] private TMP_Text _lblClickNextLevel;
    [SerializeField] private Slider _bar;
    
    public override void Init(ClickerController model)
    {
        base.Init(model);

        OnChangeLevel();
        OnChangeClickCount();

        Model.Player.ChangeLevel += OnChangeLevel;
        Model.Player.ChangeClickCount += OnChangeClickCount;
    }

    private void OnDestroy()
    {
        Model.Player.ChangeLevel -= OnChangeLevel;
        Model.Player.ChangeClickCount -= OnChangeClickCount;
    }

    private void OnChangeLevel()
    {
        _lblLevel.text = $"Level: {Model.Player.Level}";
        _lblClickNextLevel.text = $"Next level: {Model.Player.ClickNextLevel}";
        _bar.maxValue = Model.Player.ClickNextLevel;
        _bar.value = Model.Player.ClickCount;
    }
    
    private void OnChangeClickCount()
    {
        _lblClickCount.text = $"Click: {Model.Player.ClickCount}";
        _bar.value = Model.Player.ClickCount;
    }
}
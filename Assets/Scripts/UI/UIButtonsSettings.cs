using UnityEngine;

[CreateAssetMenu (fileName = "new Buttons Settings", menuName = "Buttons Settings")]
public class UIButtonsSettings : ScriptableObject
{
    [SerializeField] private float _delayFreezeTimerButton;
    [SerializeField] private float _delayKillAllEnemyButton;
    [SerializeField] private float _freezeTime;

    public float DelayFreezeTimerButton => _delayFreezeTimerButton;
    public float DelayKillAllEnemyButton => _delayKillAllEnemyButton; 
    public float FreezeTime => _freezeTime;
}

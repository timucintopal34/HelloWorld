using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    
    public UnityAction OnLevelStart;
    public Transform paintGameObject;
    public Transform percentageUI;
    
    private static object _lock = new object();
    private static GameManager _instance;
    private PlayerMovement _playerMovement;

    GameStartTimer _gameStartTimer;

    public static GameManager Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null) _instance = (GameManager) FindObjectOfType(typeof(GameManager));

                return _instance;
            }
        }
    }
    void Start()
    {
        paintGameObject.gameObject.SetActive(false);
        _gameStartTimer = FindObjectOfType<GameStartTimer>();
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public void GameStart()
    {
        //After counter time is done the scripts are informed that game has started.
        OnLevelStart?.Invoke();
    }

    public void GameWin()
    {
        paintGameObject.gameObject.SetActive(true);
        percentageUI.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
        _gameStartTimer.GameWinText();
    }

    public void GameFail()
    {
        _gameStartTimer.GameFailText();
    }
}

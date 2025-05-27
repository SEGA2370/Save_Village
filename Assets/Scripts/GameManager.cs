// GameManager.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TimeRunner HarvestTimer;
    [SerializeField] private TimeRunner EatingTimer;
    [SerializeField] private TimeRunner RaidSpawnTimer;
    [SerializeField] private TimeRunner PeasantCreateTimer;
    [SerializeField] private TimeRunner WarriorCreateTimer;
    [SerializeField] private Image RaidTimerImg;
    [SerializeField] private Image PeasantTimerImg;
    [SerializeField] private Image WarriorTimerImg;

    [SerializeField] private Button peasantButton;
    [SerializeField] private Button warriorButton;

    [SerializeField] private Text resourcesText;
    [SerializeField] private Text enemyResourcesText;

    [SerializeField] private Text gameOverMaxRaidText;
    [SerializeField] private Text gameOverResourcesText;
    [SerializeField] private Text youWonMaxRaidText;
    [SerializeField] private Text youWonResourcesText;


    public int peasantCount;
    public int warriorsCount;
    public int wheatCount;

    public int wheatPerPeasant;
    public int wheatToWarriors;

    public int peasantCost;
    public int warriorCost;

    public int raidIncrease;
    public int nextRaid;

    int maxWheat;
    int maxEnemies;
    int raidCounter;

    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private GameObject YouWonScreen;
    [SerializeField] private GameObject GameRulesScreen;



    // Start is called before the first frame update
    void Start()
    {
        RaidSpawnTimer.OnTick.AddListener(RaidTickHandler);

        HarvestTimer.OnTick.AddListener(HarvestTickHandler);
        EatingTimer.OnTick.AddListener(EatingTickHandler);

        PeasantCreateTimer.OnTick.AddListener(PeasantCreateTickHandler);
        WarriorCreateTimer.OnTick.AddListener(WarriorCreateTickHandler);

        InitializeGame();
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        UpdateText();
        WinLoseLogic();
        ButtonController();
       
    }

        public void CreatePeasant()
    {
        if (PeasantCreateTimer.currentTime <= 0)
        {
            if (wheatCount >= peasantCost)
            {
                wheatCount -= peasantCost;
                PeasantTimerImg.fillAmount = 1;
                peasantButton.interactable = false;
                PeasantCreateTimer.Restart();
            }
        }
    }

    public void CreateWarrior()
    {
        if (WarriorCreateTimer.currentTime <= 0)
        {
            if (wheatCount >= warriorCost)
            {
                wheatCount -= warriorCost;
    
                warriorButton.interactable = false;
                WarriorCreateTimer.Restart();
            }
        }
    }

    public void RestartGame()
    {
        InitializeGame();
        Time.timeScale = 1;
        GameOverScreen.SetActive(false);
        YouWonScreen.SetActive(false);
        GameRulesScreen.SetActive(false);
    }



    private void InitializeGame()
    {
        peasantCount = 5;
        warriorsCount = 2;
        wheatCount = 20;
        maxWheat = 0;
        maxEnemies = 0;
        raidCounter = 0;
        nextRaid = -2;
        UpdateText();
    }

    private void Timer()
    {
        if (RaidSpawnTimer.currentTime <= 0)
        {
            RaidSpawnTimer.Restart();
        }
        if (PeasantCreateTimer.currentTime == 0)
        {
            PeasantTimerImg.fillAmount = 1;
        }
        if (WarriorCreateTimer.currentTime == 0)
        {
            WarriorTimerImg.fillAmount = 1;
        }
        if (HarvestTimer.currentTime <= 0)
        {
            HarvestTimer.Restart();
        }
        if (EatingTimer.currentTime <= 0)
        {
            EatingTimer.Restart();
        }
    }
    private void WinLoseLogic()
    {
        if (warriorsCount < 0)
        {
            Time.timeScale = 0;
            GameOverScreen.SetActive(true);
        }
        if (wheatCount >= 5000 || peasantCount >= 85 || warriorsCount >= 35)
        {
            Time.timeScale = 0;
            YouWonScreen.SetActive(true);
        }
    }

    private void ButtonController()
    {
        if (wheatCount < peasantCost)
        {
            peasantButton.interactable = false;
        }
        if (wheatCount < warriorCost)
        {
            warriorButton.interactable = false;
        }
        if (wheatCount > peasantCost)
        {
            peasantButton.interactable = true;
        }
        if (wheatCount > warriorCost)
        {
            warriorButton.interactable = true;
        }
    }

    private void RaidTickHandler()
    {
        if (RaidSpawnTimer.currentTime <= 0)
        {
            warriorsCount -= nextRaid;
            nextRaid += raidIncrease;
            raidCounter += 1;
        }
    }
    private void WarriorCreateTickHandler()
    {
        
        if (WarriorCreateTimer.currentTime <= 0)
        {
            WarriorTimerImg.fillAmount = 1;
            warriorButton.interactable = true;
            warriorsCount += 1;
        }
    }

    private void PeasantCreateTickHandler()
    {
       
        if (PeasantCreateTimer.currentTime <= 0)
        {
            PeasantTimerImg.fillAmount = 1;
            peasantButton.interactable = true;
            peasantCount += 1;
        }
    }
    private void HarvestTickHandler()
    {
        wheatCount += peasantCount * wheatPerPeasant;
        maxWheat += wheatCount;
    }

    private void EatingTickHandler()
    {
        wheatCount -= warriorsCount * wheatToWarriors;
    }
    private void UpdateText()
    {
        resourcesText.text = peasantCount + "\n" + warriorsCount + "\n\n" + wheatCount;

        enemyResourcesText.text = nextRaid + "\n\n" + maxEnemies;
        maxEnemies = nextRaid + raidIncrease;

        gameOverResourcesText.text = peasantCount + "\n" + warriorsCount + "\n" + maxWheat;

        gameOverMaxRaidText.text = raidCounter + "\n" + nextRaid;


        youWonResourcesText.text = peasantCount + "\n" + warriorsCount + "\n" + maxWheat;

        youWonMaxRaidText.text = raidCounter + "\n" + nextRaid;
    }
}
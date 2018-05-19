using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public TrackManager Track;
    public SoundManager SoundManager;

    public int CompostCount;
    public int MetalCount;
    public int NuclearCount;

    public UnityEngine.UI.Text CompostMessage;
    public UnityEngine.UI.Text MetalMessage;
    public UnityEngine.UI.Text NuclearMessage;

    public float MaxCarbonCount = 500;
    public float CarbonCount;
    public float CarbonIncrement = 5;
    public int TypeBonus;

    public int CompostCost = 2;
    public int MetalCost = 5;
    public int NuclearCost = 1;

    public float BinValue = 3;
    public float TurbineValue = 10;
    public float SolarValue = 10;

    private int lastType;
    
    private bool started;
    private bool toStart;
    private bool compostTutorial;
    private bool metalTutorial;
    private bool nuclearTutorial;
    private int divider;

    public GameObject BinPrefab;
    public GameObject TurbinePrefab;
    public GameObject SolarPrefab;

    private void Start()
    {
        CarbonCount = 350;
        CompostCount = 0;
        MetalCount = 0;
        NuclearCount = 0;
        BinValue = 10;
        TurbineValue = 30;
        SolarValue = 50;
        CompostCost = 2;
        MetalCost = 5;
        NuclearCost = 1;
        TypeBonus = 5;
        divider = 5;
    }

    public void StartTimer()
    {
        toStart = true;
    }

    private void DoCompostTutorial()
    {
        Time.timeScale = 0;
        CompostMessage.gameObject.SetActive(true);
    }

    private void DoMetalTutorial()
    {
        Time.timeScale = 0;
        MetalMessage.gameObject.SetActive(true);
    }

    private void DoNuclearTutorial()
    {
        Time.timeScale = 0;
        NuclearMessage.gameObject.SetActive(true);
    }

    public void AddCompost(int count = 1)
    {
        CompostCount += count;
        if (CompostCount == CompostCost && !compostTutorial)
        {
            DoCompostTutorial();
        }
        if (CompostCount == CompostCost)
        {
            SoundManager.Bin.Play();
        }
        else
        {
            SoundManager.Compost.Play();
        }
    }

    public void AddMetal(int count = 1)
    {
        MetalCount += count;
        if (MetalCount == MetalCost && !metalTutorial)
        {
            DoMetalTutorial();
        }
        if (MetalCount == MetalCost)
        {
            SoundManager.Turbine.Play();
        }
        else
        {
            SoundManager.Metal.Play();
        }
    }

    public void AddNuclear(int count = 1)
    {
        NuclearCount += count;
        if (NuclearCount == NuclearCost && !nuclearTutorial)
        {
            DoNuclearTutorial();
        }
        if (NuclearCount == NuclearCost)
        {
            SoundManager.Solar.Play();
        }
        else
        {
            SoundManager.Nuclear.Play();
        }
    }

    public void BuildBins()
    {
        if (lastType != 0)
        {
            CarbonCount -= TypeBonus;
        }
        CompostCount -= CompostCost;
        CarbonCount -= BinValue;
        lastType = 0;

        Instantiate(BinPrefab, Track.segments[Track.segments.Count / 2].transform);
    }

    private void BuildTurbines()
    {
        if (lastType != 1)
        {
            CarbonCount -= TypeBonus;
        }
        MetalCount -= MetalCost;
        CarbonCount -= TurbineValue;
        lastType = 1;

        Instantiate(TurbinePrefab, Track.segments[Track.segments.Count / 2].transform);
    }

    private void BuildSolar()
    {
        if (lastType != 2)
        {
            CarbonCount -= TypeBonus;
        }
        NuclearCount -= NuclearCost;
        CarbonCount -= SolarValue;
        lastType = 2;
        if (divider < 10)
        {
            divider += 1;
        }

        Instantiate(SolarPrefab, Track.segments[Track.segments.Count / 2].transform);
    }

    private void Update()
    {
        if (toStart && !started)
        {
            Time.timeScale = .1f;
            started = true;
        }

        if (started)
        {
            CarbonIncrement = 1 + (MaxCarbonCount - CarbonCount) / divider;
            CarbonCount += CarbonIncrement * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (Time.timeScale == 0 && !compostTutorial)
            {
                Time.timeScale = 1;
                CompostMessage.gameObject.SetActive(false);
            }
            compostTutorial = true;
            if (CompostCount >= CompostCost)
            {
                BuildBins();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (Time.timeScale == 0 && !metalTutorial)
            {
                Time.timeScale = 1;
                MetalMessage.gameObject.SetActive(false);
            }
            metalTutorial = true;
            if (MetalCount >= MetalCost)
            {
                BuildTurbines();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (Time.timeScale == 0 && !nuclearTutorial)
            {
                Time.timeScale = 1;
                NuclearMessage.gameObject.SetActive(false);
            }
            nuclearTutorial = true;
            if (NuclearCount >= NuclearCost)
            {
                BuildSolar();
            }
        }

        if (CarbonCount > 500)
        {
            LoseGame();
        }
        if (CarbonCount < 350)
        {
            WinGame();
        }
    }

    private void FixedUpdate()
    {
        if (Time.timeScale < 1 && Time.timeScale != 0)
        {
            Time.timeScale += .01f;
        }
    }

    private void WinGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    private void LoseGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}

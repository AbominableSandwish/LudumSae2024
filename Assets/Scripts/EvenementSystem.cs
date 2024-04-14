using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class EventTrigger
{
    int every5Sec;
    int maxEvents;
    int graceTimer;


}
public enum EventList : int
{
    EventSwat = 0,
    EventPolice = 1,
    EventFireFighter = 2,
    Count = 3
}

public enum EventState
{
    EventConfining = 0,
    EventBreach = 1
}

public class Evenement
{
    public bool eventIsAlive = true;
    public EventList eventType = 0;
    public EventState eventState = EventState.EventBreach;


    public float eventMaxTime = 100.0f;
    private float timer = 0.0f;

    public float numberOfUnitNeeded = 2.0f;
    public float unitOnSite = 0.0f;

    public Evenement(EventList theirEventType)
    {
        eventType = theirEventType;
        if (theirEventType == EventList.EventSwat)
        {
            eventMaxTime = 5.0f;
        }
        if (theirEventType == EventList.EventPolice)
        {
            eventMaxTime = 5.0f;
        }
        if (theirEventType == EventList.EventFireFighter)
        {
            eventMaxTime = 30.0f;
        }
    }

    public void EvenementUpdate()
    {
        if (eventIsAlive == false)
        {
            return;
        }
        //Check if this room is being resolved or not
        if (unitOnSite >= numberOfUnitNeeded)
        {
            eventState = EventState.EventConfining;
        }
        else
        {
            eventState = EventState.EventBreach;
        }

        //Increments or decrements the timer
        if (eventState == EventState.EventBreach)
        {
            timer += Time.deltaTime;
        }
        if (eventState == EventState.EventConfining)
        {
            timer -= Time.deltaTime;
        }

        //Check if event got resolved or breached containment
        if (timer < 0 || timer > eventMaxTime)
        {
            eventIsAlive = false;
        }
    }


    public bool IsAlive() { return eventIsAlive; }
    public EventState GetEventState() { return eventState; }
    public float GetEventMaxTime() { return eventMaxTime; }
    public float GetEventActualTimer() { return timer; }

}

public class EvenementSystem : MonoBehaviour
{

    private SoundManager _soundManager;

    private bool _isFinish = false;
    public void SetIsFinish(bool isFinish)
    {
        this._isFinish = isFinish;
    }

    [SerializeField] AnimationCurve difficultyCurve;
    private float gameTimer = 0.0f;
    private GameManager _gameManager;

    [SerializeField] private RequestSystem _requestSystem;
    [SerializeField] List<float> _timersList;
    [SerializeField] private int maxEvenements = 4;
    private int totalEvents = 0;

    [SerializeField] private float tickTime = 0.0f;
    private float tickTimer = 0.0f;

    Evenement _eventType1 = new Evenement(EventList.EventFireFighter);

    [SerializeField] float baseTimerCooldown = 0.0f;

    // Sera divis� par 100 et extrait � base timer, 100/100 = 1s, 100/50 = 2, 100/10 = 10 (Basetimer - curve value / curve intensity)
    [SerializeField] float curveIntensity = 0.0f;

    public void AddNewTimer()
    {
        _timersList.Add(baseTimerCooldown*Random.Range(0.5f,3.5f));
        if(_timersList.Count % 5  == 0)
        {
            maxEvenements++;
        }
    }

    private void Start()
    {
        if(GameObject.Find("GameManager"))
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(GameObject.Find("SoundManager"))
            _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        if (GameObject.Find("RequestSystem"))
            _requestSystem = GameObject.Find("RequestSystem").GetComponent<RequestSystem>();
    }

    void Update()
    {
        if (_gameManager)
        {
            if (!_isFinish)
            {
                gameTimer += Time.deltaTime;
                tickTimer += Time.deltaTime;
                //Activate every tick
                if (tickTimer > tickTime)
                {
                    float curveValue = difficultyCurve.Evaluate(gameTimer);

                    //Debug.Log(curveValue);
                    //If max events in game, do nothing
                    for (int i = 0; i < _timersList.Count; i++)
                    {
                        _timersList[i] -= tickTimer;
                        if (_timersList[i] <= 0)
                        {
                            //New Request
                            _requestSystem.NewRequest();

                            //new Timer
                            float newTimer = baseTimerCooldown - curveValue / curveIntensity;
                             if(newTimer > 0)
                            {
                                _timersList[i] = newTimer;
                            }
                            else
                            {

                            }
                        }
                    }
                    tickTimer = 0.0f;
                }
            }
        }
    }

    void addEvents(int room)
    {
        EventList eventType = EventList.Count;
        switch (UnityEngine.Random.Range(0, (int)EventList.Count))
        {

        }
        AddEventTypetoRoom(room, new Evenement(eventType));
    }

    void AddEventTypetoRoom(int room, Evenement evenement)
    {
       // _requestsystem.SetEvenenement(room, evenement);
        if(_soundManager)
            _soundManager.PlaySound(SoundManager.Sound.Alert);
    }
}

using UnityEngine.UI;
using UnityEngine;

public enum GameStatus
{
    menu, play, gameover
}

public class GameManager : MonoBehaviour {

    private GameStatus currentState = GameStatus.menu;
    public GameStatus CurrentState{ get {return currentState;}}

    private bool canDo = false;
    public bool CanDo
    {
        get { return canDo;}
        set {canDo = value;}
    }
    [SerializeField] private Text ScoreText;
    private int score = 0;
    public int Score
    {
        get { return score; }
        set { score = value;}
    }
    [SerializeField] private Image Menu;
    [SerializeField] private Image PauseMenu;
    [SerializeField] private Image GameOverMenu;
    [SerializeField] private Text PlayersScore_pause;
    [SerializeField] private Text PlayersScore_dead;
    [SerializeField] private Button PauseBtn;
    [SerializeField]
    private GameObject whereBaosGrow;
    [SerializeField]
    private GameObject whereStarsShine;

    private Vector3 menuPos;
    private Vector3 pauseMenuPos;

    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }
    // Use this for initialization
    void Start ()
    {
        menuPos = Menu.transform.position;
        pauseMenuPos = PauseMenu.transform.position;
        PauseMenu.transform.position = menuPos + new Vector3(0, -2000, 0);
    }


    public void Pause()
    {
        if (currentState == GameStatus.play)
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                PauseMenu.transform.position = menuPos + new Vector3(0, -2000, 0);//correct moving by animation
                PauseBtn.GetComponent<Text>().text = "Pause";
                PauseBtn.enabled = true;
            }
            else
            {
                Time.timeScale = 0;
                PauseMenu.transform.position = pauseMenuPos;
                PlayersScore_pause.text = "Your score: \n" + score;
                PauseBtn.GetComponent<Text>().text = "";
                PauseBtn.enabled = false;
            }
        }                          

    }

    public void NewGame()
    {
        Refresh();
        Menu.transform.position = menuPos + new Vector3(0,2000,0); //correct moving by animation
        PauseMenu.transform.position = menuPos + new Vector3(0, -2000, 0);
        GameOverMenu.transform.position = menuPos + new Vector3(0, -2000, 0);
        currentState = GameStatus.play;
        whereBaosGrow.GetComponent<RandomDot>().Begin(); 
        whereStarsShine.GetComponent<RandomDot>().Begin();
    }

    public void GoToMenu()
    {
        Refresh();
        Menu.transform.position = menuPos;
        currentState = GameStatus.menu;
        PauseMenu.transform.position = menuPos + new Vector3(0, -2000, 0);
        GameOverMenu.transform.position = menuPos + new Vector3(0, -2000, 0);
    }


    public void GameOver()
    {
        currentState = GameStatus.gameover;
        GameOverMenu.transform.position = menuPos;
        PlayersScore_dead.text = "Your score: \n" + score;
        whereBaosGrow.GetComponent<RandomDot>().Stop();
        whereStarsShine.GetComponent<RandomDot>().Stop();
    }

    public void Exit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update () {

        //   fastering speed of spawning
        if (counter > maxA && waitingTime > decrease)
        {
            waitingTime -= decrease;
            maxA *= 2;
        }
        
        //   displaying score
        if (currentState == GameStatus.play)
        {ScoreText.text = "Score: " + score;
            PauseBtn.enabled = true;
            PauseBtn.GetComponent<Text>().text = "Pause";
            CameraMove.instance.Far();
        }
        else
        { ScoreText.text = "";
            PauseBtn.enabled = false;
            PauseBtn.GetComponent<Text>().text = "";
            CameraMove.instance.Near();
        }

        if (Input.GetKeyDown("p"))
        {
            Pause();
        }
	}

    public void RegisterBaobab()
    {
        counter++;
    }

    private void Refresh()
    {
        whereBaosGrow.GetComponent<RandomDot>().Stop();
        whereStarsShine.GetComponent<RandomDot>().Stop();
        Thing[] baos = FindObjectsOfType(typeof(Thing)) as Thing[];
        foreach (Thing enemy in baos)
        {
            Destroy(enemy.gameObject);
        }
        counter = 0;
        maxA = 2;
        score = 0;
        waitingTime = 4.3f;
        Time.timeScale = 1;
    }
    //number of baobabs at all
    private int counter = 0;
    //how many baos can appear with current waiting time
    private int maxA = 2;
    //how hard waiting time decreases;
    private float decrease = 0.5f;

    private float waitingTime = 4.3f;
    public float WaitingTime
    {
        get { return waitingTime; }
        set { waitingTime = value; }
    }
}

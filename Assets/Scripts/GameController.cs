using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum GameState {
    None,
    Playing,
    End
}
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    private float timeBtwSpawn;
    [SerializeField] private float startTimeBtwSpawn;
    [SerializeField] GameObject pipeSpawner;
    [SerializeField] Pipe pipePrefab;
    [SerializeField] Score score;
    [SerializeField] Score highestScore;
    [SerializeField] GameObject endGamePopUp;
    private List<Pipe> pipes;

    private GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Playing;
        pipes = new List<Pipe>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == GameState.End) {
            // stop all pipes
            for (int i = 0; i < pipes.Count; ++i)
                pipes[i].stopPipe();
            
            // reset point
            PlayerController.resetPoint();

            endGamePopUp.SetActive(true);
            int highestPoint = PlayerController.getHighestPoint();
            highestScore.setHighestPoint(highestPoint);
        } else if (gameState == GameState.Playing) {
            // player controller
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButtonDown(0)) 
                playerController.Jumping();
            else
                playerController.setIsClicked(false);

            // spawning pipe
            if (timeBtwSpawn <= 0) {
                Pipe newPipe = spawnPipe();
                pipes.Add(newPipe);
                timeBtwSpawn = startTimeBtwSpawn;
            } else {
                timeBtwSpawn -= Time.deltaTime;
            }

            // handle point
            int point = PlayerController.getPoint();
            score.setPoint(point);
        }
    }

    // spawn pipes
    private Pipe spawnPipe() {
        float y = Random.Range(0.05f, 4.67f);
        Pipe newPipe = Instantiate(pipePrefab, new Vector3(pipeSpawner.transform.position.x, y, pipeSpawner.transform.position.z), transform.rotation);
        newPipe.movingPipe();
        return newPipe;
    }

    // game state
    public void setGameState(GameState state) {
        gameState = state;
    }

    public GameState GetGameState() {
        return gameState;
    }
}

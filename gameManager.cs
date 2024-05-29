using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public BallController ballController;
    public TextMeshProUGUI strokeCountText;
    public Scene scene;
    public Canvas GameCanvas;
    public Canvas startingScreenCanvas;
    public Canvas gameOverCanvas;
    public TextMeshProUGUI finalScoreText;
    public Transform holeTransform;
    public Transform playerTransform; // Reference to your player's transform
    public GameObject spawnPos;
    public GameObject Ball;

    private int strokeCount = 0;
    private bool isGameActive = true;
// hiding the canvas not allowing the player to move and seting the scene
    void Start()
    {
        HideGameOverCanvas();
        ballController.enabled = false;
        scene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        // if you press "r" at any time call the resetGame function in the gameManager and reset the game scene.
         if(Input.GetKey(KeyCode.R))
         {
            ResetGame();
         }
    }
// Counting each stroke.
    public void IncrementStrokeCount()
    {
        strokeCount++;
        UpdateStrokeCountText();
    }
// Ending the game.
    public void EndGame()
    {
        isGameActive = false;
        ShowGameOverCanvas();
        UpdateFinalScoreText();
        Ball.gameObject.SetActive(false);
        strokeCountText.gameObject.SetActive(false);
        
    }

// restarting the game back to its original state.
    public void RestartGame()
{
    startingScreenCanvas.gameObject.SetActive(false);
    strokeCountText.gameObject.SetActive(true);
    strokeCountText.enabled = true;

    // Reset any other game-specific state
    ballController.ResetBall(); // Call the method to reset the ball in BallController.

    strokeCount = 0;
    UpdateStrokeCountText();
    HideGameOverCanvas();
    isGameActive = true;
    ballController.enabled = true;

    Ball.SetActive(true); // Corrected line: use Ball.SetActive(true) to enable the GameObject.
}
// reload the game scence to reset the game.
    public void ResetGame()
    {
        
        SceneManager.LoadScene(scene.name);
    }
    // Updating the stroke count text everytime there is a new stroke.
    private void UpdateStrokeCountText()
    {
        if (strokeCountText != null)
        {
            strokeCountText.text = "Strokes: " + strokeCount.ToString();
        }
    }
    // When the game is over show the game over Screen
    private void ShowGameOverCanvas()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.gameObject.SetActive(true);
        }
    }
    // Hide the game over screen when the game is active 
    private void HideGameOverCanvas()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.gameObject.SetActive(false);
        }
    }
    // Updating the final stroke text to display all your strokes 
    private void UpdateFinalScoreText()
    {
        if (finalScoreText != null)
        {
            finalScoreText.text = "It took you " + strokeCount.ToString() + " strokes to win";
        }
    }
}
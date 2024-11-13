using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Tracks the current player's turn (1 = Player 1, 2 = Player 2)
    private int _currentPlayer = 1;

    // Prefabs for player 1 and player 2 coins
    public GameObject player1;
    public GameObject player2;

    // Starting position for coins before they drop
    public Transform startPoint;

    // Controls whether a turn is active, preventing simultaneous actions
    [SerializeField]
    private bool _activeTurn = true;

    private void Awake()
    {
        // Ensure only one instance of GameManager exists (singleton pattern)
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Called when a column is pressed.
    /// Checks for a valid move and initiates the coin drop if possible.
    /// </summary>
    /// <param name="column">The column index that was pressed.</param>
    public void ColumnPressed(int column)
    {
        if (!_activeTurn)
        {
            Debug.Log("Please wait for the current turn to finish.");
            return;
        }

        // Check for the first valid row in the selected column
        int row = PlayField.Instance.ValidMove(column);
        if (row != -1)
        {
            // Start the coin drop animation and process the move
            StartCoroutine(PlayCoin(row, column));
        }
    }

    /// <summary>
    /// Coroutine to handle the animation and placement of the coin.
    /// </summary>
    /// <param name="row">The row index where the coin should land.</param>
    /// <param name="column">The column index where the coin should land.</param>
    private IEnumerator PlayCoin(int row, int column)
    {
        // Lock the turn to prevent other inputs during the animation
        _activeTurn = false;

        // Instantiate the appropriate coin prefab for the current player
        GameObject coin = Instantiate((_currentPlayer == 1 ? player1 : player2));

        // Set the coin's initial position above the board
        coin.transform.position = new Vector3(startPoint.position.x + column, startPoint.position.y + 1, startPoint.position.z);

        // Calculate the target position for the coin
        Vector3 goalPos = new Vector3(startPoint.position.x + column, startPoint.position.y - row, startPoint.position.z);

        // Smoothly move the coin to its target position
        while (MoveToGoal(goalPos, coin))
        {
            yield return null; // Wait until the next frame
        }

        // Update the board state to reflect the player's move
        PlayField.Instance.DropCoin(row, column, _currentPlayer);
        
        // Unlock the turn for the next player
        _activeTurn = true;
        
        //switch the player 
        SwitchPlayer();
    }

    /// <summary>
    /// Moves the coin toward its target position using frame-independent movement.
    /// </summary>
    /// <param name="goalPos">The target position of the coin.</param>
    /// <param name="coin">The coin GameObject being moved.</param>
    /// <returns>Returns true if the coin has not yet reached its destination.</returns>
    private bool MoveToGoal(Vector3 goalPos, GameObject coin)
    {
        // Smoothly move the coin toward the goal position
        coin.transform.position = Vector3.MoveTowards(coin.transform.position, goalPos, 5f * Time.deltaTime);

        // Return whether the coin has reached its destination
        return goalPos != coin.transform.position;
    }

    void SwitchPlayer()
    {
        _currentPlayer = (_currentPlayer == 1) ? 2 : 1;
    }
}

using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject playerPrefab;
    
    private Player player;
    private PlayerMovement playerMovment;
    private PlayerShooting playerShooting;

    public void Start()
    {
        GameObject playerObject = GameObject.Instantiate(playerPrefab);
        player = playerObject.GetComponent<Player>();
        playerMovment = playerObject.GetComponent<PlayerMovement>();
        playerShooting = playerObject.GetComponent<PlayerShooting>();
    }
    void Update()
    {
        player.FrameUpdate();
        playerMovment.FrameUpdate();
        playerShooting.FrameUpdate();
    }
}

using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerSpriteController : MonoBehaviour
    {
        [SerializeField] Sprite potatoSprite;
        [SerializeField] Sprite onionSprite;
        [SerializeField] Sprite pumpkinSprite;

        public void SetPlayerSprite(ClassesEnum playerClass)
        {
            SpriteRenderer spriteRenderer = this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
            if(playerClass == ClassesEnum.Potato) spriteRenderer.sprite = potatoSprite;
            if(playerClass == ClassesEnum.Onion) spriteRenderer.sprite = onionSprite;
            if(playerClass == ClassesEnum.Pumpkin) spriteRenderer.sprite = pumpkinSprite;
        }
    }
}
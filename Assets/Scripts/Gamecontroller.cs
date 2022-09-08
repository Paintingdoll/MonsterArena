using System;

using TMPro;

using UnityEngine;
using UnityEngine.InputSystem;

public class Gamecontroller : MonoBehaviour
{
  [SerializeField] private Monster monsterA;
  [SerializeField] private Monster monsterB;

  [SerializeField] private MonsterUI monsterAUI;
  [SerializeField] private MonsterUI monsterBUI;

  [SerializeField] private TextMeshProUGUI commentaryText;

  private GameInput input;

  private void Awake()
  {
      input = new GameInput();
      input.Player.Next.performed += PerformNextAction;
  }

  private void OnEnable()
  {
      input.Enable();
  }

  private void Start()
  {
      RegisterNewMonster(monsterA, monsterAUI);
      RegisterNewMonster(monsterB, monsterBUI);
      
      commentaryText.SetText($"{monsterA.GetTitle()} begegnet {monsterB.GetTitle()}!"); 
  }

  private void OnDisable()
  {
      input.Disable();
  }

  private void OnDestroy()
  {
      input.Player.Next.performed -= PerformNextAction;
  }

  private void PerformNextAction(InputAction.CallbackContext context)
  {
      Debug.Log("Enter key pressed!");
      commentaryText.SetText("Nächste Aktion!");
      // ToDo implement fighting
  }

  private void RegisterNewMonster(Monster monster, MonsterUI monsterUI)
  {
      UpdateTitle(monster, monsterUI);
      UpdateHealth(monster, monsterUI);
  }

  private void UpdateTitle(Monster monster, MonsterUI monsterUI)
  {
      monsterUI.UpdateTitle(monster.GetTitle());
  }

  private void UpdateHealth(Monster monster, MonsterUI monsterUI)
  {
      monsterUI.UpdateHealth(monster.GetCurrentHealth(), monster.GetMaxHealth());
  }
}

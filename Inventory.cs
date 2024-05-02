using UnityEngine;
using System.Collections;

public class InventoryLoot : MonoBehaviour {

  const int LOOT_WIN_ID = 2; //идентефикатор окна
  const float OFFSET = 10;

  public static LootController _Chest;
  public static InventoryLoot _Loot;

  public float ButtonSize = 40; //размер ячейки
  public float CloseWindowAize = 20; //размер кнопки закрытия

  public bool displayLootWindow = false; //видно ли окно
  int lootRows = 2; //количество колонок
  int lootColumns = 6; //количество столбцов
  Rect lootRect = new Rect(10, 10,
  280, 140); //область окна

  void Start()
  {
  _Loot = this;
  }

  void OnGUI()
  {
  if (displayLootWindow)
  {
  //создание окна лута в сундуке  
  lootRect = GUI.Window(LOOT_WIN_ID, lootRect, lootChest, "Сундук");
  }
  }

  void lootChest(int id)
  {

  //если в сундук не занесено значение выходим из метода
   
  //кнопка закрытия инвентаря
  if (GUI.Button(new Rect(lootRect.width - 20, 0, CloseWindowAize, CloseWindowAize), "x"))
  {
  //запускаем метод очищающий значения ячеек в сундуке
  clearLoot();
  }
  int pnt = 0;
  for (int y = 0; y < lootRows; y++)
  {
  for (int x = 0; x < lootColumns; x++)
  {
  if (pnt < _Chest.LootItem.Count)
  {
  //по нажатию мышки предмет перемещается в инвентарь
  if (GUI.Button(new Rect((10 + (x * ButtonSize)) * 1.09f, 10 + (y * ButtonSize) * 1.09f, ButtonSize, ButtonSize), new GUIContent(
  _Chest.LootItem[pnt].Textura)))
  {
  if (Inventory.InventoryPlayer.Count < 24)//24 это кол-во ячеек в инвентаре
  {
  for (int i = 0; i < 24; i++)
  {
  if (!Inventory.InventoryPlayer.ContainsKey(i))
  {
  Inventory.InventoryPlayer.Add(i, _Chest.LootItem[pnt]);
  _Chest.LootItem.RemoveAt(pnt);
  break;
  }
  }
  }
  else
  {
  }
  }
  }
  else
  {
  GUI.Label(new Rect((10 + (x * ButtonSize)) * 1.09f,10 + (y * ButtonSize) * 1.09f, ButtonSize, ButtonSize), (x + y * lootColumns).ToString(), "box");
  }
  pnt++;
  }
  }
  GUI.DragWindow();
  }

  /// метод отвечающий за видимость инвенторя в сундуке
  public void displayLoot()
  {
  displayLootWindow = true;
  }

  /// Очищаем наш список от предметов
  void clearLoot()
  {
  displayLootWindow = false;
  _Chest.OnMouseDown();
  }

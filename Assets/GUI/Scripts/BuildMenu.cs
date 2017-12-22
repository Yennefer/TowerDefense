using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EventsSystem;
using Settings;

public class BuildMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject menuButtons;

    [SerializeField]
    private Button buttonPrefab;

    private int money;
    private string builderId = string.Empty;
    private List<TurretButton> turretButtons = new List<TurretButton>();

    private void Awake()
    {
        if (!menuButtons || !buttonPrefab) {
			Debug.LogError("You've forgotten to set a parameters to BuildMenu script");
		}
    }

    public void UpdateMoney(int money) {
        this.money = money;
        UpdateButtons();
    }

    public void SelectPrefub(TurretsBuilder builder)
    {
        builderId = builder.id;
        if (builder.turrets.Count > 0) {
            InitMenu(builder.turrets);
        }
    }

    private void InitMenu(List<PrefabInfo> turretsPrefabs)
    {
        ClearMenu();
        for (int i = 0; i < turretsPrefabs.Count; i++) {
            Button button = Instantiate(buttonPrefab);
            PrefabInfo turretInfo = turretsPrefabs[i];
            TurretButton turretButton = button.GetComponent<TurretButton>();
            turretButton.Init(turretInfo);
            turretButton.SetMoney(money);
            turretButtons.Add(turretButton);

            button.transform.SetParent(transform);
            button.transform.localScale = new Vector3(1, 1, 1);
            button.transform.position = new Vector3(Screen.width / 2, Screen.height / 2 - i * 50, 0);
            button.onClick.AddListener(() => SelectClick(turretButton));
        }
    }

    private void UpdateButtons() {
        foreach (TurretButton turretButton in turretButtons) {
            turretButton.SetMoney(money);
        }
    }

    private void ClearMenu()
    {
        foreach (Transform button in menuButtons.transform) {
            Destroy(button.gameObject);
        }
    }

    private void SelectClick(TurretButton turretButton) {
        EventObject eo = new EventObject();
        eo.putData(EventDataTags.TURRET_TO_BUILD, turretButton.turretPrefab);
        EventManager.TriggerEvent(Events.buildPrefub.ToString() + builderId, eo);
        Close(turretButton.turretPrice);
    }

    public void Close(int turretPrice) {
        EventObject eo = new EventObject();
        eo.putData(EventDataTags.BUILDER_ID, builderId);
        eo.putData(EventDataTags.TURRET_PRICE, turretPrice);
        EventManager.TriggerEvent(Events.closeBuildMenu.ToString() + builderId, eo);
    }

    public void Close() {
        Close(0);
    }
}
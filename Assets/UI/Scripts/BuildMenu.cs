using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BuildMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject menuButtons;

    [SerializeField]
    private Button buttonPrefab;

    private string builderId = string.Empty;

    public void Awake()
    {
        if (!menuButtons || !buttonPrefab) {
			Debug.LogError("You've forgotten to set a parameters to BuildMenu script");
		}
    }

    public void OnEnable()
    {
        EventManager.RegisterListener(Events.selectPrefub.ToString(), SelectPrefub);
    }

    public void OnDisable()
    {
        EventManager.UnregisterListener(Events.selectPrefub.ToString(), SelectPrefub);
    }

    private void SelectPrefub(EventObject eo)
    {
        TurretsBuilder builder = (TurretsBuilder) eo.getObjectData(EventDataTags.TURRET_BUILDER);
        builderId = builder.GetId();
        List<GameObject> prefabs = builder.GetTurretPrefabs();
        if (prefabs.Count > 0) {
            InitMenu(prefabs);
        }
    }

    private void InitMenu(List<GameObject> prefabs)
    {
        ClearMenu();
        for (int i = 0; i < prefabs.Count; i++)
        {
            GameObject prefab = prefabs[i];
            Button button = Instantiate(buttonPrefab);
            button.transform.SetParent(menuButtons.transform, false);
            button.transform.localScale = new Vector3(1, 1, 1);
            button.transform.position = new Vector3(Screen.width / 2, Screen.height / 2 - i * 50, 0);
            button.GetComponentInChildren<Text>().text = prefab.name;
            button.onClick.AddListener(() => SelectClick(prefab));
        }
        menuButtons.gameObject.SetActive(true);
    }

    private void ClearMenu()
    {
        foreach (Transform button in menuButtons.transform)
        {
            Destroy(button.gameObject);
        }
    }

    public void SelectClick(GameObject prefab)
    {
        menuButtons.gameObject.SetActive(false);
        EventObject eo = new EventObject();
        eo.putData(EventDataTags.TURRET_TO_BUILD, prefab);
        EventManager.TriggerEvent(Events.buildPrefub.ToString() + builderId, eo);
    }
}
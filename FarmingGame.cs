using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingGame : MonoBehaviour
{

    float timer = 0f;

    List<string> inventory = new List<string>();

    Vector2 resolution = new Vector2(1920, 1080);

    bool audioEnabled = true;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 10f)
        {
            inventory.Add("crop");
            timer = 0f;
        }
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 30), "Plant"))
        {
            timer = 0f;
        }

        // Sell crops button
        if (GUI.Button(new Rect(10, 50, 100, 30), "Sell"))
        {
            int numCrops = inventory.RemoveAll(item => item == "crop");
            Debug.Log($"Sold {numCrops} crops");
        }

        // Inventory button
        if (GUI.Button(new Rect(10, 90, 100, 30), "Inventory"))
        {
            string inventoryString = string.Join(", ", inventory.ToArray());
            Debug.Log($"Inventory: {inventoryString}");
        }

        if (GUI.Button(new Rect(10, 130, 100, 30), "Settings"))
        {
            ShowSettingsMenu();
        }
    }

    void ShowSettingsMenu()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 175));
        if (GUI.Button(new Rect(0, 0, 100, 30), "Exit"))
        {
            Application.Quit();
        }
        if (GUI.Button(new Rect(0, 40, 100, 30), "Resolution"))
        {
            resolution = ShowResolutionMenu();
        }
        if (GUI.Button(new Rect(0, 80, 100, 30), audioEnabled ? "Disable Audio" : "Enable Audio"))
        {
            audioEnabled = !audioEnabled;
        }
        GUI.EndGroup();
    }

    Vector2 ShowResolutionMenu()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 175));
        if (GUI.Button(new Rect(0, 0, 100, 30), "1920x1080"))
        {
            GUI.EndGroup();
            return new Vector2(1920, 1080);
        }
        if (GUI.Button(new Rect(0, 40, 100, 30), "1280x720"))
        {
            GUI.EndGroup();
            return new Vector2(1280, 720);
        }
        if (GUI.Button(new Rect(0, 80, 100, 30), "640x480"))
        {
            GUI.EndGroup();
            return new Vector2(640, 480);
        }
        GUI.EndGroup();
        return resolution;
    }
}

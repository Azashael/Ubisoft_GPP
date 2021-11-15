/**
 * Rochelle Charline
 * Novembre 2021
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    WaitForSecondsRealtime waitForSecondsRealtime;

    void OnEnable()
    {
        LocalizationSettings.SelectedLocaleChanged += SelectedLocaleChanged;

        if (waitForSecondsRealtime == null)
            waitForSecondsRealtime = new WaitForSecondsRealtime(.5f);

        if (!LocalizationSettings.InitializationOperation.IsDone)
            StartCoroutine(Preload(null));
    }

    void OnDisable()
    {
        LocalizationSettings.SelectedLocaleChanged -= SelectedLocaleChanged;
    }

    void SelectedLocaleChanged(Locale locale)
    {
        StartCoroutine(Preload(locale));
    }

    IEnumerator Preload(Locale locale)
    {
        var operation = LocalizationSettings.InitializationOperation;

        do
        {
            if (locale == null)
                locale = LocalizationSettings.SelectedLocaleAsync.Result;
            yield return null;
        }
        while (!operation.IsDone);

        if (operation.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Failed)
        {

        }
        else
        {
            waitForSecondsRealtime.Reset();
            yield return waitForSecondsRealtime;
            StartCoroutine(LoadAsyncScene());
        }
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        Destroy(this.gameObject);
    }
}

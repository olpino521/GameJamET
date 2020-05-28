using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Windows.Speech;

public class VoiceToEvents : MonoBehaviour
{
    [SerializeField]
    private KeywordEvent[] actions;

    private Dictionary<string, UnityEvent> keyword;

    //
    private KeywordRecognizer recognizer;

    private void Start()
    {
        PopulateDictionary();

        recognizer = new KeywordRecognizer(keyword.Keys.ToArray());
        recognizer.OnPhraseRecognized += (args) =>
        {
            Debug.Log($"[{args.text}]\nConfidence: [{args.confidence}]\nTime taken: [{DateTime.Now - args.phraseStartTime}");
            keyword[args.text]?.Invoke();
        };
        recognizer.Start();
    }

    private void PopulateDictionary()
    {
        keyword = new Dictionary<string, UnityEvent>();

        foreach (var item in actions)
        {
            keyword[item.keyword] = item.Action;
        }
    }
}

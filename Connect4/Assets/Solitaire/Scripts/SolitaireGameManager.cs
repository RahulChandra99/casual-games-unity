using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolitaireGameManager : MonoBehaviour
{
    public static string[] suits = new string[] { "C", "D", "H", "S" };
    public static string[] values = new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

    public List<string> deck;

    private void Start()
    {
        PlayCards();
    }

    public void PlayCards()
    {
        deck = GenerateDeck();

        foreach (string card in deck)
        {
            print(card);
        }
    }
    
    public static List<string> GenerateDeck()
    {
        List<string> newDeck = new List<string>();
        foreach (string s in suits)
        {
            foreach (string v in values)
            {
                newDeck.Add(s + v);
            }
        }

        return newDeck;
    }

    void Shuffle<T>(List<T> list)
    {
        
    }
}

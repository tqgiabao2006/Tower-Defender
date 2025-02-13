using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class CoinUI : MonoBehaviour
{
    TextMeshProUGUI _text;
    GameManager _gameM;

    void Start()
    {
        _text = this.GetComponent<TextMeshProUGUI>();
        _gameM = GameManager.Instant;
        
    }

    void Update()
    {
        _text.text = _gameM._currentCoins.ToString();
    }
}

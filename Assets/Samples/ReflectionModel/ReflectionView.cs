using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

/// <summary>
/// モデルにアタッチ
/// </summary>
public class ReflectionView : MonoBehaviour {
    [SerializeField]
    private Material _material = null;
    [SerializeField]
    private Text _text;

    [SerializeField]
    private ReflectionModel _model;

	// Use this for initialization
	void Start () {
        _model.Shader
            .Subscribe(shader => 
            {
                _material.shader = shader;
            });
    }
}

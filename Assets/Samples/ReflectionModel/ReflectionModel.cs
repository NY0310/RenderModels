using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ReflectionModel : MonoBehaviour {

    [SerializeField]
    private List<Shader> _shaders = new List<Shader>();

    private ReactiveProperty<Shader> _shader = new ReactiveProperty<Shader>();
    public IReadOnlyReactiveProperty<Shader> Shader
    {
        get { return _shader; }
    }

    [SerializeField]
    private LoadText _loatText;

    private ReactiveProperty<string> _textString = new ReactiveProperty<string>();
    public IReadOnlyReactiveProperty<string> TextString
    {
        get { return _textString; }
    }
    private int _index;

    public void Start()
    {
        _loatText = new LoadText();
        _loatText.Initialize();
        SetShader();
    }

    public void ShiftRightShader()
    {
        _index++;
        SetShader();
    }

    public void ShiftLeftShader()
    {
        _index--;
        SetShader();
    }

    public void SetShader()
    {
        int element = (int)Mathf.Repeat(_index, _shaders.Count);
        _shader.Value = _shaders[element];
        //_textString.Value = _loatText.textWords[element, 0] + "/" + _loatText.textWords[element, 1];
    }
}

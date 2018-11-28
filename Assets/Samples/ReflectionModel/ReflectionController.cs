using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class ReflectionController : MonoBehaviour {

    [SerializeField]
    private ReflectionModel _model;

	// Use this for initialization
	void Start () {

        //左キーを押されたとき
        this.UpdateAsObservable()
            .Where(_=> Input.GetKey(KeyCode.LeftArrow))
            .Subscribe(_ =>
            {
                _model.ShiftLeftShader();
            });

        //右キーを押されたとき
        this.UpdateAsObservable()
         .Where(_ => Input.GetKey(KeyCode.RightArrow))
         .Subscribe(_ =>
         {
             _model.ShiftRightShader();
         });
    }
}

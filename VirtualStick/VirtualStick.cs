
//using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

namespace VirtualStick
{

    public interface IVirtualnput
    {
        Vector2 StickMovement { get; }
    }

    

    #region 参考リンク
    // UnityEngine.UI.Button のスクリプトリファレンス
    // https://docs.unity3d.com/ja/540/ScriptReference/UI.Button.html
    //
    // UnityEngine.UI.Selectable のスクリプトリファレンス
    // https://docs.unity3d.com/ja/540/ScriptReference/UI.Selectable.html
    #endregion


    /// <summary>
    /// UnityEngine.UI.Button の継承/実装 を真似て作った自作 UI。エディタ上でパネルなどを作ってそれに取り付ける
    /// </summary>
    public class VirtualStick :  Selectable, IBeginDragHandler, IDragHandler, IEndDragHandler, IVirtualnput
    {
        private VirtualStickCalculator calculator;
        public Vector2 StickMovement { get; private set; }

        
       public VirtualStick()
        {
            calculator = new VirtualStickCalculator();
        }


        /// <summary>
        /// UnityEngine.EventSystems.IBeginDragHandler によって実装されたイベント関数。
        /// レイキャストがこのUIに当たり、ドラッグが開始されたときに呼ばれる。
        /// </summary>
        /// <param name="eventData"></param>
        public void OnBeginDrag(PointerEventData eventData)
        {
            calculator.WhenTouchBegin();
        }


        /// <summary>
        /// UnityEngine.EventSystems.IDragHandler によって実装されたイベント関数。
        /// ドラッグ中に呼ばれる。
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
           StickMovement = calculator.WhileTouching();
            Debug.Log(this.name + " : " + StickMovement);
        }


        /// <summary>
        /// UnityEngine.EventSystems.IEndDragHandler によって実装されたイベント関数。
        /// ドラッグ終了時に呼ばれる。
        /// </summary>
        /// <param name="eventData"></param>
        public void OnEndDrag(PointerEventData eventData)
        {
            StickMovement = Vector2.zero;
            calculator.WhenTouchEnd();
        }
    }
}
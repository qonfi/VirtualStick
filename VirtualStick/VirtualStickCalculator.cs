
//using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace VirtualStick
{
    public class VirtualStickCalculator
    {
        private Vector2 dragStartPosition;


        public VirtualStickCalculator()
        {
            dragStartPosition = Vector2.zero;
        }


        public void WhenTouchBegin()
        {
            // タッチ開始座標を記録 (指が離れるまで保持。離れたら破棄する)
            this.dragStartPosition = CalcMousePosition();
        }


        public Vector2 WhileTouching()
        {
            // スティックの移動量
            Vector2 currentMousePosition = CalcMousePosition();
            return  currentMousePosition - dragStartPosition;
        }


        public void WhenTouchEnd()
        {
            // タッチ開始座標を破棄
            // スティックの移動量を初期化
            dragStartPosition = Vector2.zero;
        }


        /// <summary>
        /// マウスが要素内のどこをクリックしているか取得したいメソッド。暫定。
        /// </summary>
        /// <returns></returns>
        private Vector2 CalcMousePosition()
        {
            Vector2 vec = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            return vec;
        }
    }
}
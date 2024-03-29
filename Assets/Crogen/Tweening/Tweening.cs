﻿using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using Crogen.Tweening;
using UnityEngine.UI;

namespace Crogen.Tweening
{
    public class  Tweening : MonoSingleton<Tweening>
    {
        #region Move
            public void DOMove(Transform transform, Vector3 endPoint, float duration, EasingType easing, IEnumerator lateCoroutine = null)
            {
                StartCoroutine(Move(transform, endPoint, duration, easing, lateCoroutine));
            }
            public void DOMove(RectTransform rectTransform, Vector3 endPoint, float duration, EasingType easing, IEnumerator lateCoroutine = null, Action lateAction = null)
            {
                StartCoroutine(Move(rectTransform, endPoint, duration, easing, lateCoroutine, lateAction));
            }
            public void DOMove(Rigidbody rigidbody, Vector3 endPoint, float duration, EasingType easing, IEnumerator lateCoroutine)
            {
                StartCoroutine(Move(rigidbody, endPoint, duration, easing, lateCoroutine));
            }
            
            private IEnumerator Move(Transform transform, Vector3 endPoint, float duration, EasingType easing, IEnumerator lateCoroutine = null)
            {
                float currentTime = 0;
                float percentTime = 0;
                
                Vector3 startPoint = transform.position;
                
                while (currentTime < duration)
                {
                    currentTime += Time.deltaTime;
                    percentTime = currentTime / duration;
                    transform.localPosition = Vector3.Lerp(startPoint, endPoint, new EaseTweeningCollection().SetEase(easing, percentTime));
                    yield return null;
                }
                transform.localPosition = endPoint;
                yield return new WaitForSeconds(duration);

                if (lateCoroutine != null)
                {
                    yield return StartCoroutine(lateCoroutine);
                }
            }
            private IEnumerator Move(RectTransform rectTransform, Vector3 endPoint, float duration, EasingType easing, IEnumerator lateCoroutine = null, Action lateAction = null)
            {
                float currentTime = 0;
                float percentTime = 0;
                
                Vector3 startPoint = rectTransform.anchoredPosition;
                
                while (currentTime < duration)
                {
                    currentTime += Time.deltaTime;
                    percentTime = currentTime / duration;
                    rectTransform.anchoredPosition = Vector2.Lerp(startPoint, endPoint, new EaseTweeningCollection().SetEase(easing, percentTime));
                    yield return null;
                }
                rectTransform.anchoredPosition = endPoint;
                yield return new WaitForSeconds(duration);
                lateAction?.Invoke();

                if (lateCoroutine != null)
                {
                    yield return StartCoroutine(lateCoroutine);
                }
            }

            private IEnumerator Move(Rigidbody rigidbody, Vector3 endPoint, float duration, EasingType easing, IEnumerator lateCoroutine = null)
            {
                float currentTime = 0;
                float percentTime = 0;
                
                Vector3 startPoint = rigidbody.position;
                
                while (currentTime < duration)
                {
                    currentTime += Time.deltaTime;
                    percentTime = currentTime / duration;
                    transform.localPosition = Vector3.Lerp(startPoint, endPoint, new EaseTweeningCollection().SetEase(easing, percentTime));
                    yield return null;
                }
                rigidbody.position = endPoint;
                yield return new WaitForSeconds(duration);
                if (lateCoroutine != null)
                {
                    yield return StartCoroutine(lateCoroutine);
                }
            }
        #endregion

        //for Renderers
        public IEnumerator DOColor(Renderer target, Color endPoint, float duration, EasingType easing)
        {
            float currentTime = 0;
            float percentTime = 0;
                
            Color startPoint = target.material.color;
                
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                percentTime = currentTime / duration;
                target.material.color = Color.Lerp(startPoint, endPoint, new EaseTweeningCollection().SetEase(easing, percentTime));
                yield return null;
            }        
            target.material.color = endPoint;
        }

        public void DOColor(Image image, Color endPoint, float duration, EasingType easing)
        {
            StartCoroutine(ChangeColor(image, endPoint, duration, easing));
        }
        
        private IEnumerator ChangeColor(Image image, Color endPoint, float duration, EasingType easing)
        {
            float currentTime = 0;
            float percentTime = 0;

            Color startColor = image.color;
            
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                percentTime = currentTime / duration;
                image.color = Color.Lerp(startColor, endPoint, new EaseTweeningCollection().SetEase(easing, percentTime));
                yield return null;
            }        
            image.color = endPoint;
        }
        
        public void DOColor(Image image, Color endPoint, float duration, IEnumerator lateCoroutine, EasingType easing)
        {
            StartCoroutine(ChangeColor(image, endPoint, duration, lateCoroutine, easing));
        }
        
        private IEnumerator ChangeColor(Image image, Color endPoint, float duration, IEnumerator lateCoroutine, EasingType easing)
        {
            float currentTime = 0;
            float percentTime = 0;

            Color startColor = image.color;
            
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                percentTime = currentTime / duration;
                image.color = Color.Lerp(startColor, endPoint, new EaseTweeningCollection().SetEase(easing, percentTime));
                yield return null;
            }        
            image.color = endPoint;

            yield return new WaitForSeconds(duration);
            yield return StartCoroutine(lateCoroutine);
        }
    }
}
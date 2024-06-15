using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageRotation : MonoBehaviour
{
    public Sprite[] images;
    public float rotationInterval = 2f;   // Dönme hýzý
    private Image imageComponent;
    private int currentIndex = 0;
    private Coroutine rotationCoroutine;
    private bool isRotating = true; // Dönme durumunu tutacak deðiþken

    private void Start()
    {
        imageComponent = GetComponent<Image>();
        if (images.Length > 0)
        {
            imageComponent.sprite = images[currentIndex];  // Resim dizisini oluþturma
            rotationCoroutine = StartCoroutine(RotateImages());
        }
        else
        {
            Debug.LogError("Resim dizisi boþ!");
        }
    }

    private IEnumerator RotateImages()
    {
        while (isRotating) // Dönme durumu kontrolü
        {
            yield return new WaitForSeconds(rotationInterval);
            currentIndex = (currentIndex + 1) % images.Length;
            imageComponent.sprite = images[currentIndex];
        }
    }

    public void ToggleRotation()
    {
        isRotating = !isRotating; // Dönme durumunu tersine çevir
        if (isRotating)
        {
            rotationCoroutine = StartCoroutine(RotateImages());
        }
        else
        {
            StopCoroutine(rotationCoroutine);
        }
    }

    private void OnDestroy()
    {
        if (rotationCoroutine != null)
        {
            StopCoroutine(rotationCoroutine);
        }
    }
}

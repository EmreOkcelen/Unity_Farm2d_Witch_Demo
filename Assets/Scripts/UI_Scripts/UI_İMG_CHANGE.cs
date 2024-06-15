using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageRotation : MonoBehaviour
{
    public Sprite[] images;
    public float rotationInterval = 2f;   // D�nme h�z�
    private Image imageComponent;
    private int currentIndex = 0;
    private Coroutine rotationCoroutine;
    private bool isRotating = true; // D�nme durumunu tutacak de�i�ken

    private void Start()
    {
        imageComponent = GetComponent<Image>();
        if (images.Length > 0)
        {
            imageComponent.sprite = images[currentIndex];  // Resim dizisini olu�turma
            rotationCoroutine = StartCoroutine(RotateImages());
        }
        else
        {
            Debug.LogError("Resim dizisi bo�!");
        }
    }

    private IEnumerator RotateImages()
    {
        while (isRotating) // D�nme durumu kontrol�
        {
            yield return new WaitForSeconds(rotationInterval);
            currentIndex = (currentIndex + 1) % images.Length;
            imageComponent.sprite = images[currentIndex];
        }
    }

    public void ToggleRotation()
    {
        isRotating = !isRotating; // D�nme durumunu tersine �evir
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public Animator animator;
    private bool isScoped = false;
    public GameObject scopeOverlay;
    public GameObject weaponCamera;
    public Camera mainCamera;

    public float scopeFov = 15f;
    private float normalFov;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            animator.SetBool("Scoped", isScoped);

            if (isScoped)
                StartCoroutine(OnScoped());
            else
                OnUnscoped();
        }
    }
    void OnUnscoped()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);

        mainCamera.fieldOfView = normalFov;
    }
    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(.15f);

        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);

        normalFov = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopeFov;
    }
}

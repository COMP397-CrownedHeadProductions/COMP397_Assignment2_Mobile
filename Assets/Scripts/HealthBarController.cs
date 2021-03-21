using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    //[SerializeField]
    //private Image fgImg;
    //[SerializeField]
    //private float updateSpd = .5f;

    [Header("Health Properties")]
    [Range(0, 100)]
    public int currentHealth;
    [Range(1, 100)]
    public int maximumHealth;
    public Slider healthBarSlider;
    private PlayerController maxHealth;
    void Start()
    {
        //if (GetComponentInParent<PlayerController>() != null)
        //{
        //    GetComponentInParent<PlayerController>().OnHealthPercentChanged += HealthChangeHdlr;
        //}
        //else if (GetComponentInParent<RangeEnemyController>() != null)
        //{
        //    GetComponentInParent<RangeEnemyController>().OnREHelathPercentChanged += HealthChangeHdlr;
        //}
        healthBarSlider = GetComponent<Slider>();
        currentHealth = maximumHealth;
    }
    void LateUpdate()
    {
        //transform.LookAt(Camera.main.transform);
        //transform.Rotate(0, 180, 0);
    }

    //private void HealthChangeHdlr(float percent)
    //{
    //    fgImg.fillAmount = percent;
    //    StartCoroutine(ChangeToPercent(percent));
    //}
    ////Smooth decrease for the health bar.
    //private IEnumerator ChangeToPercent(float percent)
    //{
    //    float preChangePercent = fgImg.fillAmount;
    //    float elapsedTime = 0f;
    //    while (elapsedTime < updateSpd)
    //    {
    //        elapsedTime += Time.deltaTime;
    //        fgImg.fillAmount = Mathf.Lerp(preChangePercent, percent, elapsedTime / updateSpd);
    //        yield return null;
    //    }
    //    fgImg.fillAmount = percent;
    //}

    public void TakeDamage(int damage)
    {
        healthBarSlider.value -= damage;
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            healthBarSlider.value = 0;
            currentHealth = 0;
        }
    }
    public void SetHealth(int healthValue)
    {
        healthBarSlider.value = healthValue;
        currentHealth = healthValue;
    }
    public void Reset()
    {
        healthBarSlider.value = maximumHealth;
        currentHealth = maximumHealth;
    }
}
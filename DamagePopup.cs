using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamagePopup : MonoBehaviour
{
    public float disappearTimer = 2f;
    public float disappearSpeed = 1f;

    private TextMeshPro textMesh;
    private Vector3 moveVector;
    private Color textColor;
    private const float DISAPPEAR_TIMER_MAX = 1f;

    private static int sortingOrder;
    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
        textColor = textMesh.color;
    }

    public static DamagePopup Create(Vector3 position,float damageAmount,bool isCriticalHit)
    {
        Transform damagePopupTransform = Instantiate(GameAssets.Instance.DamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount,isCriticalHit);
        return damagePopup;
    }
    private void Setup(float damageAmount,bool isCriticalHit)
    {
        textMesh.SetText(damageAmount.ToString());
        if(!isCriticalHit)
        {
            textMesh.fontSize = 5;
        }
        else
        {
            textMesh.fontSize = 7;
            textColor = Color.red;
        }
        textMesh.color = textColor;
        disappearTimer = DISAPPEAR_TIMER_MAX;

        moveVector = new Vector3(.7f, 1) * 10;
        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;
    }
    private void Update()
    {
        transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * 7 * Time.deltaTime;

        if(disappearTimer > DISAPPEAR_TIMER_MAX * .5f)
        {
            float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        else
        {
            float decreaseScaleAmount = 1f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0 )
        {
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if(textColor.a < 0 )
            {
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Step13_Controller : MonoBehaviour
{
    [SerializeField] private GameObject warningSign;
    [SerializeField] private SpriteRenderer SR_anteversion, SR_inclination, SR_pic;
    [SerializeField] private Sprite S_anteversion, S_anteversion_warning, S_inclination, S_inclination_warning, S_pic, S_pic_warning;
    [SerializeField] private double anteversion_upper_bound, anteversion_lower_bound;
    [SerializeField] private double inclination_upper_bound, inclination_lower_bound;
    [SerializeField] private TMP_Text anteversion_text, inclination_text;
    private double anteversion = 0, inclination = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // For testing purpose
        if(Input.GetKey(KeyCode.U))
        {
            anteversion -= 0.1;
        }
        if (Input.GetKey(KeyCode.I))
        {
            anteversion += 0.1;
        }
        if (Input.GetKey(KeyCode.J))
        {
            inclination -= 0.1;
        }
        if (Input.GetKey(KeyCode.K))
        {
            inclination += 0.1;
        }
        updateState();
    }

    void updateState()
    {
        inclination_text.text = inclination == 0 ? "0" : inclination.ToString("#.##");
        anteversion_text.text = anteversion == 0 ? "0" : anteversion.ToString("#.##");

        bool anteversion_safe = true, inclination_safe = true;
        if (anteversion < anteversion_lower_bound || anteversion > anteversion_upper_bound) anteversion_safe = false;
        if (inclination < inclination_lower_bound || inclination > inclination_upper_bound) inclination_safe = false;

        if (anteversion_safe && inclination_safe)
        {
            warningSign.SetActive(false);
            SR_pic.sprite = S_pic;
        }
        else
        {
            warningSign.SetActive(true);
            SR_pic.sprite = S_pic_warning;
        }

        if (anteversion_safe) SR_anteversion.sprite = S_anteversion;
        else SR_anteversion.sprite = S_anteversion_warning;

        if (inclination_safe) SR_inclination.sprite = S_inclination;
        else SR_inclination.sprite = S_inclination_warning;
    }
}

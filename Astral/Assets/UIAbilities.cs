using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIAbilities : MonoBehaviour
{
    [Header("FirstSkill")]
    public Image abilityimage1;
    public Text abilityText1;
    public KeyCode ability1Key;
    public float ability1Cooldown;

    [Header("SecondSkill")]
    public Image abilityimage2;
    public Text abilityText2;
    public KeyCode ability2Key;
    public float ability2Cooldown;

    [Header("DashSkill")]
    public Image abilityimage3;
    public Text abilityText3;
    public KeyCode ability3Key;
    public float ability3Cooldown;

    private bool isAbility1Cooldown = false;
    private bool isAbility2Cooldown = false;
    private bool isAbility3Cooldown = false;

    private float currentAbility1Cooldown;
    private float currentAbility2Cooldown;
    private float currentAbility3Cooldown;

    // Start is called before the first frame update
    void Start()
    {
        abilityimage1.fillAmount = 0;
        abilityimage2.fillAmount = 0;
        abilityimage3.fillAmount = 0;


        
    }

    // Update is called once per frame
    void Update()
    {
        Ability1Input();
        Ability2Input();
        Ability3Input();

        AbilityCooldown(ref currentAbility1Cooldown, ability1Cooldown, ref isAbility1Cooldown, abilityimage1, abilityText1);
        AbilityCooldown(ref currentAbility2Cooldown, ability2Cooldown, ref isAbility2Cooldown, abilityimage2, abilityText2);
        AbilityCooldown(ref currentAbility3Cooldown, ability3Cooldown, ref isAbility3Cooldown, abilityimage3, abilityText3);

    }
    private void Ability1Input()
    {
        if (Input.GetKeyDown(ability1Key) && !isAbility1Cooldown)
        {
            isAbility1Cooldown = true;
            currentAbility1Cooldown = ability1Cooldown;
        }
    }
    private void Ability2Input()
        {
            if (Input.GetKeyDown(ability2Key) && !isAbility2Cooldown)
            {
                isAbility2Cooldown = true;
                currentAbility2Cooldown = ability2Cooldown;
            }
        }
    private void Ability3Input()
            {
                if (Input.GetKeyDown(ability3Key) && !isAbility3Cooldown)
                {
                    isAbility3Cooldown = true;
                    currentAbility3Cooldown = ability3Cooldown;
                }
            }
    private void AbilityCooldown(ref float currentCooldown, float maxCooldown, ref bool  isCooldown, Image SkillImage, Text skilltext)
    {
        if (isCooldown)
        {
            currentCooldown -= Time.deltaTime;
            if (currentCooldown <= 0f)
            {
                isCooldown = false;
                currentCooldown = 0f;
                if(SkillImage != null)
                {
                    SkillImage.fillAmount = 0f;
                }
                if(skilltext != null)
                {
                    skilltext.text = "";
                }
            }
            else
            {
                if(SkillImage != null)
                {
                    SkillImage.fillAmount = currentCooldown / maxCooldown;
                }
                if(skilltext != null)
                {
                    skilltext.text = Mathf.Ceil(currentCooldown).ToString();
                }
            }
        }
    }
}
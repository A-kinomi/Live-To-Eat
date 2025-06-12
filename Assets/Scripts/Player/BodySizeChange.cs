using UnityEngine;

public class BodySizeChange : MonoBehaviour
{
    [SerializeField] GameObject energuBar;
    EnergyBar energyBarScript;

    [SerializeField] GameObject s_Cat;
    [SerializeField] GameObject m_Cat;
    [SerializeField] GameObject l_Cat;

    PlayerMovement playerMovementScript;
    [SerializeField] float sCatRunSpeed = 15f;
    [SerializeField] float sCatJumpSpeed = 26f;
    [SerializeField] float mCatRunSpeed = 10f;
    [SerializeField] float mCatJumpSpeed = 18f;
    [SerializeField] float lCatRunSpeed = 6f;
    [SerializeField] float lCatJumpSpeed = 13f;

    void Start()
    {
        energyBarScript = energuBar.GetComponent<EnergyBar>();
        playerMovementScript = GetComponent<PlayerMovement>();

        if(energyBarScript.initialEnergy < energyBarScript.underwight)
        {
            S_CatActive();
        }
        if(energyBarScript.underwight <= energyBarScript.initialEnergy &&
            energyBarScript.initialEnergy <= energyBarScript.overwight)
        {
            M_CatActive();
        }
        if(energyBarScript.initialEnergy < energyBarScript.overwight)
        {
            L_CatActive();
        }
    }

    private void Update()
    {
        SmallToMiddleBodySize();
        MiddleToLargeBodySize();
        LargeToMiddleBodySize();
        MiddleToSmallBodySize();
    }

    void S_CatActive()
    {
        s_Cat.SetActive(true);
        m_Cat.SetActive(false);
        l_Cat.SetActive(false);
        playerMovementScript.runSpeed = sCatRunSpeed;
        playerMovementScript.jumpSpeed = sCatJumpSpeed;
    }

    void M_CatActive()
    {
        s_Cat.SetActive(false);
        m_Cat.SetActive(true);
        l_Cat.SetActive(false);
        playerMovementScript.runSpeed = mCatRunSpeed;
        playerMovementScript.jumpSpeed = mCatJumpSpeed;
    }

    void L_CatActive()
    {
        s_Cat.SetActive(false);
        m_Cat.SetActive(false);
        l_Cat.SetActive(true);
        playerMovementScript.runSpeed = lCatRunSpeed;
        playerMovementScript.jumpSpeed = lCatJumpSpeed;
    }

    void SmallToMiddleBodySize()
    {
        if(energyBarScript.currentEnergy > energyBarScript.underwight)
        {
            M_CatActive();
        }
    }

    void MiddleToLargeBodySize()
    {
        if (energyBarScript.currentEnergy > energyBarScript.overwight)
        {
            L_CatActive();
        }
    }

    void LargeToMiddleBodySize()
    {
        if (energyBarScript.currentEnergy < energyBarScript.overwight)
        {
            M_CatActive();
        }
    }

    void MiddleToSmallBodySize()
    {
        if (energyBarScript.currentEnergy < energyBarScript.underwight)
        {
            S_CatActive();
        }
    }
}

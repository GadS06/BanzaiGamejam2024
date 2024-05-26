using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool showAsBossHp;
    public int scoreReward;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Add any death behavior here, such as destroying the GameObject
        Destroy(gameObject);
        FindObjectOfType<Score>().AddScore(scoreReward);
        FindObjectOfType<BossHpUI>(true).gameObject.SetActive(false);
        FindObjectOfType<LevelOrchestrator>().LevelFinished();
    }

    void UpdateUI()
    {
        if (showAsBossHp)
        {
            var ui = FindObjectOfType<BossHpUI>(true);
            ui.gameObject.SetActive(true);
            var slider = ui.GetComponent<Slider>();
            slider.minValue = 0;
            slider.maxValue = maxHealth;
            slider.value = currentHealth;
        }
    }
}
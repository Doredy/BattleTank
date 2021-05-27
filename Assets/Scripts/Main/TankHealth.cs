using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPrefab1;
    [SerializeField]
    private GameObject effectPrefab2;
    public int tankHP;
    [SerializeField]
    private Text HPLabel;
    public int tankMaxHP = 10;
    public bool isInvincible;
    public float invincibleTime;

    private void Start()
    {
        tankHP = tankMaxHP;
        HPLabel.text = "HP:" + tankHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        //���G���ǂ����̊m�F
        if (isInvincible == true)
        {
            return;
        }
        if (other.gameObject.tag == "EnemyShell")
        {
            tankHP -= 1;

            HPLabel.text = "HP:" + tankHP;
                Destroy(other.gameObject);
            if (tankHP > 0)
            {
                GameObject effect1 = Instantiate(effectPrefab1, transform.position, Quaternion.identity);
                Destroy(effect1, 1.0f);
            }
            else
            {
                GameObject effect2 = Instantiate(effectPrefab2, transform.position, Quaternion.identity);
                Destroy(effect2, 1.0f);
                //Destroy(gameObject);
                this.gameObject.SetActive(false);
                Invoke("GoToGameOver", 1.5f);
            }
        }
    }

    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void AddHP(int amount)
    {
        tankHP += amount;
        if (tankHP > tankMaxHP)
        {
            tankHP = tankMaxHP;
        }
        HPLabel.text = "HP:" + tankHP;
    }
    private void Update()
    {
        //���G���̊m�F
        if (isInvincible == true)
        {

            //���G�Ȃ疳�G���Ԃ����炷
            invincibleTime -= Time.deltaTime;

            //���G���Ԃ��O�ȉ��ɂȂ�����
            if (invincibleTime <= 0)
            {
                //���G��Ԃ���߂�
                isInvincible = false;
                invincibleTime = 0;
            }
        }
    }
}

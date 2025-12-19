using Codice.CM.Client.Differences;
using System.Collections;
using System.Collections.Generic;
using Unity.Plastic.Newtonsoft.Json.Converters;
using UnityEditor.Build.Content;
using UnityEngine;

namespace Babu2Test
{
    public class Player : MonoBehaviour
    {
        public float bulletTime = 0.1f;
        public float reloadTime = 0f;
        Rigidbody thisRigi;
        public GameObject objBullet;
        public Transform BulletPoint;

        GameManager gameManger;

        public GameObject[] item;

        
        void Start()
        {
            GameObject gamManagerObject = GameObject.FindGameObjectWIthTag("GameManger");
            if (gamManagerObject != null)
            {
                gameManger = gameManagerObject.GetComponent<GameManager>();
            }
            if (gameManger == null)
            {
                Debug.LogError("게임 메니져가 존재하지 않아")
            }
            thisRigi = this.GetComponent<Rigidbody>();
        }

        void Update() 
        {
            Move();
            fireBullet();
        }

        private void Move()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(moveX, 0, moveZ);
            thisRigi.velocity = move * GameDataManager.Instance.speed;

            Vector3 posInWorld = Camera.main.WorldToScreenPoint(this.transform.position);

            float posX = Mathf.Clamp(posInWorld.x, 0, Screen.width);
            float posZ = Mathf.Clamp(posInWorld.y, 0, Screen.height);

            Vector3 posInScreen = Camera.main.ScreenToWorldPoint(new Vector3(posX, posZ, 0));

            thisRigi.position = new Vector3(posInScreen.x, 0, posInScreen.z);
        }

        void fireBullet()
        {
            reloadTime += Time.deltaTime;

            if(Input.GetButton("Fire1") && (bulletTime <= reloadTime))
            {
                reloadTime = 0f;
                GameObject bullet = Instantiate(objBullet, BulletPoint.position, this.transform.roatation);
                bullet.GetComponent<Bullet>().SetBullet(BulletPoint.position + Vector3.forward);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Bullet")) 
            {
                GameDataManager.Instance.hp -= 1;
                if(GameDataManager.Instance.hp < 1)
                {
                    Destroy(gameObject);
                }
                Destory(other.gameObject);
            }
            else if (other.CompareTag("Enemy"))
            {
                GameDataManager.Instance.hp -= 1;
            }

            if (ohter.GetComponent<Item>().itemStatus)
            {

            }
        }


    }
}

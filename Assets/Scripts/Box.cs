using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Box : MonoBehaviour
{
    #region Fields

    [SerializeField]
    GameObject prefabParticles;

    [SerializeField]
    Material particleMaterial = null;

    public Color[] color = new Color[] { Color.red, Color.green};
    int[] id = new int[2] { -1, -1 };
    public Vector3 direction = Vector3.back;

    float speed;

    // score event support
    CollideWithBucketEvent collideWithBucketEvent = new CollideWithBucketEvent();
    #endregion

    #region Properties
    
    public int[] Id
    {
        get { return id; }
        set 
        {
            id = value;
        }

    }
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    #endregion
    void Start()
    {
        EventManager.AddInvoker(this);

        switch(SpawnerUtils.difficulty)
        {
            case Difficulty.Easy:
                speed = Configuration.SpeedOnEasyLevel;
                break;
            case Difficulty.Medium:
                speed = Configuration.SpeedOnMediumLevel;
                break;
            case Difficulty.Hard:
                speed = Configuration.SpeedOnHardLevel;
                break;
        }
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        int idOfCollisionObject = int.Parse(collision.gameObject.tag);
        // сollide with suit bucket 
        if (Id[0] == idOfCollisionObject)
        {
            AudioManager.Play(AudioClipName.RightBucket);
            collideWithBucketEvent.Invoke(idOfCollisionObject);

            if (transform.position.x < 0)
                Instantiate(prefabParticles, transform.position, Quaternion.AngleAxis(90, new Vector3(0, 1, 0))).GetComponent<Renderer>().material.color =
                    color[0];
            else
                Instantiate(prefabParticles, transform.position, Quaternion.AngleAxis(-90, new Vector3(0, 1, 0))).GetComponent<Renderer>().material.color =
                    color[0];

        }
        else if (Id[1] == idOfCollisionObject)
        {
            AudioManager.Play(AudioClipName.RightBucket);
            collideWithBucketEvent.Invoke(idOfCollisionObject);

            if (transform.position.x < 0)
                Instantiate(prefabParticles, transform.position, Quaternion.AngleAxis(90, new Vector3(0, 1, 0))).GetComponent<Renderer>().material.color =
                    color[1];
            else
                Instantiate(prefabParticles, transform.position, Quaternion.AngleAxis(-90, new Vector3(0, 1, 0))).GetComponent<Renderer>().material.color =
                    color[1];
        }
        else if (idOfCollisionObject == 8) // collide with destroyer
        {
            AudioManager.Play(AudioClipName.DestroyerBump);
            HighlightManager.instance.RemoveFromListAndReHighlight(gameObject);

            ScoreManager.instance.UpdateScore(ScoreManager.pointsPerSkippedBox);
            ScoreManager.instance.UpdateBoxesLeftScore();

        }
        else if (idOfCollisionObject == 7) // collide with void
        {
            AudioManager.Play(AudioClipName.Explosion);
            ScoreManager.instance.UpdateScore(ScoreManager.pointsPerDestroyBox);
            ScoreManager.instance.UpdateBoxesLeftScore();
            if (transform.position.x < 0)
                Instantiate(prefabParticles, transform.position, Quaternion.AngleAxis(90, new Vector3(0, 1, 0))).GetComponent<Renderer>().material.color =
                    particleMaterial.color;
            else
                Instantiate(prefabParticles, transform.position, Quaternion.AngleAxis(-90, new Vector3(0, 1, 0))).GetComponent<Renderer>().material.color =
                    particleMaterial.color;
        }
        else   // collide with another bucket
        {
            AudioManager.Play(AudioClipName.Explosion);
            ScoreManager.instance.UpdateScore(ScoreManager.pointsPerWrongBucket);
            ScoreManager.instance.UpdateBoxesLeftScore();
            if (transform.position.x < 0)
                Instantiate(prefabParticles, transform.position, Quaternion.AngleAxis(90, new Vector3(0, 1, 0))).GetComponent<Renderer>().material.color =
                    particleMaterial.color;
            else
                Instantiate(prefabParticles, transform.position, Quaternion.AngleAxis(-90, new Vector3(0, 1, 0))).GetComponent<Renderer>().material.color =
                    particleMaterial.color;
        }

        // anyway destroy when collide


        Destroy(gameObject);
    }

    public void AddListener (UnityAction<int> listener)
    {
        collideWithBucketEvent.AddListener(listener);
    }
}

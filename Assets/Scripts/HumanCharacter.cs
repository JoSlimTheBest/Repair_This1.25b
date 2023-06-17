using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine;

public class HumanCharacter : MonoBehaviour
{
   
    public bool man = true;
    public int IDperson;


    public string namePersonEng = "name";
    public string surnamePersonEng = "surname";

    

    [HideInInspector]public int _brokenPartPhone = -1;
    [HideInInspector] public string _brokenModelPhone;

    public enum detailBroken { Display, Camera, BottomBoard , Mainboard, Dinamic, BackPanel }
    public detailBroken previewDetail;

    public enum brokenPhoneModelChoice { A,M,S}
    public brokenPhoneModelChoice previewModel;


    public enum countMoneyBuyer { min, midle, max,sellPhone }
    public countMoneyBuyer previewMoneyBuyer;
    [SerializeField, Range(250f, 1000f)] public int moneyBuyer = -1;

    [SerializeField, Range(0f, 25f)]  public int clock = -1;



    public int day;
    public int hour;
    public int minute;


    public bool randomSex = false;
    public bool random = false;
    [Header("PartBody")]
    public SpriteRenderer addNew;
    public SpriteRenderer addNew2;

    public SpriteRenderer hair;
    public SpriteRenderer brow;
    public SpriteRenderer eye;
    public SpriteRenderer nose;
    public SpriteRenderer glasses;
    public SpriteRenderer mustage;
    public SpriteRenderer mouth;
    public SpriteRenderer body;
    public SpriteRenderer cloth;
    //Men
    [SerializeField] public List<Sprite> hairM = new List<Sprite>();
    public List<Sprite> brownM = new List<Sprite>();
    public List<Sprite> eyeM = new List<Sprite>();
    public List<Sprite> glassesM = new List<Sprite>();
    
    public List<Sprite> noseM = new List<Sprite>();
    public List<Sprite> mustageM = new List<Sprite>();
    public List<Sprite> mouthM = new List<Sprite>();
    public List<Sprite> bodyM = new List<Sprite>();
    public List<Sprite> clothM = new List<Sprite>();


    //women
   
    public List<Sprite> hairW = new List<Sprite>();
    public List<Sprite> browW = new List<Sprite>();
    public List<Sprite> eyeW = new List<Sprite>();
    public List<Sprite> glassesW = new List<Sprite>();
    public List<Sprite> noseW = new List<Sprite>();
    public List<Sprite> mouthW = new List<Sprite>();
    public List<Sprite> bodyW = new List<Sprite>();
    public List<Sprite> clothW = new List<Sprite>();


    
    public Sprite capDelivery; // delivery gay
    public Sprite clothesDelivery;
    private HumanQueue queue;
    private ComputerTime compT;
    private bool stayAfk = false;
    public float startDialogAfter = 10;
    public float currentStartDialogAfter;



    public bool delivery;
    
    private Animator animator;
    public bool activeAnim = false;

    
    public FirstDialog dial;
    public DialogRemove DRemove;
   
    


    public Material lightMater;
    public Material usuallyMater;
    private Camera shotScreen;
    public Sprite myFace;
    private bool photoReady = false;

    public void PickPhonePickDetail()
    {
        _brokenModelPhone = previewModel.ToString();
        

        _brokenPartPhone = (int)previewDetail;
       
    }


    public void Awake()
    {
        dial = GetComponent<FirstDialog>();
       

        DRemove = GetComponent<DialogRemove>();
        PickPhonePickDetail();
       

        ChangeActiveColor(false);

        shotScreen = GetComponentInChildren<Camera>();
        currentStartDialogAfter = startDialogAfter;
    }
    public void Start()
    {
        myFace = GivePicture();


        animator = GetComponent<Animator>();
        animator.enabled = false;
        queue = GameObject.Find("QueueControll").GetComponent<HumanQueue>();
        compT = queue.GetComponent<ComputerTime>();
        if(delivery != true)
        {
            dial.enabled = false;
        }
        else
        {
            ChangeActiveColor(true);

        }
        
       
        if(DRemove != null)
        {
            DRemove.enabled = false;
        }
        

        if(randomSex == true)
        {
            int random = Random.Range(0, 2);
           if(random > 0)
           {
                man = true;
           }
           else
           {
                man = false;
           }
           
        }

        GiveMoney();

        if (random == true)
        {
            RandomFace();
            
        }
       
        

        queue.GetComponent<ComputerTime>().Addheroes(gameObject);

        if(GetComponent<LandLord>()!=null)
        {
            day = queue.GetComponent<ComputerTime>().currentDay;
        }
        RenameCharacter();

        

    }

    public Sprite GivePicture()
    {
        shotScreen.enabled = true;
        
      
            ChangeActiveColor(true);

       
       

        int width = this.shotScreen.pixelWidth;
        int height = this.shotScreen.pixelHeight;
        Texture2D texture = new Texture2D(width, height);

        RenderTexture targetTexture = RenderTexture.GetTemporary(width, height);

        this.shotScreen.targetTexture = targetTexture;
        this.shotScreen.Render();


        RenderTexture.active = targetTexture;

        Rect rect = new Rect(0, 0, width, height);
        texture.ReadPixels(rect, 0, 0);
        texture.Apply();
        Sprite mySprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
        shotScreen.enabled = false;
       

        
            ChangeActiveColor(false);
        
        return mySprite;
    }

    private void RenameCharacter()
    {
        gameObject.name = gameObject.name + "D" + day.ToString() + "H" + hour.ToString() + "M" + minute.ToString();
    }

    public void ChangeSpriteLayer(int count)
    {
        hair.sortingOrder -= count;
        brow.sortingOrder -= count;
        glasses.sortingOrder -= count;
        eye.sortingOrder -= count;
        nose.sortingOrder -= count;
        mustage.sortingOrder -= count;
        mouth.sortingOrder -= count;
        body.sortingOrder -= count;
        cloth.sortingOrder -= count;
        if (addNew != null)
        {
            addNew.sortingOrder -= count;
        }
        if(addNew2 != null)
        {
            addNew2.sortingOrder -= count;
        }
        
    }

    public void ActivetingAnim()
    {
        animator.enabled = true;
        activeAnim = true;

        //ChangeActiveColor(true);
       
    }

    public void RandomFace()
    {

        
        if(man == true)
        {
            
            
                hair.sprite = hairM[Random.Range(0, hairM.Count)];
                brow.sprite = brownM[Random.Range(0, brownM.Count)];
                eye.sprite = eyeM[Random.Range(0, eyeM.Count)];
                int glass = Random.Range(0, 3);
                if (glass < 1)
                {
                    glasses.sprite = glassesM[Random.Range(0, eyeM.Count)];
                }
                else
                {
                    glasses.sprite = null;
                }
                
                nose.sprite = noseM[Random.Range(0, eyeM.Count)];

                int mus = Random.Range(0, 3);
                if (mus < 1)
                {
                    mustage.sprite = mustageM[Random.Range(0, mustageM.Count)];
                }
                else
                {
                    mustage.sprite = null;
                }

                mouth.sprite = mouthM[Random.Range(0, mouthM.Count)];
                body.sprite = bodyM[Random.Range(0, bodyM.Count)];
                cloth.sprite = clothM[Random.Range(0, clothM.Count)];


             

                Color hairs = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
                Color must = new Color(Random.Range(0f, 0.3f), Random.Range(0f, 0.3f), Random.Range(0f, 0.3f), 1);


            
                
                Color cloth_ = new Color(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), 1);
            if (delivery == true)
            {
                hair.sprite = capDelivery;
                cloth.sprite = clothesDelivery;
                cloth_ = hairs;
            }

            hair.color = hairs;
            mustage.color = must;
            brow.color = hairs;
            cloth.color = cloth_;
           

        }
        else
        {
           
            
            hair.sprite = hairW[Random.Range(0, hairW.Count)];
            
           
            brow.sprite = browW[Random.Range(0, brownM.Count)];
            eye.sprite = eyeW[Random.Range(0, eyeW.Count)];
            int glass = Random.Range(0, 4);
            if (glass < 2)
            {
                glasses.sprite = glassesW[Random.Range(0, eyeM.Count)];
            }
            else
            {
                glasses.sprite = null;
            }
            mustage.sprite = null;
            mouth.sprite = mouthW[Random.Range(0, mouthM.Count)];
            body.sprite = bodyW[Random.Range(0, bodyM.Count)];
            cloth.sprite = clothW[Random.Range(0, clothM.Count)];

           

            Color hairs = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
            Color cloth_ = new Color(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), 1);
            if (delivery == true)
            {
                hair.sprite = capDelivery;
                cloth.sprite = clothesDelivery;
                cloth_ = hairs;
            }
            cloth.color = cloth_;
            hair.color = hairs;
            brow.color = hairs;
        }
    }

    public void ChangeActiveColor(bool active)
    {
        
        if (active == true)
        {

            
            hair.material = usuallyMater;
            brow.material = usuallyMater;
            glasses.material = usuallyMater;
            eye.material = usuallyMater;
            nose.material = usuallyMater;
            mustage.material = usuallyMater;
            mouth.material = usuallyMater;
            body.material = usuallyMater;
            cloth.material = usuallyMater;
            if (addNew != null)
            {
                addNew.material = usuallyMater;
            }
            if (addNew2 != null)
            {
                addNew2.material = usuallyMater;
            }

            photoReady = true;


        }
        else
        {
            hair.material = lightMater;
            brow.material = lightMater;
            glasses.material = lightMater;
            eye.material = lightMater;
            nose.material = lightMater;
            mustage.material = lightMater;
            mouth.material = lightMater;
            body.material = lightMater;
            cloth.material = lightMater;

            if(addNew != null)
            {
                addNew.material = lightMater;
            }
            
            if(addNew2 != null)
            {
                addNew2.material = lightMater;
            }

            photoReady = false;
            
        }
    }

    public void GiveMoney()
    {
        int firstcost = GameObject.Find("ManagerStock").GetComponent<ManagerStock>().CheckCost(previewModel.ToString(), (int)previewDetail);
        
        if((int)previewMoneyBuyer == 3)
        {
            return;
        }
      
        if((int)previewMoneyBuyer == 0)
        {
            firstcost += 100;
            moneyBuyer = firstcost;
        }

        if((int)previewMoneyBuyer == 1)
        {
            firstcost += 200;
            moneyBuyer = firstcost;
        }

        if ((int)previewMoneyBuyer == 2)
        {
            firstcost += 300;
            moneyBuyer = firstcost;
        }


        

        if (clock < 0)
        {
            clock = Random.Range(2, 50);
        }
    }

    public void EquelTime()
    {
        currentStartDialogAfter = startDialogAfter;
    }



    private void FixedUpdate()
    {
        
        if(compT.currentDay == day )
        {
            if(queue.humanList.Count == 0 )
            {
                return;
            }

            if(queue.humanList[0] != gameObject)
            {
                return;
            }

            if(compT.gameStop == true)
            {
                return;
            }
            if(compT.hours == hour && compT.minute > minute)
            {
                if(stayAfk == false)
                {
                    currentStartDialogAfter -= Time.deltaTime;
                    if(currentStartDialogAfter < 0)
                    {
                        stayAfk = true;
                    }
                }
                else
                {
                    GetComponent<FirstDialog>().DialogStart();
                    EquelTime();
                    stayAfk = false;
                }
                return;
            }

            if (compT.hours > hour)
            {
                if (stayAfk == false)
                {
                    currentStartDialogAfter -= Time.deltaTime;
                    if (currentStartDialogAfter < 0)
                    {
                        stayAfk = true;
                    }
                }
                else
                {
                    GetComponent<FirstDialog>().DialogStart();
                    currentStartDialogAfter = startDialogAfter;
                    stayAfk = false;
                }
                return;
            }
        }

        if (compT.currentDay > day)
        {
            day = compT.currentDay;
            hour = Random.Range(13, 18);
        }



    }
    

   



}

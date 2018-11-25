using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO.Ports;

public class TicketCount : MonoBehaviour
{
    public static SerialPort sp = new SerialPort("COM4", 9600);
    public static SerialPort sp1 = new SerialPort("COM6", 9600);
    public Text redtickets;
    public Text whitetickets;
    int redno;
    int whiteno;
    int turncount;
    int sceneno;
    bool drawtick = false;
    public Text redplayer;
    public Text whiteplayer;
    public Text redtext;
    public Text whitetext;
    public Text sloplayer;
    public Text solono;
    string stl;

    public void Start()
    {
       
        turncount = PlayerPrefs.GetInt("turncount");
        sceneno = PlayerPrefs.GetInt("Scene");
        Debug.Log(sceneno);
        Debug.Log(turncount);
        solono.enabled = false;
        sloplayer.enabled = false;
      
    }
    void setactive()
    {
        solono.enabled = true;
        sloplayer.enabled = true;
        redplayer.enabled = false;
        whiteplayer.enabled = false;
        redtext.enabled = false;
        whitetext.enabled = false;
    }
    //public void serialread()
    //{
    //    sp.Open();
    //    stl = sp.ReadLine();
    //    sp.ReadTimeout = 1;

    //}
    public void drawtickets()
    {
      
        if (turncount >= 0 && turncount <= 10)
        {
            

            redtickets.text = "70";
            whitetickets.text = "10";
            sendred();
        }


        if (turncount <= 20 && turncount >= 11)
        {
            redtickets.text = "60";
            whitetickets.text = "20";
            sendyelow();

        }
        if (turncount <= 30 && turncount >= 21)
        {
            redtickets.text = "50";
            whitetickets.text = "30";
            sendblue();
        }
        if (turncount <= 42 && turncount >= 31)
        {
            redtickets.text = "40";
            whitetickets.text = "40";
            sendpink();
        }



    } 
    public void drawtickets1()
    {
        if (turncount >= 0 && turncount <= 10)
        {
            redtickets.text = "10";
            whitetickets.text = "70";
            sendred1();
        }


        if (turncount <= 20 && turncount >= 11)
        {
            redtickets.text = "20";
            whitetickets.text = "60";
            sendyelow1();

        }
        if (turncount <= 30 && turncount >= 21)
        {
            redtickets.text = "30";
            whitetickets.text = "50";
            sendblue1();
        }
        if (turncount <= 42 && turncount >= 31)
        {
            redtickets.text = "40";
            whitetickets.text = "40";
            sendpink1();
        }



    }
    public void drawtickets2()
    {
        setactive();
        if (turncount >= 0 && turncount <= 10)
        {
            solono.text = "70";

            //redtickets.text = "70";
           
            sendred2();
        }


        if (turncount <= 20 && turncount >= 11)
        {
            solono.text = "60";

            sendyelow2();

        }
        if (turncount <= 30 && turncount >= 21)
        {
            solono.text = "50";

            sendblue2();
        }
        if (turncount <= 42 && turncount >= 31)
        {
            solono.text = "40";

            sendpink2();
        }



    }
    public void drawtickets3()
    {
        setactive();
        if (turncount >= 0 && turncount <= 10)
        {

            solono.text = "10";
            sendred3();
        }


        if (turncount <= 20 && turncount >= 11)
        {
            solono.text = "20";
            sendyelow3();

        }
        if (turncount <= 30 && turncount >= 21)
        {
            solono.text = "30";
            sendblue3();
        }
        if (turncount <= 42 && turncount >= 31)
        {
            solono.text = "40";
            sendpink3();
        }



    }

    #region SENDCOLORS
    public static void sendred()
    {
        sp.Open();
        sp1.Open();
        Debug.Log("Sending Red");

        sp.Write("z");
        sp.Write("sensor1");
        sp1.Write("b");
        sp1.Write("sensor1");
        Debug.Log("sent   ");
        sp.Close();
        sp1.Close();


    }
    public static void sendyelow()
    {
        sp.Open();
        sp1.Open();
        sp.Write("y");
        sp.Write("sensor1");
        sp1.Write("x");
        sp1.Write("sensor1");
        Debug.Log("sent   ");
        sp.Close();
        sp1.Close();

    }
    public static void sendblue()
    {
        Debug.Log("Sending blue");
        sp.Open();
        sp1.Open();
        sp.Write("g");
        sp.Write("sensor1");
        sp1.Write("m");
        sp1.Write("sensor1");
        Debug.Log("sent   ");
        sp.Close();
        sp1.Close();


    }
    public static void sendpink()
    {
        sp.Open();
        sp1.Open();
        sp.Write("p");
        sp.Write("sensor1");
        sp1.Write("p");
        sp1.Write("sensor1");
        Debug.Log("sent   ");
        sp.Close();
        sp1.Close();


    }
    public static void sendred1()
    {
        sp.Open();
        sp1.Open();
        sp.Write("b");
        sp.Write("sensor1");
        sp1.Write("z");
        sp1.Write("sensor1");
        Debug.Log("sent   ");
        sp.Close();
        sp1.Close();

    }
    public static void sendyelow1()
    {
        sp.Open();
        sp1.Open();
        sp.Write("x");
        sp.Write("sensor1");
        sp1.Write("y");
        sp1.Write("sensor1");
        Debug.Log("sent   ");
        sp.Close();
        sp1.Close();


    }
    public static void sendblue1()
    {
        Debug.Log("Sending blue");
        sp.Open();
        sp1.Open();
        sp.Write("m");
        sp.Write("sensor1");
        sp1.Write("g");
        sp1.Write("sensor1");
        Debug.Log("sent   ");
        sp.Close();
        sp1.Close();


    }
    public static void sendpink1()
    {
        sp.Open();
        sp1.Open();
        sp.Write("p");
        sp.Write("sensor1");
        sp1.Write("p");
        sp1.Write("sensor1");
        Debug.Log("sent   ");
        sp.Close();
        sp1.Close();


    }
    public static void sendred2()
    {
        sp.Open();
     
        Debug.Log("Sending Red");

        sp.Write("z");
        sp.Write("sensor1");
        sp.Close();


    }
    public static void sendyelow2()
    {
        sp.Open();
        sp.Write("y");
        sp.Write("sensor1");
        sp.Close();

    }
    public static void sendblue2()
    {
        Debug.Log("Sending blue");
        sp.Open();
        sp.Write("g");
        sp.Write("sensor1");
     
        sp.Close();



    }
    public static void sendpink2()
    {
        sp.Open();
        sp.Write("p");
        sp.Write("sensor1");
        
        sp.Close();
      


    }
    public static void sendred3()
    {

        sp.Open();

        
        Debug.Log("Sending Red");

        sp.Write("b");
        sp.Write("sensor1");
       
        sp.Close();
      


    }
    public static void sendyelow3()
    {
        sp.Open();
       
        sp.Write("g");
        sp.Write("sensor1");
       
        sp.Close();
       
    }
    public static void sendblue3()
    {
        Debug.Log("Sending blue");
        sp.Open();
        
        sp.Write("y");
        sp.Write("sensor1");
       
        Debug.Log("sent   ");
        sp.Close();
       


    }
    public static void sendpink3()
    {
        sp.Open();
        sp.Write("z");
        sp.Write("sensor1");
       
        Debug.Log("sent   ");
        sp.Close();
   


    }

    #endregion
    public void Update()
    {
       
  

        int tcount = int.Parse(redtickets.text);
        int tcount1 = int.Parse(whitetickets.text);
        int tcount2 = int.Parse(solono.text);
        solono.text = tcount2.ToString();
        redtickets.text = tcount.ToString();
        whitetickets.text = tcount1.ToString();
        if (sceneno == 1 && drawtick == false)
        {
          
           
            drawtick = true;
            drawtickets();
            PlayerPrefs.SetInt("turncount", 0);

        }
        if (sceneno == 2 && drawtick == false)
        {
           

            drawtick = true;
            drawtickets1();
            PlayerPrefs.SetInt("turncount", 0);
        }
        if (sceneno == 3 && drawtick == false)
        {

            drawtick = true;
            drawtickets2();
            PlayerPrefs.SetInt("turncount", 0);
        }
        if (sceneno == 4 && drawtick == false)
        {

            drawtick = true;
            drawtickets3();
            PlayerPrefs.SetInt("turncount", 0);
        }
        if (int.Parse(redtickets.text) <= 0)
        {
            redtickets.text  =" 0";

        }
        if (int.Parse(whitetickets.text) <= 0)
        {
            whitetickets.text = "0";
        }
        if (int.Parse(solono.text) <= 0)
        {
            solono.text = "0";
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            tcount--;
        

            redtickets.text = tcount.ToString();
           

        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            tcount2--;
            tcount1--;
            whitetickets.text = tcount1.ToString();

            solono.text = tcount2.ToString();
        }



        if (int.Parse(redtickets.text) == 0 && int.Parse(whitetickets.text) == 0 && solono.enabled == false)
            {
                StartCoroutine(gotodemo());

            }
       
            if (int.Parse(solono.text) == 0&& solono.enabled ==true)
            {
                StartCoroutine(gotodemo());
            }

        
        

    }
    IEnumerator gotodemo()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
    public void OpenConnection()
    {
        if (sp != null)
        {
            if (sp.IsOpen)
            {
                sp.Close();
                print("Closing port, because it was already open!");
            }
            else
            {
                sp.Open();                                                  // opens the connection
                sp.ReadTimeout = 20;                                        // sets the timeout value before reporting error
                print("Port Opened!");
            }
        }
        else
        {
            if (sp.IsOpen)
            {
                print("Port is already open");
            }
            else
            {
                print("Port == null");
            }
        }
    }
    public void OpenConnection1()
    {
        if (sp1 != null)
        {
            if (sp1.IsOpen)
            {
                sp1.Close();
                print("Closing port, because it was already open!");
            }
            else
            {
                sp1.Open();                                                  // opens the connection
                sp1.ReadTimeout = 20;                                        // sets the timeout value before reporting error
                print("Port Opened!");
            }
        }
        else
        {
            if (sp1.IsOpen)
            {
                print("Port is already open");
            }
            else
            {
                print("Port == null");
            }
        }
    }
    public  void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }

}




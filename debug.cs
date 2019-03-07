using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debug : MonoBehaviour
{
    public List<Transform> Objs;
    public Color[] ObjectColors;
    private int colorNumber;
    public GameObject ObjectToColor;
    int i, cx, cy, cz,count =0;
    float x, y, z;
    float total_tyre_volume = 0, total_tyre_weight = 0;
    float[] xx = new float[5];
    float[] yy = new float[5];
    float[] zz = new float[5];
    float truck_length;
    float truck_breadth;
    float truck_height;
    float truck_capacity;
    float truck_volume;

    float[] tyre_diameter;
    float[] tyre_width;
    float tyre_weight;
    int n;

    struct tyre
    {
        public float diameter;
        public float width;
        public float weight;
        public float volume;
        public int n;
    };

    tyre[] tyr = new tyre[5];
    private float efficiency=0;
    private float tyrvol=0;

    float Inch(float n)
    {
        float mm = n * 25.4f;
        return mm;
    }

    float Feet(float n)
    {
        float mm = n * 304.8f;
        return mm;
    }

    float Dia(float sectional_width, float aspect_ratio, float rim_dia)
    {
        float dia = Inch(rim_dia) + aspect_ratio / 100 * sectional_width * 2;
        return dia;
    }

    // Start is called before the first frame update
    void Start()
    {

        tyr[0].diameter = Dia(205,55,16);
        tyr[1].diameter = Dia(205,65,16);
        tyr[2].diameter = Dia(215,65,16);
        tyr[3].diameter = Dia(215, 55, 17);
        tyr[4].diameter = Dia(225,60,17);

        tyr[0].width = 205;
        tyr[1].width = 205;
        tyr[2].width = 215;
        tyr[3].width = 215;
        tyr[4].width = 225;

        tyr[0].weight = 9.6f;
        tyr[1].weight = 10.9f;
        tyr[2].weight = 10.6f;
        tyr[3].weight = 10.7f;
        tyr[4].weight = 11.5f;

        tyr[0].n = 200;
        tyr[1].n = 200;
        tyr[2].n = 200;
        tyr[3].n = 200;
        tyr[4].n = 200;

        truck_length = Feet(32);
        truck_breadth = Feet(10.3f);
        truck_height = Feet(8.5f);
        truck_capacity = 14000;

        truck_volume = truck_length * truck_breadth * truck_height;

        for (i = 0; i < 5; i++)
        {
            tyr[i].volume = 3.141592f * (tyr[i].diameter) / 2 * (tyr[i].diameter) / 2 * tyr[i].width;
            total_tyre_volume += tyr[i].n * tyr[i].volume;
            total_tyre_weight += tyr[i].n * tyr[i].weight;
        }
        if (truck_capacity > total_tyre_weight)
        {
            if (truck_volume < total_tyre_volume)
            {
                Debug.Log("Overutilization of Space. and less weight");
                float residual_volume = (truck_volume - total_tyre_volume) / 1000;
                Debug.Log("Overutilization by" + residual_volume.ToString());
                float percentage = (total_tyre_volume * 100) / truck_volume;
                Debug.Log("percentage of volume occupied " + percentage);
            }

            else if (truck_volume > total_tyre_volume)
            {
                Debug.Log("Underutilization of Space. less weight");
                float residual_volume = (truck_volume - total_tyre_volume) / 1000;
                Debug.Log("Space left is " + residual_volume);
                float percentage = (total_tyre_volume * 100) / truck_volume;
                Debug.Log("percentage of volume occupied " + percentage);                   
            }

            else {
                Debug.Log("Underweight\n");
            }

            Debug.Log("Container lenght " + truck_length);
            Debug.Log("Container width " + truck_breadth);
            Debug.Log("Container height " + truck_height);
            Debug.Log("Container Capacity " + truck_capacity);
            Debug.Log("Container volume " + truck_volume);
            Debug.Log("No of types of tyres : 5 ");
            
            for (int i = 0; i < 5; i++)
            {
                tyrvol += tyr[i].diameter * tyr[i].diameter * tyr[i].width * tyr[i].n + tyr[i].diameter / 2 * tyr[i].diameter/2 * Mathf.PI * tyr[i].width;
                Debug.Log("Tyre diameter " + i +" " + tyr[i].diameter);
                Debug.Log("Tyre width " + i +" "+ tyr[i].width);
                Debug.Log("tyre weight " + i +" " +tyr[i].weight);
                Debug.Log("No of tyres " + i +" "+ tyr[i].n);
            }
            efficiency = (tyrvol * 100 ) /( truck_volume*2);
            Debug.Log("efficiency " + efficiency);
            Debug.Log("Cumulative tyre Weight " + total_tyre_weight);
            Debug.Log("Cumulative tyre volume " + total_tyre_volume);
        }

        else if (truck_capacity < total_tyre_weight)
        {

            if (truck_volume < total_tyre_volume)
            {
                Debug.Log("Overutilization of Space. and over weight");
                float residual_volume = (truck_volume - total_tyre_volume) / -1000;
                Debug.Log("Overutilization by " + residual_volume.ToString());
                float percentage = (total_tyre_volume * 100) / truck_volume;
                Debug.Log("percentage of volume occupied " + percentage);
            }

            else if (truck_volume > total_tyre_volume)
            {
                Debug.Log("Underutilization of Space. and over weight");
                float residual_volume = (truck_volume - total_tyre_volume) / 1000;
                Debug.Log("Space left is " + residual_volume.ToString());//print statment reguarding the volume
                float percentage = (total_tyre_volume * 100) / truck_volume;
                Debug.Log("percentage of volume occupied " + percentage);
            }

            else
            {
                Debug.Log("Overweight, remove some tyres.");
                float residual_weight = truck_capacity - total_tyre_weight;
                Debug.Log("Overweight by " + residual_weight.ToString());
                float percentage = (total_tyre_volume * 100) / truck_volume;
                Debug.Log("percentage of volume occupied " + percentage);
            }
        }


        //Bubble Sort
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5 - i - 1; j++)
            {
                if (tyr[j].weight > tyr[j + 1].weight)
                {
                    float temp = tyr[j].weight;
                    tyr[j].weight = tyr[j + 1].weight;
                    tyr[j + 1].weight = temp;

                    temp = tyr[j].width;
                    tyr[j].width = tyr[j + 1].width;
                    tyr[j + 1].width = temp;

                    temp = tyr[j].diameter;
                    tyr[j].diameter = tyr[j + 1].diameter;
                    tyr[j + 1].diameter = temp;

                    temp = tyr[j].n;
                    tyr[j].n = tyr[j + 1].n;
                    tyr[j + 1].n =(int) temp;
                }
            }
        }

        for (i = 0; i < 5; i++)
        {
            cx = 0; cy = 0; cz = 0;
            //  printf("%f\n", tyre[i].diameter);
            if (i == 0)
                y = tyr[i].width / 2;
            else
            {
                if (cy == 0)
                {
                    y = yy[i - 1];
                    cy++;
                }
                else
                    y = tyr[i].width / 2;
            }
            while (y <= truck_height-(tyr[i].width) / 2 && truck_capacity >= 0 && tyr[i].n > 0)
            {
                if (i == 0)
                    x = tyr[i].width / 2;
                else
                {
                    if (cx == 0)
                    {
                        x = xx[i - 1];
                        cx++;
                    }
                    else
                        x = tyr[i].width / 2;
                }
                while (x <= truck_length-(tyr[i].diameter)/2 && truck_capacity >= 0 && tyr[i].n > 0)
                {
                    count++;
                    if (i == 0)
                    {
                        if (count % 2 == 1)
                        {
                            z = tyr[i].diameter / 2;
                        }
                        else
                            z = tyr[i].diameter;
                    }
                    else
                    {
                        if (cz == 0)
                        {
                            z = zz[i - 1] + tyr[i].diameter;
                            cz++;
                        }
                        else
                            z = 0;
                    }
                    while (z <= truck_breadth-(tyr[i].diameter)/ 2 && truck_capacity >= 0 && tyr[i].n > 0)
                    {
                        tyr[i].n--;
                        truck_capacity -= tyr[i].weight;
                        //printf("%f,%f,%f\n", x, y, z);
                    /*   GameObject cylind = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                        cylind.AddComponent<CapsuleCollider>();
                        cylind.GetComponent<Renderer>().material.color = Color.yellow;
                        cylind.GetComponent<Renderer>().material.color = Color.blue;
                        cylind.transform.localScale = new Vector3(0.5f, 0.05f, 0.5f);
                        cylind.transform.Rotate(0,0,90); //the local scale value is in metres so less value it willbe in cm
                        cylind.transform.position = new Vector3(x/1800, y/1800, z/1800);
                     */ 

                        ChangeColor();
                        xx[i] = x; yy[i] = y; zz[i] = z;
                        z += tyr[i].diameter;
                    }
                    x += tyr[i].width;
                }
                y += tyr[i].diameter;
            }
        }
    }
    // Start is called before the first frame update

    // Update is called once per frame
     void Awake()
      {
        ObjectColors = new Color[]
        {
           Color.red,
           Color.yellow,
           Color.blue,
           Color.magenta,
           Color.green
          };
          colorNumber = 0;
      }
      public void ChangeColor()
      {
          ChangeColor(-1);
      }
      public void ChangeColor(int specificColor)
      {
          if (specificColor < 0)
          {
              GameObject cylind = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
              cylind.AddComponent<CapsuleCollider>();
             // cylind.GetComponent<Renderer>().material.color = Color.yellow;
              cylind.transform.localScale = new Vector3(0.5f, 0.05f, 0.5f);//the local scale value is in metres so less value it willbe in cm
              cylind.transform.position = new Vector3(x / 1800, y / 1800, z / 1800);
               cylind.transform.Rotate(0,0,90);
              cylind.GetComponent<Renderer>().material.color = ObjectColors[colorNumber++];
              if (colorNumber >= ObjectColors.Length)
                  colorNumber = 0;
          }
          else
          {
              ObjectToColor.GetComponent<Renderer>().material.color = ObjectColors[specificColor];
              colorNumber = specificColor + 1;
              if (colorNumber >= ObjectColors.Length)
                  colorNumber = 0;
          }
      } 
    void Update()
    {

    }
}
